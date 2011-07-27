using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class userControls_ucRealtyMarket : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
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
        CtrRealtyMarket ctrN = new CtrRealtyMarket();
        var _data = ctrN.GetListRealtyMarketByCondition(2,1,1,1,100,500, ucPaging1.CurrentPage, ucPaging1.PageSize);
        RptReatyMarket.DataSource = _data.Items;
         RptReatyMarket.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;
    }
}