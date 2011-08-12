<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="Function.aspx.cs" Inherits="BackEnd_pages_account_Function" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">    
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <telerik:RadScriptBlock ID="RadScriptBlock1" runat="server">
    <script type="text/javascript">
        function onClientContextMenuItemClicking(sender, args) {
            var menuItem = args.get_menuItem();
            var treeNode = args.get_node();
            menuItem.get_menu().hide();

            switch (menuItem.get_value()) {
                case "Add":
                    <%if ((permission & VTCO.Config.Constants.PERMISSION_ADD) != VTCO.Config.Constants.PERMISSION_ADD)
                    { %>
                        alert("Bạn không có quyền thêm mới chức năng!");
                        args.set_cancel(true);
                    <%} %>
                    break;
                case "Edit":
                    if (parseInt(treeNode.get_value()) == 0) {
                        alert("Bạn không thể sửa chức năng này!");
                        args.set_cancel(true);
                    }

                     <%if ((permission & VTCO.Config.Constants.PERMISSION_EDIT) != VTCO.Config.Constants.PERMISSION_EDIT)
                    { %>
                        alert("Bạn không có quyền sửa chức năng!");
                        args.set_cancel(true);
                    <%} %>
                    break;
                case "Delete":
                    if (parseInt(treeNode.get_value()) == 0) {
                        alert("Bạn không thể xóa menu này!");
                        args.set_cancel(true);
                    } else {  
                                          
                        <%if ((permission & VTCO.Config.Constants.PERMISSION_DELETE) != VTCO.Config.Constants.PERMISSION_DELETE)
                        { %>
                            alert("Bạn không có quyền xóa chức năng!");
                            args.set_cancel(true);
                        <%}else{ %>
                            var result = confirm("Bạn có muốn xóa Menu: " + treeNode.get_text() + " hay không ? ");
                            args.set_cancel(!result)
                        <%} %>
                        
                    }                    
                    break;
            }
        }
    </script>
    </telerik:RadScriptBlock>
    <div class="box" style="width: 920px">
        <div class="title">
           <span>Quản lý chức năng</span>
        </div>
        <div class="content" style="width: 918px">
            <div id="divContentMenuAdmin">
                <div style="text-align: center; margin-top: 12px;">
                    <asp:Label ID="lblMsg1" CssClass="lblMsg" BackColor="#E5EAB4" runat="server" ForeColor="Red"
                        Visible="false" Text=""></asp:Label>
                </div>
                <div>
                    <telerik:RadAjaxLoadingPanel ID="RadAjaxLoadingPanel1" runat="server" Skin="Default">
                    </telerik:RadAjaxLoadingPanel>
                    <telerik:RadAjaxManager ID="RadAjaxManager1" runat="server" DefaultLoadingPanelID="RadAjaxLoadingPanel1">
                        <AjaxSettings>                            
                            <telerik:AjaxSetting AjaxControlID="RadTreeViewMenu">
                                <UpdatedControls>                                    
                                    <telerik:AjaxUpdatedControl ControlID="RadTreeViewMenu" />
                                    <telerik:AjaxUpdatedControl ControlID="lblMsg1" />
                                    <telerik:AjaxUpdatedControl ControlID="CtrEdit" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                        <AjaxSettings>
                            <telerik:AjaxSetting AjaxControlID="CtrEdit">
                                <UpdatedControls>
                                    <telerik:AjaxUpdatedControl ControlID="CtrEdit" />
                                    <telerik:AjaxUpdatedControl ControlID="RadTreeViewMenu" />
                                </UpdatedControls>
                            </telerik:AjaxSetting>
                        </AjaxSettings>
                    </telerik:RadAjaxManager>
                </div>
                <div class="divframesystemsmenu" style="width:40%; float:left;">
                    <div id="divSystemMenu">
                        <div style="padding: 3px;">
                            <telerik:RadTreeView ID="RadTreeViewMenu" runat="server" OnContextMenuItemClick="RadTreeViewMenu_ContextMenuItemClick"
                                OnClientContextMenuItemClicking="onClientContextMenuItemClicking" Skin="Hay"
                                Font-Size="11px" Font-Names="Times New Roman">
                                <ContextMenus>
                                    <telerik:RadTreeViewContextMenu Skin="WebBlue">
                                        <Items>                                                                                    
                                            <telerik:RadMenuItem runat="server" Font-Size="13px" ImageUrl="~/BackEnd/img/action_add.gif"
                                                Text="Thêm mới" Value="Add">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Font-Size="13px" ImageUrl="~/BackEnd/img/action_check.gif"
                                                Text="Sửa" Value="Edit">
                                            </telerik:RadMenuItem>
                                            <telerik:RadMenuItem runat="server" Font-Size="13px" ImageUrl="~/BackEnd/img/action_delete.gif"
                                                Text="Xóa" Value="Delete">
                                            </telerik:RadMenuItem>
                                        </Items>
                                    </telerik:RadTreeViewContextMenu>
                                </ContextMenus>
                                <ExpandAnimation Duration="300" />
                            </telerik:RadTreeView>
                        </div>
                        <div style="clear: both">
                        </div>
                    </div>
                    <div style="clear: both">
                    </div>
                </div>

                <div id="CtrEdit" class="divframe" runat="server" visible="false" style="width:49%; float:left;">
                    <div class="divSubHeader" style="font-weight:bold; padding:20px; padding-left:100px;">
                        <asp:Label runat="server" ID="lblTitleDetails" Text="Chi tiết chức năng" Font-Size="14px"></asp:Label>
                    </div>
                    <div class="divDetailMenu">
                        <div style="margin-left: 45px; font-size: 12px;">
                            <table>
                                <tr>
                                    <td style="padding: 10px;">
                                        Menu cha:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlParentID" runat="server" CssClass="inputText" Width="187"
                                            DataTextField="Name" DataValueField="CategoryID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px;">
                                        Tên Menu:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMenuName" MaxLength="50" Width="180px" runat="server" CssClass="inputText"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr id="trUrl" runat="server">
                                    <td style="padding: 10px;">
                                        Đường dẫn
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtUrl" runat="server" CssClass="inputText" MaxLength="255"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px;">
                                        Thứ tự:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOrder" MaxLength="2" runat="server" CssClass="inputText" Width="40"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding: 10px;">
                                        Trạng thái:
                                    </td>
                                    <td>
                                        <asp:DropDownList runat="server" ID="ddlStatus">
                                            <asp:ListItem Text="Kích hoạt" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Khóa" Value="0"></asp:ListItem>
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                            </table>
                        </div>
                        <div style="margin-left: 100px; font-size: 14px;">
                            <div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ValidationGroup="Error"
                                    Display="Dynamic" ControlToValidate="txtMenuName" runat="server" ErrorMessage="(*) Bạn chưa nhập tên Menu"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ValidationGroup="Error"
                                    Display="Dynamic" ControlToValidate="txtOrder" runat="server" ErrorMessage="(*) Bạn chưa nhập thứ tự"></asp:RequiredFieldValidator>
                            </div>
                            <div>
                                <asp:RangeValidator ID="RangeValidator2" ControlToValidate="txtOrder" Display="Dynamic"
                                    MinimumValue="1" MaximumValue="20" Type="Integer" runat="server" ValidationGroup="Error"
                                    ErrorMessage="(*) Thứ tự phải kiểu số từ 1-->20"></asp:RangeValidator>
                            </div>
                        </div>
                        <br />
                        <div style="margin-left: 90px; margin-bottom: 10px">
                            <asp:Button ID="btnSave" runat="server" Text=" Cập nhật " ValidationGroup="Error" OnClick="btnSave_Click"/>
                            <asp:Button ID="btnClose" runat="server" Text=" Hủy bỏ " OnClick="btnClose_Click" />
                        </div>
                    </div>
                </div>
                <div style="clear: both">
                </div>
            </div>
        </div>
    </div>
</asp:Content>
