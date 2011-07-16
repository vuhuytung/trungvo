using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
public partial class BackEnd_pages_content_Partners : System.Web.UI.Page
{
    CtrPartner partner = new CtrPartner();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindRpt();
        }
    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
    }
    void BindRpt()
    {
        RptPartner.DataSource = partner.GetListPartner();
        RptPartner.DataBind();
    }
    protected void RptPartner_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Panel1.Visible = true;
            RptDetail.DataSource = partner.GetInfoByID(Int32.Parse(e.CommandArgument.ToString()));
            RptDetail.DataBind();
        }
        else if (e.CommandName == "Delete")
        {
            try
            {
                HiddenField img = (HiddenField)e.Item.FindControl("hdImg");
                partner.DeletePartner(Int32.Parse(e.CommandArgument.ToString()));
                partner.DeleteImg(img.Value.Replace("/","\\"), Request);
                ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Xóa thành công !')", true);
                BindRpt();
            }
            catch
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Xóa thất bại !')", true);
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        FileUpload fupload = (FileUpload)RptDetail.Controls[1].FindControl("fupload");
        Label img = (Label)RptDetail.Controls[1].FindControl("lblImg");
        Label ID = (Label)RptDetail.Controls[1].FindControl("lblID");
        TextBox Name = (TextBox)RptDetail.Controls[1].FindControl("txtName");
        TextBox web = (TextBox)RptDetail.Controls[1].FindControl("txtWeb");
        CheckBox status = (CheckBox)RptDetail.Controls[1].FindControl("chkstatus");

        if (fupload != null && img != null && ID != null && Name != null && web != null && status != null)
        {
            if (fupload.FileName == "")
            {
                try
                {
                    partner.UpdatePartner(Int32.Parse(ID.Text), Name.Text, img.Text, web.Text, status.Checked);
                    BindRpt();
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Cập nhật thành công !')", true);
                }
                catch
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Cập nhật lỗi !')", true);
                }
            }
            else
            {
                try
                {

                    string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\partner");
                    strFile += "\\" + fuploadLogo.FileName;
                    var EditImage = System.Drawing.Image.FromFile(fuploadLogo.PostedFile.FileName);
                    VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
                    var newimg = Img.Crop(EditImage, 150, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
                    newimg.Save(strFile);

                    partner.UpdatePartner(Int32.Parse(ID.Text), Name.Text, @"/images/partner/" + fupload.FileName, web.Text, status.Checked);
                    partner.DeleteImg(img.Text, Request);
                    BindRpt();
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Cập nhật thành công !')", true);
                }
                catch
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Cập nhật lỗi !')", true);
                }
            }
        }
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuploadLogo.FileName == "")
            {
                partner.InsertPartner(txtName.Text, "#", txtWeb.Text, chkstatus.Checked);
                ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Thêm mới thành công !')", true);
                BindRpt();
            }
            else
            {
                try
                {
                    string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\partner");
                    strFile += "\\" + fuploadLogo.FileName;
                    var EditImage = System.Drawing.Image.FromFile(fuploadLogo.PostedFile.FileName);
                    VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
                    var newimg = Img.Crop(EditImage, 150, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
                    newimg.Save(strFile);
                    //fuploadLogo.PostedFile.SaveAs(strFile);


                    partner.InsertPartner(txtName.Text, @"/images/partner/" + fuploadLogo.FileName, txtWeb.Text, chkstatus.Checked);
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Thêm mới thành công !')", true);
                    BindRpt();
                }
                catch
                {
                }
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Thêm mới lỗi !')", true);
        }
    }
    protected void btnHuy1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
    }
            
}