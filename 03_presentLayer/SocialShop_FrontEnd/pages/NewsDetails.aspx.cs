using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using DataContext;

public partial class pages_NewsDetails : System.Web.UI.Page
{
    protected int NewsID = -1;
    protected int CatID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        try{
            NewsID = Convert.ToInt32(Request.QueryString["NewsID"]);
            CatID = Convert.ToInt32(Request.QueryString["CategoryID"]);
        }finally{
            CtrNews ctrN = new CtrNews();
            var _data = ctrN.GetInfo(NewsID);
            if ((_data.Img == null) || (_data.Img.Trim() == ""))
                selImage.Visible = false;
            else
                selImage.Src = _data.Img;
            selTitle.InnerText = _data.Title;
            Page.Title = _data.Title;
            selCreateDate.InnerText = _data.CreateDate.ToString("dd/MM/yyyy");
            selDescription.InnerText = _data.Description;
            selContent.InnerHtml = _data.Content;
            if ((_data.Resource == null) || (_data.Resource.Trim() == ""))
                selResource.Visible = false;
            else
                selResource.InnerText = "Nguồn: "+_data.Resource;
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
        CtrNews ctrN = new CtrNews();
        var _data = ctrN.GetListNewsByCategoryOther(CatID, NewsID.ToString(), ucPaging1.CurrentPage, ucPaging1.PageSize);
        rptOther.DataSource = _data.Items;
        rptOther.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;
        ucPaging1.Visible = ucPaging1.TotalPage > 1;
        divListOtherNews.Visible = _data.TotalRecord > 0;
    }
}