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
    CtrRealtyMarket market = new CtrRealtyMarket();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            var _data = Location.GetProvince();
            List<LocationInfoSearch> _source = new List<LocationInfoSearch>();
            foreach (var item in _data)
            {
                LocationInfoSearch lInfo=new LocationInfoSearch();
                lInfo.LocationValue=item.LocationID+"_"+item.ProvinceCode;
                lInfo.LocationText=item.Name;
                _source.Add(lInfo);
            }

            ddlProvince.DataSource = _source;
            ddlProvince.DataTextField = "LocationText";
            ddlProvince.DataValueField = "LocationValue";            
            ddlProvince.DataBind();
            ddlProvince.Items.Insert(0, new ListItem("Tất cả", "-1"));
            ddlProvince.SelectedIndex = 0;


            ddlDistrict.Items.Insert(0, new ListItem("Tất cả", "-1"));
            ddlVillage.Items.Insert(0, new ListItem("Tất cả", "-1"));

            //add Type BDS temp
            //ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần bán","21"));
            //ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần mua","22"));

            ddlTypeBDS.DataSource = market.GetCatByType();
            ddlTypeBDS.DataTextField = "Name";
            ddlTypeBDS.DataValueField = "CategoryID";
            ddlTypeBDS.DataBind();

            //add Price temp

            ddlPrice.Items.Add(new ListItem("tất cả", "0"));
            ddlPrice.Items.Add(new ListItem("dưới 20 triệu", "1"));
            ddlPrice.Items.Add(new ListItem("20-100 triệu", "2"));
            ddlPrice.Items.Add(new ListItem("100-500 triệu", "3"));
            ddlPrice.Items.Add(new ListItem("500 triệu-2 tỷ", "4"));
            ddlPrice.Items.Add(new ListItem("2-10 tỷ", "5"));
            ddlPrice.Items.Add(new ListItem("10-20 tỷ", "6"));
            ddlPrice.Items.Add(new ListItem("trên 20 tỷ", "7"));
        }

    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int index = Int32.Parse(ddlProvince.SelectedValue.Split('_')[1]);
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
            ddlDistrict.Items.Insert(0, new ListItem("Tất cả", "-1"));
            ddlDistrict.SelectedIndex = 0;

            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, new ListItem("Tất cả", "-1"));
        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Insert(0, new ListItem("Tất cả", "-1"));

            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, new ListItem("Tất cả", "-1"));
        }
    }
    protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
    {
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
            ddlVillage.Items.Insert(0, new ListItem("Tất cả", "-1"));
            ddlVillage.SelectedIndex = 0;
        }
        else
        {
            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, new ListItem("Tất cả", "-1"));
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
    private void GetPrice(int type, ref double begin, ref double end)
    {
        if (type == 0)
        {
            begin = 0;
            end = double.MaxValue;
        }
        else if (type == 1)
        {
            begin = 0;
            end = 20000000;
        }
        else if (type == 2)
        {
            begin = 20000000;
            end = 100000000;
        }
        else if (type == 3)
        {
            begin = 100000000;
            end = 500000000;
        }
        else if (type == 4)
        {
            begin = 500000000;
            end = 2000000000;
        }
        else if (type == 5)
        {
            begin = 2000000000;
            end = 10000000000;
        }
        else if (type == 6)
        {
            begin = 10000000000;
            end = 20000000000;
        }
        else if (type == 7)
        {
            begin = 20000000000;
            end = double.MaxValue;
        }

    }
    protected void ImgSearch_Click(object sender, ImageClickEventArgs e)
    {
        //try
        //{
            double begin = 0;
            double end = 0;
            int Code, typeCode, typeBDS;
            typeBDS = Int32.Parse(ddlTypeBDS.SelectedValue);
            GetPrice(Int32.Parse(ddlPrice.SelectedValue), ref begin, ref end);
            if (Int32.Parse(ddlProvince.SelectedValue.Split('_')[0]) != -1) //kiểm tra nếu chọn tỉnh
            {
                if (Int32.Parse(ddlDistrict.SelectedValue.Split('_')[0]) != -1) //nếu chọn huyện
                {
                    if (Int32.Parse(ddlVillage.SelectedValue.Split('_')[0]) != -1)
                    {
                        Code = Int32.Parse(ddlVillage.SelectedValue.Split('_')[1]);
                        typeCode = 3;
                    }
                    else
                    {
                        Code = Int32.Parse(ddlDistrict.SelectedValue.Split('_')[1]);
                        typeCode = 2;
                    }

                }
                else
                {
                    Code = Int32.Parse(ddlProvince.SelectedValue.Split('_')[1]);
                    typeCode = 1;
                }
            }
            else
            {
                Code = 0;
                typeCode = 1;
            }
            string str = "realtymarket.aspx?code=" +Code.ToString()+"&typecode="+typeCode.ToString()+"&typebds="+typeBDS.ToString()+"&price="+ddlPrice.SelectedValue;
            Response.Redirect(str);
        //}
        //catch(Exception ex)
       // {
          //  string error = ex.ToString();
        //    Response.Redirect("realtymarket.aspx?code=0");
        //}
        
            
       

    }
}