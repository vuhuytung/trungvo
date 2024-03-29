﻿using System;
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

public partial class BackEnd_pages_content_Category : System.Web.UI.Page
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

    CtrCategory MyMenu = new CtrCategory();
    protected int permission = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        permission = Convert.ToInt32(Session[Constants.SESSION_ADMIN_PERMISSION] ?? 0);
        if (!IsPostBack)
        {
            LoadTreeMenu();
            BinDataForDropType();
        }
    }

    private void LoadTreeMenu()
    {
        var RootNode = new RadTreeNode("Trang chủ", "0");
        RadTreeViewMenu.Nodes.Add(RootNode);
        AddNodes(RadTreeViewMenu.Nodes[0].Nodes, 0);
        RadTreeViewMenu.ExpandAllNodes();
    }

    private void SetControls(bool edit)
    {
        lblUrl.Visible = edit;
        txtUrl.Visible = edit;
    }

    private void SetControlsRdb(int status)
    {
        if ((status & 1) == 1)
            ddlStatus.SelectedValue = "1";
        else
            ddlStatus.SelectedValue = "0";
        if ((status & 2) == 2)
            ddlDefault.SelectedValue = "2";
        else
            ddlDefault.SelectedValue = "0";
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
        var ListMenu = MyMenu.GetByParentID(menuParentID,-1);
        foreach (var Menu in ListMenu)
        {
            var Node = new RadTreeNode(Menu.Name, Menu.CategoryID.ToString());
            radTreeMenu.Add(Node);
            AddNodes(Node.Nodes, Menu.CategoryID);
        }
    }
    //private void MoveNodes(RadTreeNodeCollection radTreeMenu, int menuParentID)
    //{
    //    var ListMenu = MyMenu.GetByParentID(menuParentID,-1);
    //    foreach (var Menu in ListMenu)
    //    {
    //        var Node = new RadTreeNode(Menu.Name, Menu.CategoryID.ToString());
    //        radTreeMenu.Remove(Node);
    //        MoveNodes(Node.Nodes, Menu.CategoryID);
    //    }
    //}
    private void BinDataForDropType()
    {
        ddlMenuType.Items.Add(new ListItem("Nhóm menu", "1"));
        ddlMenuType.Items.Add(new ListItem("Tin tức", "2"));
        ddlMenuType.Items.Add(new ListItem("Tài nguyên", "3"));
        ddlMenuType.Items.Add(new ListItem("Bất động sản", "4"));
        ddlMenuType.Items.Add(new ListItem("Liên kết", "5"));
        ddlMenuType.Items.Add(new ListItem("Đăng tin bất động sản", "6"));
        ddlMenuType.Items.Add(new ListItem("Liên hệ", "7"));
    }

    private void BinDataForDropDllPrentID()
    {
        ddlParentID.DataSource = MyMenu.GetListCategory(-1);
        ddlParentID.DataBind();
    }


    public void GetMenuTop(List<uspCategoryGetListResult> tb, int parentID, string space, int currentMenuID)
    {        
        if (tb == null)
        {
            tb = MyMenu.GetListCategory(-1);
            ddlParentID.Items.Add(new ListItem("Trang chủ", "0"));
        }        
        var rows = tb.Where(x=>x.ParentID==parentID);
        foreach (var row in rows)
        {
            if (row.CategoryID == currentMenuID) continue;
            ddlParentID.Items.Add(new ListItem(space + ". . . " + row.Name, row.CategoryID.ToString()));
            GetMenuTop(tb, row.CategoryID, space + ". . . ", currentMenuID);
        }
    }


    protected void RadTreeViewMenu_ContextMenuItemClick(object sender, Telerik.Web.UI.RadTreeViewContextMenuEventArgs e)
    {
        var MyMenuInfo = MyMenu.GetInfo(Convert.ToInt32(e.Node.Value));

        switch (e.MenuItem.Value)
        {
            case "Add":
                //if (Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.RootAdmin) || Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.Admin))
                {
                    CheckAddOrEdit = 1;
                    txtMenuName.Focus();
                    SetControlsEdit(true, " Lưu lại ");
                    SetControls(false);
                    Clear();
                    MenuID = Convert.ToInt32(e.Node.Value);
                    BinDataForDropDllPrentID();
                    var listItemAdd = new ListItem(e.Node.Text, e.Node.Value);
                    listItemAdd.Selected = true;
                    ddlParentID.Items.Add(listItemAdd);
                    ddlParentID.Enabled = false;
                    ddlMenuType.Items.Clear();
                    SetControlsRdb(1);
                    BinDataForDropType();
                }
                //else
                //{
                //    lblMsg1.Text = "  <img src='/images/attention.ico' width='20px' height='20px' /> Bạn không được quyền sử dụng chức năng này  ";
                //    lblMsg1.Visible = true;
                //}
                break;
            case "Edit":
                //if (Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.RootAdmin) || Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.Admin))
                {
                    CheckAddOrEdit = 0;
                    txtMenuName.Focus();
                    SetControlsEdit(true, " Cập nhật ");
                    MenuID = Convert.ToInt32(e.Node.Value);
                    if (MenuID <= 0)
                    {
                        SetControlsEdit(false, "");
                        lblMsg1.Text = "  <img src='/images/attention.ico' width='20px' height='20px' /> Không thể sửa danh mục này! ";
                        lblMsg1.Visible = true;
                        return;
                    }
                    ddlParentID.Enabled = true;
                    ddlParentID.Items.Clear();
                    GetMenuTop(null, 0, "", MenuID);
                    txtMenuName.Text = HtmlUtility.HtmlDecode(MyMenuInfo.Name.ToString());
                    txtOrder.Text = MyMenuInfo.Order.ToString();
                    SetControlsRdb(MyMenuInfo.Status);
                    if (MyMenuInfo.Type != 5)//Convert.ToInt32(EnumMenuType.Link))
                    {
                        SetControls(false);
                    }
                    else
                    {
                        SetControls(true);                        
                    }
                    txtUrl.Text = HtmlUtility.HtmlDecode(MyMenuInfo.URL);
                    ddlMenuType.SelectedValue = MyMenuInfo.Type.ToString();
                    ddlParentID.SelectedValue = MyMenuInfo.ParentID.ToString();

                    if ((ddlMenuType.SelectedValue == "5") && (MyMenuInfo.URL.Trim() != "/contact") && (MyMenuInfo.URL.Trim() != "/addrealtymarket"))
                    {
                        SetControls(true);
                    }
                    else
                    {
                        SetControls(false);

                        if (MyMenuInfo.URL.Trim() == "/contact")
                            ddlMenuType.SelectedValue = "7";
                        else
                            if(MyMenuInfo.URL.Trim()=="/addrealtymarket")
                                ddlMenuType.SelectedValue = "6";
                    }
                }
                //else
                //{
                //    lblMsg1.Text = "  <img src='/images/attention.ico' width='20px' height='20px' /> Bạn không được quyền sử dụng chức năng này  ";
                //    lblMsg1.Visible = true;
                //}
                break;
            case "Delete":
                //if (Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.RootAdmin) || Convert.ToInt32(MyAccount.GetInfo(Convert.ToInt32(Session[Constants.SESSION_ACCOUNTID])).Type) == Convert.ToInt32(EnumAccountType.Admin))
                {
                    var permis = ((permission & Constants.PERMISSION_DELETE) == Constants.PERMISSION_DELETE);
                    if (!permis)
                    {
                        Response.Redirect("~/admin/notpermission");
                    }
                    CtrEdit.Visible = false;
                    MenuID = Convert.ToInt32(e.Node.Value);
                    var MenuChild = MyMenu.GetByParentID(Convert.ToInt32(e.Node.Value),-1);
                    if (MenuChild.Count == 0)
                    {
                        try
                        {
                            MyMenu.Delete(MenuID);
                        }
                        catch
                        {
                            lblMsg1.Visible = true;
                            return;
                        }
                        Response.Redirect("~/admin/category");
                    }
                    else
                    {
                        lblMsg1.Text = "  <img src='/images/attention.ico' width='20px' height='20px' /> Bạn không được xóa danh mục này  ";
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
        int type = 1;
        int order = 1;
        int parentId = 1;
        string link = "";
        int active = 1;
        int indefault = 1;
        int status = 1;
        if (CheckAddOrEdit == 1)
        {
            name = HtmlUtility.HtmlEncode(txtMenuName.Text.Trim());
            type = Convert.ToInt32(ddlMenuType.SelectedValue);
            order= Convert.ToInt32(txtOrder.Text);
            parentId = Convert.ToInt32(ddlParentID.SelectedValue);
            if (type == 5)
            {
                link = HtmlUtility.HtmlEncode(txtUrl.Text.Trim());
            }
            active = Convert.ToInt32(ddlStatus.SelectedValue);
            indefault = Convert.ToInt32(ddlDefault.SelectedValue);
            status = active | indefault;
            MyMenu.Insert(parentId,name,link,status,order,type);
            Response.Redirect("~/admin/category");
        }
        else
        {
            name = HtmlUtility.HtmlEncode(txtMenuName.Text.Trim());
            type = Convert.ToInt32(ddlMenuType.SelectedValue);
            order = Convert.ToInt32(txtOrder.Text);
            parentId = Convert.ToInt32(ddlParentID.SelectedValue);
            if (type == 5)
            {
                link = HtmlUtility.HtmlEncode(txtUrl.Text.Trim());
            }
            if(type==6)
            {
                type = 5;
                link = "/addrealtymarket";
            }
            if (type == 7)
            {
                type = 5;
                link = "/contact";
            }
            active = Convert.ToInt32(ddlStatus.SelectedValue);
            indefault = Convert.ToInt32(ddlDefault.SelectedValue);
            status = active | indefault;

            if (MyMenu.Update(MenuID, parentId, name, link, status, order, type) > 0)
            {
                SetControlsEdit(false, " Cập nhật ");
                RadAjaxManager1.ResponseScripts.Add("alert('Cập nhật thành công!')");
            }
            else
            {
                RadAjaxManager1.ResponseScripts.Add("alert('Cập nhật thất bại!')");
            }
        }
    }

    protected void ddlMenuType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlMenuType.SelectedValue == "5")
        {
            SetControls(true);
        }
        else
        {
            SetControls(false);
        }
    }

    protected void btnClose_Click(object sender, EventArgs e)
    {
        CtrEdit.Visible = false;
    }
}
