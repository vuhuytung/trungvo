using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class userControls_ucDocument : System.Web.UI.UserControl
{
    CtrDocument doc = new CtrDocument();
    protected int CatID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        
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
        try
        {
            if (Request.QueryString["CategoryID "] != null)
            {
                CtrDocument ctrN = new CtrDocument();
                var _data = ctrN.GetListDocByCategory(Convert.ToInt32(Request.QueryString["CategoryID "]), ucPaging1.CurrentPage, ucPaging1.PageSize);
                RptDocument.DataSource = _data.Items;
                RptDocument.DataBind();
                ucPaging1.TotalRecord = _data.TotalRecord;
            }
        }
        catch
        {
                
        }
        
    }
}