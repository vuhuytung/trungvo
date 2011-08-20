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
using VTCO.Config;
using System.Web.UI.HtmlControls;
public partial class BackEnd_pages_content_Partners : System.Web.UI.Page
{
    public int PartnersID
    {
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["PartnersID"]);
            }
            catch
            {
                return -1;
            }
        }

        set
        {
            ViewState["PartnersID"] = value;
        }
    }
    public string PartnersImg
    {
        get
        {
            try
            {
                return ViewState["PartnersImg"].ToString();
            }
            catch
            {
                return "";
            }
        }

        set
        {
            ViewState["PartnersImg"] = value;
        }
    }
    CtrPartner partner = new CtrPartner();
    protected int permission = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        if (!IsPostBack)
        {
            BindRpt();

            if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/images/partner"))
            {
                System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/images/partner");
            }
            partner.DeleteImgTemp(Request);
            if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/images/temp"))
            {
                System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/images/temp");
            }
        }
        lblMsg.Text = "";
    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
        Panel3.Visible = false;
        txtName.Text = "";
        txtWeb.Text = "";
        ddlStatus.SelectedValue = "1";
    }
    void BindRpt()
    {
        RptPartner.DataSource = partner.GetListPartner();
        RptPartner.DataBind();
    }
    protected void RptPartner_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            (e.Item.FindControl("spSTT") as HtmlGenericControl).InnerText = (e.Item.ItemIndex + 1).ToString();

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
    protected void RptPartner_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            PartnersID = Int32.Parse(e.CommandArgument.ToString());
            var pat = partner.GetInfoByID(PartnersID);
            PartnersImg = pat.Img;
            txtNameEdit.Text = pat.Name;
            txtWebEdit.Text = pat.Website;
            try { ddlStatusEdit.SelectedValue = pat.Status.Value ? "1" : "0"; }
            catch { ddlStatusEdit.SelectedValue = "0"; }
            lblMsg.Text = "";
        }
        else if (e.CommandName == "delete")
        {
            try
            {
                PartnersID = Int32.Parse(e.CommandArgument.ToString());
                var pat = partner.GetInfoByID(PartnersID);
                PartnersImg = pat.Img;
                if (partner.DeletePartner(PartnersID) > 0)
                {
                    partner.DeleteImg(PartnersImg.Replace("/", "\\"), Request);
                    lblMsg.Text = "Xóa thành công !";
                    BindRpt();
                }
                else
                    lblMsg.Text = "Xóa thất bại!";
            }
            catch
            {
                lblMsg.Text = "Xóa thất bại!";
            }
        }
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuploadEdit.FileName == "")
            {
                try
                {
                    if (partner.UpdatePartner(PartnersID, txtNameEdit.Text, PartnersImg, txtWebEdit.Text, ddlStatusEdit.SelectedValue == "1" ? true : false) > 0)
                    {
                        BindRpt();
                        lblMsg.Text = "Cập nhật thành công !";
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = true;
                    }
                    else
                        lblMsg.Text = "Cập nhật bị lỗi !";
                }
                catch
                {
                    lblMsg.Text = "Cập nhật bị lỗi !";
                }
            }
            else
            {
                try
                {
                    //luu anh vo temp
                    string strTemp = Path.Combine(Request.PhysicalApplicationPath, "images\\temp\\" + fuploadEdit.FileName);
                    fuploadEdit.SaveAs(strTemp);

                    string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\partner");
                    string strFile1 = DateTime.Now.ToString("ddMMyyhhmmss") + Path.GetExtension(fuploadEdit.FileName);
                    strFile += "\\" + strFile1;
                    //lay anh tu temp de cat va save vo partner
                    var EditImage = System.Drawing.Image.FromFile(strTemp);
                    VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
                    var newimg = Img.Crop(EditImage, 150, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
                    newimg.Save(strFile);

                    if (partner.UpdatePartner(PartnersID, txtNameEdit.Text, @"/images/partner/" + strFile1, txtWebEdit.Text.Trim(), ddlStatusEdit.SelectedValue == "1" ? true : false) > 0)
                    {
                        partner.DeleteImg(PartnersImg, Request);
                        BindRpt();
                        lblMsg.Text = "Cập nhật thành công !";
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = true;
                    }
                    else
                        lblMsg.Text = "Cập nhật bị lỗi !";
                }
                catch
                {
                    lblMsg.Text = "Cập nhật bị lỗi !";
                }
                finally
                {
                    //xoa anh trong temp
                    partner.DeleteImgTemp(Request);
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
        Panel2.Visible = false;
        Panel3.Visible = true;
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            if (fuploadLogo.FileName == "")
            {
                if (partner.InsertPartner(txtName.Text, "#", txtWeb.Text, ddlStatus.SelectedValue == "1" ? true : false) > 0)
                {
                    lblMsg.Text = "Thêm mới thành công";
                    BindRpt();
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                    Panel3.Visible = true;
                }
                else
                    lblMsg.Text = "Thêm mới thất bại";
            }
            else
            {
                try
                {
                    string strTemp = Path.Combine(Request.PhysicalApplicationPath, "images\\temp\\" + fuploadLogo.FileName);
                    fuploadLogo.SaveAs(strTemp);

                    string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\partner");
                    string strFile1 = DateTime.Now.ToString("ddMMyyhhmmss") + Path.GetExtension(fuploadEdit.FileName);
                    strFile += "\\" + strFile1;
                    var EditImage = System.Drawing.Image.FromFile(strTemp);
                    VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
                    var newimg = Img.Crop(EditImage, 150, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
                    newimg.Save(strFile);
                    //fuploadLogo.PostedFile.SaveAs(strFile);


                    if (partner.InsertPartner(txtName.Text, @"/images/partner/" + strFile1, txtWeb.Text.Trim(), ddlStatus.SelectedValue == "1" ? true : false) > 0)
                    {
                        lblMsg.Text = "Thêm mới thành công";
                        BindRpt();
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = true;
                    }
                    else
                        lblMsg.Text = "Thêm mới thất bại";
                    //xoa file trong temp
                    partner.DeleteImgTemp(Request);

                }
                catch (Exception ex)
                {
                    lblMsg.Text = "Thêm mới thất bại";
                }
            }
        }
        catch
        {
            lblMsg.Text = "Thêm mới thất bại";
        }
    }
    protected void btnHuy1_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = false;
        Panel3.Visible = true;
    }

}