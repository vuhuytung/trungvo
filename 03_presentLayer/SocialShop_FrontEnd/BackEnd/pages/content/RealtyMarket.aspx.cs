using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.IO;
using VTCO.Config;
using System.Web.UI.HtmlControls;
public partial class BackEnd_pages_content_RealtyMarket : System.Web.UI.Page
{
    public int CurrentID
    {
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["CurrentID"]);
            }
            catch
            {
                return -1;
            }
        }

        set
        {
            ViewState["CurrentID"] = value;
        }
    }
    CtrLocation Location = new CtrLocation();
    CtrRealtyMarket ctrN = new CtrRealtyMarket();
    protected int permission = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(ucPaging1_PageChange);
        if (!IsPostBack)
        {
            //=========top search

            var _data = Location.GetProvince();

            ddlProvince.DataSource = _data;
            ddlProvince.DataTextField = "Name";
            ddlProvince.DataValueField = "ProvinceCode";
            ddlProvince.DataBind();
            ddlProvince.Items.Insert(0, new ListItem("--Tất cả--", "-1"));
            ddlProvince.SelectedIndex = 0;

            ddlDistrict.Items.Insert(0, new ListItem("--Tất cả--", "-1"));

            //add Type BDS temp
            ddlTypeBDS.DataSource = ctrN.GetCatByType();
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

            //================

            ucPaging1.PageSize = 10;
            ucPaging1.PageDisplay = 5;

            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);

            if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/images/Market"))
            {
                System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/images/Market");
            }
            CtrPartner pn = new CtrPartner();
            pn.DeleteImgTemp(Request);
            if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/images/temp"))
            {
                System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/images/temp");
            }
        }
        lblMsg.Text = "";
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
    protected void ucPaging1_PageChange(object sender)
    {
        BindRpt();
    }


    protected void BindRpt()
    {
        long begin = 0;
        long end = 0;
        GetPrice(Int32.Parse(ddlPrice.SelectedValue), ref begin, ref end);

        if (Int32.Parse(ddlDistrict.SelectedValue) != -1) //nếu chọn huyện
        {

            int Code = Int32.Parse(ddlDistrict.SelectedValue);
            var _data = ctrN.GetListRealtyMarket(-1, Code, 2, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end,Convert.ToInt32(ddlStatusSearch.SelectedValue), ucPaging1.CurrentPage, ucPaging1.PageSize);
            RptReatyMarket.DataSource = _data.Items;
            RptReatyMarket.DataBind();
            ucPaging1.TotalRecord = _data.TotalRecord;
            divPaging.Visible = ucPaging1.TotalPage > 1;

        }
        else
        {
            int Code = Int32.Parse(ddlProvince.SelectedValue);
            var _data = ctrN.GetListRealtyMarket(-1, Code, 1, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end,Convert.ToInt32(ddlStatusSearch.SelectedValue), ucPaging1.CurrentPage, ucPaging1.PageSize);
            RptReatyMarket.DataSource = _data.Items;
            RptReatyMarket.DataBind();
            ucPaging1.TotalRecord = _data.TotalRecord;
            divPaging.Visible = ucPaging1.TotalPage > 1;
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
        //some code here
        BindRpt();
    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel3.Visible = false;
    }


    protected void RptReatyMarket_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            HtmlGenericControl divListRow = e.Item.FindControl("divListRow") as HtmlGenericControl;
            if (divListRow == null)
            {
                return;
            }
            if (e.Item.ItemIndex % 2 == 0)
            {
                divListRow.Attributes["class"] = "adminListRow-even";
            }
            if ((permission & VTCO.Config.Constants.PERMISSION_EDIT) == VTCO.Config.Constants.PERMISSION_EDIT)
            {
                switch (Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Status")))
                {
                    case 1:
                        (e.Item.FindControl("liUnLock") as HtmlGenericControl).Visible = false;
                        break;
                    case 2:
                        (e.Item.FindControl("liLock") as HtmlGenericControl).Visible = false;
                        break;
                }
            }
        }

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
    protected void RptReatyMarket_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Panel1.Visible = true;
            Panel3.Visible = false;
            CurrentID = Int32.Parse(e.CommandArgument.ToString());
            var info = ctrN.GetDetailRealtyMarketByID(CurrentID);
            lblTitle.Text=info.Title;
            lblUser.Text=info.UserPublish;
            try
            {
                lblAddress.Text = ctrN.GetFullAddressbyLocationID(info.LocationID.Value);
            }
            catch { lblAddress.Text = ""; }
            lblPhone.Text=info.Phone;
            lblEmail.Text=info.Email;
            CtrCategory ctrCat = new CtrCategory();
            try
            {
                lblCategory.Text = ctrCat.GetInfo(info.Type.Value).Name;
            }
            catch { lblCategory.Text = ""; }
            
            //ddlTypeBDSs
            lblAddressStreet.Text=info.Address;
            lblAreage.Text=info.Acreage.ToString();
            lblLegatStatus.Text=info.LegalStatus;
            lblPosition.Text=info.Position;
            lblFloor.Text=info.Floor.ToString();
            lblClientRoom.Text=info.ClientRoom.ToString();
            lblBedRoom.Text=info.BedRoom.ToString();
            lblBathRoom.Text=info.Bathrooms.ToString();
            lblNearKindergarten.Text=info.NearKindergarten.Value?"Có":"Không";
            lblNearSchool.Text=info.NearlySchool.Value?"Có":"Không";
            lblNearHospital.Text=info.NearHospital.Value?"Có":"Không";
            lblMarket.Text=info.NearlyMarket.Value?"Có":"Không";
            lblNearUniversity.Text=info.NearlyUniversity.Value?"Có":"Không";
            lblPrice.Text = getTextPrice(info.Price);
            lblDescription.Text=info.Descrition;
            ddlStatus.Items.Clear();
            ddlStatus.Items.Add(new ListItem("Kích hoạt","1"));
            ddlStatus.Items.Add(new ListItem("Khóa","2"));
            if(info.Status==0)
                ddlStatus.Items.Insert(0, new ListItem("Chưa duyệt","0"));
            ddlStatus.SelectedValue=info.Status.ToString();
            Panel1.Visible = true;
            Panel3.Visible = false;
            lblMsg.Text = "";
            if ((info.Image != null) && (info.Image.Trim() != ""))
                imgImage.ImageUrl =  info.Image + ".thumb";
            else
            {
                imgImage.ImageUrl = "/images/nomarket.jpg";
            }
        }
        else if (e.CommandName == "delete")
        {
            try
            {
                CurrentID = Int32.Parse(e.CommandArgument.ToString());
                var info = ctrN.GetDetailRealtyMarketByID(CurrentID);

                var image1 = info.Image;

                if (ctrN.DeleteMarket(Int32.Parse(e.CommandArgument.ToString())) > 0)
                {
                    BindRpt();
                    ctrN.DeleteImg(image1.Replace("/", "\\"), Request);
                    ctrN.DeleteImg((image1+".thumb").Replace("/", "\\"), Request);
                    lblMsg.Text = "Xóa thành công!";
                }
                else
                {
                    lblMsg.Text = "Xóa thất bại!";
                }
            }
            catch
            {
                lblMsg.Text = "Có lỗi xảy ra!";
            }
        }

        if (e.CommandName == "lockNews")
        {
            if (ctrN.UpdateStatus(Convert.ToInt32(e.CommandArgument), 2) > 0)
            {
                BindRpt();
                lblMsg.Text = "Cập nhật thành công";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");

            }
            else
            {
                lblMsg.Text = "Cập nhật thất bại";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
            }
        }

        if (e.CommandName == "unlockNews")
        {
            if (ctrN.UpdateStatus(Convert.ToInt32(e.CommandArgument), 1) > 0)
            {
                BindRpt();
                lblMsg.Text = "Cập nhật thành công";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");
            }
            else
            {
                lblMsg.Text = "Cập nhật thất bại";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        if (ctrN.UpdateStatus(CurrentID, Convert.ToInt32(ddlStatus.SelectedValue)) > 0)
        {
            lblMsg.Text = "Cập nhật thành công!";
            Panel3.Visible = true;
            Panel1.Visible = false;
        }else
            lblMsg.Text = "Cập nhật thất bại!";

    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel3.Visible = true;
    }

    protected void lbtDeleteAll_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem item in RptReatyMarket.Items)
            {
                CheckBox chkDeleteAll = (CheckBox)item.FindControl("chkDeleteAll");
                HiddenField hdID = (HiddenField)item.FindControl("hdID");
                if (chkDeleteAll != null && hdID != null)
                {
                    if (chkDeleteAll.Checked == true)
                    {
                        var Img = ctrN.GetDetailRealtyMarketByID(Convert.ToInt32(hdID.Value)).Image;
                        ctrN.DeleteImg(Img.Replace("/", "\\"), Request);
                        ctrN.DeleteImg((Img+".thumb").Replace("/", "\\"), Request);

                        ctrN.DeleteMarket(Int32.Parse(hdID.Value));
                    }

                }
            }
            BindRpt();
        }
        catch
        {
        }
    }
}