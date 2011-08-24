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

public partial class BackEnd_pages_account_User : System.Web.UI.Page
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
    protected int permission = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        ucPaging1.PageChange += new UserControls_ucPaging.PagingHandler(pageChange);
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        if (!IsPostBack)
        {
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
        CtrUser ctrUser=new CtrUser();
        var dt = ctrUser.UserGetList(txtKeyword.Text, Convert.ToInt32(ddlStatus.SelectedValue), ucPaging1.CurrentPage, ucPaging1.PageSize);
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
        CtrUser ctrUser = new CtrUser();
        if (e.CommandArgument == null) return;
        if (e.CommandName == "lockNews")
        {
            if (ctrUser.UserUpdateStatus(Convert.ToInt32(e.CommandArgument), 0) > 0)
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
            if (ctrUser.UserUpdateStatus(Convert.ToInt32(e.CommandArgument), 1) > 0)
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
            LoadPanel(3);
            CurrentNewsID = Convert.ToInt32(e.CommandArgument);
            var info = ctrUser.UserGetInfo(CurrentNewsID);
            lblUserName.Text = info.UserName;
            lblFullName.Text = info.FullName;
            lblUserName.Visible = false;
            lblUserName.Visible = true;            
            lblEmail.Text = info.Email;
            lblPhone.Text = info.Phone;
            lblCreateDate.Text = info.RegisterDate.Value.ToString("dd/MM/yyyy");
            lblBirthday.Text = info.Birthday.HasValue?info.Birthday.Value.ToString("dd/MM/yyyy"):"";
            ddlStatusEdit.SelectedValue = info.Status.ToString();
            lblAddress.Text = info.Address;
        }

        if (e.CommandName == "delete")
        {
            CurrentNewsID = Convert.ToInt32(e.CommandArgument);            
            if (ctrUser.UserDelete(CurrentNewsID) > 0)
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
    protected void lbtSave_Click(object sender, EventArgs e)
    {
        var permis = ((permission & Constants.PERMISSION_EDIT) == Constants.PERMISSION_EDIT);
        if (!permis)
        {
            Response.Redirect("~/admin/notpermission");
        }
        CtrUser ctrUser = new CtrUser();
        var ret = ctrUser.UserUpdateStatus(CurrentNewsID,Convert.ToInt32(ddlStatusEdit.SelectedValue));     
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