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

public partial class userControls_ucPaging : System.Web.UI.UserControl
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
            if (CurrentPage != value)
            {
                ViewState["CurrentPage"] = value;
                if (SiblingPaging != null)
                {
                    SiblingPaging.ViewState["CurrentPage"] = value;
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
            if (PageSize != value)
            {
                ViewState["PageSize"] = value;
                if (SiblingPaging != null)
                {
                    SiblingPaging.ViewState["PageSize"] = value;
                }
                ViewState["CurrentPage"] = 1;
                if (SiblingPaging != null)
                {
                    SiblingPaging.ViewState["CurrentPage"] = 1;
                }
                DrawPaging();
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
            if (TotalRecord != value)
            {
                ViewState["TotalRecord"] = value;
                if (SiblingPaging != null)
                {
                    SiblingPaging.ViewState["TotalRecord"] = value;
                }
                ViewState["CurrentPage"] = 1;
                if (SiblingPaging != null)
                {
                    SiblingPaging.ViewState["CurrentPage"] = 1;
                }
                DrawPaging();
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
            if (PageDisplay != value)
            {
                ViewState["PageDisplay"] = value;
                if (SiblingPaging != null)
                {
                    SiblingPaging.ViewState["PageDisplay"] = value;
                }
                if (CurrentPage > TotalPage)
                {
                    ViewState["CurrentPage"] = 1;
                    if (SiblingPaging != null)
                    {
                        SiblingPaging.ViewState["CurrentPage"] = 1;
                    }
                }
                DrawPaging();
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
    private userControls_ucPaging m_SiblingPaging = null;
    /// <summary>
    /// Trang phụ thuộc
    /// </summary>
    public userControls_ucPaging SiblingPaging
    {
        set
        {
            if (value != null)
            {
                if ((m_SiblingPaging != null) && m_SiblingPaging.Equals(value)) return;
                m_SiblingPaging = value;
                m_SiblingPaging.PageSize = PageSize;
                m_SiblingPaging.TotalRecord = TotalRecord;
                m_SiblingPaging.PageDisplay = PageDisplay;
                if (m_SiblingPaging.PageChange == null)
                    m_SiblingPaging.PageChange += PageChange;
            }
        }
        get
        {
            return m_SiblingPaging;
        }
    }

    /// <summary>
    /// Khai báo Delegate
    /// </summary>
    public delegate void PagingHandler();
    /// <summary>
    /// Khai báo sự kiện Base Delegate
    /// </summary>
    public event PagingHandler PageChange;

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
        
        int d = CurrentPage - PageDisplay / 2; // First
        d = d < 1 ? 1 : d;
        int c = d + PageDisplay - 1;           // Last
        c = c > TotalPage ? TotalPage : c;
        if (c - d != PageDisplay - 1)
        {
            d = c - PageDisplay + 1;
            d = d < 1 ? 1 : d;
        }
        int iPrevious = CurrentPage - 1 > 0 ? CurrentPage - 1 : 1;
        int iNext = CurrentPage + 1 <= TotalPage ? CurrentPage + 1 : TotalPage;
        lst.Add(new userControls_PageInfo("Đầu", 1));
        lst.Add(new userControls_PageInfo("&laquo;", iPrevious));
        

        for (int i = d; i <= c; i++)
        {
            lst.Add(new userControls_PageInfo(i.ToString(), i));
        }
        lst.Add(new userControls_PageInfo("&raquo;", iNext));
        lst.Add(new userControls_PageInfo("Cuối", TotalPage));
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
        if (SiblingPaging != null)
        {
            SiblingPaging.display();
        }
        if (PageChange != null)
        {
            PageChange();
        }
    }

    /// <summary>
    /// Vẽ dãy phân trang
    /// </summary>
    private void DrawPaging()
    {
        display();
        if (SiblingPaging != null)
        {
            SiblingPaging.display();
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
        if ((linkPage.CommandArgument.ToString() == CurrentPage.ToString()) && (linkPage.Text != "&laquo;") && (linkPage.Text != "&raquo;") && (linkPage.Text != "Đầu") && (linkPage.Text != "Cuối"))
        {
            linkPage.Enabled = false;
            linkPage.ToolTip = "";
            linkPage.CssClass = "current01";
        }
        else
        {
            linkPage.CssClass = "Current";
        }
        if ((linkPage.Text == "&laquo;" || linkPage.Text == "Đầu") && (CurrentPage == 1))
        {
            linkPage.Enabled = false;
            linkPage.CssClass = "Current";
        }
        if ((linkPage.Text == "&raquo;" || linkPage.Text == "Cuối") && (CurrentPage == TotalPage))
        { 
            linkPage.Enabled = false;
            linkPage.CssClass = "Current";
        }


    }
}
