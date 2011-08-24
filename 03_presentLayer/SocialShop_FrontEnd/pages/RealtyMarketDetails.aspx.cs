using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using DAL;
using DataContext;
public partial class pages_RealtyMarketDetails : System.Web.UI.Page
{
    CtrRealtyMarket market = new CtrRealtyMarket();
    protected int CurrentID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            CtrRealtyMarket ctrN = new CtrRealtyMarket();
            CurrentID = Int32.Parse(Request.QueryString["ID"]);
            var info = ctrN.GetDetailRealtyMarketByID(CurrentID);
            selTitle.InnerHtml = info.Title;
            Page.Title = info.Title;
            lblUser.Text = info.UserPublish;
            try
            {
                lblAddress.Text = ctrN.GetFullAddressbyLocationID(info.LocationID.Value);
            }
            catch { lblAddress.Text = ""; }
            lblPhone.Text = info.Phone;
            lblEmail.Text = info.Email;

            //ddlTypeBDSs
            lblAddressStreet.Text = info.Address;
            lblAreage.Text = info.Acreage.Value>0?info.Acreage.ToString()+" m²":"Không xác định";
            lblLegatStatus.Text = info.LegalStatus;
            lblPosition.Text = info.Position;
            lblFloor.Text = info.Floor.ToString();
            lblClientRoom.Text = info.ClientRoom.ToString();
            lblBedRoom.Text = info.BedRoom.ToString();
            lblBathRoom.Text = info.Bathrooms.ToString();
            lblNearKindergarten.Text = info.NearKindergarten.Value ? "Có" : "Không";
            lblNearSchool.Text = info.NearlySchool.Value ? "Có" : "Không";
            lblNearHospital.Text = info.NearHospital.Value ? "Có" : "Không";
            lblMarket.Text = info.NearlyMarket.Value ? "Có" : "Không";
            lblNearUniversity.Text = info.NearlyUniversity.Value ? "Có" : "Không";
            lblPrice.Text = getTextPrice(info.Price);
            lblDescription.InnerHtml = info.Descrition;
            if ((info.Image != null) && (info.Image.Trim() != ""))
                selImage.Src = info.Image;
            else
            {
                selImage.Visible = false;
            }
        }
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(ucPaging1_PageChange);
        if (!IsPostBack)
        {
            ucPaging1.PageSize = 10;
            ucPaging1.PageDisplay = 5;

            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);
        }
    }
    protected void ucPaging1_PageChange(object sender)
    {        
        int CurrentCateID = Int32.Parse(Request.QueryString["CategoryID"]);
        CtrRealtyMarket ctrN = new CtrRealtyMarket();
        var _data = ctrN.GetListRealtyMarket(-1, -1, 1, CurrentCateID, 0,long.MaxValue,1, ucPaging1.CurrentPage, ucPaging1.PageSize);        
        rptOther.DataSource = _data.Items;
        rptOther.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;
        ucPaging1.Visible = ucPaging1.TotalPage > 1;
        divListOtherNews.Visible = _data.TotalRecord > 1;
    }
    protected string getTextPrice(long? _price)
    {
        if ((!_price.HasValue) || (_price.Value == 0))
            return "Thỏa thuận";
        double pr = 0;
        pr = _price.Value / 1000000000.0;
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
        if (pr >= 1)
        {
            return pr.ToString() + " Trăm nghìn";
        }
        return _price.Value.ToString("0,0") + " VNĐ";
    }
}