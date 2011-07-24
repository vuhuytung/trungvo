using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;

public partial class userControls_ucNavigator : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Link = "";
        Link = "<a href='/' class='navigator' >Trang chủ</a>";
        int CatID=0;
        try{
            CatID=Convert.ToInt32(Request.QueryString["CategoryID"]);
        }finally{
            CtrCategory ctrCat = new CtrCategory();
            var data = ctrCat.GetNavigator(CatID);
            foreach (var item in data)
            {
                switch (item.Type.Value)
                {
                    case 1:
                        Link += " » " + "<a href='#' class='navigator'>" + item.Name + "</a>";
                        break;
                    case 2:
                        Link += " » " + "<a href='/news/" + VTCO.Library.Lib.GetUrlText(item.Name) + "-" + item.CategoryID + "' class='navigator'>" + item.Name + "</a>";
                        break;
                    case 3:
                        Link += " » " + "<a href='/document/" + VTCO.Library.Lib.GetUrlText(item.Name) + "-" + item.CategoryID + "' class='navigator'>" + item.Name + "</a>";
                        break;
                    case 4:
                        Link += " » " + "<a href='/realtymarket/" + VTCO.Library.Lib.GetUrlText(item.Name) + "-" + item.CategoryID + "' class='navigator'>" + item.Name + "</a>";
                        break;
                    default:
                        Link += " » " + "<a href='" + item.URL + "' class='navigator'>" + item.Name + "</a>";
                        break;
                }
                
            }
            ltrNavigator.Text = Link;
        }
    }
}