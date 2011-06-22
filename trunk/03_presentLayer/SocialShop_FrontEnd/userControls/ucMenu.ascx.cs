using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using DataContext;
public partial class userControls_ucMenu : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        CtrCategory Menu = new CtrCategory();
        if (!IsPostBack)
        {
            ltrMenu.Text = GetMenuTop(null, 0);
        }
        
    }

    /// <summary>
    /// Description: Lấy các menu top
    /// </summary>
    /// <param name="tb">Bảng dữ liệu</param>
    /// <param name="parentID">ID Menu cha</param>
    /// <returns></returns>
    public string GetMenuTop(List<uspCategoryGetListResult> tb, int parentID)
    {
        CtrCategory menuMgr = new CtrCategory();
        string str = "<ul>";
        if (tb == null)
        {
            str="<ul class='menu' id='menu'>";
            tb = new List<uspCategoryGetListResult>();
            tb = menuMgr.GetListCategory(1);
            str += "<li><a href='/home' class='menulink' >Trang chủ</a></li>";
        }
        //Lấy các menu trong bảng tb có trạng thái hoạt động và có menu cha là parentID sắp xếp theo Order
        var rows = tb.Where(x=>x.ParentID == parentID);
        if (rows.Count() <= 0)
            return "";
        foreach (uspCategoryGetListResult row in rows)
        {
            str += "<li>";
            if (row.ParentID == 0)
            {
                str += "<a href='#" + row.CategoryID + ".html' class='menulink'>" + row.Name + "</a>";
            }
            else
            {
                str += "<a href='#" + row.CategoryID + ".html'>" + row.Name + "</a>";
            }
            str += GetMenuTop(tb, row.CategoryID);
            str += "</li>";
        }
        str += "</ul>";
        return str;
    }
}