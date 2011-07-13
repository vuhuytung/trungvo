using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using DataContext;
using EntityBLL;

public partial class pages_Default : System.Web.UI.Page
{
    protected int ktra=0;
    List<ClassExtend<uspCategoryGetByParentIDResult,uspNewsGetByCategoryIDHomeResult>> _data;
    protected void Page_Load(object sender, EventArgs e)
    {
        CtrNews ctrNews = new CtrNews();
        _data=ctrNews.GetListCategoryNewsForHome().Items;
        rptContent.DataSource = _data;
        rptContent.DataBind();
        ((master_masterFrontend)(this.Master)).VisibleNavigator = false;        
    }
}