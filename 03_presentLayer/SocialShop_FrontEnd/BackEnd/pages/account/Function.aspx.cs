using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using WorkFlowBLL;
using DataContext;
using VTCO.Config;
using Telerik.Web.UI;
using VTCO.Library;
using System.Text;
using System.Collections.Generic;

public partial class BackEnd_pages_account_Function : System.Web.UI.Page
{
    public int MenuID
    {
        get
        {
            return Convert.ToInt32(ViewState["MenuID"]);
        }
        set
        {
            ViewState["MenuID"] = value;
        }
    }

    public int CheckAddOrEdit
    {
        get
        {
            return Convert.ToInt32(ViewState["CheckAddOrEdit"]);
        }
        set
        {
            ViewState["CheckAddOrEdit"] = value;
        }
    }

    CtrAdmin MyMenu = new CtrAdmin();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadTreeMenu();
        }
    }

    private void LoadTreeMenu()
    {
        var RootNode = new RadTreeNode("Hệ thống quản trị website", "0");
        RadTreeViewMenu.Nodes.Add(RootNode);
        AddNodes(RadTreeViewMenu.Nodes[0].Nodes, 0);
        RadTreeViewMenu.ExpandAllNodes();
    }


    private void SetControlsRdb(bool edit)
    {
        ddlStatus.SelectedValue = edit ? "1" : "0";
    }

    private void SetControlsEdit(bool edit, string name)
    {
        CtrEdit.Visible = edit;
        lblMsg1.Visible = !edit;
        btnSave.Text = name;
    }

    private void Clear()
    {
        txtMenuName.Text = string.Empty;
        txtOrder.Text = string.Empty;
        txtUrl.Text = string.Empty;
    }

    private void AddNodes(RadTreeNodeCollection radTreeMenu, int menuParentID)
    {
        var ListMenu = MyMenu.FunctionGetByParentID(menuParentID,-1);
        foreach (var Menu in ListMenu)
        {
            var Node = new RadTreeNode(Menu.Name, Menu.FunctionID.ToString());
            radTreeMenu.Add(Node);
            AddNodes(Node.Nodes, Menu.FunctionID);
        }
    }

    private void BinDataForDropDllPrentID()
    {
        ddlParentID.DataSource = MyMenu.FunctionGetByParentID(0,-1);
        ddlParentID.DataBind();
    }


    public void GetMenuTop(List<uspFunctionByParentIDResult> tb, int parentID, string space, int currentMenuID)
    {        
        if (tb == null)
        {
            tb = MyMenu.FunctionGetByParentID(0,-1);
            ddlParentID.Items.Add(new ListItem("Hệ thống quản trị website", "0"));
        }        
        var rows = tb.Where(x=>x.ParrentID==parentID);
        foreach (var row in rows)
        {
            if (row.FunctionID == currentMenuID) continue;
            ddlParentID.Items.Add(new ListItem(space + ". . . " + row.Name, row.FunctionID.ToString()));
            GetMenuTop(tb, row.FunctionID, space + ". . . ", currentMenuID);
        }
    }

    protected void RadTreeViewMenu_ContextMenuItemClick(object sender, Telerik.Web.UI.RadTreeViewContextMenuEventArgs e)
    {
        var MyMenuInfo = MyMenu.FunctionGetInfo(Convert.ToInt32(e.Node.Value));

        switch (e.MenuItem.Value)
        {
            case "Add":
                //if (Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.RootAdmin) || Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.Admin))
                {
                    CheckAddOrEdit = 1;
                    txtMenuName.Focus();
                    SetControlsEdit(true, " Lưu lại ");
                    Clear();
                    MenuID = Convert.ToInt32(e.Node.Value);
                    BinDataForDropDllPrentID();
                    var listItemAdd = new ListItem(e.Node.Text, e.Node.Value);
                    listItemAdd.Selected = true;
                    ddlParentID.Items.Add(listItemAdd);
                    ddlParentID.Enabled = false;
                    SetControlsRdb(false);
                }
                //else
                //{
                //    lblMsg1.Text = "  <img src='/images/attention.ico' width='20px' height='20px' /> Bạn không được quyền sử dụng chức năng này  ";
                //    lblMsg1.Visible = true;
                //}
                break;
            case "Edit":
    //            //if (Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.RootAdmin) || Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.Admin))
                {
                    CheckAddOrEdit = 0;
                    txtMenuName.Focus();
                    SetControlsEdit(true, " Cập nhật ");
                    MenuID = Convert.ToInt32(e.Node.Value);
                    ddlParentID.Enabled = true;
                    ddlParentID.Items.Clear();
                    GetMenuTop(null, 0, "", MenuID);
                    txtMenuName.Text = HtmlUtility.HtmlDecode(MyMenuInfo.Name.ToString());
                    txtOrder.Text = MyMenuInfo.Order.ToString();
                    txtUrl.Text = MyMenuInfo.Url;
                    if (MyMenuInfo.Status == 1)
                    {
                        SetControlsRdb(true);
                    }
                    else
                    {
                        SetControlsRdb(false);
                    }                    
                    ddlParentID.SelectedValue = MyMenuInfo.ParrentID.ToString();
                }
    //            //else
    //            //{
    //            //    lblMsg1.Text = "  <img src='/images/attention.ico' width='20px' height='20px' /> Bạn không được quyền sử dụng chức năng này  ";
    //            //    lblMsg1.Visible = true;
    //            //}
                break;
            case "Delete":
                //if (Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.RootAdmin) || Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.Admin))
                {
                    CtrEdit.Visible = false;
                    MenuID = Convert.ToInt32(e.Node.Value);
                    var MenuChild = MyMenu.FunctionGetByParentID(Convert.ToInt32(e.Node.Value), -1);
                    if (MenuChild.Count == 0)
                    {
                        try
                        {
                            MyMenu.FunctionDelete(MenuID);
                        }
                        catch
                        {
                            lblMsg1.Visible = true;
                            return;
                        }
                        Response.Redirect("~/admin/function");
                    }
                    else
                    {
                        lblMsg1.Text = "  <img src='/Backend/images/attention.ico' width='20px' height='20px' /> Bạn không được xóa chức năng này  ";
                        lblMsg1.Visible = true;
                    }
                }
                //else
                //{
                //    lblMsg1.Text = "  <img src='/images/attention.ico' width='20px' height='20px' /> Bạn không được quyền sử dụng chức năng này  ";
                //    lblMsg1.Visible = true;
                //}
                break;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        string name = "";
        int order = 1;
        int parentId = 1;
        string link = "";
        int status = 1;
        if (CheckAddOrEdit == 1)
        {
            name = HtmlUtility.HtmlEncode(txtMenuName.Text.Trim());
            order = Convert.ToInt32(txtOrder.Text);
            parentId = Convert.ToInt32(ddlParentID.SelectedValue);
            link = HtmlUtility.HtmlEncode(txtUrl.Text.Trim());
            status = Convert.ToInt32(ddlStatus.SelectedValue);
            MyMenu.FunctionInsert(name, link, order, parentId,status);
            Response.Redirect("~/admin/function");
        }
        else
        {
            name = HtmlUtility.HtmlEncode(txtMenuName.Text.Trim());
            order = Convert.ToInt32(txtOrder.Text);
            parentId = Convert.ToInt32(ddlParentID.SelectedValue);
            link = HtmlUtility.HtmlEncode(txtUrl.Text.Trim());
            status = Convert.ToInt32(ddlStatus.SelectedValue);
            MyMenu.FunctionUpdate(MenuID, name, link, order, parentId, status);
            Response.Redirect("~/admin/function");
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        CtrEdit.Visible = false;
    }
}
