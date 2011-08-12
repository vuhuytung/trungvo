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

public partial class BackEnd_pages_account_Role : System.Web.UI.Page
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
        if (!IsPostBack)
        {
            lbtAddNew.Visible = ((permission & VTCO.Config.Constants.PERMISSION_ADD) == VTCO.Config.Constants.PERMISSION_ADD);

            LoadPanel(1);
            CtrAdmin ctrAdmin=new CtrAdmin();
            rptRole.DataSource = ctrAdmin.RoleGetAll();
            rptRole.DataBind();
        }
        lblMsg.Text = "";
    }
    /// <summary>
    /// 
    /// </summary>
    /// <param name="panel">
    /// 1: Danh sách
    /// 2: Chi tiết
    /// </param>
    private void LoadPanel(int panel)
    {

        pnlManager.Visible = (panel == 1);
        pnlDetail.Visible = (panel == 2);
    }    

    protected void rptRole_ItemDataBound(object sender, RepeaterItemEventArgs e)
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
            HtmlGenericControl spSTT = e.Item.FindControl("spSTT") as HtmlGenericControl;
            spSTT.InnerText = (e.Item.ItemIndex+1).ToString();            
        }

    }
    protected void rptRole_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        CtrAdmin ctrAdmin = new CtrAdmin();
        if (e.CommandArgument == null) return;
        if (e.CommandName == "lockNews")
        {
            if (ctrAdmin.RoleUpdateStatus(Convert.ToInt32(e.CommandArgument), 0) > 0)
            {
                lblMsg.Text = "Cập nhật thành công";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");
                Response.Redirect("~/admin/role");

            }
            else
            {
                lblMsg.Text = "Cập nhật thất bại";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
            }
        }

        if (e.CommandName == "unlockNews")
        {
            if (ctrAdmin.RoleUpdateStatus(Convert.ToInt32(e.CommandArgument), 1) > 0)
            {
                lblMsg.Text = "Cập nhật thành công";
                ////RadAjaxPanel1.ResponseScripts.Add("alert('Cập nhật thành công!')");
                Response.Redirect("~/admin/role");
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
            LoadPanel(2);
            CurrentNewsID = Convert.ToInt32(e.CommandArgument);
            var info = ctrAdmin.RoleGetInfo(CurrentNewsID);
            ddlStatusEdit.SelectedValue = info.Status ==1 ? "1" : "0";

            txtTitle.Text = HtmlUtility.HtmlDecode(info.Name);
            txtAbstract.Text = HtmlUtility.HtmlDecode(info.Description);

            rptRoleFunction.DataSource = ctrAdmin.FunctionGetChildInRole(CurrentNewsID);
            rptRoleFunction.DataBind();

            divListAdmin.Visible = true;
            rptAdminInRole.DataSource = ctrAdmin.AdminGetListByRole(CurrentNewsID);
            rptAdminInRole.DataBind();

            rptAdminNotInRole.DataSource = ctrAdmin.AdminGetListNotInRole(CurrentNewsID);
            rptAdminNotInRole.DataBind();
            divPopupAddAdmin.Visible = false;
        }

        if (e.CommandName == "delete")
        {
            CurrentNewsID = Convert.ToInt32(e.CommandArgument);            
            if (ctrAdmin.RoleDelete(CurrentNewsID) > 0)
            {
                //RadAjaxPanel1.ResponseScripts.Add("alert('Đã xóa thành công!')");
                lblMsg.Text = "Đã xóa thành công";
            }
            else
            {
                //RadAjaxPanel1.ResponseScripts.Add("alert('Không xóa được!')");
                lblMsg.Text = "Không xóa được";
            }
            rptRole.DataSource = ctrAdmin.RoleGetAll();
            rptRole.DataBind();
        }
    }


    protected void rptAdminInRole_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        CtrAdmin ctrAdmin = new CtrAdmin();
        if (e.CommandArgument == null) return;
        if (e.CommandName == "delete")
        {
            if (ctrAdmin.PermissionDelete(Convert.ToInt32(e.CommandArgument)) > 0)
            {
                rptAdminInRole.DataSource = ctrAdmin.AdminGetListByRole(CurrentNewsID);
                rptAdminInRole.DataBind();

                rptAdminNotInRole.DataSource = ctrAdmin.AdminGetListNotInRole(CurrentNewsID);
                rptAdminNotInRole.DataBind();
            }
        }
    }
    protected void rptAdminNotInRole_ItemCommand(object source, RepeaterCommandEventArgs e)
    {
        CtrAdmin ctrAdmin = new CtrAdmin();
        if (e.CommandArgument == null) return;
        if (e.CommandName == "add")
        {
            if (ctrAdmin.PermissionInsert(CurrentNewsID, Convert.ToInt32(e.CommandArgument)) > 0)
            {
                rptAdminInRole.DataSource = ctrAdmin.AdminGetListByRole(CurrentNewsID);
                rptAdminInRole.DataBind();

                rptAdminNotInRole.DataSource = ctrAdmin.AdminGetListNotInRole(CurrentNewsID);
                rptAdminNotInRole.DataBind();
            }
        }
    }

    private int curentParent = 0;
    protected void rptRoleFunction_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            int cp=Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "ParrentID"));
            if (curentParent != cp)
            {
                curentParent = cp;
                HtmlTableRow trGroup = e.Item.FindControl("trGroup") as HtmlTableRow;
                trGroup.Visible = true;
            }
            int per = Convert.ToInt32(DataBinder.Eval(e.Item.DataItem, "Permission"));
            CheckBox cbxView = e.Item.FindControl("cbxView") as CheckBox;
            CheckBox cbxAdd = e.Item.FindControl("cbxAdd") as CheckBox;
            CheckBox cbxEdit = e.Item.FindControl("cbxEdit") as CheckBox;
            CheckBox cbxDelete= e.Item.FindControl("cbxDelete") as CheckBox;
            cbxView.Checked = ((per & 8) == 8);
            cbxAdd.Checked = ((per & 4) == 4);
            cbxEdit.Checked = ((per & 2) == 2);
            cbxDelete.Checked = ((per & 1) == 1);
        }
    }
    protected void lbtAddNew_Click(object sender, EventArgs e)
    {
        CurrentNewsID = 0;
        isNew = true;
        LoadPanel(2);
        txtTitle.Text = "";
        txtAbstract.Text = "";
        ddlStatusEdit.SelectedValue = "1";
        spTitle.InnerText = "Thêm mới";
        CtrAdmin ctrAdmin = new CtrAdmin();
        rptRoleFunction.DataSource = ctrAdmin.FunctionGetChildInRole(CurrentNewsID);
        rptRoleFunction.DataBind();
        divListAdmin.Visible = false;
        divPopupAddAdmin.Visible = false;
    }
    protected void lbtAddAdmin_Click(object sender, EventArgs e)
    {
        if (rptAdminNotInRole.Items.Count == 0)
            ClientScript.RegisterStartupScript(Page.GetType(), "thong bao", "alert('Tất cả các quản trị đã được thêm vào'", true);
        else
            divPopupAddAdmin.Visible = true;
        
    }
    protected void linkClose_Click(object sender, EventArgs e)
    {
        divPopupAddAdmin.Visible = false;
    }
    protected void lbtSave_Click(object sender, EventArgs e)
    {
        if (!isNew)
        {
            lbtSaveEdit();
            return;
        }
        CtrAdmin ctrAdmin = new CtrAdmin();
        var ret = ctrAdmin.RoleInsert(txtTitle.Text.Trim(), txtAbstract.Text.Trim(), Convert.ToInt32(ddlStatusEdit.SelectedValue));
        if (ret > 0)
        {
            foreach (RepeaterItem item in rptRoleFunction.Items)
            {
                int per = 0;
                CheckBox cbxView = item.FindControl("cbxView") as CheckBox;
                CheckBox cbxAdd = item.FindControl("cbxAdd") as CheckBox;
                CheckBox cbxEdit = item.FindControl("cbxEdit") as CheckBox;
                CheckBox cbxDelete = item.FindControl("cbxDelete") as CheckBox;
                if (cbxView.Checked) per = per | 8;
                if (cbxAdd.Checked) per = per | 4;
                if (cbxEdit.Checked) per = per | 2;
                if (cbxDelete.Checked) per = per | 1;

                var hdFunctionID = item.FindControl("hdFunctionID") as HiddenField;
                ctrAdmin.RoleFunctionUpdate(ret, Convert.ToInt32(hdFunctionID.Value), per);
            }     
            lblMsg.Text = "Thêm mới thành công!";           
            Response.Redirect("~/admin/role");
        }
        else
            lblMsg.Text = "Không thêm được!";

    }
    protected void lbtSaveEdit()
    {        
        CtrAdmin ctrAdmin = new CtrAdmin();
        if (ctrAdmin.RoleUpdate(CurrentNewsID,txtTitle.Text.Trim(),txtAbstract.Text.Trim(),Convert.ToInt32(ddlStatusEdit.SelectedValue)) >0)
        {
            foreach(RepeaterItem item in rptRoleFunction.Items)
            {
                int per=0;
                CheckBox cbxView = item.FindControl("cbxView") as CheckBox;
                CheckBox cbxAdd = item.FindControl("cbxAdd") as CheckBox;
                CheckBox cbxEdit = item.FindControl("cbxEdit") as CheckBox;
                CheckBox cbxDelete= item.FindControl("cbxDelete") as CheckBox;
                if(cbxView.Checked) per = per | 8;
                if(cbxAdd.Checked) per = per | 4;
                if(cbxEdit.Checked) per = per | 2;
                if(cbxDelete.Checked) per = per | 1;

                var hdFunctionID =item.FindControl("hdFunctionID") as HiddenField;
                ctrAdmin.RoleFunctionUpdate(CurrentNewsID, Convert.ToInt32(hdFunctionID.Value), per);
            }            
            lblMsg.Text = "Cập nhật thành công";
            Response.Redirect("~/admin/role");
        }
        else
            lblMsg.Text = "Cập nhật thất bại!";
    }

    protected void lbtCancel_Click(object sender, EventArgs e)
    {
        LoadPanel(1);
    }
    protected void linkBack_Click(object sender, EventArgs e)
    {
        LoadPanel(isNew ?1 : 2);
    }

}