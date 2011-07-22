using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using DAL;
using DataContext;
public partial class pages_RealtyMarketDetails : System.Web.UI.Page
{
    CtrRealtyMarket market = new CtrRealtyMarket();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
                RptDetail.DataSource = market.GetDetailRealtyMarketByID(Int32.Parse(Request.QueryString["ID"]));
                RptDetail.DataBind();
           
        }
    }
}