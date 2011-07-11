using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class pages_realtymarket : System.Web.UI.Page
{
    CtrLocation Location = new CtrLocation();
    protected void Page_Load(object sender, EventArgs e)
    {
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(ucPaging1_PageChange);
        if (!IsPostBack)
        {
            //=========top search

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
            ddlProvince.Items.Insert(0, new ListItem("Tất cả", "-1"));
            ddlProvince.SelectedIndex = 0;

            ddlDistrict.Items.Insert(0, new ListItem("Tất cả", "-1"));
            ddlVillage.Items.Insert(0, new ListItem("Tất cả", "-1"));

            //add Type BDS temp
            ddlTypeBDS.Items.Add(new ListItem("Tất cả"));
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần bán"));
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần mua"));

            //add Price temp
            ddlPrice.Items.Add(new ListItem("tất cả"));
            ddlPrice.Items.Add(new ListItem("dưới 5 triệu"));
            ddlPrice.Items.Add(new ListItem("5 -20 triệu"));
            ddlPrice.Items.Add(new ListItem("20-100 triệu"));
            ddlPrice.Items.Add(new ListItem("100-500 triệu"));
            ddlPrice.Items.Add(new ListItem("500 triệu-2 tỷ"));
            ddlPrice.Items.Add(new ListItem("2-3 tỷ"));
            ddlPrice.Items.Add(new ListItem("trên 3 tỷ"));

            //================
            
            ucPaging1.PageSize = 10;
            ucPaging1.PageDisplay = 5;

            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);
            
        }
        
    }
    protected void ucPaging1_PageChange(object sender)
    {
        BindRpt();
       /* CtrRealtyMarket ctrN = new CtrRealtyMarket();
        var _data = ctrN.GetListRealtyMarketByCondition(1, 1, 1, 0, 50000, ucPaging1.CurrentPage, ucPaging1.PageSize);
        RptReatyMarket.DataSource = _data.Items;
        RptReatyMarket.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;*/
    }
    protected void BindRpt()
    {
        CtrRealtyMarket ctrN = new CtrRealtyMarket();

        if (Int32.Parse(ddlProvince.SelectedValue.Split('_')[0]) != -1) //kiểm tra nếu chọn tỉnh
        {
            if (Int32.Parse(ddlDistrict.SelectedValue.Split('_')[0]) != -1) //nếu chọn huyện
            {
                if (Int32.Parse(ddlVillage.SelectedValue.Split('_')[0]) != -1)
                {
                    int Code = Int32.Parse(ddlVillage.SelectedValue.Split('_')[0]);
                    var _data = ctrN.GetListRealtyMarketByCondition(Code, 3, 1, 0, 50000, ucPaging1.CurrentPage, ucPaging1.PageSize);
                    RptReatyMarket.DataSource = _data.Items;
                    RptReatyMarket.DataBind();
                    ucPaging1.TotalRecord = _data.TotalRecord;
                }
                else
                {
                    int Code = Int32.Parse(ddlDistrict.SelectedValue.Split('_')[0]);
                    var _data = ctrN.GetListRealtyMarketByCondition(Code, 2, 1, 0, 50000, ucPaging1.CurrentPage, ucPaging1.PageSize);
                    RptReatyMarket.DataSource = _data.Items;
                    RptReatyMarket.DataBind();
                    ucPaging1.TotalRecord = _data.TotalRecord;
                }

            }
            else
            {
                int Code = Int32.Parse(ddlProvince.SelectedValue.Split('_')[0]);
                var _data = ctrN.GetListRealtyMarketByCondition(Code, 1, 1, 0, 50000, ucPaging1.CurrentPage, ucPaging1.PageSize);
                RptReatyMarket.DataSource = _data.Items;
                RptReatyMarket.DataBind();
                ucPaging1.TotalRecord = _data.TotalRecord;
            }

        }
        else
        {
            var _data = ctrN.GetListRealtyMarketByCondition(1, 1, 1, 0, 50000, ucPaging1.CurrentPage, ucPaging1.PageSize);
            RptReatyMarket.DataSource = _data.Items;
            RptReatyMarket.DataBind();
            ucPaging1.TotalRecord = _data.TotalRecord;
        }
        //var _data = ctrN.GetListRealtyMarketByCondition(1, 1, 1, 100, 500, ucPaging1.CurrentPage, ucPaging1.PageSize);
        //RptReatyMarket.DataSource = _data.Items;
       // RptReatyMarket.DataBind();
        //ucPaging1.TotalRecord = _data.TotalRecord;
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
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        //some code here

        try
        {
            BindRpt();
            //ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(ucPaging1_PageChange);
        }
        catch
        {
        }

    }



    //=============================
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
}