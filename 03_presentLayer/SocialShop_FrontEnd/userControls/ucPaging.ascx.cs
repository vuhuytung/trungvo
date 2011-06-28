using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Collections.Generic;
using System.ComponentModel;

internal class userControls_PageInfo
{
    private int m_PageNumber;

    public int PageNumber
    {
        get { return m_PageNumber; }
        set { m_PageNumber = value; }
    }
    private string m_Name;

    public string Name
    {
        get { return m_Name; }
        set { m_Name = value; }
    }
    public userControls_PageInfo()
    {
    }
    public userControls_PageInfo(string name, int pageNumber)
    {
        m_Name = name;
        m_PageNumber = pageNumber;
    }
}

public partial class UserControls_ucPaging : System.Web.UI.UserControl
{
    /// <summary>
    /// Trang hiện tại (Get / Set)
    /// </summary>
    public int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] == null)
                return 1;
            return Convert.ToInt32(ViewState["CurrentPage"]);
        }
        set
        {
            if (this.CurrentPage != value)
            {
                ViewState["CurrentPage"] = value;
                if (this.SiblingPaging != null)
                {
                    this.SiblingPaging.ViewState["CurrentPage"] = value;
                }
                OnPageChange();
            }
        }
    }

    /// <summary>
    /// Kích thước của trang (Get / Set)
    /// </summary>
    public int PageSize
    {
        get
        {
            if ((ViewState["PageSize"] == null) || ((int)ViewState["PageSize"] < 1))
                return 1;
            return (int)ViewState["PageSize"];
        }
        set
        {
            if (this.PageSize != value)
            {
                ViewState["PageSize"] = value;
                if (this.SiblingPaging != null)
                {
                    this.SiblingPaging.ViewState["PageSize"] = value;
                }
                ViewState["CurrentPage"] = 1;
                if (this.SiblingPaging != null)
                {
                    this.SiblingPaging.ViewState["CurrentPage"] = 1;
                }
                this.DrawPaging();
            }
        }
    }

    /// <summary>
    /// Số lượng Record (Get / Set)
    /// </summary>
    public int TotalRecord
    {
        get
        {
            if (ViewState["TotalRecord"] == null)
                return 0;
            return (int)ViewState["TotalRecord"];
        }
        set
        {
            if (this.TotalRecord != value)
            {
                ViewState["TotalRecord"] = value;
                if (this.SiblingPaging != null)
                {
                    this.SiblingPaging.ViewState["TotalRecord"] = value;
                }
                ViewState["CurrentPage"] = 1;
                if (this.SiblingPaging != null)
                {
                    this.SiblingPaging.ViewState["CurrentPage"] = 1;
                }
                this.DrawPaging();
            }
        }
    }

    /// <summary>
    /// Số trang hiển thị (Set/Get)
    /// </summary>
    [DefaultSettingValue("1")]
    public int PageDisplay
    {
        get
        {
            if ((ViewState["PageDisplay"] == null) || ((int)ViewState["PageDisplay"] < 1))
                return 1;
            return (int)ViewState["PageDisplay"];
        }
        set
        {
            if (this.PageDisplay != value)
            {
                ViewState["PageDisplay"] = value;
                if (this.SiblingPaging != null)
                {
                    this.SiblingPaging.ViewState["PageDisplay"] = value;
                }
                if (CurrentPage > TotalPage)
                {
                    ViewState["CurrentPage"] = 1;
                    if (this.SiblingPaging != null)
                    {
                        this.SiblingPaging.ViewState["CurrentPage"] = 1;
                    }
                }
                this.DrawPaging();
            }
        }
    }


    /// <summary>
    /// Tổng số trang (Get)
    /// </summary>
    public int TotalPage
    {
        get
        {
            int _totalPage = (TotalRecord - 1) / PageSize + 1;
            return _totalPage < 1 ? 1 : _totalPage;
        }
    }
    private UserControls_ucPaging m_SiblingPaging = null;
    /// <summary>
    /// Trang phụ thuộc
    /// </summary>
    public UserControls_ucPaging SiblingPaging
    {
        set
        {
            if (value != null)
            {
                if ((this.m_SiblingPaging != null) && this.m_SiblingPaging.Equals(value)) return;
                this.m_SiblingPaging = value;
                this.m_SiblingPaging.PageSize = PageSize;
                this.m_SiblingPaging.TotalRecord = TotalRecord;
                this.m_SiblingPaging.PageDisplay = PageDisplay;
                if (this.m_SiblingPaging.PageChange == null)
                    this.m_SiblingPaging.PageChange += this.PageChange;
            }
        }
        get
        {
            return m_SiblingPaging;
        }
    }

    /// <summary>
    /// Css Class Cho control
    /// </summary>
    public string CssClass
    {
        get
        {
            if ((ViewState["CssClass"] == null))
                return "";
            return ViewState["CssClass"].ToString();
        }
        set
        {
            if (this.CssClass != value)
            {
                ViewState["CssClass"] = value;
            }
        }
    }
    /// <summary>
    /// Khai báo Delegate
    /// </summary>
    public delegate void PagingHandler(object sender);
    /// <summary>
    /// Khai báo sự kiện Base Delegate
    /// </summary>
    [Browsable(true)]
    public event PagingHandler PageChange;

    public string CommandArgument
    {
        get
        {
            if ((ViewState["CommandArgument"] == null))
                return "";
            return ViewState["CommandArgument"].ToString();
        }
        set
        {
            if (this.CommandArgument != value)
            {
                ViewState["CommandArgument"] = value;
            }
        }
    }

    public string CommandName
    {
        get
        {
            if ((ViewState["CommandName"] == null))
                return "";
            return ViewState["CommandName"].ToString();
        }
        set
        {
            if (this.CommandName != value)
            {
                ViewState["CommandName"] = value;
            }
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        //if (!IsPostBack)
        //{
        //    display();
        //}
    }

    private List<userControls_PageInfo> getListPage()
    {
        List<userControls_PageInfo> lst = new List<userControls_PageInfo>();

        int d = CurrentPage - PageDisplay / 2; // Đầu
        d = d < 1 ? 1 : d;
        int c = d + PageDisplay - 1;           // Cuối
        c = c > TotalPage ? TotalPage : c;
        if (c - d != PageDisplay - 1)
        {
            d = c - PageDisplay + 1;
            d = d < 1 ? 1 : d;
        }
        int iPrevious = CurrentPage - 1 > 0 ? CurrentPage - 1 : 1;
        int iNext = CurrentPage + 1 <= TotalPage ? CurrentPage + 1 : TotalPage;
        lst.Add(new userControls_PageInfo("«", 1));
        lst.Add(new userControls_PageInfo("‹", iPrevious));


        for (int i = d; i <= c; i++)
        {
            lst.Add(new userControls_PageInfo(i.ToString(), i));
        }
        lst.Add(new userControls_PageInfo("›", iNext));
        lst.Add(new userControls_PageInfo("»", TotalPage));
        return lst;
    }

    private void display()
    {
        rptPaging.DataSource = getListPage();
        rptPaging.DataBind();
    }

    private void OnPageChange()
    {
        display();
        if (this.SiblingPaging != null)
        {
            this.SiblingPaging.display();
        }
        if (PageChange != null)
        {
            PageChange(this);
        }
    }

    /// <summary>
    /// Vẽ dãy phân trang
    /// </summary>
    private void DrawPaging()
    {
        display();
        if (this.SiblingPaging != null)
        {
            this.SiblingPaging.display();
        }
    }

    protected void rptPaging_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName.Equals("changepage"))
        {
            CurrentPage = Convert.ToInt32(e.CommandArgument);
        }
    }

    protected void rptPaging_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        LinkButton linkPage = e.Item.FindControl("linkPage") as LinkButton;
        if (linkPage == null) return;
        if (linkPage.CommandArgument.ToString() == CurrentPage.ToString())
        {
            linkPage.Enabled = false;
            linkPage.ToolTip = "";
            if (linkPage.Text != "«" && linkPage.Text != "‹" && linkPage.Text != "›" && linkPage.Text != "»")
            {
                linkPage.CssClass = "selected";
            }            
        }
    }
}