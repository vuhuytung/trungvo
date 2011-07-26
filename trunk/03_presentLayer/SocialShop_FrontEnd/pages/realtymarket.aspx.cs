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
    CtrRealtyMarket market = new CtrRealtyMarket();
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
            //ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần bán", "21"));
            //ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần mua", "22"));
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

            //================

            ucPaging1.PageSize = 10;
            ucPaging1.PageDisplay = 5;

            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);

        }

    }
    protected void ucPaging1_PageChange(object sender)
    {
        if (Request.QueryString["code"] != null && Request.QueryString["typecode"] != null)
        {
            double begin = 0;
            double end = 0;
            GetPrice(Int32.Parse(Request.QueryString["price"]), ref begin, ref end);
            CtrRealtyMarket ctrN = new CtrRealtyMarket();
            var _data = ctrN.GetListRealtyMarketByStatus(Convert.ToInt32(Request.QueryString["code"]), Convert.ToInt32(Request.QueryString["typecode"]), Convert.ToInt32(Request.QueryString["typebds"]), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
            RptReatyMarket.DataSource = _data.Items;
            RptReatyMarket.DataBind();
            ucPaging1.TotalRecord = _data.TotalRecord;

        }
        else if (!string.IsNullOrEmpty(Request.QueryString["CategoryID"]))
        {
            
            CtrRealtyMarket ctrN = new CtrRealtyMarket();
            var _data = ctrN.GetListRealtyMarketByCatID(Convert.ToInt32(Request.QueryString["CategoryID"]),ucPaging1.CurrentPage, ucPaging1.PageSize);
            RptReatyMarket.DataSource = _data.Items;
            RptReatyMarket.DataBind();
            ucPaging1.TotalRecord = _data.TotalRecord;
        }
        else
        {
            BindRpt();
        }
        /* CtrRealtyMarket ctrN = new CtrRealtyMarket();
         var _data = ctrN.GetListRealtyMarketByCondition(1, 1, 1, 0, 50000, ucPaging1.CurrentPage, ucPaging1.PageSize);
         RptReatyMarket.DataSource = _data.Items;
         RptReatyMarket.DataBind();
         ucPaging1.TotalRecord = _data.TotalRecord;*/
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

    protected void BindRpt()
    {
        CtrRealtyMarket ctrN = new CtrRealtyMarket();
        double begin = 0;
        double end = 0;
        GetPrice(Int32.Parse(ddlPrice.SelectedValue), ref begin, ref end);
        if (Int32.Parse(ddlProvince.SelectedValue.Split('_')[0]) != -1) //kiểm tra nếu chọn tỉnh
        {
            if (Int32.Parse(ddlDistrict.SelectedValue.Split('_')[0]) != -1) //nếu chọn huyện
            {
                if (Int32.Parse(ddlVillage.SelectedValue.Split('_')[0]) != -1)
                {
                    int Code = Int32.Parse(ddlVillage.SelectedValue.Split('_')[1]);
                    var _data = ctrN.GetListRealtyMarketByStatus(Code, 3, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
                    RptReatyMarket.DataSource = _data.Items;
                    RptReatyMarket.DataBind();
                    ucPaging1.TotalRecord = _data.TotalRecord;
                }
                else
                {
                    int Code = Int32.Parse(ddlDistrict.SelectedValue.Split('_')[1]);
                    var _data = ctrN.GetListRealtyMarketByStatus(Code, 2, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
                    RptReatyMarket.DataSource = _data.Items;
                    RptReatyMarket.DataBind();
                    ucPaging1.TotalRecord = _data.TotalRecord;
                }

            }
            else
            {
                int Code = Int32.Parse(ddlProvince.SelectedValue.Split('_')[1]);
                var _data = ctrN.GetListRealtyMarketByStatus(Code, 1, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
                RptReatyMarket.DataSource = _data.Items;
                RptReatyMarket.DataBind();
                ucPaging1.TotalRecord = _data.TotalRecord;
            }

        }
        else
        {
            // var _data = ctrN.GetListRealtyMarketByCondition(0,1, 21, begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
            var _data = ctrN.GetListRealtyMarketByStatus(0, 1, Convert.ToInt32(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
            RptReatyMarket.DataSource = _data.Items;
            RptReatyMarket.DataBind();
            ucPaging1.TotalRecord = _data.TotalRecord;
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