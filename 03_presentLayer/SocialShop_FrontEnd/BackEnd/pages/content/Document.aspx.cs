﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.IO;
using System.Web.UI.HtmlControls;
using VTCO.Config;
public partial class BackEnd_pages_content_Document : System.Web.UI.Page
{
    CtrDocument doc = new CtrDocument();
    protected int CatID = -1;
    protected int permission = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        //CatID = 21;// Int32.Parse(Request.QueryString["CategoryID"]);
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(ucPaging1_PageChange);
        if (!IsPostBack)
        {
            ucPaging1.PageSize = 8;
            ucPaging1.PageDisplay = 5;
            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);
            if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/Resource"))
            {
                System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/Resource");
            }
        }
    }
    protected void ucPaging1_PageChange(object sender)
    {
        CtrDocument ctrN = new CtrDocument();
        var _data = ctrN.GetAllDoc(Int32.Parse(ddlTypeDoc.SelectedValue), ucPaging1.CurrentPage, ucPaging1.PageSize, "n", 2);
        RptDocument.DataSource = _data.Items;
        RptDocument.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;
        divPaging.Visible = ucPaging1.TotalPage > 1;
    }
    private void BindRpt(string day, int status)
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
            if (e.CommandName == "lockNews")
            {
                if (ctrN.UpdateDocStatus(Convert.ToInt32(e.CommandArgument), 0) > 0)
                {
                    ucPaging1_PageChange(ucPaging1);
                    lblMsg.Text = "Cập nhật thành công";
                    ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");

                }
                else
                {
                    lblMsg.Text = "Cập nhật thất bại";
                    ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
                }
            }

            if (e.CommandName == "unlockNews")
            {
                if (ctrN.UpdateDocStatus(Convert.ToInt32(e.CommandArgument), 1) > 0)
                {
                    ucPaging1_PageChange(ucPaging1);
                    lblMsg.Text = "Cập nhật thành công";
                    ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");
                }
                else
                {
                    lblMsg.Text = "Cập nhật thất bại";
                    ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
                }
            }

            if (e.CommandName == "edit")
            {

                //Repeater RptDetail = (Repeater)Panel1.Controls[0].FindControl("RptDetail");
                //DropDownList ddlTypeDoc = (DropDownList)Panel1.Controls[0].FindControl("ddlTypeDoc");
                if (RptDetail != null && ddlTypeDoc != null)
                {
                    Panel1.Visible = true;
                    Panel2.Visible = false;
                    Panel3.Visible = false;
                    RptDetail.DataSource = ctrN.GetInfoDocByID(Int32.Parse(e.CommandArgument.ToString()));
                    RptDetail.DataBind();
                }
            }
            else if (e.CommandName == "delete")
            {
                Label URL = (Label)RptDetail.Controls[1].FindControl("lblUrl");
                ctrN.DeleteDocByID(Int32.Parse(e.CommandArgument.ToString()));
                ctrN.DeleteDocument(URL.Text, Request);
                ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Xóa thành công');", true);
            }
        }
        finally
        {
            BindRpt("n", Int32.Parse(ddlStatus.SelectedValue));
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel3.Visible = true;
        Panel2.Visible = false;
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
                    DateTime day = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    ctrN.UpdateDocByID(Int32.Parse(docID.Text), title.Text, text, URL.Text, day, 21, status.Checked == true ? 1 : 0);
                    ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('cập nhật thành công !');", true);
                }
                else
                {

                    string strFile = Path.Combine(Request.PhysicalApplicationPath, "Resource");
                    strFile += "\\" + fupload.FileName;
                    fupload.PostedFile.SaveAs(strFile);
                    string text = HttpUtility.HtmlEncode(desc.Text).Replace("\n", "</br>");
                    DateTime day = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                    ctrN.UpdateDocByID(Int32.Parse(docID.Text), title.Text, text, fupload.FileName, day, 21, status.Checked == true ? 1 : 0);
                    ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Cập nhật thành công !');", true);
                }
            }
        }
        catch
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Cập nhật lỗi !');", true);
        }
        finally
        {
            if (RadDatePicker1.SelectedDate == null)
            {
                BindRpt("n", Int32.Parse(ddlStatus.SelectedValue));
            }
            else
            {
                BindRpt(RadDatePicker1.SelectedDate.ToString(), Int32.Parse(ddlStatus.SelectedValue));
            }
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
            ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Thêm mới thành công !');", true);
        }
        catch
        {
            ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('thêm mới lỗi !');", true);
        }
        finally
        {
            BindRpt("n", Int32.Parse(ddlStatus.SelectedValue));
        }

    }
    protected void btnThemmoi_Click(object sender, EventArgs e)
    {
        Panel2.Visible = true;
        Panel1.Visible = false;
        Panel3.Visible = false;

    }
    protected void btnHuy_Click(object sender, EventArgs e)
    {
        Panel2.Visible = false;
        Panel3.Visible = true;
        Panel1.Visible = false;
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        try
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
        catch
        {
        }
    }
    protected void RptDocument_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        try
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlTableRow listRow = e.Item.FindControl("listRow") as HtmlTableRow;
                if (listRow == null)
                    return;
                if (e.Item.ItemIndex % 2 == 0)
                {
                    listRow.Attributes["class"] = "adminListRow-even";
                }
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
        catch
        {
        }
    }
    protected void lbtDeleteAll_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (RepeaterItem item in RptDocument.Items)
            {
                CheckBox chkDeleteAll = (CheckBox)item.FindControl("chkDeleteAll");
                HiddenField hdID = (HiddenField)item.FindControl("hdID");
                HiddenField hdFile = (HiddenField)item.FindControl("hdFile");
                if (chkDeleteAll != null && hdID != null)
                {
                    if (chkDeleteAll.Checked == true)
                    {
                        doc.DeleteDocByID(Int32.Parse(hdID.Value));
                        doc.DeleteDocument(hdFile.Value, Request);
                    }

                }
            }
            if (RadDatePicker1.SelectedDate == null)
            {
                BindRpt("n", Int32.Parse(ddlStatus.SelectedValue));
            }
            else
            {
                BindRpt(RadDatePicker1.SelectedDate.ToString(), Int32.Parse(ddlStatus.SelectedValue));
            }
            ClientScript.RegisterStartupScript(Page.GetType(), "thongbao", "alert('Xóa thành công !');", true);

        }
        catch
        {
        }
    }

}