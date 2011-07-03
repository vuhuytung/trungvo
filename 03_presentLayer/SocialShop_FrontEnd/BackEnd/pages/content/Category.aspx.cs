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
using System.Messaging;
using System.Text;
using VTCO.Encrypt;
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
    protected void Page_Load(object sender, EventArgs e)
    {
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

        var RootNode1 = new TreeNode("Trang chủ", "0");
        trvCategory.Nodes.Add(RootNode1);
        AddNodes1(trvCategory.Nodes[0].ChildNodes, 0);
        trvCategory.ExpandAll();
    }

    private void SetControls(bool edit)
    {
        lblUrl.Visible = edit;
        txtUrl.Visible = edit;
    }

    private void SetControlsRdb(bool edit)
    {
        rdbActive.Checked = edit;
        rdbNoActive.Checked = !edit;
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
    private void AddNodes1(TreeNodeCollection treeMenu, int menuParentID)
    {
        var ListMenu = MyMenu.GetByParentID(menuParentID, -1);
        foreach (var Menu in ListMenu)
        {
            var Node = new TreeNode("<b onclick='alert(0); return false;'>"+Menu.Name+"</b>", Menu.CategoryID.ToString());
            treeMenu.Add(Node);
            AddNodes1(Node.ChildNodes, Menu.CategoryID);
        }
    }
    private void MoveNodes(RadTreeNodeCollection radTreeMenu, int menuParentID)
    {
        var ListMenu = MyMenu.GetByParentID(menuParentID,-1);
        foreach (var Menu in ListMenu)
        {
            var Node = new RadTreeNode(Menu.Name, Menu.CategoryID.ToString());
            radTreeMenu.Remove(Node);
            MoveNodes(Node.Nodes, Menu.CategoryID);
        }
    }
    private void BinDataForDropType()
    {
        ddlMenuType.Items.Add(new ListItem("Nhóm menu", "1"));
        ddlMenuType.Items.Add(new ListItem("Menu chỉ chứa 1 tin", "2"));
        ddlMenuType.Items.Add(new ListItem("Nhóm các tin", "3"));
        ddlMenuType.Items.Add(new ListItem("Tài nguyên", "4"));
        ddlMenuType.Items.Add(new ListItem("Bất động sản", "5"));
        ddlMenuType.Items.Add(new ListItem("Liên kết ngoài", "6"));
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
                    SetControlsEdit(true, "Lưu lại");
                    SetControls(false);
                    Clear();
                    MenuID = Convert.ToInt32(e.Node.Value);
                    BinDataForDropDllPrentID();
                    var listItemAdd = new ListItem(e.Node.Text, e.Node.Value);
                    listItemAdd.Selected = true;
                    ddlParentID.Items.Add(listItemAdd);
                    ddlParentID.Enabled = false;
                    ddlMenuType.Items.Clear();
                    SetControlsRdb(false);
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
                    SetControlsEdit(true, "Cập nhật");
                    MenuID = Convert.ToInt32(e.Node.Value);
                    ddlParentID.Enabled = true;
                    ddlParentID.Items.Clear();
                    GetMenuTop(null, 0, "", MenuID);
                    txtMenuName.Text = HtmlUtility.HtmlDecode(MyMenuInfo.Name.ToString());
                    txtOrder.Text = MyMenuInfo.Order.ToString();
                    if (MyMenuInfo.Status == 1)
                    {
                        SetControlsRdb(true);
                    }
                    else
                    {
                        SetControlsRdb(false);
                    }
                    if (MyMenuInfo.Type != 4)//Convert.ToInt32(EnumMenuType.Link))
                    {
                        SetControls(false);
                    }
                    else
                    {
                        SetControls(true);
                        txtUrl.Text = HtmlUtility.HtmlDecode(MyMenuInfo.URL);
                    }
                    ddlMenuType.SelectedValue = MyMenuInfo.Type.ToString();
                    ddlParentID.SelectedValue = MyMenuInfo.ParentID.ToString();
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
                    CtrEdit.Visible = false;
                    MenuID = Convert.ToInt32(e.Node.Value);
                    var MenuChild = MyMenu.GetByParentID(Convert.ToInt32(e.Node.Value),-1);
                    if (MenuChild.Count == 0)
                    {
                        try
                        {
                            //MyMenu.DeleteMenuByMenuID(MenuID);
                        }
                        catch
                        {
                            lblMsg1.Visible = true;
                            return;
                        }
                        Response.Redirect("~/backend/Menu.aspx");
                    }
                    else
                    {
                        lblMsg1.Text = "  <img src='/images/attention.ico' width='20px' height='20px' /> Bạn không được xóa Menu này  ";
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

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Clear();
    }
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (CheckAddOrEdit == 1)
        //{
        //    MenuInfo MenuInfo = new MenuInfo();
        //    MenuInfo.Name = HtmlUtility.HtmlEncode(txtMenuName.Text.Trim());
        //    MenuInfo.Type = Convert.ToInt32(ddlMenuType.SelectedValue);
        //    MenuInfo.Order = Convert.ToInt32(txtOrder.Text);
        //    MenuInfo.ParentID = MenuID;
        //    if (MenuInfo.Type != Convert.ToInt32(EnumMenuType.Link))
        //    {
        //        if (MenuInfo.Type == Convert.ToInt32(EnumMenuType.GroupMenu))
        //        {
        //            MenuInfo.Url = "#";
        //        }
        //        else
        //            MenuInfo.Url = string.Empty;
        //    }
        //    else
        //    {
        //        MenuInfo.Url = HtmlUtility.HtmlEncode(txtUrl.Text.Trim());
        //    }
        //    if (rdbActive.Checked)
        //    {
        //        MenuInfo.Status = Convert.ToInt32(EnumStatus.Active);
        //    }
        //    if (rdbNoActive.Checked)
        //    {
        //        MenuInfo.Status = Convert.ToInt32(EnumStatus.InActive);
        //    }
        //    MyMenu.InsertMenu(MenuInfo);
        //    Response.Redirect("~/backend/Menu.aspx");
        //}
        //else
        //{
        //    MenuInfo MenuInfo = MyMenuDB.GetInfo(MenuID);
        //    MenuInfo.Name = HtmlUtility.HtmlEncode(txtMenuName.Text.Trim());
        //    MenuInfo.Type = Convert.ToInt32(ddlMenuType.SelectedValue);
        //    MenuInfo.Order = Convert.ToInt32(txtOrder.Text);
        //    MenuInfo.ParentID = Convert.ToInt32(ddlParentID.SelectedValue);
        //    if (MenuInfo.Type == Convert.ToInt32(EnumMenuType.Link))
        //    {
        //        MenuInfo.Url = HtmlUtility.HtmlEncode(txtUrl.Text.Trim());
        //    }
        //    else
        //    {
        //        if (MenuInfo.Type == Convert.ToInt32(EnumMenuType.GroupMenu))
        //        {
        //            MenuInfo.Url = "#";
        //        }
        //        else
        //            MenuInfo.Url = string.Empty;
        //    }
        //    if (rdbActive.Checked)
        //    {
        //        MenuInfo.Status = Convert.ToInt32(EnumStatus.Active);
        //    }
        //    if (rdbNoActive.Checked)
        //    {
        //        MenuInfo.Status = Convert.ToInt32(EnumStatus.InActive);
        //    }
        //    MyMenu.UpdateMenuByMenuID(MenuInfo);
        //    Response.Redirect("~/backend/Menu.aspx");
        //}
    }

    protected void ddlMenuType_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (ddlMenuType.SelectedValue == "4")//Convert.ToInt32(EnumMenuType.Link).ToString())
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
