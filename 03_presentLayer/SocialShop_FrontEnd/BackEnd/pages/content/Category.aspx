<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="Category.aspx.cs" Inherits="BackEnd_pages_content_Category" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <script type="text/javascript">
        function onClientContextMenuItemClicking(sender, args) {
            var menuItem = args.get_menuItem();
            var treeNode = args.get_node();
            menuItem.get_menu().hide();

            switch (menuItem.get_value()) {
                case "Add":
                    break;
                case "Edit":
                    break;
                case "Delete":
                    var result = confirm("Bạn có muốn xóa Menu: " + treeNode.get_text() + " hay không ? ");
                    args.set_cancel(!result)
                    break;
            }
        }
    </script>
    <div class="box" style="width: 920px">
        <div class="title">
            Hệ thống quản lý Menu
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

                <div id="CtrEdit" class="divframe" runat="server" visible="false" style="width:49%; float:right;">
                    <div class="divSubHeader">
                        Chi tiết Menu
                    </div>
                    <div class="divDetailMenu">
                        <div style="margin-left: 45px; font-size: 12px;">
                            <table>
                                <tr>
                                    <td style="padding-top: 10px;">
                                        Menu cha:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlParentID" runat="server" CssClass="inputText" Width="187"
                                            DataTextField="Name" DataValueField="CategoryID">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 10px;">
                                        Tên Menu:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtMenuName" MaxLength="35" runat="server" CssClass="inputText"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 10px">
                                        Loại Menu:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlMenuType" runat="server" CssClass="inputText" Width="187"
                                            OnSelectedIndexChanged="ddlMenuType_SelectedIndexChanged1" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr id="Url">
                                    <td>
                                        <asp:Label ID="lblUrl" runat="server" Text="Nhập Url:"></asp:Label>
                                    </td>
                                    <td colspan="2">
                                        <asp:TextBox ID="txtUrl" runat="server" CssClass="inputText" MaxLength="255"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 10px">
                                        Thứ tự:
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtOrder" MaxLength="2" runat="server" CssClass="inputText" Width="40"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="padding-top: 10px; padding-bottom: 15px">
                                        Trạng thái:
                                    </td>
                                    <td>
                                        <asp:RadioButton ID="rdbActive" runat="server" GroupName="status" Text="Kích hoạt" />
                                        <asp:RadioButton ID="rdbNoActive" runat="server" GroupName="status" Text="Khóa" />
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
                            <div>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="(*) Bạn chưa nhập đường dẫn"
                                    ControlToValidate="txtUrl" ValidationGroup="Error" Display="Dynamic"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <br />
                        <div style="margin-left: 90px; margin-bottom: 10px">
                            <asp:Button ID="btnSave" CssClass="button" runat="server" ValidationGroup="Error"
                                OnClick="btnSave_Click" BorderStyle="None" />
                            <asp:Button ID="btnCancel" CssClass="button" runat="server" Text="Hủy" OnClick="btnCancel_Click"
                                BorderStyle="None" />
                            <asp:Button ID="btnClose" CssClass="button" runat="server" Text="Đóng" OnClick="btnClose_Click"
                                BorderStyle="None" />
                        </div>
                    </div>
                </div>
                <div style="clear: both">
                </div>
            </div>
            <asp:TreeView runat="server" ID="trvCategory">
            </asp:TreeView>
        </div>
    </div>
</asp:Content>
