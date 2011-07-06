using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class BackEnd_pages_content_Document : System.Web.UI.Page
{
    CtrDocument doc = new CtrDocument();
    protected int CatID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        CatID = 21;// Int32.Parse(Request.QueryString["CategoryID"]);
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(ucPaging1_PageChange);
        if (!IsPostBack)
        {
            ucPaging1.PageSize = 3;
            ucPaging1.PageDisplay = 5;

            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);
        }
    }
    protected void ucPaging1_PageChange(object sender)
    {
        CtrDocument ctrN = new CtrDocument();
        var _data = ctrN.GetListDocByCategory(CatID, ucPaging1.CurrentPage, ucPaging1.PageSize);
        RptDocument.DataSource = _data.Items;
        RptDocument.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;
    }
}