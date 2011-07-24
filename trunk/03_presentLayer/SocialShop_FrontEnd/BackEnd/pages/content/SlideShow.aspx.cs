using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.IO;
public partial class BackEnd_pages_content_SlideShow : System.Web.UI.Page
{
    CtrSlideShow slide = new CtrSlideShow();
    protected void Page_Load(object sender, EventArgs e)
    {
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
        }
    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
    }
    protected void ucPaging1_PageChange(object sender)
    {

        //var _data = ctrN.GetAllDoc(Int32.Parse(ddlTypeDoc.SelectedValue), ucPaging1.CurrentPage, ucPaging1.PageSize, "n", 2);
        BindRpt(); ;
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
        FileUpload fupload = (FileUpload)RptDetail.Controls[1].FindControl("fupload");
        Image img = (Image)RptDetail.Controls[1].FindControl("Image1");
        HiddenField imgThumb = (HiddenField)RptDetail.Controls[1].FindControl("ImgThumb");
        Label ID = (Label)RptDetail.Controls[1].FindControl("lblID");
        TextBox Title = (TextBox)RptDetail.Controls[1].FindControl("txtDesc");
        CheckBox status = (CheckBox)RptDetail.Controls[1].FindControl("chkstatus");
        if (fupload != null && img != null && ID != null && Title != null && status != null)
        {
            if (fupload.FileName == "")
            {
                try
                {
                    slide.SlideUpdate(Int32.Parse(ID.Text), Title.Text, img.ImageUrl, imgThumb.Value, status.Checked == true ? 1 : 0);
                    BindRpt();
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Update thành công !')", true);
                    Panel1.Visible = false;
                }
                catch
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Update lỗi !')", true);
                }
            }
            else
            {
                try
                {
                    //delete old images 

                    slide.DeleteImg(img.ImageUrl.Replace("/", "\\"), Request);
                    slide.DeleteImg(imgThumb.Value.Replace("/", "\\"), Request);

                    //=======================
                    string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\slideshow");
                    strFile += "\\" + fupload.FileName;
                    //fupload.PostedFile.SaveAs(strFile);
                    // FileUpload1.PostedFile.SaveAs(strFile);

                    var EditImage1 = System.Drawing.Image.FromFile(fupload.PostedFile.FileName);
                    VTCO.Library.ImageResize Img1 = new VTCO.Library.ImageResize();
                    var newimg1 = Img1.Crop(EditImage1, 370, 210, VTCO.Library.ImageResize.AnchorPosition.Center);
                    newimg1.Save(strFile);
                    //create Image Thumb

                    int length = fupload.FileName.Length - 4;
                    string newname = fupload.FileName.Substring(0, length) + "_thumb";
                    string exp = fupload.FileName.Substring(length);
                    newname = newname + exp;
                    string strFile1 = Path.Combine(Request.PhysicalApplicationPath, "images\\slideshow");
                    strFile1 += "\\" + newname;

                    var EditImage = System.Drawing.Image.FromFile(fupload.PostedFile.FileName);
                    VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
                    var newimg = Img.Crop(EditImage, 150, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
                    newimg.Save(strFile1);

                    slide.SlideUpdate(Int32.Parse(ID.Text), Title.Text, @"/images/slideshow/" + fupload.FileName, @"/images/slideshow/" + newname, status.Checked == true ? 1 : 0);
                    BindRpt();
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Update thành công !')", true);
                    Panel1.Visible = false;
                }
                catch
                {
                    ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Update lỗi !')", true);
                }
            }
        }
        //ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('kk')", true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }



    protected void RptSlide_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandName == "Edit")
        {
            Panel1.Visible = true;
            RptDetail.DataSource = slide.GetSlideInfo(Int32.Parse(e.CommandArgument.ToString()));
            RptDetail.DataBind();
        }
        else if (e.CommandName == "Delete")
        {
            try
            {
                HiddenField Img = (HiddenField)e.Item.FindControl("Img");
                HiddenField ImgThumb = (HiddenField)e.Item.FindControl("ImgThumb");
                //delete img
                slide.DeleteImg(Img.Value.Replace("/", "\\"), Request);
                slide.DeleteImg(ImgThumb.Value.Replace("/", "\\"), Request);

                slide.SlideDeleteByID(Int32.Parse(e.CommandArgument.ToString()));
                ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Delete thành công !')", true);
            }
            catch
            {
                ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Delete lổi !')", true);
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
            //up anh
            string strFile = Path.Combine(Request.PhysicalApplicationPath, "images\\slideshow");
            strFile += "\\" + FileUpload1.FileName;
            // FileUpload1.PostedFile.SaveAs(strFile);

            var EditImage1 = System.Drawing.Image.FromFile(FileUpload1.PostedFile.FileName);
            VTCO.Library.ImageResize Img1 = new VTCO.Library.ImageResize();
            var newimg1 = Img1.Crop(EditImage1, 370, 210, VTCO.Library.ImageResize.AnchorPosition.Center);
            newimg1.Save(strFile);
            //create thumb img
            //doi ten file anh

            int length = FileUpload1.FileName.Length - 4;
            string newname = FileUpload1.FileName.Substring(0, length) + "_thumb";
            string exp = FileUpload1.FileName.Substring(length);
            newname = newname + exp;
            string strFile1 = Path.Combine(Request.PhysicalApplicationPath, "images\\slideshow");
            strFile1 += "\\" + newname;

            var EditImage = System.Drawing.Image.FromFile(FileUpload1.PostedFile.FileName);
            VTCO.Library.ImageResize Img = new VTCO.Library.ImageResize();
            var newimg = Img.Crop(EditImage, 150, 100, VTCO.Library.ImageResize.AnchorPosition.Center);
            newimg.Save(strFile1);
            //

            //========
            slide.SlideInsert(txtTitle.Text, @"/images/slideshow/" + FileUpload1.FileName, @"/images/slideshow/" + newname, chkstatus.Checked == true ? 1 : 0);
            BindRpt();
            ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Thêm mới thành công !')", true);
        }
        catch
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Thêm mới lổi !')", true);
        }
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
    }
    protected void lbtDeleteAll_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem item in RptSlide.Items)
            {
                CheckBox chkDeleteAll = (CheckBox)item.FindControl("chkDeleteAll");
                HiddenField slID = (HiddenField)item.FindControl("slID");
                HiddenField Img = (HiddenField)item.FindControl("Img");
                HiddenField ImgThumb = (HiddenField)item.FindControl("ImgThumb");
                if (chkDeleteAll != null && slID != null && Img != null)
                {
                    if (chkDeleteAll.Checked == true)
                    {
                        slide.SlideDeleteByID(Int32.Parse(slID.Value));

                        slide.DeleteImg(Img.Value.Replace("/", "\\"), Request);
                        slide.DeleteImg(ImgThumb.Value.Replace("/", "\\"), Request);
                    }
                }
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "thông báo", "alert('Xóa thành công !')", true);
            BindRpt();
        }
        catch
        {
        }
    }
}