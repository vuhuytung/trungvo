using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class pages_Myrealtymarket : System.Web.UI.Page
{
    CtrLocation Location = new CtrLocation();
    protected CtrRealtyMarket market = new CtrRealtyMarket();
    protected void Page_Load(object sender, EventArgs e)
    {
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(ucPaging1_PageChange);
        if (!IsPostBack)
        {
            //=========top search

            var _data = Location.GetProvince();
            ddlProvince.DataSource = _data;
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "ProvinceCode";
            ddlProvince.DataBind();

            ddlProvince.Items.Insert(0, new ListItem("Tất cả", "-1"));
            ddlProvince.SelectedIndex = 0;

            ddlDistrict.Items.Insert(0, new ListItem("Tất cả", "-1"));
            
            ddlTypeBDS.DataSource = market.GetCatByType();
            ddlTypeBDS.DataTextField = "Name";
            ddlTypeBDS.DataValueField = "CategoryID";
            ddlTypeBDS.DataBind();

            //add Price temp
            ddlPrice.Items.Add(new ListItem("Tất cả", "0"));
            ddlPrice.Items.Add(new ListItem("Dưới 20 triệu", "1"));
            ddlPrice.Items.Add(new ListItem("20-100 triệu", "2"));
            ddlPrice.Items.Add(new ListItem("100-500 triệu", "3"));
            ddlPrice.Items.Add(new ListItem("500 triệu-2 tỷ", "4"));
            ddlPrice.Items.Add(new ListItem("2-10 tỷ", "5"));
            ddlPrice.Items.Add(new ListItem("10-20 tỷ", "6"));
            ddlPrice.Items.Add(new ListItem("Trên 20 tỷ", "7"));

            //================
           
            ucPaging1.PageSize = 30;
            ucPaging1.PageDisplay = 5;

            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);
        }

    }
    protected void ucPaging1_PageChange(object sender)
    {
        if (!Convert.ToBoolean(Session[VTCO.Config.Constants.SESSION_USER_ID] ?? false))
            Response.Redirect("/login");
         var userID = Convert.ToInt32(Session[VTCO.Config.Constants.SESSION_USER_ID]);
         int code =-1;
         int typecode = 1;
         int cat=Convert.ToInt32(ddlTypeBDS.SelectedValue);
         int price = Int32.Parse(ddlPrice.SelectedValue);
         long begin = 0;
         long end = 0;
         GetPrice(price, ref begin, ref end);

         if (ddlDistrict.SelectedValue != "-1")
         {
             try { code = Convert.ToInt32(ddlDistrict.SelectedValue); }
             catch { }
             typecode = 2;
         }
         else
         {
             try { code = Convert.ToInt32(ddlProvince.SelectedValue); }
             catch { }
             typecode = 1;
         }

         CtrRealtyMarket ctrN = new CtrRealtyMarket();


         var _data = ctrN.GetListRealtyMarket(userID, code, typecode, cat, begin, end, -1, ucPaging1.CurrentPage, ucPaging1.PageSize);
         RptReatyMarket.DataSource = _data.Items;
         RptReatyMarket.DataBind();
         ucPaging1.TotalRecord = _data.TotalRecord;
         divPaging.Visible = ucPaging1.TotalPage > 1;
        RptReatyMarket.Visible=ucPaging1.TotalRecord>0;
        ctNoFound.Visible = !RptReatyMarket.Visible;
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

    protected string getTextPrice(long? _price)
    {
        if ((!_price.HasValue) || (_price.Value==0))
            return "Thỏa thuận";
        double pr = 0;
        pr=_price.Value / 1000000000.0;
        if (pr >= 1)
        {
            return pr.ToString() + " Tỷ";
        }
        pr = _price.Value / 1000000.0;
        if (pr >= 1)
        {
            return pr.ToString() + " Triệu";
        }

        pr = _price.Value / 100000;
        if (pr>=1)
        {
            return pr.ToString() + " Trăm nghìn";
        }
        return _price.Value.ToString("0,0") + " VNĐ";
    }

    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
        //int index = Int32.Parse(ddlProvince.SelectedValue.Split('_')[1]);
        if (ddlProvince.SelectedValue.Trim() != "-1")
        {
            int index = Int32.Parse(ddlProvince.SelectedValue);
            var _data = Location.GetDistrict(index);
            ddlDistrict.Items.Clear();
            ddlDistrict.DataSource = _data;
            ddlDistrict.DataTextField = "Name";
            ddlDistrict.DataValueField = "DistrictCode";
            ddlDistrict.DataBind();
            ddlDistrict.Items.Insert(0, new ListItem("Tất cả", "-1"));
            ddlDistrict.SelectedIndex = 0;

        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Insert(0, new ListItem("Tất cả", "-1"));
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ucPaging1_PageChange(ucPaging1);
    }
    protected void RptReatyMarket_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "delete")
        {
            try
            {
                CtrRealtyMarket ctrN = new CtrRealtyMarket();
                int CurrentID = Int32.Parse(e.CommandArgument.ToString());
                var info = ctrN.GetDetailRealtyMarketByID(CurrentID);

                var image1 = info.Image;

                if (ctrN.DeleteMarket(Int32.Parse(e.CommandArgument.ToString())) > 0)
                {
                    ucPaging1.CurrentPage = 1;
                    ucPaging1_PageChange(ucPaging1);
                    ctrN.DeleteImg(image1.Replace("/", "\\"), Request);
                    ctrN.DeleteImg((image1 + ".thumb").Replace("/", "\\"), Request);
                    ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Xóa thành công!", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Không xóa được!", true);
                }
            }
            catch
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Có lỗi xảy ra!", true);
            }
        }
    }
}