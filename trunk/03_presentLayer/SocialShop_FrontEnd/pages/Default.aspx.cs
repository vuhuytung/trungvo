using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using DataContext;
using EntityBLL;
using System.Data;
public partial class pages_Default : System.Web.UI.Page
{
    protected int ktra=0;
    List<ClassExtend<uspCategoryGetByParentIDResult,uspNewsGetByCategoryIDHomeResult>> _data;
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Title = "CÔNG TY CỔ PHẦN BẤT ĐỘNG SẢN ÂU LẠC";
        CtrNews ctrNews = new CtrNews();
        _data=ctrNews.GetListCategoryNewsForHome().Items;
        rptContent.DataSource = _data;
        rptContent.DataBind();
        ((master_masterFrontend)(this.Master)).VisibleNavigator = false;
        DataSet ds = new DataSet();
        try
        {
            ds.ReadXml("http://www.vietcombank.com.vn/ExchangeRates/ExrateXML.aspx");
            GridView1.DataSource = ds.Tables[1];
            GridView1.DataBind();
        }
        catch
        {
        }
    }
}