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

            ddlProvince.DataSource = _data;
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "ProvinceCode";            
            ddlProvince.DataBind();
            ddlProvince.Items.Insert(0, new ListItem("--Tất cả--", "-1"));
            ddlProvince.SelectedIndex = 0;


            ddlDistrict.Items.Insert(0, new ListItem("--Tất cả--", "-1"));


            ddlTypeBDS.DataSource = market.GetCatByType();
            ddlTypeBDS.DataTextField = "Name";
            ddlTypeBDS.DataValueField = "CategoryID";
            ddlTypeBDS.DataBind();

            //add Price temp

            ddlPrice.Items.Add(new ListItem("--Tất cả--", "0"));
            ddlPrice.Items.Add(new ListItem("Dưới 20 triệu", "1"));
            ddlPrice.Items.Add(new ListItem("20-100 triệu", "2"));
            ddlPrice.Items.Add(new ListItem("100-500 triệu", "3"));
            ddlPrice.Items.Add(new ListItem("500 triệu-2 tỷ", "4"));
            ddlPrice.Items.Add(new ListItem("2-10 tỷ", "5"));
            ddlPrice.Items.Add(new ListItem("10-20 tỷ", "6"));
            ddlPrice.Items.Add(new ListItem("Trên 20 tỷ", "7"));
        }

    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlProvince.SelectedValue.Trim() != "-1")
        {
            int index = Int32.Parse(ddlProvince.SelectedValue);
            var _data = Location.GetDistrict(index);

            ddlDistrict.Items.Clear();
            ddlDistrict.DataSource = _data;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "DistrictCode";            
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("--Tất cả--", "-1"));
            ddlDistrict.SelectedIndex = 0;
        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Insert(0, new ListItem("--Tất cả--", "-1"));

        }
    }

    private void GetPrice(int type, ref long begin, ref long end)
    {
        if (type == 0)
        {
            begin = 0;
            end = long.MaxValue;
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
            end = long.MaxValue;
        }

    }
    protected void ImgSearch_Click(object sender, ImageClickEventArgs e)
    {

            long begin = 0;
            long end = 0;
            int Code, typeBDS,CodeP;
            typeBDS = Int32.Parse(ddlTypeBDS.SelectedValue);
            GetPrice(Int32.Parse(ddlPrice.SelectedValue), ref begin, ref end);
            Code = Int32.Parse(ddlDistrict.SelectedValue);
            CodeP = Int32.Parse(ddlProvince.SelectedValue);            
            string str = "~/pages/realtymarket.aspx?code=" + Code.ToString() + "&codep=" + CodeP.ToString() + "&typebds=" + typeBDS.ToString() + "&price=" + ddlPrice.SelectedValue;
            Response.Redirect(str);
    }
}