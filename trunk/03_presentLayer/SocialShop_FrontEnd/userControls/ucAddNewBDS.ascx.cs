using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class userControls_ucAddNewBDS : System.Web.UI.UserControl
{
    CtrLocation location = new CtrLocation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlProvince.DataSource = location.LocationGetProvince();
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "ProvinceCode";
            ddlProvince.SelectedIndex = -1;
            ddlProvince.DataBind();
            ddlDistrict.Items.Add(new ListItem("---------Tất cả---------"));
            ddlVillage.Items.Add(new ListItem("---------Tất cả---------"));

            //add Type BDS temp
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần bán"));
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần mua"));

            //add Price temp
        }
    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = Int32.Parse(ddlProvince.SelectedValue);
        if (index != -1)
        {
            ddlDistrict.DataSource = location.LocationGetDistrict(index);
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "DistrictCode";
            ddlDistrict.DataBind();
        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add(new ListItem("---------Tất cả---------"));

            ddlVillage.Items.Clear();
            ddlVillage.Items.Add(new ListItem("---------Tất cả---------"));
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = Int32.Parse(ddlDistrict.SelectedValue);
        if (index != -1)
        {
            ddlVillage.DataSource = location.LocationGetVillage(index);
            ddlVillage.DataTextField = "Name";
            ddlVillage.DataValueField = "VillageCode";
            ddlVillage.DataBind();
        }
        else
        {
            ddlVillage.Items.Clear();
            ddlVillage.Items.Add(new ListItem("---------Tất cả---------"));
        }
    }
}