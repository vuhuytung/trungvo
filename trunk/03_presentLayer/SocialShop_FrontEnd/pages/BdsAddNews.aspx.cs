using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.IO;
public partial class pages_Bds_AddNews : System.Web.UI.Page
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
            ddlProvince.Items.Insert(0, new ListItem("Tỉnh/TP", "-1"));
            ddlProvince.SelectedIndex = 0;


            ddlDistrict.Items.Insert(0, new ListItem("Quận/Huyện", "-1"));
            ddlVillage.Items.Insert(0, new ListItem("Phường/Xã", "-1"));

            //add Type BDS temp
            ddlTypeBDS.DataSource = market.GetCatByType();
            ddlTypeBDS.DataTextField = "Name";
            ddlTypeBDS.DataValueField = "CategoryID";
            ddlTypeBDS.DataBind();


            for (int i = 0; i <= 20; i++)
            {
                ddlBathrooms.Items.Add(new ListItem(i.ToString(),i.ToString()));
                ddlBedRoom.Items.Add(new ListItem(i.ToString(),i.ToString()));
                ddlClientRoom.Items.Add(new ListItem(i.ToString(),i.ToString()));
                if(i<=10)
                    ddlFloor.Items.Add(new ListItem(i.ToString(),i.ToString()));                
            }

            if (!Convert.ToBoolean(Session[VTCO.Config.Constants.SESSION_USER_ISLOGIN] ?? false))
            {
                Response.Redirect("/login");
            }
            else
            {
                CtrUser us = new CtrUser();
                var m_UI=us.UserGetInfo(Convert.ToInt32(Session[VTCO.Config.Constants.SESSION_USER_ID] ?? -1));
                if (m_UI != null)
                {
                    txtUser.Text = m_UI.FullName;
                    txtEmail.Text = m_UI.Email;
                    txtPhone.Text = m_UI.Phone;
                    txtAddress.Text = m_UI.Address;
                }
            }

        }
        if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/images/Market"))
        {
            System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/images/Market");
        }
        if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/images/temp"))
        {
            System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/images/temp");
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
            int index = Int32.Parse(ddlDistrict.SelectedValue);
            var _data = Location.GetVillage(index);
            ddlVillage.DataSource = _data;
            ddlVillage.DataTextField = "Name";
            ddlVillage.DataValueField = "LocationID";
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

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        CtrRealtyMarket ctrN = new CtrRealtyMarket();
        try
        {            
            if (!Convert.ToBoolean(Session[VTCO.Config.Constants.SESSION_USER_ID] ?? false))
                Response.Redirect("/login");
            int locationID = Location.getLocationIDByCode(Convert.ToInt32(ddlProvince.SelectedValue),Convert.ToInt32(ddlDistrict.SelectedValue),Convert.ToInt32(ddlVillage.SelectedValue));
            var userID = Convert.ToInt32(Session[VTCO.Config.Constants.SESSION_USER_ID]);
            long price = 0;
            
            try
            {
                price = Int64.Parse(txtPrice.Text.Trim());
            }
            catch { price = 0; }
            int dientich=0;
            try
            {
                dientich = Int32.Parse(txtDientich.Text.Trim());
            }
            catch { dientich = 0; }
             
            if (fupload.FileName != "")
            {
                //luu anh vo temp                
                string fileName = DateTime.Now.ToString("ddMMyyhhmmss") + fupload.FileName;
                string strTemp = Path.Combine(Request.PhysicalApplicationPath, "images\\temp\\" + fupload.FileName);
                fupload.SaveAs(strTemp);

                string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\Market");
                strFile += "\\" + fileName;
                var EditImage1 = System.Drawing.Image.FromFile(strTemp);
                VTCO.Library.ImageResize Img2 = new VTCO.Library.ImageResize();
                var newimg1 = Img2.Crop(EditImage1, 500, 300, VTCO.Library.ImageResize.AnchorPosition.Center);
                newimg1.Save(strFile);
                //fupload.PostedFile.SaveAs(strFile);

                string newname = fileName + ".thumb";                                
                string strFile1 = Path.Combine(Request.PhysicalApplicationPath, "images\\Market");
                strFile1 += "\\" + newname;

                var EditImage = System.Drawing.Image.FromFile(strTemp);
                VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
                var newimg = Img.Crop(EditImage, 150, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
                newimg.Save(strFile1);
                CtrPartner pth = new CtrPartner();
                pth.DeleteImgTemp(Request);
                
                
                if(
                ctrN.Insert(txtTitle.Text.Trim(),HttpUtility.HtmlEncode(txtDesc.Text.Trim()), @"/images/market/" + fileName, HttpUtility.HtmlEncode(txtUser.Text.Trim()), HttpUtility.HtmlEncode(txtPhone.Text.Trim()),
                    HttpUtility.HtmlEncode(txtEmail.Text.Trim()), HttpUtility.HtmlEncode(txtAddress.Text.Trim()), price * Convert.ToInt32(ddlDonVi.SelectedValue),
                    Int32.Parse(ddlTypeBDS.SelectedValue), HttpUtility.HtmlEncode(txtLegal.Text.Trim()), dientich, Int32.Parse(ddlClientRoom.SelectedValue), Int32.Parse(ddlBedRoom.SelectedValue), 
                    Int32.Parse(ddlBathrooms.SelectedValue), HttpUtility.HtmlEncode(txtPosition.Text.Trim()), Int32.Parse(ddlFloor.SelectedValue), chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked, 
                    chkUniversity.Checked,locationID,HttpUtility.HtmlEncode(txtStreet.Text.Trim()), 0,userID)>0)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Thêm mới thành công! Chúng tôi sẽ kiểm duyệt trước khi đưa lên trang!'); window.location='/myrealtymarket';", true);
                }
            }
            else
            {
                if (
                 ctrN.Insert(txtTitle.Text.Trim(), HttpUtility.HtmlEncode(txtDesc.Text.Trim()), "", HttpUtility.HtmlEncode(txtUser.Text.Trim()), HttpUtility.HtmlEncode(txtPhone.Text.Trim()),
                    HttpUtility.HtmlEncode(txtEmail.Text.Trim()), HttpUtility.HtmlEncode(txtAddress.Text.Trim()), price * Convert.ToInt32(ddlDonVi.SelectedValue),
                    Int32.Parse(ddlTypeBDS.SelectedValue), HttpUtility.HtmlEncode(txtLegal.Text.Trim()), dientich, Int32.Parse(ddlClientRoom.SelectedValue), Int32.Parse(ddlBedRoom.SelectedValue),
                    Int32.Parse(ddlBathrooms.SelectedValue), HttpUtility.HtmlEncode(txtPosition.Text.Trim()), Int32.Parse(ddlFloor.SelectedValue), chkMaugiao.Checked, chkHospital.Checked, chkschool.Checked, chkMarket.Checked,
                    chkUniversity.Checked, locationID, HttpUtility.HtmlEncode(txtStreet.Text.Trim()), 0, userID) > 0)
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Thêm mới thành công! Chúng tôi sẽ kiểm duyệt trước khi đưa lên trang!'); window.location='/myrealtymarket';", true);
                }
            }
            
        }
        catch
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "Thông báo", "alert('Thêm mới lỗi !')", true);
        }
    }
}