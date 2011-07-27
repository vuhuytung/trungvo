using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.IO;
public partial class userControls_ucAddNewBDS : System.Web.UI.UserControl
{
    CtrLocation Location = new CtrLocation();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
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

            ddlProvince.DataSource = _source;
            ddlProvince.DataTextField = "LocationText";
            ddlProvince.DataValueField = "LocationValue";
            ddlProvince.DataBind();
            ddlProvince.Items.Insert(0, new ListItem("Tỉnh/TP", "-1"));
            ddlProvince.SelectedIndex = 0;


            ddlDistrict.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));

            //add Type BDS temp
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần bán"));
            ddlTypeBDS.Items.Add(new ListItem("Bất động sản cần mua"));
        }
    }
    protected void ddlProvince_SelectedIndexChanged(object sender, EventArgs e)
    {
       
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
            ddlDistrict.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));
            ddlDistrict.SelectedIndex = 0;

            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
        }
        else
        {
            ddlDistrict.Items.Clear();
            ddlDistrict.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));

            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
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
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
            ddlVillage.SelectedIndex = 0;
        }
        else
        {
            ddlVillage.Items.Clear();
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));
        }
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
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        CtrRealtyMarket ctrN = new CtrRealtyMarket();
        try
        {
            if (fupload.FileName != "")
            {
                string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\Market");
                strFile += "\\" + fupload.FileName;
                fupload.PostedFile.SaveAs(strFile);


                int length = fupload.FileName.Length - 4;
                string newname = fupload.FileName.Substring(0, length) + "_thumb";
                string exp = fupload.FileName.Substring(length);
                newname = newname + exp;
                string strFile1 = Path.Combine(Request.PhysicalApplicationPath, "images\\Market");
                strFile1 += "\\" + newname;

                var EditImage = System.Drawing.Image.FromFile(fupload.PostedFile.FileName);
                VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
                var newimg = Img.Crop(EditImage, 150, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
                newimg.Save(strFile1);


                int locationID = GetLocationID(ddlProvince, ddlDistrict, ddlVillage);

                ctrN.InsertMarket(txtTitle.Text, txtDesc.Text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDS.SelectedValue), @"/images/Market/" + fupload.FileName, @"/images/Market/" + newname, txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, locationID, txtStreet.Text, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked,false,0);
            }
            else
            {

                int locationID = GetLocationID(ddlProvince, ddlDistrict, ddlVillage);

                ctrN.InsertMarket(txtTitle.Text, txtDesc.Text, txtUser.Text, txtPhone.Text, txtEmail.Text, Int32.Parse(txtPrice.Text), Int32.Parse(ddlTypeBDS.SelectedValue), @"/images/Market/", @"/images/Market/", txtLegal.Text, txtDientich.Text, txtClientRoom.Text, txtBedRoom.Text, txtBathrooms.Text, txtPosition.Text, txtAddress.Text, txtFloor.Text, locationID, txtStreet.Text, chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, chkUniversity.Checked,false,0);
            }
            Page.RegisterStartupScript("Thông báo", "alert('Thêm mới thành công!')");
        }
        catch
        {
            //ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Insert fail !')", true);
            Page.RegisterStartupScript("Thông báo", "alert('Thêm mới lỗi !')");
        }
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