using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class userControls_ucTopSearch : System.Web.UI.UserControl
{
    CtrLocation Location = new CtrLocation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ddlProvince.DataSource = Location.LocationGetProvince();
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "ProvinceCode";
            ddlProvince.SelectedIndex = -1;
            ddlProvince.DataBind();
            ddlDistrict.Items.Add(new ListItem("---------Tất cả---------"));
            ddlVillage.Items.Add(new ListItem("--------Tất cả----------"));

            //add Type BDS temp
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần bán"));
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần mua"));

            //add Price temp

            ddlPrice.Items.Add(new ListItem("dưới 5 triệu"));
            ddlPrice.Items.Add(new ListItem("5 -20 triệu"));
            ddlPrice.Items.Add(new ListItem("20-100 triệu"));
            ddlPrice.Items.Add(new ListItem("100-500 triệu"));
            ddlPrice.Items.Add(new ListItem("500 triệu-2 tỷ"));
            ddlPrice.Items.Add(new ListItem("2-3 tỷ"));
            ddlPrice.Items.Add(new ListItem("trên 3 tỷ"));
        }

    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = Int32.Parse(ddlProvince.SelectedValue);
        if (index != -1)
        {
            ddlDistrict.DataSource = Location.LocationGetDistrict(index);
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "DistrictCode";
            ddlDistrict.DataBind();
        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Add(new ListItem("--------Tất cả--------"));

            ddlVillage.Items.Clear();
            ddlVillage.Items.Add(new ListItem("--------Tất cả----------"));
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        int index = Int32.Parse(ddlDistrict.SelectedValue);
        if (index != -1)
        {
            ddlVillage.DataSource = Location.LocationGetVillage(index);
            ddlVillage.DataTextField = "Name";
            ddlVillage.DataValueField = "VillageCode";
            ddlVillage.DataBind();
        }
        else
        {
            ddlVillage.Items.Clear();
            ddlVillage.Items.Add(new ListItem("--------Tất cả--------"));
        }
    }
}