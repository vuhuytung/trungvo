using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.IO;
public partial class BackEnd_pages_content_RealtyMarket : System.Web.UI.Page
{
    CtrLocation Location = new CtrLocation();
    CtrRealtyMarket ctrN = new CtrRealtyMarket();
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
            //ddlTypeBDS.Items.Add(new ListItem("Tất cả","0"));
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần bán","21"));
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần mua","22"));

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
        if (Int32.Parse(ddlProvince.SelectedValue.Split('_')[0]) != -1) //kiểm tra nếu chọn tỉnh
        {
            if (Int32.Parse(ddlDistrict.SelectedValue.Split('_')[0]) != -1) //nếu chọn huyện
            {
                if (Int32.Parse(ddlVillage.SelectedValue.Split('_')[0]) != -1)
                {
                    int Code = Int32.Parse(ddlVillage.SelectedValue.Split('_')[1]);
                    var _data = ctrN.GetListRealtyMarketByCondition(Code, 3, Int32.Parse(ddlTypeBDS.SelectedValue), 0, 500000, ucPaging1.CurrentPage, ucPaging1.PageSize);
                    RptReatyMarket.DataSource = _data.Items;
                    RptReatyMarket.DataBind();
                    ucPaging1.TotalRecord = _data.TotalRecord;
                    
                }
                else
                {
                    int Code = Int32.Parse(ddlDistrict.SelectedValue.Split('_')[1]);
                    var _data = ctrN.GetListRealtyMarketByCondition(Code, 2, Int32.Parse(ddlTypeBDS.SelectedValue), 0, 500000, ucPaging1.CurrentPage, ucPaging1.PageSize);
                    RptReatyMarket.DataSource = _data.Items;
                    RptReatyMarket.DataBind();
                    ucPaging1.TotalRecord = _data.TotalRecord;
                   // return Code;
                }

            }
            else
            {
                int Code = Int32.Parse(ddlProvince.SelectedValue.Split('_')[1]);
                var _data = ctrN.GetListRealtyMarketByCondition(Code, 1, Int32.Parse(ddlTypeBDS.SelectedValue), 0, 500000, ucPaging1.CurrentPage, ucPaging1.PageSize);
                RptReatyMarket.DataSource = _data.Items;
                RptReatyMarket.DataBind();
                ucPaging1.TotalRecord = _data.TotalRecord;
               // return Code;
            }
           
        }
        else
        {
            var _data = ctrN.GetListRealtyMarketByCondition(0, 1, Int32.Parse(ddlTypeBDS.SelectedValue), 0, 500000, ucPaging1.CurrentPage, ucPaging1.PageSize);
            RptReatyMarket.DataSource = _data.Items;
            RptReatyMarket.DataBind();
            ucPaging1.TotalRecord = _data.TotalRecord;
        }
        //var _data = ctrN.GetListRealtyMarketByCondition(1, 1, 1, 100, 500, ucPaging1.CurrentPage, ucPaging1.PageSize);
        //RptReatyMarket.DataSource = _data.Items;
        // RptReatyMarket.DataBind();
        //ucPaging1.TotalRecord = _data.TotalRecord;
       // return 1;
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
        }
        catch
        {
        }

    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        
        try
        {
            Panel2.Visible = true;
            BindDrop(ref ddlProvince2, ref ddlDistrict2, ref ddlVillage2);

        }
        catch
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

    protected void RptReatyMarket_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Panel1.Visible = true;
            RptDetail.DataSource = ctrN.GetDetailRealtyMarketByID(Int32.Parse(e.CommandArgument.ToString()));
            RptDetail.DataBind();

            DropDownList  ddlProvince1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlProvince1");
            DropDownList ddlDistrict1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlDistrict1");
            DropDownList ddlVillage1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlVillage1");
            if (ddlProvince1 != null && ddlDistrict1 != null && ddlVillage1 != null)
            {
                try
                {
                    BindDrop(ref ddlProvince1, ref ddlDistrict1, ref ddlVillage1);
                }
                catch
                {

                }
            }

        }
        else if (e.CommandName == "Delete")
        {
            try
            {
                ctrN.DeleteMarket(Int32.Parse(e.CommandArgument.ToString()));
                BindRpt();
                ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Delete success !')", true);
            }
            catch
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Delete fail !')", true);
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        //update reatymarket
        //get controls in RptDetail
        try
        {
            DropDownList ddlProvince1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlProvince1");
            DropDownList ddlDistrict1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlDistrict1");
            DropDownList ddlVillage1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlVillage1");
            DropDownList ddlTypeBDS1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlTypeBDS");

            TextBox txtTitle = (TextBox)RptDetail.Controls[1].FindControl("txtTitle");
            TextBox txtUser = (TextBox)RptDetail.Controls[1].FindControl("txtUser");
            TextBox txtAddress = (TextBox)RptDetail.Controls[1].FindControl("txtAddress");
            TextBox txtPhone = (TextBox)RptDetail.Controls[1].FindControl("txtPhone");
            TextBox txtEmail = (TextBox)RptDetail.Controls[1].FindControl("txtEmail");
            TextBox txtDientich = (TextBox)RptDetail.Controls[1].FindControl("txtDientich");
            TextBox txtLegal = (TextBox)RptDetail.Controls[1].FindControl("txtLegal");
            TextBox txtPosition = (TextBox)RptDetail.Controls[1].FindControl("txtPosition");
            TextBox txtFloor = (TextBox)RptDetail.Controls[1].FindControl("txtFloor");
            TextBox txtClientRoom = (TextBox)RptDetail.Controls[1].FindControl("txtClientRoom");
            TextBox txtBedRoom = (TextBox)RptDetail.Controls[1].FindControl("txtBedRoom");
            TextBox txtBathrooms = (TextBox)RptDetail.Controls[1].FindControl("txtBathrooms");
            TextBox txtPrice = (TextBox)RptDetail.Controls[1].FindControl("txtPrice");
            TextBox txtDesc = (TextBox)RptDetail.Controls[1].FindControl("txtDesc");
            TextBox txtStreet = (TextBox)RptDetail.Controls[1].FindControl("txtStreet");
           // CheckBox chkCooler = (CheckBox)RptDetail.Controls[1].FindControl("chkCooler");
            //CheckBox chkCable = (CheckBox)RptDetail.Controls[1].FindControl("chkCable");
            CheckBox chkMaugiao = (CheckBox)RptDetail.Controls[1].FindControl("chkMaugiao");
            CheckBox chkschool = (CheckBox)RptDetail.Controls[1].FindControl("chkschool");
            CheckBox chkHospital = (CheckBox)RptDetail.Controls[1].FindControl("chkHospital");
            CheckBox chkMarket = (CheckBox)RptDetail.Controls[1].FindControl("chkMarket");
            CheckBox chkUniversity = (CheckBox)RptDetail.Controls[1].FindControl("chkUniversity");
            //CheckBox chkPark = (CheckBox)RptDetail.Controls[1].FindControl("chkPark");
           // CheckBox chkInternet = (CheckBox)RptDetail.Controls[1].FindControl("chkInternet");
            //CheckBox chkOto = (CheckBox)RptDetail.Controls[1].FindControl("chkOto");
            CheckBox chkStatus = (CheckBox)RptDetail.Controls[1].FindControl("chkStatus");
            FileUpload fupload = (FileUpload)RptDetail.Controls[1].FindControl("fupload");
            HiddenField hdLocation = (HiddenField)RptDetail.Controls[1].FindControl("hdLocation");
            Label lblID = (Label)RptDetail.Controls[1].FindControl("lblID");
            try
            {
                int location=GetLocationID(ddlProvince1, ddlDistrict1, ddlVillage1);
                if (fupload.FileName != "")
                {

                    string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\Market");
                    strFile += "\\" + fupload.FileName;
                    fupload.PostedFile.SaveAs(strFile);

                    if (location != 0)
                    {
                        string text = HttpUtility.HtmlEncode(txtDesc.Text).Replace("\n", "</br>");
                        ctrN.UpdateMarket(Int32.Parse(lblID.Text), txtTitle.Text, text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDS1.SelectedValue), @"/images/Market/" + fupload.FileName, txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, location, txtStreet.Text, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked);
                    }
                    else
                    {
                        string text = HttpUtility.HtmlEncode(txtDesc.Text).Replace("\n", "</br>");
                        ctrN.UpdateMarket(Int32.Parse(lblID.Text), txtTitle.Text, text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDS1.SelectedValue), @"/images/Market/" + fupload.FileName, txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, Int32.Parse(hdLocation.Value), txtStreet.Text, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked);
                    }
                }
                else
                {
                    if (location != 0)
                    {
                        string text = HttpUtility.HtmlEncode(txtDesc.Text).Replace("\n", "</br>");
                        ctrN.UpdateMarket(Int32.Parse(lblID.Text), txtTitle.Text, text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDS1.SelectedValue),"", txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, location, txtStreet.Text, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked);
                    }
                    else
                    {
                        string text = HttpUtility.HtmlEncode(txtDesc.Text).Replace("\n", "</br>");
                        ctrN.UpdateMarket(Int32.Parse(lblID.Text), txtTitle.Text, text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDS1.SelectedValue),"", txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, Int32.Parse(hdLocation.Value), txtStreet.Text, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked);
                    }
                }
                BindRpt();
                ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Update success !')",true);

            }
            catch
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Update fail !')",true);
            }
        }
        catch
        {
        }

    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void ddlProvince1_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            DropDownList ddlProvince1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlProvince1");
            DropDownList ddlDistrict1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlDistrict1");
            DropDownList ddlVillage1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlVillage1");
            if (ddlProvince1.SelectedValue.Trim() != "-1")
            {
                int index = Int32.Parse(ddlProvince1.SelectedValue.Split('_')[1]);
                var _data = Location.GetDistrict(index);
                List<LocationInfoSearch> _source = new List<LocationInfoSearch>();
                foreach (var item in _data)
                {
                    LocationInfoSearch lInfo = new LocationInfoSearch();
                    lInfo.LocationValue = item.LocationID + "_" + item.DistrictCode;
                    lInfo.LocationText = item.Name;
                    _source.Add(lInfo);
                }
                ddlDistrict1.Items.Clear();
                ddlDistrict1.DataSource = _source;
                ddlDistrict1.DataTextField = "LocationText";
                ddlDistrict1.DataValueField = "LocationValue";
                ddlDistrict1.DataBind();
                ddlDistrict1.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));
                ddlDistrict1.SelectedIndex = 0;

                ddlVillage1.Items.Clear();
                ddlVillage1.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
            }
            else
            {
                ddlDistrict1.Items.Clear();
                ddlDistrict1.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));

                ddlVillage1.Items.Clear();
                ddlVillage1.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
            }
        }
        catch
        {
        }
    }
    protected void ddlDistrict1_SelectedIndexChanged(object sender, EventArgs e)
    {

        DropDownList ddlProvince1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlProvince1");
        DropDownList ddlDistrict1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlDistrict1");
        DropDownList ddlVillage1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlVillage1");
        if (ddlDistrict1.SelectedValue.Trim() != "-1")
        {
            int index = Int32.Parse(ddlDistrict1.SelectedValue.Split('_')[1]);
            var _data = Location.GetVillage(index);
            List<LocationInfoSearch> _source = new List<LocationInfoSearch>();
            foreach (var item in _data)
            {
                LocationInfoSearch lInfo = new LocationInfoSearch();
                lInfo.LocationValue = item.LocationID + "_" + item.VillageCode;
                lInfo.LocationText = item.Name;
                _source.Add(lInfo);
            }
            ddlVillage1.DataSource = _source;
            ddlVillage1.DataTextField = "LocationText";
            ddlVillage1.DataValueField = "LocationValue";
            ddlVillage1.DataBind();
            ddlVillage1.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
            ddlVillage1.SelectedIndex = 0;
        }
        else
        {
            ddlVillage1.Items.Clear();
            ddlVillage1.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
        }
    }
    //=========================phan xu ly viec insert du lieu mới==================
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            

                string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\Market");
                strFile += "\\" + fupload.FileName;
                fupload.PostedFile.SaveAs(strFile);
                int locationID = GetLocationID(ddlProvince2, ddlDistrict2, ddlVillage2);
                ctrN.InsertMarket(txtTitle.Text, txtDesc.Text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDSs2.SelectedValue), @"/images/Market/" + fupload.FileName, txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, locationID, txtStreet.Text, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked);
           
            BindRpt();
            ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Insert success !')", true);
        }
        catch
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Insert fail !')", true);
        }
    }
    protected void btnThoat_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
    }

    protected void ddlProvince2_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlProvince2.SelectedValue.Trim() != "-1")
            {
                int index = Int32.Parse(ddlProvince2.SelectedValue.Split('_')[1]);
                var _data = Location.GetDistrict(index);
                List<LocationInfoSearch> _source = new List<LocationInfoSearch>();
                foreach (var item in _data)
                {
                    LocationInfoSearch lInfo = new LocationInfoSearch();
                    lInfo.LocationValue = item.LocationID + "_" + item.DistrictCode;
                    lInfo.LocationText = item.Name;
                    _source.Add(lInfo);
                }
                ddlDistrict2.Items.Clear();
                ddlDistrict2.DataSource = _source;
                ddlDistrict2.DataTextField = "LocationText";
                ddlDistrict2.DataValueField = "LocationValue";
                ddlDistrict2.DataBind();
                ddlDistrict2.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));
                ddlDistrict2.SelectedIndex = 0;

                ddlVillage2.Items.Clear();
                ddlVillage2.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
            }
            else
            {
                ddlDistrict2.Items.Clear();
                ddlDistrict2.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));

                ddlVillage2.Items.Clear();
                ddlVillage2.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
            }
        }
        catch
        {
        }
    }
    protected void ddlDistrict2_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (ddlDistrict2.SelectedValue.Trim() != "-1")
        {
            int index = Int32.Parse(ddlDistrict2.SelectedValue.Split('_')[1]);
            var _data = Location.GetVillage(index);
            List<LocationInfoSearch> _source = new List<LocationInfoSearch>();
            foreach (var item in _data)
            {
                LocationInfoSearch lInfo = new LocationInfoSearch();
                lInfo.LocationValue = item.LocationID + "_" + item.VillageCode;
                lInfo.LocationText = item.Name;
                _source.Add(lInfo);
            }
            ddlVillage2.DataSource = _source;
            ddlVillage2.DataTextField = "LocationText";
            ddlVillage2.DataValueField = "LocationValue";
            ddlVillage2.DataBind();
            ddlVillage2.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
            ddlVillage2.SelectedIndex = 0;
        }
        else
        {
            ddlVillage2.Items.Clear();
            ddlVillage2.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
        }
    }
    protected void lbtDeleteAll_Click(object sender, EventArgs e)
    {

        foreach (RepeaterItem item in RptReatyMarket.Items)
        {
            CheckBox chkDeleteAll = (CheckBox)item.FindControl("chkDeleteAll");
            HiddenField hdID = (HiddenField)item.FindControl("hdID");
            if (chkDeleteAll != null && hdID != null)
            {
                if (chkDeleteAll.Checked == true)
                {
                    ctrN.DeleteMarket(Int32.Parse(hdID.Value));
                }

            }
        }
        BindRpt();
    }
}