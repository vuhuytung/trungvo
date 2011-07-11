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
        RptSlide.DataSource = slide.SlideGetAll();
        RptSlide.DataBind();
    }

    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        FileUpload fupload = (FileUpload)RptDetail.Controls[1].FindControl("fupload");
        Image img = (Image)RptDetail.Controls[1].FindControl("Image1");
        Label ID = (Label)RptDetail.Controls[1].FindControl("lblID");
        TextBox Title = (TextBox)RptDetail.Controls[1].FindControl("txtDesc");
        CheckBox status = (CheckBox)RptDetail.Controls[1].FindControl("chkstatus");
        if (fupload != null && img != null && ID != null && Title != null && status != null)
        {
            if (fupload.FileName == "")
            {
                try
                {
                    slide.SlideUpdate(Int32.Parse(ID.Text), Title.Text, img.ImageUrl, status.Checked == true ? 1 : 0);
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

                    string strFile = Path.Combine(Request.PhysicalApplicationPath, "images");
                    strFile += "\\" + fupload.FileName;
                    fupload.PostedFile.SaveAs(strFile);
                    slide.SlideUpdate(Int32.Parse(ID.Text), Title.Text, @"/images/"+fupload.FileName, status.Checked == true ? 1 : 0);
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
            string strFile = Path.Combine(Request.PhysicalApplicationPath, "images");
            strFile += "\\" + FileUpload1.FileName;
            FileUpload1.PostedFile.SaveAs(strFile);
            slide.SlideInsert(txtTitle.Text,@"/images/"+ FileUpload1.FileName, chkstatus.Checked == true ? 1 : 0);
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
}