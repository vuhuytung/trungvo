using System;
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

public partial class BackEnd_pages_account_Admin : System.Web.UI.Page
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
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(pageChange);
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        if (!IsPostBack)
        {
            lbtAddNew.Visible = ((permission & VTCO.Config.Constants.PERMISSION_ADD) == VTCO.Config.Constants.PERMISSION_ADD);

            CtrAdmin ctrAdmin = new CtrAdmin();
            ddlRole.DataSource = ctrAdmin.RoleGetAll();
            ddlRole.DataTextField = "Name";
            ddlRole.DataValueField = "RoleID";
            ddlRole.DataBind();
            ddlRole.Items.Insert(0, new ListItem("Tất cả", "-1"));

            ucPaging1.PageSize = 10;
            ucPaging1.CurrentPage = 1;
            ucPaging1.PageDisplay = 10;
            pageChange(ucPaging1);
            LoadPanel(1);            
        }
        lblMsg.Text = "";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="panel">
    /// 1: Danh sách
    /// 3: Chi tiết
    /// </param>
    private void LoadPanel(int panel)
    {
        pnlManager.Visible = (panel == 1);
        pnlDetail.Visible = (panel == 3);
    }


    protected void pageChange(object sender)
    {
        ucPaging1.Visible = false;       
        CtrAdmin ctrAdmin=new CtrAdmin();
        var dt = ctrAdmin.AdminGetList(txtKeyword.Text, Convert.ToInt32(ddlRole.SelectedValue), Convert.ToInt32(ddlStatus.SelectedValue), ucPaging1.CurrentPage, ucPaging1.PageSize);
        rptAdmin.DataSource = dt.Items;
        ucPaging1.TotalRecord = dt.TotalRecord;
        rptAdmin.DataBind();
        divPaging.Visible = ucPaging1.TotalPage > 1;
        if (dt.TotalRecord > 0)
        {
            rptAdmin.Visible = true;
            pNoRow.Visible = false;
        }
        else
        {
            rptAdmin.Visible = false;
            pNoRow.Visible = true;
        }
    }
    protected void rptAdmin_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            
        }

    }
    protected void rptAdmin_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        CtrAdmin ctrAdmin = new CtrAdmin();
        if (e.CommandArgument == null) return;
        if (e.CommandName == "lockNews")
        {
            if (ctrAdmin.AdminUpdateStatus(Convert.ToInt32(e.CommandArgument), 0) > 0)
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
            if (ctrAdmin.AdminUpdateStatus(Convert.ToInt32(e.CommandArgument), 1) > 0)
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

       
        if (e.CommandName == "edit")
        {
            spTitle.InnerText = "Chi tiết";
            isNew = false;
            LoadPanel(3);
            CurrentNewsID = Convert.ToInt32(e.CommandArgument);
            var info = ctrAdmin.AdminGetInfo(CurrentNewsID);
            lblUserName.Text = info.UserName;
            txtFullName.Text = info.FullName;
            txtUserName.Visible = false;
            lblUserName.Visible = true;
            trPass.Visible = false;
            txtEmail.Text = info.Email;
            txtTelephone.Text = info.Telephone;
            lblCreateDate.Text = info.DateCreate.Value.ToString("dd/MM/yyyy");
            rdpBirthday.SelectedDate = info.Birthday;
            ddlStatusEdit.SelectedValue = info.Status.ToString();
            txtAbstract.Text = info.Description;
            txtUserName.Text = info.UserName;
            txtUserName.Visible = false;
            lblUserName.Visible = true;
        }

        if (e.CommandName == "delete")
        {
            var permis = ((permission & Constants.PERMISSION_DELETE) == Constants.PERMISSION_DELETE);
            if (!permis)
            {
                Response.Redirect("~/admin/notpermission");
            }
            CurrentNewsID = Convert.ToInt32(e.CommandArgument);            
            if (ctrAdmin.AdminDelete(CurrentNewsID) > 0)
            {               
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
        txtEmail.Text = "";
        txtFullName.Text = "";
        txtPassword.Text = "";
        txtTelephone.Text = "";
        txtUserName.Text = "";
        lblCreateDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        trPass.Visible = true;
        rdpBirthday.SelectedDate = new DateTime(1985, 1, 1);
        txtAbstract.Text = "";
        ddlStatusEdit.SelectedValue = "1";
        spTitle.InnerText = "Thêm mới";
        lblUserName.Text = "";
        lblUserName.Visible = false;
        txtUserName.Visible = true;
    }
    protected void lbtSave_Click(object sender, EventArgs e)
    {
        if (!isNew)
        {
            lbtSaveEdit();
            return;
        }

        var permis = ((permission & Constants.PERMISSION_ADD) == Constants.PERMISSION_ADD);
        if (!permis)
        {
            Response.Redirect("~/admin/notpermission");
        }

        CtrAdmin ctrAdmin = new CtrAdmin();
        var pass = VTCO.Utils.Encryption.GetMD5(txtPassword.Text);
        var ret = ctrAdmin.AdminInsert(txtUserName.Text, pass, txtFullName.Text, rdpBirthday.SelectedDate.Value, txtEmail.Text, txtTelephone.Text, txtAbstract.Text, Convert.ToInt32(ddlStatusEdit.SelectedValue));
        if (ret > 0)
        {
            lblMsg.Text = "Thêm mới thành công!";
            LoadPanel(1);
            pageChange(ucPaging1);
        }
        else
        {
            if (ret == -1)
                lblMsg.Text = "Tên đăng nhập đã tồn tại";
            else
                lblMsg.Text = "Không thêm được!";
        }

    }
    protected void lbtSaveEdit()
    {
        var permis = ((permission & Constants.PERMISSION_EDIT) == Constants.PERMISSION_EDIT);
        if (!permis)
        {
            Response.Redirect("~/admin/notpermission");
        }
        CtrAdmin ctrAdmin = new CtrAdmin();
        var ret = ctrAdmin.AdminUpdate(CurrentNewsID,txtFullName.Text, rdpBirthday.SelectedDate.Value, txtEmail.Text, txtTelephone.Text, txtAbstract.Text, Convert.ToInt32(ddlStatusEdit.SelectedValue));     
        if (ret> 0)
        {
            lblMsg.Text = "Cập nhật thành công";
            LoadPanel(1);
            pageChange(ucPaging1);
        }
        else
            lblMsg.Text = "Cập nhật thất bại!";
    }

    protected void lbtCancel_Click(object sender, EventArgs e)
    {
        LoadPanel(1);
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        ucPaging1.CurrentPage = 1;
        pageChange(ucPaging1);
    }
}