using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.IO;
public partial class BackEnd_pages_content_Document : System.Web.UI.Page
{
    CtrDocument doc = new CtrDocument();
    protected int CatID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        //CatID = 21;// Int32.Parse(Request.QueryString["CategoryID"]);
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(ucPaging1_PageChange);
        if (!IsPostBack)
        {
            ucPaging1.PageSize = 8;
            ucPaging1.PageDisplay = 5;
            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);
            
        }
    }
    protected void ucPaging1_PageChange(object sender)
    {
        CtrDocument ctrN = new CtrDocument();
        var _data = ctrN.GetAllDoc(Int32.Parse(ddlTypeDoc.SelectedValue), ucPaging1.CurrentPage, ucPaging1.PageSize,"n",2);
        RptDocument.DataSource = _data.Items;
        RptDocument.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;
    }
    private void BindRpt(string day,int status)
    {
        CtrDocument ctrN = new CtrDocument();
        var _data = ctrN.GetAllDoc(Int32.Parse(ddlTypeDoc.SelectedValue), ucPaging1.CurrentPage, ucPaging1.PageSize, day, status);
        RptDocument.DataSource = _data.Items;
        RptDocument.DataBind();
        //ucPaging1.TotalRecord = _data.TotalRecord;
    }
    protected void RptDocument_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        CtrDocument ctrN = new CtrDocument();
        //Repeater RptDetail = (Repeater)Panel1.Controls[0].FindControl("RptDetail");
        DropDownList ddlTypeDoc = (DropDownList)Panel1.Controls[0].FindControl("ddlTypeDoc");
        try
        {
            if (e.CommandName == "Edit")
            {

                //Repeater RptDetail = (Repeater)Panel1.Controls[0].FindControl("RptDetail");
                //DropDownList ddlTypeDoc = (DropDownList)Panel1.Controls[0].FindControl("ddlTypeDoc");

                if (RptDetail != null && ddlTypeDoc != null)
                {
                    Panel1.Visible = true;
                    RptDetail.DataSource = ctrN.GetInfoDocByID(Int32.Parse(e.CommandArgument.ToString()));
                    RptDetail.DataBind();
                }
            }
            else
                if (e.CommandName == "Detail")
                {
                    Panel1.Visible = true;
                    RptDetail.DataSource = ctrN.GetInfoDocByID(Int32.Parse(e.CommandArgument.ToString()));
                    RptDetail.DataBind();
                    FileUpload fupload = (FileUpload)RptDetail.Controls[1].FindControl("fupload");
                    CheckBox status = (CheckBox)RptDetail.Controls[1].FindControl("chkstatus");
                    Label URL = (Label)RptDetail.Controls[1].FindControl("lblUrl");
                    Label lblTitle = (Label)RptDetail.Controls[1].FindControl("lblTitle");
                    Button btnUpdate = (Button)RptDetail.Controls[1].FindControl("btnUpdate");
                    Button btnhuy = (Button)RptDetail.Controls[1].FindControl("Button1");
                    fupload.Visible = false;
                    status.Enabled = false;
                    URL.Visible = true;
                    btnUpdate.Visible = false;
                    btnhuy.Text = "Thoát";
                    lblTitle.Text = "Chi tiết thông tin";
                }
                else if (e.CommandName == "Delete")
                {
                    ctrN.DeleteDocByID(Int32.Parse(e.CommandArgument.ToString()));
                    ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Delete success');", true);
                }
        }
        finally
        {
            BindRpt("n",Int32.Parse(ddlStatus.SelectedValue));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
       
        CtrDocument ctrN = new CtrDocument();
        FileUpload fupload = (FileUpload)RptDetail.Controls[1].FindControl("fupload");
        TextBox title = (TextBox)RptDetail.Controls[1].FindControl("txtTitle");
        TextBox desc = (TextBox)RptDetail.Controls[1].FindControl("txtDesc");
        CheckBox status = (CheckBox)RptDetail.Controls[1].FindControl("chkstatus");
        Label docID = (Label)RptDetail.Controls[1].FindControl("lblDocID");
        Label URL = (Label)RptDetail.Controls[1].FindControl("lblUrl");
        try
        {
            if (fupload != null && title != null && desc != null & status != null)
            {
                if (fupload.FileName == "")
                {
                    string text = HttpUtility.HtmlEncode(desc.Text).Replace("\n", "</br>");
                    DateTime day=new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day,0,0,0);
                    ctrN.UpdateDocByID(Int32.Parse(docID.Text), title.Text, text, URL.Text, day,21,status.Checked==true?1:0);
                    ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('update success');", true);
                }
            }
        }
        catch
        {
        }
        finally
        {
            Panel1.Visible = false;
        }
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        CtrDocument ctrN = new CtrDocument();
        try
        {
            string strFile = Path.Combine(Request.PhysicalApplicationPath, "Resource");
            strFile += "\\" + fupload.FileName;
            fupload.PostedFile.SaveAs(strFile);
            ctrN.InsertDoc(txtTitle.Text, txtDesc.Text, fupload.FileName, new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0), Int32.Parse(ddlTypeDoc1.SelectedValue), chkstatus.Checked == true ? 1 : 0);
            Panel2.Visible = false;
            ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Insert success');", true);
        }
        catch
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('insert fail');", true);
        }
        finally
        {
            BindRpt("n", Int32.Parse(ddlStatus.SelectedValue));
        }
            
    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        
    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        if (RadDatePicker1.SelectedDate == null)
        {
            BindRpt("n", Int32.Parse(ddlStatus.SelectedValue));
        }
        else
        {
            BindRpt(RadDatePicker1.SelectedDate.ToString(), Int32.Parse(ddlStatus.SelectedValue));
        }

    }

      
}