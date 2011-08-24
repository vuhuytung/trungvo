using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using System.IO;
using System.Web.UI.HtmlControls;
using VTCO.Config;
using DataContext;
public partial class BackEnd_pages_content_Document : System.Web.UI.Page
{
    public int CurrentDocID
    {
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["CurrentDocID"]);
            }
            catch
            {
                return -1;
            }
        }

        set
        {
            ViewState["CurrentDocID"] = value;
        }
    }
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
            rdpFromDate.SelectedDate = DateTime.Now.AddMonths(-12);
            rdpToDate.SelectedDate = DateTime.Now;

            CtrCategory ctrCat = new CtrCategory();
            var tb = ctrCat.GetMenuByType(3);

            ddlTypeDoc.Items.Add(new ListItem("Trang chủ", "0"));
            GetMenuTop(tb, 0, "");
            ddlTypeDoc1.Items.Clear();
            ddlTypeDocEdit.Items.Clear();
            GetMenuNewsAdd(tb, 0, "");
            
            ucPaging1.PageSize = 8;
            ucPaging1.PageDisplay = 5;
            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);
            if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath + "/Resource"))
            {
                System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath + "/Resource");
            }
        }
        lblMsg.Text = "";
    }
    public void GetMenuTop(List<uspCategoryGetMenuByTypeResult> tb, int parentID, string space)
    {
        var rows = tb.Where(x => x.ParentID == parentID);
        foreach (var row in rows)
        {
            ddlTypeDoc.Items.Add(new ListItem(space + ". . . " + row.Name, row.CategoryID.ToString()));
            GetMenuTop(tb, row.CategoryID.Value, space + ". . . ");
        }
    }
    public void GetMenuNewsAdd(List<uspCategoryGetMenuByTypeResult> tb, int parentID, string space)
    {
        var rows = tb.Where(x => x.ParentID == parentID);
        foreach (var row in rows)
        {
            if (row.Type == 3)
            {
                ListItem item = new ListItem(space + " » " + row.Name, row.CategoryID.ToString());
                ddlTypeDoc1.Items.Add(item);
                ddlTypeDocEdit.Items.Add(item);
            }
            GetMenuNewsAdd(tb, row.CategoryID.Value, space + " » " + row.Name);
        }
    }
    protected void ucPaging1_PageChange(object sender)
    {

        if ((!rdpFromDate.SelectedDate.HasValue) || (!rdpToDate.SelectedDate.HasValue))
        {
            lblMsg.Text = "Ngày tháng tìm kiếm không hợp lệ!";
            return;
        }

        if (rdpFromDate.SelectedDate.Value.CompareTo(rdpToDate.SelectedDate.Value) > 0)
        {
            lblMsg.Text = "Ngày tháng tìm kiếm không hợp lệ!";
            return;
        }
        CtrDocument ctrN = new CtrDocument();
        var _data = ctrN.GetAllDoc(txtKeyWord.Text,Int32.Parse(ddlTypeDoc.SelectedValue), rdpFromDate.SelectedDate.Value,rdpToDate.SelectedDate.Value,Convert.ToInt32(ddlStatus.SelectedValue), ucPaging1.CurrentPage, ucPaging1.PageSize);
        RptDocument.DataSource = _data.Items;
        RptDocument.DataBind();
        ucPaging1.TotalRecord = _data.TotalRecord;
        divPaging.Visible = ucPaging1.TotalPage > 1;
    }


    protected void RptDocument_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        if (e.CommandArgument == null) return;
        CtrDocument ctrN = new CtrDocument();
        try
        {
            if (e.CommandName == "lockNews")
            {
                if (ctrN.UpdateDocStatus(Convert.ToInt32(e.CommandArgument), 0) > 0)
                {
                    ucPaging1_PageChange(ucPaging1);
                    lblMsg.Text = "Cập nhật thành công!";
                    ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");

                }
                else
                {
                    lblMsg.Text = "Cập nhật thất bại!";
                    ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
                }
            }

            if (e.CommandName == "unlockNews")
            {
                if (ctrN.UpdateDocStatus(Convert.ToInt32(e.CommandArgument), 1) > 0)
                {
                    ucPaging1_PageChange(ucPaging1);
                    lblMsg.Text = "Cập nhật thành công!";
                    ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");
                }
                else
                {
                    lblMsg.Text = "Cập nhật thất bại!";
                    ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
                }
            }

            if (e.CommandName == "edit")
            {
                CurrentDocID = Convert.ToInt32(e.CommandArgument);
                var info = ctrN.GetInfoDocByID(CurrentDocID);
                txtTitleEdit.Text = info.Title;
                txtDescEdit.Text = HttpUtility.HtmlDecode(info.Description);
                ddlStatusEdit.SelectedValue = info.Status.ToString();
                Panel1.Visible = true;
                Panel2.Visible = false;
                Panel3.Visible = false;
            }
            else if (e.CommandName == "delete")
            {
                var info = ctrN.GetInfoDocByID(Convert.ToInt32(e.CommandArgument));
                if (ctrN.DeleteDocByID(info.DocumentID) > 0)
                {
                    ctrN.DeleteDocument(info.URL, Request);
                    lblMsg.Text = "Xóa thành công!";
                    ucPaging1.CurrentPage = 1;
                    ucPaging1_PageChange(ucPaging1);
                }
            }
        }
        catch { }
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


        if (fuploadEdit.FileName == "")
        {
            string text = HttpUtility.HtmlEncode(txtDescEdit.Text).Replace("\n", "</br>");
            DateTime day = DateTime.Now;
            if (ctrN.UpdateDocByID(CurrentDocID, txtTitleEdit.Text, text, ctrN.GetInfoDocByID(CurrentDocID).URL, day, Convert.ToInt32(ddlTypeDocEdit.SelectedValue), Convert.ToInt32(ddlStatusEdit.SelectedValue)) > 0)
            {
                Panel2.Visible = false;
                Panel3.Visible = true;
                Panel1.Visible = false;
                ucPaging1_PageChange(ucPaging1);
                lblMsg.Text = "Cập nhật thành công!";
            }
            else
            {
                lblMsg.Text = "Cập nhật lỗi!";
            }
        }
        else
        {

            string strFile = Path.Combine(Request.PhysicalApplicationPath, "Resource");
            string fileName = DateTime.Now.ToString("ddMMyyhhmmss") + fuploadEdit.FileName;
            strFile += "\\" + fileName;
            fuploadEdit.PostedFile.SaveAs(strFile);
            string text = HttpUtility.HtmlEncode(txtDescEdit.Text).Replace("\n", "</br>");
            string old = ctrN.GetInfoDocByID(CurrentDocID).URL;
            if (ctrN.UpdateDocByID(CurrentDocID, txtTitleEdit.Text, text, fileName, DateTime.Now, Convert.ToInt32(ddlTypeDocEdit.SelectedValue), Convert.ToInt32(ddlStatusEdit.SelectedValue)) > 0)
            {
                doc.DeleteDocument(old, Request);
                Panel2.Visible = false;
                Panel3.Visible = true;
                Panel1.Visible = false;
                ucPaging1_PageChange(ucPaging1);
                lblMsg.Text = "Cập nhật thành công!";
            }
            else
            {
                lblMsg.Text = "Cập nhật lỗi!";
            }
        }
                
    }
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        CtrDocument ctrN = new CtrDocument();
        try
        {
            string strFile = Path.Combine(Request.PhysicalApplicationPath, "Resource");
            string fileName = DateTime.Now.ToString("ddMMyyhhmmss") + fupload.FileName;
            strFile += "\\" + fileName;
            fupload.PostedFile.SaveAs(strFile);
            if (ctrN.InsertDoc(txtTitle.Text, txtDesc.Text, fileName, DateTime.Now, Int32.Parse(ddlTypeDoc1.SelectedValue), Convert.ToInt32(ddlStatusNew.SelectedValue)) > 0)
            {
                Panel2.Visible = false;
                Panel3.Visible = true;
                Panel1.Visible = false;
                ucPaging1_PageChange(ucPaging1);
                lblMsg.Text = "Thêm mới thành công!";
            }else
                lblMsg.Text = "Thêm mới thất bại!";
        }
        catch
        {
            lblMsg.Text = "Có lỗi xảy ra!";
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
        ucPaging1_PageChange(ucPaging1);
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
                    if (chkDeleteAll.Checked == true)
                    {
                        var info = doc.GetInfoDocByID(Int32.Parse(hdID.Value));
                        if (doc.DeleteDocByID(info.DocumentID) > 0)
                        {
                            doc.DeleteDocument(info.URL, Request);
                        }
                    }
            }
            lblMsg.Text = "Xóa thành công!";
            ucPaging1.CurrentPage = 1;
            ucPaging1_PageChange(ucPaging1);
        }
        catch
        {
            lblMsg.Text = "Có lỗi xảy ra!";
        }
    }

}