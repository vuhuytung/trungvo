using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class userControls_Slide : System.Web.UI.UserControl
{
    CtrProject project = new CtrProject();
    CtrLocation Location = new CtrLocation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Literal1.Text = project.GenHtmlSlide();
            DropDownProvince.DataSource = Location.GetProvince();
            DropDownProvince.DataTextField = "Name";
            DropDownProvince.DataValueField = "ProvinceCode";
            DropDownProvince.SelectedIndex = 26;
            DropDownProvince.DataBind();
        } 
           
    }
    protected void DropDownProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = Int32.Parse(DropDownProvince.SelectedValue);
        DropDownDistrict.DataSource = Location.GetDistrict(index);
        DropDownDistrict.DataTextField = "Name";
        DropDownDistrict.DataValueField = "DistrictCode";
        DropDownDistrict.DataBind();
    }
    protected void DropDownDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = Int32.Parse(DropDownDistrict.SelectedValue);
        DropDownVillage.DataSource = Location.GetVillage(index);
        DropDownVillage.DataTextField = "Name";
        DropDownVillage.DataValueField = "VillageCode";
        DropDownVillage.DataBind();
    }
}