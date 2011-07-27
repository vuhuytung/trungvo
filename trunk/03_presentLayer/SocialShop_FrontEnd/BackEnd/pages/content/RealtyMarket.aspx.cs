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
            //ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần bán", "21"));
            //ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần mua", "22"));
            ddlTypeBDS.DataSource = ctrN.GetCatByType();
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

            if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/images/Market"))
            {
                System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/images/Market");
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
                if (Int32.Parse(ddlVillage.SelectedValue.Split('_')[0]) != -1)
                {
                    int Code = Int32.Parse(ddlVillage.SelectedValue.Split('_')[1]);
                    var _data = ctrN.GetListRealtyMarketByCondition( Int32.Parse(ddlTypeUser.SelectedValue),Code, 3, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
                    RptReatyMarket.DataSource = _data.Items;
                    RptReatyMarket.DataBind();
                    ucPaging1.TotalRecord = _data.TotalRecord;
                }
                else
                {
                    int Code = Int32.Parse(ddlDistrict.SelectedValue.Split('_')[1]);
                    var _data = ctrN.GetListRealtyMarketByCondition(Int32.Parse(ddlTypeUser.SelectedValue),Code, 2, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
                    RptReatyMarket.DataSource = _data.Items;
                    RptReatyMarket.DataBind();
                    ucPaging1.TotalRecord = _data.TotalRecord;
                    // return Code;
                }

            }
            else
            {
                int Code = Int32.Parse(ddlProvince.SelectedValue.Split('_')[1]);
                var _data = ctrN.GetListRealtyMarketByCondition(Int32.Parse(ddlTypeUser.SelectedValue),Code, 1, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
                RptReatyMarket.DataSource = _data.Items;
                RptReatyMarket.DataBind();
                ucPaging1.TotalRecord = _data.TotalRecord;
                // return Code;
            }

        }
        else
        {
            var _data = ctrN.GetListRealtyMarketByCondition(Int32.Parse(ddlTypeUser.SelectedValue),0, 1, Int32.Parse(ddlTypeBDS.SelectedValue), begin, end, ucPaging1.CurrentPage, ucPaging1.PageSize);
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

            //DropDownList ddlTypeBDS1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlTypeBDS");
            //=================================================
            ddlTypeBDSs2.DataSource = ctrN.GetCatByType();
            ddlTypeBDSs2.DataTextField = "Name";
            ddlTypeBDSs2.DataValueField = "CategoryID";
            ddlTypeBDSs2.DataBind();
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

            DropDownList ddlProvince1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlProvince1");
            DropDownList ddlDistrict1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlDistrict1");
            DropDownList ddlVillage1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlVillage1");

            DropDownList ddlTypeBDS1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlTypeBDSs");
            if (ctrN.GetShower(Int32.Parse(e.CommandArgument.ToString())) == 0)
            {
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
                fupload.Enabled = false;
                txtAddress.Enabled = false;
                txtBathrooms.Enabled = false;
                txtBedRoom.Enabled = false;
                txtClientRoom.Enabled = false;
                txtDesc.Enabled = false;
                txtDientich.Enabled = false;
                txtEmail.Enabled = false;
                txtFloor.Enabled = false;
                txtLegal.Enabled = false;
                txtPhone.Enabled = false;
                txtPosition.Enabled = false;
                txtPrice.Enabled = false;
                txtStreet.Enabled = false;
                txtTitle.Enabled = false;
                txtUser.Enabled = false;
                chkHospital.Enabled = false;
                chkMarket.Enabled = false;
                chkMaugiao.Enabled = false;
                chkschool.Enabled = false;
                chkUniversity.Enabled = false;
                ddlDistrict1.Enabled = false;
                ddlProvince1.Enabled = false;
                ddlVillage1.Enabled = false;
                ddlTypeBDS1.Enabled = false;

            }
           

            //=================================================
            ddlTypeBDS1.DataSource = ctrN.GetCatByType();
            ddlTypeBDS1.DataTextField = "Name";
            ddlTypeBDS1.DataValueField = "CategoryID";
            ddlTypeBDS1.DataBind();
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
                HiddenField Img = (HiddenField)e.Item.FindControl("Img");
                HiddenField ImgThumb = (HiddenField)e.Item.FindControl("ImgThumb");

                ctrN.DeleteImg(Img.Value.Replace("/", "\\"), Request);
                ctrN.DeleteImg(ImgThumb.Value.Replace("/", "\\"), Request);

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
            DropDownList ddlTypeBDS1 = (DropDownList)RptDetail.Controls[1].FindControl("ddlTypeBDSs");
           //=================================================
            ddlTypeBDS1.DataSource = ctrN.GetCatByType();
            ddlTypeBDS1.DataTextField = "Name";
            ddlTypeBDS1.DataValueField = "CategoryID";
            ddlTypeBDS1.DataBind();

            //===============================================
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
            HiddenField fullAdd = (HiddenField)RptDetail.Controls[1].FindControl("fullAdd");
            Label lblID = (Label)RptDetail.Controls[1].FindControl("lblID");


            HiddenField Img = (HiddenField)RptDetail.Controls[1].FindControl("Img");
            HiddenField ImgThumb = (HiddenField)RptDetail.Controls[1].FindControl("ImgThumb");
            if (ctrN.GetShower(Int32.Parse(lblID.Text)) == 1)
            {
                try
                {
                    int location = GetLocationID(ddlProvince1, ddlDistrict1, ddlVillage1);
                    if (fupload.FileName != "")
                    {
                        string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\Market");
                        strFile += "\\" + fupload.FileName;

                        var EditImage1 = System.Drawing.Image.FromFile(fupload.PostedFile.FileName);
                        VTCO.Library.ImageResize Img2 = new VTCO.Library.ImageResize();
                        var newimg1 = Img2.Crop(EditImage1, 500, 300, VTCO.Library.ImageResize.AnchorPosition.Center);
                        newimg1.Save(strFile);

                        // fupload.PostedFile.SaveAs(strFile);

                        int length = fupload.FileName.Length - 4;
                        string newname = fupload.FileName.Substring(0, length) + "_thumb";
                        string exp = fupload.FileName.Substring(length);
                        newname = newname + exp;
                        string strFile1 = Path.Combine(Request.PhysicalApplicationPath, "images\\Market");
                        strFile1 += "\\" + newname;

                        var EditImage = System.Drawing.Image.FromFile(fupload.PostedFile.FileName);
                        VTCO.Library.ImageResize Img1 = new VTCO.Library.ImageResize();
                        var newimg = Img1.Crop(EditImage, 120, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
                        newimg.Save(strFile1);


                        if (location != 0)
                        {
                            string text = HttpUtility.HtmlEncode(txtDesc.Text).Replace("\n", "</br>");
                            string address = ctrN.GetFullAddressbyLocationID(location);
                            string str = txtStreet.Text + "-" + address;
                            ctrN.UpdateMarket(Int32.Parse(lblID.Text), txtTitle.Text, text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDS1.SelectedValue), @"/images/Market/" + fupload.FileName, @"/images/Market/" + newname, txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, location, str, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked);
                        }
                        else
                        {
                            string text = HttpUtility.HtmlEncode(txtDesc.Text).Replace("\n", "</br>");
                            ctrN.UpdateMarket(Int32.Parse(lblID.Text), txtTitle.Text, text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDS1.SelectedValue), @"/images/Market/" + fupload.FileName, @"/images/Market/" + newname, txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, Int32.Parse(hdLocation.Value), fullAdd.Value, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked);
                        }
                    }
                    else
                    {
                        if (location != 0)
                        {
                            string text = HttpUtility.HtmlEncode(txtDesc.Text).Replace("\n", "</br>");
                            string address = ctrN.GetFullAddressbyLocationID(location);
                            string str = txtStreet.Text + "-" + address;
                            ctrN.UpdateMarket(Int32.Parse(lblID.Text), txtTitle.Text, text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDS1.SelectedValue), Img.Value, ImgThumb.Value, txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, location, str, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked);
                        }
                        else
                        {
                            string text = HttpUtility.HtmlEncode(txtDesc.Text).Replace("\n", "</br>");
                            ctrN.UpdateMarket(Int32.Parse(lblID.Text), txtTitle.Text, text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDS1.SelectedValue), Img.Value, ImgThumb.Value, txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, Int32.Parse(hdLocation.Value), fullAdd.Value, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked);
                        }
                    }
                    BindRpt();
                    ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Cập nhật thành công !')", true);

                }
                catch
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Cập nhật thất bại !')", true);
                }
            }
            else
            {
                
                if (ctrN.UpdateStatus(Int32.Parse(lblID.Text), chkStatus.Checked) > 0)
                {
                    BindRpt();
                    ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Cập nhật thành công !')", true);
                }
                else
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Cập nhật thất bại !')", true);
                }
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
        try
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
        catch
        {
        }
    }
    //=========================phan xu ly viec insert du lieu mới==================
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {

            ddlTypeBDSs2.DataSource = ctrN.GetCatByType();
            ddlTypeBDSs2.DataTextField = "Name";
            ddlTypeBDSs2.DataValueField = "CategoryID";
            ddlTypeBDSs2.DataBind();
            if (fupload.FileName != "")
            {
                string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\Market");
                strFile += "\\" + fupload.FileName;
               
                var EditImage1 = System.Drawing.Image.FromFile(fupload.PostedFile.FileName);
                VTCO.Library.ImageResize Img2 = new VTCO.Library.ImageResize();
                var newimg1 = Img2.Crop(EditImage1, 500, 300, VTCO.Library.ImageResize.AnchorPosition.Center);
                newimg1.Save(strFile);

                //fupload.PostedFile.SaveAs(strFile);


                int length = fupload.FileName.Length - 4;
                string newname = fupload.FileName.Substring(0, length) + "_thumb";
                string exp = fupload.FileName.Substring(length);
                newname = newname + exp;
                string strFile1 = Path.Combine(Request.PhysicalApplicationPath, "images\\Market");
                strFile1 += "\\" + newname;

                var EditImage = System.Drawing.Image.FromFile(fupload.PostedFile.FileName);
                VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
                var newimg = Img.Crop(EditImage, 120, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
                newimg.Save(strFile1);


                int locationID = GetLocationID(ddlProvince2, ddlDistrict2, ddlVillage2);
                string address = ctrN.GetFullAddressbyLocationID(locationID);
                string str = txtStreet.Text + "-" + address;
                ctrN.InsertMarket(txtTitle.Text, txtDesc.Text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDSs2.SelectedValue), @"/images/Market/" + fupload.FileName, @"/images/Market/" + newname, txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, locationID, str, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked,1);
            }
            else
            {

                int locationID = GetLocationID(ddlProvince2, ddlDistrict2, ddlVillage2);
                string address = ctrN.GetFullAddressbyLocationID(locationID);
                string str = txtStreet.Text + "-" + address;
                ctrN.InsertMarket(txtTitle.Text, txtDesc.Text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDSs2.SelectedValue), @"/images/Market/", @"/images/Market/", txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, locationID, str, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked, chkStatus.Checked,1);
            }
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
        try
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
        catch
        {
        }
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