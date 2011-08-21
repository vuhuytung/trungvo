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
            ddlProvince.Items.Insert(0, new ListItem("--Tất cả--", "-1"));
            ddlProvince.SelectedIndex = 0;

            ddlDistrict.Items.Insert(0, new ListItem("--Tất cả--", "-1"));
            //ddlVillage.Items.Insert(0, new ListItem("--Tất cả--", "-1"));

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
    }
    private void BindDrop(ref DropDownList ddl1, ref DropDownList ddl2, ref DropDownList ddl3)
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

        ddl1.DataSource = _source;
        ddl1.DataTextField = "LocationText";
        ddl1.DataValueField = "LocationValue";
        ddl1.DataBind();
        ddl1.Items.Insert(0, new ListItem("TP/Tỉnh", "-1"));
        ddl1.SelectedIndex = 0;

        ddl2.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));
        ddl3.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
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
    protected void ucPaging1_PageChange(object sender)
    {
        BindRpt();
    }
    private int GetLocationID(DropDownList ddlProvince, DropDownList ddlDistrict, DropDownList ddlVillage)
    {
        if (Int32.Parse(ddlProvince.SelectedValue.Split('_')[0]) != -1) //kiểm tra nếu chọn tỉnh
        {
            if (Int32.Parse(ddlDistrict.SelectedValue.Split('_')[0]) != -1) //nếu chọn huyện
            {
                if (Int32.Parse(ddlVillage.SelectedValue.Split('_')[0]) != -1)
                {
                    return Int32.Parse(ddlVillage.SelectedValue.Split('_')[0]);
                }
                else
                {
                    return Int32.Parse(ddlDistrict.SelectedValue.Split('_')[0]);
                }
            }
            else
            {
                return Int32.Parse(ddlProvince.SelectedValue.Split('_')[0]);
            }
        }

        return 0;
    }

    protected void BindRpt()
    {
        double begin = 0;
        double end = 0;
        GetPrice(Int32.Parse(ddlPrice.SelectedValue), ref begin, ref end);
        if (Int32.Parse(ddlProvince.SelectedValue.Split('_')[0]) != -1) //kiểm tra nếu chọn tỉnh
        {
            if (Int32.Parse(ddlDistrict.SelectedValue.Split('_')[0]) != -1) //nếu chọn huyện
            {

                int Code = Int32.Parse(ddlDistrict.SelectedValue.Split('_')[1]);
                var _data = ctrN.GetListRealtyMarketByCondition(Int32.Parse(ddlTypeUser.SelectedValue), Code, 2, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
                RptReatyMarket.DataSource = _data.Items;
                RptReatyMarket.DataBind();
                ucPaging1.TotalRecord = _data.TotalRecord;
                // return Code;

            }
            else
            {
                int Code = Int32.Parse(ddlProvince.SelectedValue.Split('_')[1]);
                var _data = ctrN.GetListRealtyMarketByCondition(Int32.Parse(ddlTypeUser.SelectedValue), Code, 1, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
                RptReatyMarket.DataSource = _data.Items;
                RptReatyMarket.DataBind();
                ucPaging1.TotalRecord = _data.TotalRecord;
                // return Code;
            }

        }
        else
        {
            var _data = ctrN.GetListRealtyMarketByCondition(Int32.Parse(ddlTypeUser.SelectedValue), 0, 1, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
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

            if (Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "Status")))
            {
                if ((permission & VTCO.Config.Constants.PERMISSION_EDIT) == VTCO.Config.Constants.PERMISSION_EDIT)
                    (e.Item.FindControl("lbtUnLock") as LinkButton).Visible = false;
            }
            else
            {
                if ((permission & VTCO.Config.Constants.PERMISSION_EDIT) == VTCO.Config.Constants.PERMISSION_EDIT)
                    (e.Item.FindControl("lbtLock") as LinkButton).Visible = false;
            }
        }

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
            lblAreage.Text=info.Acreage;
            lblLegatStatus.Text=info.LegalStatus;
            lblPosition.Text=info.Position;
            lblFloor.Text=info.Floor;
            lblClientRoom.Text=info.ClientRoom;
            lblBedRoom.Text=info.BedRoom;
            lblBathRoom.Text=info.Bathrooms;
            lblNearKindergarten.Text=info.NearKindergarten.Value?"Có":"Không";
            lblNearSchool.Text=info.NearlySchool.Value?"Có":"Không";
            lblNearHospital.Text=info.NearHospital.Value?"Có":"Không";
            lblMarket.Text=info.NearlyMarket.Value?"Có":"Không";
            lblNearUniversity.Text=info.NearlyUniversity.Value?"Có":"Không";
            lblPrice.Text=info.Price.Value.ToString("0,0");
            lblDescription.Text=info.Descrition;
            ddlStatus.SelectedValue=info.Status.Value?"1":"0";
            Panel1.Visible = true;
            Panel3.Visible = false;
            lblMsg.Text = "";
        }
        else if (e.CommandName == "delete")
        {
            try
            {
                CurrentID = Int32.Parse(e.CommandArgument.ToString());
                var info = ctrN.GetDetailRealtyMarketByID(CurrentID);

                var image1 = info.Image;
                var image2 = info.ImageThumb;

                if (ctrN.DeleteMarket(Int32.Parse(e.CommandArgument.ToString())) > 0)
                {
                    BindRpt();
                    ctrN.DeleteImg(image1.Replace("/", "\\"), Request);
                    ctrN.DeleteImg(image2.Replace("/", "\\"), Request);
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
            if (ctrN.UpdateStatus(Convert.ToInt32(e.CommandArgument), false) > 0)
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
            if (ctrN.UpdateStatus(Convert.ToInt32(e.CommandArgument), true) > 0)
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
        if (ctrN.UpdateStatus(CurrentID, Convert.ToBoolean(ddlStatus.SelectedValue)) > 0)
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
                        HiddenField Img = (HiddenField)item.FindControl("Img");
                        HiddenField ImgThumb = (HiddenField)item.FindControl("ImgThumb");

                        ctrN.DeleteImg(Img.Value.Replace("/", "\\"), Request);
                        ctrN.DeleteImg(ImgThumb.Value.Replace("/", "\\"), Request);

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