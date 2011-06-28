using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using DataContext;
using System.Threading;

public partial class pages_News : System.Web.UI.Page
{
    protected string NewsIDs = "";
    protected int CatID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try{
            CatID=Convert.ToInt32(Request.QueryString["CategoryID"]);
        }finally{
            CtrNews ctrN = new CtrNews();
            var _data = ctrN.GetListNewsByCategory(CatID, 10);
            rptContent.DataSource = _data;
            rptContent.DataBind();
            foreach (var item in _data)
            {
                NewsIDs += item.CategoryID + ",";
            }
            if(NewsIDs.Length>0)
                NewsIDs = NewsIDs.Substring(NewsIDs.LastIndexOf(","));

        }
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(ucPaging1_PageChange);
        if (!IsPostBack)
        {
            ucPaging1.PageSize = 10;
            ucPaging1.PageDisplay = 5;

            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);
        }
    }

    protected void ucPaging1_PageChange(object sender)
    {
        Thread.Sleep(3000);
        CtrNews ctrN = new CtrNews();
        var _data = ctrN.GetListNewsByCategoryOther(CatID, NewsIDs, ucPaging1.CurrentPage, ucPaging1.PageSize);
        rptOther.DataSource = _data.Items;
        rptOther.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;
    }
}