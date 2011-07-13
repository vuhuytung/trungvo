using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class userControls_ucAddNewBDS : System.Web.UI.UserControl
{
    CtrLocation Location = new CtrLocation();
    protected void Page_Load(object sender, EventArgs e)
    {
        /*  if (!IsPostBack)
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
          }*/
        if (!IsPostBack)
        {

            var _data = Location.GetProvince();
            List<LocationInfoSearch> _source = new List<LocationInfoSearch>();
            foreach (var item in _data)
            {
                LocationInfoSearch lInfo = new LocationInfoSearch();
                lInfo.LocationValue = item.LocationID + "_" + item.ProvinceCode;
                lInfo.LocationText = item.Name;
                _source.Add(lInfo);
            }

            ddlProvince.DataSource = _source;
            ddlProvince.DataTextField = "LocationText";
            ddlProvince.DataValueField = "LocationValue";
            ddlProvince.DataBind();
            ddlProvince.Items.Insert(0, new ListItem("Tỉnh/TP", "-1"));
            ddlProvince.SelectedIndex = 0;


            ddlDistrict.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));

            //add Type BDS temp
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần bán"));
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần mua"));
        }
    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*int index = Int32.Parse(ddlProvince.SelectedValue);
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
            ddlDistrict.Items.Add(new ListItem("---------Tất cả---------"));

            ddlVillage.Items.Clear();
            ddlVillage.Items.Add(new ListItem("---------Tất cả---------"));
        }*/
        if (ddlProvince.SelectedValue.Trim() != "-1")
        {
            int index = Int32.Parse(ddlProvince.SelectedValue.Split('_')[1]);
            var _data = Location.GetDistrict(index);
            List<LocationInfoSearch> _source = new List<LocationInfoSearch>();
            foreach (var item in _data)
            {
                LocationInfoSearch lInfo = new LocationInfoSearch();
                lInfo.LocationValue = item.LocationID + "_" + item.DistrictCode;
                lInfo.LocationText = item.Name;
                _source.Add(lInfo);
            }
            ddlDistrict.Items.Clear();
            ddlDistrict.DataSource = _source;
            ddlDistrict.DataTextField = "LocationText";
            ddlDistrict.DataValueField = "LocationValue";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));
            ddlDistrict.SelectedIndex = 0;

            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));

            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
        /*int index = Int32.Parse(ddlDistrict.SelectedValue);
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
            ddlVillage.Items.Add(new ListItem("---------Tất cả---------"));
        }*/
        if (ddlDistrict.SelectedValue.Trim() != "-1")
        {
            int index = Int32.Parse(ddlDistrict.SelectedValue.Split('_')[1]);
            var _data = Location.GetVillage(index);
            List<LocationInfoSearch> _source = new List<LocationInfoSearch>();
            foreach (var item in _data)
            {
                LocationInfoSearch lInfo = new LocationInfoSearch();
                lInfo.LocationValue = item.LocationID + "_" + item.VillageCode;
                lInfo.LocationText = item.Name;
                _source.Add(lInfo);
            }
            ddlVillage.DataSource = _source;
            ddlVillage.DataTextField = "LocationText";
            ddlVillage.DataValueField = "LocationValue";
            ddlVillage.DataBind();
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
            ddlVillage.SelectedIndex = 0;
        }
        else
        {
            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
    }
         
}
 public class LocationInfoSearch
    {
        protected string m_LocationValue;
        protected string m_LocationText;
        public string LocationValue
        {
            get { return m_LocationValue; }
            set { m_LocationValue = value; }
        }
        public string LocationText
        {
            get { return m_LocationText; }
            set { m_LocationText = value; }
        }
    }