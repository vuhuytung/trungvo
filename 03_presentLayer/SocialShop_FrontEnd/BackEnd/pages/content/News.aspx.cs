﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WorkFlowBLL;
using DataContext;
using System.Web.UI.HtmlControls;
using VTCO.Library;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using VTCO.Config;

public partial class BackEnd_pages_content_News : System.Web.UI.Page
{
    public int CurrentNewsID
    {
        get
        {
            try
            {
                return Convert.ToInt32(ViewState["CurrentNewsID"]);
            }
            catch
            {
                return -1;
            }
        }

        set
        {
            ViewState["CurrentNewsID"] = value;
        }
    }
    private bool isNew
    {
        get
        {
            try
            {
                return Convert.ToBoolean(ViewState["isNew"]);
            }
            catch
            {
                return false;
            }
        }

        set
        {
            ViewState["isNew"] = value;
        }
    }
    protected int permission = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(pageChange);
        if (!IsPostBack)
        {

            lbtAddNew.Visible = ((permission & VTCO.Config.Constants.PERMISSION_ADD) == VTCO.Config.Constants.PERMISSION_ADD);

            rdpFromDate.SelectedDate = DateTime.Now.AddMonths(-12);
            rdpToDate.SelectedDate = DateTime.Now;

            CtrCategory ctrCat = new CtrCategory();
            var tb = ctrCat.GetNewsMenu();

            ddlCategory.Items.Add(new ListItem("Trang chủ", "0"));
            GetMenuTop(tb, 0, "");
            ddlNewsMenu.Items.Clear();
            GetMenuNewsAdd(tb, 0, "");

            ucPaging1.PageSize = 15;
            ucPaging1.CurrentPage = 1;
            ucPaging1.PageDisplay = 10;
            pageChange(ucPaging1);
            LoadPanel(1);

            if (!System.IO.Directory.Exists(Request.PhysicalApplicationPath+"/images/news/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString()))
            {
                System.IO.Directory.CreateDirectory(Request.PhysicalApplicationPath+"/images/news/" + DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString());
            }
        }
        lblMsg.Text = "";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="panel">
    /// 1: Danh sách
    /// 2: Xem
    /// 3: Chi tiết
    /// </param>
    private void LoadPanel(int panel)
    {

        pnlManager.Visible = (panel == 1);
        pnlView.Visible = (panel == 2);
        pnlDetail.Visible = (panel == 3);
    }

    public void GetMenuTop(List<uspCategoryGetNewsMenuResult> tb, int parentID, string space)
    {
        var rows = tb.Where(x => x.ParentID == parentID);
        foreach (var row in rows)
        {
            ddlCategory.Items.Add(new ListItem(space + ". . . " + row.Name, row.CategoryID.ToString()));
            GetMenuTop(tb, row.CategoryID.Value, space + ". . . ");
        }
    }
    public void GetMenuNewsAdd(List<uspCategoryGetNewsMenuResult> tb, int parentID, string space)
    {
        var rows = tb.Where(x => x.ParentID == parentID);
        foreach (var row in rows)
        {
            if (row.Type == 2)
            {                
                ListItem item = new ListItem(space + " » " + row.Name, row.CategoryID.ToString());
                ddlNewsMenu.Items.Add(item);
            }
            GetMenuNewsAdd(tb, row.CategoryID.Value, space + " » " + row.Name);
        }
    }

    protected void pageChange(object sender)
    {        
        if ((!rdpFromDate.SelectedDate.HasValue) || (!rdpToDate.SelectedDate.HasValue))
        {
            lblMsg.Text = "Ngày tháng tìm kiếm không hợp lệ!";
            return;
        }

        if (rdpFromDate.SelectedDate.Value.CompareTo(rdpToDate.SelectedDate.Value)>0)
        {
            lblMsg.Text = "Ngày tháng tìm kiếm không hợp lệ!";
            return;
        }

        CtrNews ctrNews = new CtrNews();
        var list = ctrNews.GetListForAdmin(Convert.ToInt32(ddlCategory.SelectedValue),txtKeyword.Text,rdpFromDate.SelectedDate.Value, rdpToDate.SelectedDate.Value, Convert.ToInt32(ddlStatus.SelectedValue),Convert.ToInt32(ddlIsHot.SelectedValue),ucPaging1.CurrentPage, ucPaging1.PageSize);

        ucPaging1.TotalRecord = list.TotalRecord;
        divPaging.Visible = ucPaging1.TotalPage > 1;

        rptAllNews.DataSource = list.Items;
        rptAllNews.DataBind();
        if (list.TotalRecord > 0)
        {
            rptAllNews.Visible = true;
            pNoRow.Visible = false;
        }
        else
        {
            rptAllNews.Visible = false;
            pNoRow.Visible = true;
        }
    }
    protected void rptAllNews_ItemDataBound(object sender, RepeaterItemEventArgs e)
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

            if (Convert.ToBoolean(DataBinder.Eval(e.Item.DataItem, "IsHot")))
            {
                if ((permission & VTCO.Config.Constants.PERMISSION_EDIT) == VTCO.Config.Constants.PERMISSION_EDIT)
                    (e.Item.FindControl("lbtHot") as LinkButton).Visible = false;
            }
            else
            {
                if ((permission & VTCO.Config.Constants.PERMISSION_EDIT) == VTCO.Config.Constants.PERMISSION_EDIT)
                    (e.Item.FindControl("lbtUnHot") as LinkButton).Visible = false;
            }
        }

    }
    protected void rptAllNews_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        CtrNews ctrNews = new CtrNews();
        if (e.CommandArgument == null) return;
        if (e.CommandName == "lockNews")
        {
            if (ctrNews.UpdateStatus(Convert.ToInt32(e.CommandArgument), false) > 0)
            {
                pageChange(ucPaging1);
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
            if (ctrNews.UpdateStatus(Convert.ToInt32(e.CommandArgument), true) > 0)
            {
                pageChange(ucPaging1);
                lblMsg.Text = "Cập nhật thành công";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");
            }
            else
            {
                lblMsg.Text = "Cập nhật thất bại";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
            }
        }

        if (e.CommandName == "unhotNews")
        {
            if (ctrNews.UpdateHot(Convert.ToInt32(e.CommandArgument), false) > 0)
            {
                ucPaging1.CurrentPage = 1;
                pageChange(ucPaging1);
                lblMsg.Text = "Cập nhật thành công";
                //RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");

            }
            else
            {
                lblMsg.Text = "Cập nhật thất bại";
                //RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
            }
        }

        if (e.CommandName == "hotNews")
        {
            if (ctrNews.UpdateHot(Convert.ToInt32(e.CommandArgument), true) > 0)
            {
                ucPaging1.CurrentPage = 1;
                pageChange(ucPaging1);
                lblMsg.Text = "Cập nhật thành công";
                //RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");
            }
            else
            {
                lblMsg.Text = "Cập nhật thất bại";
                //RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
            }
        }

        if (e.CommandName == "edit")
        {
            trAdmin.Visible = true;
            trDate.Visible = true;
            spTitle.InnerText = "Chi tiết";
            isNew = false;
            LoadPanel(3);
            CurrentNewsID = Convert.ToInt32(e.CommandArgument);
            var info = ctrNews.GetInfo(CurrentNewsID);
            lbAccountEdit.Text = info.AdminName;
            lbCreateDateEdit.Text = info.CreateDate.ToString("dd/MM/yyyy HH:mm:ss");

            lblAccountModifyEdit.Text = info.AdminModify;
            lblLastModifyEdit.Text = info.LastModify.Value.ToString("dd/MM/yyyy HH:mm:ss");
            rdpPublishDateEdit.SelectedDate = info.PublishDate;
            ddlStatusEdit.SelectedValue = info.Status ? "1" : "0";
            ddlIsHotEdit.SelectedValue = info.IsHot??false ? "1" : "0";

            txtTitle.Text = HtmlUtility.HtmlDecode(info.Title);
            txtAbstract.Text = HtmlUtility.HtmlDecode(info.Description);
            txtResource.Text = HtmlUtility.HtmlDecode(info.Resource);
            imgNews.Src = info.Img+".thumb";
            try
            {
                ddlNewsMenu.SelectedValue = info.CategoryID.ToString();
            }
            catch
            {
                ddlNewsMenu.SelectedValue = "0";
            }                        
            radContent.Content = info.Content;
        }

        if (e.CommandName == "delete")
        {
            var permis = ((permission & Constants.PERMISSION_DELETE) == Constants.PERMISSION_DELETE);
            if (!permis)
            {
                Response.Redirect("~/admin/notpermission");
            }
            CurrentNewsID = Convert.ToInt32(e.CommandArgument);            
            string strImage = "";
            try
            {
                strImage = ctrNews.GetInfo(CurrentNewsID).Img.ToString();
            }
            catch
            {
            }
            string strImagePath = Request.PhysicalApplicationPath + strImage;
            if (ctrNews.Delete(CurrentNewsID) > 0)
            {
                if (File.Exists(strImagePath) && !strImage.Contains("noimage.jpg"))
                {                    
                    FileInfo file = new FileInfo(strImagePath);
                    file.Attributes = FileAttributes.Archive;
                    file.Delete();
                }
                //RadAjaxPanel1.ResponseScripts.Add("alert('Đã xóa thành công!')");
                lblMsg.Text = "Đã xóa thành công";
                ucPaging1.CurrentPage = 1;
                pageChange(ucPaging1);
            }
            else
            {
                //RadAjaxPanel1.ResponseScripts.Add("alert('Không xóa được!')");
                lblMsg.Text = "Không xóa được";
            }
        }
    }
    protected void lbtAddNew_Click(object sender, EventArgs e)
    {
        CurrentNewsID = 0;
        isNew = true;
        LoadPanel(3);
        txtTitle.Text = "";
        txtAbstract.Text = "";
        imgNews.Src = "~/images/news/noimage.jpg.thumb";        
        radContent.Content = "";
        ddlIsHotEdit.SelectedValue = "0";
        ddlStatusEdit.SelectedValue = "1";
        rdpPublishDateEdit.SelectedDate = DateTime.Now;
        trAdmin.Visible = false;
        trDate.Visible = false;
        spTitle.InnerText = "Thêm mới";
    }
    protected void lbtSave_Click(object sender, EventArgs e)
    {
        if (!isNew)
        {
            lbtSaveEdit();
            return;
        }
        CtrNews ctrNews = new CtrNews();        
        var image = "";
        if (string.IsNullOrEmpty(UploadImage.FileName))
        {
            image = "/images/news/noimage.jpg";
        }
        else
        {
            string strNewImage = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(UploadImage.FileName);
            image = "/images/news/" + strNewImage;
        }
        int adminID = 0;
        adminID = Convert.ToInt32(Session[Constants.SESSION_ADMIN_ID] ?? 0);
        if (adminID <= 0)
            Response.Redirect("~/admin/login");
        var ret = ctrNews.Insert(HtmlUtility.HtmlEncode(txtTitle.Text), HtmlUtility.HtmlEncode(txtAbstract.Text), radContent.Content, image, rdpPublishDateEdit.SelectedDate.Value, Convert.ToInt32(ddlNewsMenu.SelectedValue), HtmlUtility.HtmlEncode(txtResource.Text), ddlStatusEdit.SelectedValue == "1" ? true : false, ddlIsHotEdit.SelectedValue == "1" ? true : false, adminID);
        if (ret > 0)
        {
            lblMsg.Text = "Thêm mới thành công!";
            if (!string.IsNullOrEmpty(UploadImage.FileName))
            {
                try
                {
                    UploadImage.SaveAs(Request.PhysicalApplicationPath + image);
                    var thumb = System.Drawing.Image.FromFile(Request.PhysicalApplicationPath + image);
                    VTCO.Library.ImageResize img = new ImageResize();
                    var m_thumb = img.Crop(thumb, 150, 100, ImageResize.AnchorPosition.Center);
                    m_thumb.Save(Request.PhysicalApplicationPath + image + ".thumb");
                }
                catch
                {
                    //loi luu anh 
                }                
            }
            Response.Redirect("~/admin/news");
        }
        else
            lblMsg.Text = "Không thêm được!";

    }
    protected void lbtSaveEdit()
    {        
        var title = HtmlUtility.HtmlEncode(txtTitle.Text);
        var description = HtmlUtility.HtmlEncode(txtAbstract.Text);
        var content = radContent.Content;
        var categoryID = Convert.ToInt32(ddlNewsMenu.SelectedValue);
        var newsID = CurrentNewsID;
        var status = Convert.ToInt32(ddlStatusEdit.SelectedValue)==1?true:false;
        var isHot = Convert.ToInt32(ddlIsHotEdit.SelectedValue)==1?true:false;
        var publishDate=rdpPublishDateEdit.SelectedDate.Value;
        var resource=txtResource.Text;
        var image = "";
        if (!string.IsNullOrEmpty(UploadImage.FileName))
        {
            string strNewImage = DateTime.Now.ToString("yyyyMMddHHmmssfff") + Path.GetExtension(UploadImage.FileName);
            image = "/images/news/" + strNewImage;
        }
        else
        {
            image = imgNews.Src.Substring(0, imgNews.Src.IndexOf(".thumb")+1);
        }        
        CtrNews ctrNews = new CtrNews();
        int adminID = 0;
        adminID = Convert.ToInt32(Session[Constants.SESSION_ADMIN_ID] ?? 0);
        if (adminID <= 0)
            Response.Redirect("~/admin/login");
        string imgN = ctrNews.GetInfo(newsID).Img;
        if (ctrNews.Update(newsID, title, description, content, image, publishDate, categoryID, resource, status, isHot, adminID) > 0)
        {
            lblMsg.Text = "Cập nhật thành công";
            if (!string.IsNullOrEmpty(UploadImage.FileName))
            {
                try
                {
                    UploadImage.SaveAs(Request.PhysicalApplicationPath + image);      
                    var thumb=System.Drawing.Image.FromFile(Request.PhysicalApplicationPath + image);
                    VTCO.Library.ImageResize img = new ImageResize();
                    var m_thumb=img.Crop(thumb, 150, 100, ImageResize.AnchorPosition.Center);
                    m_thumb.Save(Request.PhysicalApplicationPath + image+".thumb");
                }
                catch
                {
                    //loi luu anh 
                }
                ctrNews.DeleteImage(Request, imgN);
            }
            Response.Redirect("~/admin/news");
        }
        else
            lblMsg.Text = "Cập nhật thất bại!";
    }

    protected void lbtCancel_Click(object sender, EventArgs e)
    {
        LoadPanel(1);
    }
    protected void LinkView_Click(object sender, EventArgs e)
    {
        LoadPanel(2);
        ltrTitleTemp.Text = txtTitle.Text;
        ltrCreateDateTemp.Text = DateTime.Now.ToString("dd/MM/yyyy");
        ltrContentTemp.Text = radContent.Content;
        ltrAbstractTemp.Text = txtAbstract.Text;
        imgNewsTemp.Src = imgNews.Src.Substring(0, imgNews.Src.IndexOf(".thumb"));

    }
    protected void linkBack_Click(object sender, EventArgs e)
    {
        LoadPanel(isNew ?1 : 3);
    }

    protected void lbtDeleteAll_Click(object sender, EventArgs e)
    {
        var permis = ((permission & Constants.PERMISSION_DELETE) == Constants.PERMISSION_DELETE);
        if (!permis)
        {
            Response.Redirect("~/admin/notpermission");
        }
        CtrNews ctrNews = new CtrNews();
        foreach (RepeaterItem item in rptAllNews.Items)
        {
            CheckBox cbxCheck = item.FindControl("cbxCheck") as CheckBox;
            HiddenField hdfNewsID = item.FindControl("hdNewsID") as HiddenField;
            if (cbxCheck.Checked)
            {
                int NewsID = Convert.ToInt32(hdfNewsID.Value);
                string urlimg = ctrNews.GetInfo(NewsID).Img;                
                if (ctrNews.Delete(NewsID)>0)
                {
                    ctrNews.DeleteImage(Request, urlimg);
                }
            }
        }
        lblMsg.Text = "Xóa thành công!";
        ucPaging1.CurrentPage = 1;
        pageChange(ucPaging1);
    }
    protected void btnSearch_Click1(object sender, EventArgs e)
    {
        ucPaging1.CurrentPage = 1;
        pageChange(ucPaging1);
    }
}