using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using DataContext;
public partial class userControls_ucMenuTop : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //CtrCategory Menu = new CtrCategory();
        if (!IsPostBack)
        {
            ltrMenu.Text = GetMenuTop(null, 0, 0);
        }

    }

    /// <summary>
    /// Description: Lấy các menu top
    /// </summary>
    /// <param name="tb">Bảng dữ liệu</param>
    /// <param name="parentID">ID Menu cha</param>
    /// <returns></returns>
    public string GetMenuTop(List<uspCategoryGetListResult> tb, int parentID, int level)
    {
        CtrCategory menuMgr = new CtrCategory();
        string str = "<ul>";
        if (level == 1)
            str = "<ul class='sub'>";
        if (level == 0)
        {
            str = "<ul id='nav'>";
            tb = new List<uspCategoryGetListResult>();
            tb = menuMgr.GetListCategory(1);
            str += "<li class='top'><a href='/index.htm' class='top_link' ><span>Trang chủ</span></a></li>";
        }
        //Lấy các menu trong bảng tb có trạng thái hoạt động và có menu cha là parentID sắp xếp theo Order
        var rows = tb.Where(x => x.ParentID == parentID);
        if (rows.Count() <= 0)
            return "";
        foreach (uspCategoryGetListResult row in rows)
        {
            if (level == 0)
                str += "<li class='top'>";
            else
                str += "<li>";
            var down = "";
            if (tb.Where(x => x.ParentID == row.CategoryID).Count() > 0)
            {
                down = "class='down'";
            }
            var fly = "";
            if ((tb.Where(x => x.ParentID == row.CategoryID).Count() > 0) && level > 0)
            {
                fly = "class='fly'";
            }

            switch (row.Type.Value)
            {
                case 2:
                    if (level == 0)
                        str += "<a href='/news/" + VTCO.Library.Lib.GetUrlText(row.Name) + "-" + row.CategoryID + "' class='top_link'><span " + down + ">" + row.Name + "</span></a>";
                    else
                        str += "<a href='/news/" + VTCO.Library.Lib.GetUrlText(row.Name) + "-" + row.CategoryID + "' " + fly + ">" + row.Name + "</a>";
                    break;
                default:
                    str += "<a href='#" + row.CategoryID + ".html' class='top_link'>" + row.Name + "</a>";
                    break;
            }

            str += GetMenuTop(tb, row.CategoryID, level + 1);
            str += "</li>";
        }
        str += "</ul>";
        return str;
    }
}