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
public partial class BackEnd_pages_content_SlideShow : System.Web.UI.Page
{
    public string SlideShowImg
    {
        get
        {
            try
            {
                return ViewState["SlideShowImg"].ToString();
            }
            catch
            {
                return "";
            }
        }

        set
        {
            ViewState["SlideShowImg"] = value;
        }
    }
    public int SlideShowID
    {
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["SlideShowID"]);
            }
            catch
            {
                return -1;
            }
        }

        set
        {
            ViewState["SlideShowID"] = value;
        }
    }
    CtrSlideShow slide = new CtrSlideShow();
    protected int permission = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(ucPaging1_PageChange);
        if (!IsPostBack)
        {

            ucPaging1.PageSize = 10;
            ucPaging1.PageDisplay = 5;
            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);

            if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/images/slideshow"))
            {
                System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/images/slideshow");
            }
            CtrPartner pn = new CtrPartner();
            pn.DeleteImgTemp(Request);
            if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/images/temp"))
            {
                System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/images/temp");
            }
        }
    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
        Panel3.Visible = false;
    }
    protected void ucPaging1_PageChange(object sender)
    {

        //var _data = ctrN.GetAllDoc(Int32.Parse(ddlTypeDoc.SelectedValue), ucPaging1.CurrentPage, ucPaging1.PageSize, "n", 2);
        BindRpt();
        //ucPaging1.TotalRecord = _data.TotalRecord;
    }
    void BindRpt()
    {
        var _data = slide.GetSlideForPageAll(ucPaging1.CurrentPage, ucPaging1.PageSize);
        RptSlide.DataSource = _data.Items;
        RptSlide.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        
            if (fuploadEdit.FileName == "")
            {
                try
                {
                    if (slide.SlideUpdate(SlideShowID, txtNameEdit.Text.Trim(), SlideShowImg, SlideShowImg + ".thumb", txtWebEdit.Text.Trim(), Convert.ToInt32(ddlStatusEdit.SelectedValue)) > 0)
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
                    string strTemp = Path.Combine(Request.PhysicalApplicationPath, "images\\temp\\" + FileUpload1.FileName);
                    FileUpload1.SaveAs(strTemp);
                    //up anh
                    string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\slideshow");
                    string strFile1 = DateTime.Now.ToString("ddMMyyhhmmss") + Path.GetExtension(fuploadEdit.FileName);
                    strFile += "\\" + strFile1;
                    // FileUpload1.PostedFile.SaveAs(strFile);

                    var EditImage1 = System.Drawing.Image.FromFile(strTemp);
                    VTCO.Library.ImageResize Img1 = new VTCO.Library.ImageResize();
                    var newimg1 = Img1.Crop(EditImage1, 370, 210, VTCO.Library.ImageResize.AnchorPosition.Center);
                    newimg1.Save(strFile);
                    //create thumb img
                    //doi ten file anh

                    string strFile2 = Path.Combine(Request.PhysicalApplicationPath, "images\\slideshow") + "\\" + strFile1 + ".thumb";

                    var EditImage = System.Drawing.Image.FromFile(strTemp);
                    VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
                    var newimg = Img.Crop(EditImage, 150, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
                    newimg.Save(strFile2);

                    if (slide.SlideUpdate(SlideShowID, txtNameEdit.Text.Trim(), @"/images/slideshow/" + strFile1, @"/images/slideshow/" + strFile1+".thumb", txtWebEdit.Text.Trim(), Convert.ToInt32(ddlStatusEdit.SelectedValue)) > 0)
                    {
                        slide.DeleteImg(SlideShowImg,Request);
                        BindRpt();
                        lblMsg.Text = "Cập nhật thành công !";
                        Panel1.Visible = false;
                        Panel2.Visible = false;
                        Panel3.Visible = true;
                    }
                    else
                        lblMsg.Text = "Cập nhật bị lỗi !";
                    CtrPartner pat = new CtrPartner();
                    pat.DeleteImgTemp(Request);
                }
                catch
                {
                    lblMsg.Text = "Cập nhật bị lỗi !";
                }
            }
    }
    protected void btnHuy1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel3.Visible = true;
        Panel2.Visible = false;
    }

    protected void RptSlide_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            //(e.Item.FindControl("spSTT") as HtmlGenericControl).InnerText = (e.Item.ItemIndex + 1).ToString();

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

    protected void RptSlide_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
            Panel3.Visible = false;
            SlideShowID = Int32.Parse(e.CommandArgument.ToString());
            var pat = slide.GetSlideInfo(SlideShowID);
            SlideShowImg = pat.Img;
            txtNameEdit.Text = pat.Title;
            txtWebEdit.Text = pat.Url;
            try { ddlStatusEdit.SelectedValue = pat.Status.ToString(); }
            catch { ddlStatusEdit.SelectedValue = "0"; }
            lblMsg.Text = "";
        }
        else if (e.CommandName == "Delete")
        {
            try
            {
                SlideShowID = Int32.Parse(e.CommandArgument.ToString());
                var pat = slide.GetSlideInfo(SlideShowID);
                SlideShowImg = pat.Img;

                slide.DeleteImg(SlideShowImg.Replace("/", "\\"), Request);

                if (slide.SlideDeleteByID(Int32.Parse(e.CommandArgument.ToString())) > 0)
                {
                    slide.DeleteImg(SlideShowImg.Replace("/", "\\"), Request);
                    slide.DeleteImg(SlideShowImg.Replace("/", "\\")+".thumb", Request);
                    lblMsg.Text = "Xóa thành công!";
                }
                else
                {
                    lblMsg.Text = "Xóa bị lỗi!";
                }
            }
            catch
            {
                lblMsg.Text = "Có lỗi xảy ra!";
            }
            finally
            {
                BindRpt();
            }


        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {
            //luu anh vo temp
            string strTemp = Path.Combine(Request.PhysicalApplicationPath, "images\\temp\\" + FileUpload1.FileName);
            FileUpload1.SaveAs(strTemp);
            //up anh
            string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\slideshow");
            string strFile1 = DateTime.Now.ToString("ddMMyyhhmmss") + Path.GetExtension(fuploadEdit.FileName);
            strFile += "\\" + strFile1;
            // FileUpload1.PostedFile.SaveAs(strFile);

            var EditImage1 = System.Drawing.Image.FromFile(strTemp);
            VTCO.Library.ImageResize Img1 = new VTCO.Library.ImageResize();
            var newimg1 = Img1.Crop(EditImage1, 370, 210, VTCO.Library.ImageResize.AnchorPosition.Center);
            newimg1.Save(strFile);
            //create thumb img
            //doi ten file anh

            string strFile2 = Path.Combine(Request.PhysicalApplicationPath, "images\\slideshow") + "\\" + strFile1 + ".thumb";

            var EditImage = System.Drawing.Image.FromFile(strTemp);
            VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
            var newimg = Img.Crop(EditImage, 150, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
            newimg.Save(strFile2);
            //

            //========
            if (slide.SlideInsert(txtName.Text, @"/images/slideshow/" + strFile1, @"/images/slideshow/" + strFile1 + ".thumb",txtWeb.Text.Trim(), Convert.ToInt32(ddlStatus.SelectedValue)) > 0)
            {
                BindRpt();
                Panel1.Visible = false;
                Panel2.Visible = false;
                Panel3.Visible = true;
            }
            else
                lblMsg.Text = "Thêm mới thất bại";
            CtrPartner ctrP = new CtrPartner();
            ctrP.DeleteImgTemp(Request);
        }
        catch
        {
            lblMsg.Text = "Có lỗi xảy ra!";
        }
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel1.Visible = false;
        Panel3.Visible = true;
    }    
}