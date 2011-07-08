using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
public partial class BackEnd_pages_content_Document : System.Web.UI.Page
{
    CtrDocument doc = new CtrDocument();
    protected int CatID = -1;
    protected void Page_Load(object sender, EventArgs e)
    {
        CatID = 21;// Int32.Parse(Request.QueryString["CategoryID"]);
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
        var _data = ctrN.GetListDocByCategory(CatID, ucPaging1.CurrentPage, ucPaging1.PageSize);
        RptDocument.DataSource = _data.Items;
        RptDocument.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;
    }
    protected void RptDocument_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        
        CtrDocument ctrN = new CtrDocument();
        if (e.CommandName == "Edit")
        {
            
            Repeater RptDetail = (Repeater)Panel1.Controls[0].FindControl("RptDetail");
            DropDownList ddlTypeDoc = (DropDownList)Panel1.Controls[0].FindControl("ddlTypeDoc");
            List<NewDocument> list1 = new List<NewDocument>();
            
            if (RptDetail != null && ddlTypeDoc!=null)
            {
                Panel1.Visible = true;

                list1.Add(new NewDocument(Int32.Parse(e.CommandArgument.ToString())));
                RptDetail.DataSource =list1;// ctrN.GetInfoDocByID(Int32.Parse(e.CommandArgument.ToString()));
                RptDetail.DataBind();
               
            }
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {
        CtrDocument ctrN = new CtrDocument();
        Repeater RptDetail = (Repeater)Panel1.Controls[0].FindControl("RptDetail");
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
                    ctrN.UpdateDocByID(Int32.Parse(docID.Text), title.Text, text, URL.Text, 21, 1);
                    
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
    
      
}