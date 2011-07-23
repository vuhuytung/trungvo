<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="Role.aspx.cs" Inherits="BackEnd_pages_account_Role" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<asp:Content ID="contentHead" runat="server" ContentPlaceHolderID="Header">
    <script type="text/javascript">
        $(function () {
            $("#chkAll").click(function () {
                $(".adminListRow-odd, .adminListRow-even").find("input:checkbox").attr("checked", $(this).attr("checked"));
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <center style="color: Red; line-height: 30px;">
        <asp:Label ID="lblMsg" runat="server"></asp:Label></center>
    <asp:Panel ID="pnlManager" runat="server">
        <%--Danh sách nhóm quyền--%>
        <div id="divListRole" runat="server" class="box" style="width: 920px;">
            <div class="title">
                <span style="float: left">Danh sách nhóm quyền </span>
                <asp:LinkButton ID="lbtAddNew" runat="server" CssClass="title-addnew" OnClick="lbtAddNew_Click">
                <img src="/BackEnd/img/addnew_16.png" style="vertical-align: top" alt='Thêm mới' />
                Thêm mới
                </asp:LinkButton>
            </div>
            <div class="clearn">
            </div>
            <div class="content" style="width: 100% !important">
                <asp:Repeater ID="rptRole" runat="server" OnItemCommand="rptRole_ItemCommand" OnItemDataBound="rptRole_ItemDataBound">
                    <HeaderTemplate>
                        <div class="adminListRow-Header">
                            <div class="adminColumn" style="width: 30px">
                                STT
                            </div>
                            <div class="adminColumn" style="width: 200px; padding-left: 20px; text-align: left;">
                                Tên
                            </div>
                            <div class="adminColumn" style="width: 525px; text-align: left">
                                Mô tả
                            </div>
                            <div class="adminColumn" style="width: 80px;">
                                Trạng thái
                            </div>
                            <div class="adminColumn" style="width: 80px; float: right">
                                Chức năng
                            </div>
                            <div class="clearn">
                            </div>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdfRole" runat="server" Value='<%#Eval("RoleID") %>' />
                        <div class="adminListRow-odd" id="divListRow" runat="server">
                            <div class="adminColumn" style="width: 30px; text-align: left; padding-left: 15px;">
                                <span runat="server" id="spSTT"></span>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 200px; text-align: left;">
                                <%#Eval("Name")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 525px; text-align: left">
                                <%#Eval("Description")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 80px; text-align: center;">
                                <asp:LinkButton ID="lbtLock" runat="server" CssClass='lock_icon' ToolTip='Bị khóa'
                                    CommandName="unlockNews" CommandArgument='<%#Eval("RoleID") %>'>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtUnLock" runat="server" CssClass='checked_icon' ToolTip='Đang hoạt động'
                                    CommandName="lockNews" CommandArgument='<%#Eval("RoleID") %>'>
                                </asp:LinkButton>
                            </div>
                            <div class="adminColumn" style="width: 80px; float: right">
                                <asp:LinkButton ID="lbtEdit" runat="server" CssClass="edit_icon" ToolTip="Sửa" CommandName="edit"
                                    CommandArgument='<%#Eval("RoleID") %>'>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtDelete" runat="server" CssClass="delete_icon" ToolTip="Xóa"
                                    OnClientClick="return ConfirmDelete()" CommandName="delete" CommandArgument='<%#Eval("RoleID") %>'>
                                </asp:LinkButton>&nbsp;
                            </div>
                            <div class="clearn">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <p runat="server" id="pNoRow" style="text-align: center" visible="false">
                    Không tìm thấy bản ghi nào!</p>
                <div class="clearn">
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlDetail">
        <div id="divNewsInfo" class="box" style="width: 920px">
            <div class="title">
                <span style="float: left" runat="server" id="spTitle">Chi tiết</span>
                <asp:LinkButton ID="lbtCancel" runat="server" CssClass="title-addnew" OnClick="lbtCancel_Click">
                    <img src="/BackEnd/img/cancel.png" style="vertical-align: top" alt='' />
                    Bỏ qua
                </asp:LinkButton>
                <asp:LinkButton ID="lbtSave" runat="server" CssClass="title-addnew" ValidationGroup="news"
                    OnClick="lbtSave_Click">
                    <img src="/BackEnd/img/page_save.png" style="vertical-align: top" alt='' />
                    Lưu
                </asp:LinkButton>
            </div>
            <div class="content">
                <table width="420px" class="nl">
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Tên
                        </td>
                        <td colspan="5" class="tdStyle" style="width: 320px">
                            <asp:TextBox ID="txtTitle" runat="server" Width="200px" MaxLength="100" CssClass="inputText"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ValidationGroup="news"
                                ForeColor="Red" ErrorMessage="*" ControlToValidate="txtTitle"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tdStyle" valign="top">
                            Mô tả
                        </td>
                        <td colspan="5" class="tdStyle">
                            <asp:TextBox ID="txtAbstract" runat="server" Width="320px" MaxLength="250" Height="100px"
                                CssClass="inputText" TextMode="MultiLine" Rows="2" Font-Names="Arial" Font-Size="13px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="news"
                                ForeColor="Red" ErrorMessage="*" ControlToValidate="txtAbstract"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 100px" class="tdStyle">
                            Trạng thái
                        </td>
                        <td class="tdStyle">
                            <asp:DropDownList runat="server" ID="ddlStatusEdit">
                                <asp:ListItem Value="1" Text="Hoạt động"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Khóa"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
                <div class="nr" style="width: 350px; margin-right: 20px;" runat="server" id="divListAdmin">
                    <div class="box">
                        <div class="title">
                            <span class="nl">Danh sách quản trị thuộc nhóm</span>
                            <asp:LinkButton ID="lbtAddAdmin" runat="server" CssClass="title-addnew" OnClick="lbtAddAdmin_Click">
                                <img src="/BackEnd/img/addnew_16.png" style="vertical-align: top" alt='Thêm mới' />
                                Thêm mới
                            </asp:LinkButton>
                        </div>
                        <div class="clearn">
                        </div>
                        <div class="content">
                            <asp:Repeater runat="server" ID="rptAdminInRole" OnItemCommand="rptAdminInRole_ItemCommand">
                                <HeaderTemplate>
                                    <div class="adminListRow-Header">
                                        <div class="adminColumn" style="width: 30px">
                                            STT
                                        </div>
                                        <div class="adminColumn" style="width: 200px; padding-left: 20px; text-align: left;">
                                            Tên đăng nhập
                                        </div>
                                        <div class="adminColumn" style="width: 30px; text-align: left;">
                                            &nbsp;
                                        </div>
                                    </div>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <div class="adminListRow-odd" id="divListRow" runat="server">
                                        <div class="adminColumn" style="width: 30px; text-align: left; padding-left: 15px;">
                                            <%#Eval("RowNumber") %>&nbsp;
                                        </div>
                                        <div class="adminColumn" style="width: 200px; text-align: left;">
                                            <%#Eval("UserName") %>&nbsp;
                                        </div>
                                        <div class="adminColumn" style="width: 30px; text-align: left;">
                                            <asp:LinkButton ID="lbtDelete" runat="server" CssClass="delete_icon" ToolTip="Xóa"
                                                OnClientClick="return ConfirmDelete()" CommandName="delete" CommandArgument='<%#Eval("PermissionID") %>'>
                                            </asp:LinkButton>&nbsp;
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <AlternatingItemTemplate>
                                    <div class="adminListRow-even" id="divListRow" runat="server">
                                        <div class="adminColumn" style="width: 30px; text-align: left; padding-left: 15px;">
                                            <%#Eval("RowNumber") %>&nbsp;
                                        </div>
                                        <div class="adminColumn" style="width: 200px; text-align: left;">
                                            <%#Eval("UserName") %>&nbsp;
                                        </div>
                                        <div class="adminColumn" style="width: 30px; text-align: left;">
                                            <asp:LinkButton ID="lbtDelete" runat="server" CssClass="delete_icon" ToolTip="Xóa"
                                                OnClientClick="return ConfirmDelete()" CommandName="delete" CommandArgument='<%#Eval("AdminID") %>'>
                                            </asp:LinkButton>&nbsp;
                                        </div>
                                    </div>
                                </AlternatingItemTemplate>
                                <FooterTemplate>
                                    </table>
                                </FooterTemplate>
                            </asp:Repeater>
                        </div>
                    </div>
                </div>
                <div class="clearn">
                </div>
            </div>
            <div class="content">
                <div class="box">
                    <div class="title">
                        <span>Phân quyền cho nhóm quyền</span>
                    </div>
                </div>
                <asp:Repeater runat="server" ID="rptRoleFunction" OnItemDataBound="rptRoleFunction_ItemDataBound">
                    <HeaderTemplate>
                        <table style="margin-left: 50px;">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr runat="server" id="trGroup" visible="false" style="background: #EEE;">
                            <td colspan="5" style="padding: 5px; border: solid 1px #999;">
                                <%#Eval("ParentName")%>
                            </td>
                        </tr>
                        <tr>
                            <td style="padding: 5px; border: solid 1px #999;">
                                <asp:HiddenField runat="server" ID="hdFunctionID" Value='<%#Eval("FunctionID") %>' />
                                <%#Eval("Name") %>
                            </td>
                            <td style="padding: 5px; border: solid 1px #999;">
                                <asp:CheckBox runat="server" ID="cbxView" Text=" Xem " />
                            </td>
                            <td style="padding: 5px; border: solid 1px #999;">
                                <asp:CheckBox runat="server" ID="cbxAdd" Text=" Thêm " />
                            </td>
                            <td style="padding: 5px; border: solid 1px #999;">
                                <asp:CheckBox runat="server" ID="cbxEdit" Text=" Sửa " />
                            </td>
                            <td style="padding: 5px; border: solid 1px #999;">
                                <asp:CheckBox runat="server" ID="cbxDelete" Text=" Xóa " />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div id="divPopupAddAdmin" runat="server">
            <div id="divPopupBg" class="_divPopup_bg" style="left: 0">
            </div>
            <div id="divPopup" class="_divPopup_wrapperMain" style="width: 400px;
                margin: auto; left: 220px; position: absolute;">
                <div id="divWapper" runat="server" class="_divPopup_border">
                    <div class="_divPopup_wrapper">
                        <div id="divTitle" runat="server" class="_divPopup_title">
                            <span id="spanTitleName" runat="server" class="spanText">Thêm quản trị vào nhóm quyền</span>
                            <span class="spanIcon">
                                <asp:LinkButton ID="linkClose" runat="server" CssClass="link_closeNone" OnClick="linkClose_Click">&nbsp;</asp:LinkButton>
                            </span>
                        </div>
                        <div class="_divPopup_content">
                            <div class="box">
                                <div class="title">
                                    <span>Danh sách quản trị</span>
                                </div>
                                <div class="clearn">
                                </div>
                                <div class="content">
                                    <asp:Repeater runat="server" ID="rptAdminNotInRole" OnItemCommand="rptAdminNotInRole_ItemCommand">
                                        <HeaderTemplate>
                                            <div class="adminListRow-Header">
                                                <div class="adminColumn" style="width: 30px">
                                                    STT
                                                </div>
                                                <div class="adminColumn" style="width: 200px; padding-left: 20px; text-align: left;">
                                                    Tên đăng nhập
                                                </div>
                                                <div class="adminColumn" style="width: 30px; text-align: left;">
                                                    &nbsp;
                                                </div>
                                            </div>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <div class="adminListRow-odd" id="divListRow" runat="server">
                                                <div class="adminColumn" style="width: 30px; text-align: left; padding-left: 15px;">
                                                    <%#Eval("RowNumber") %>&nbsp;
                                                </div>
                                                <div class="adminColumn" style="width: 200px; text-align: left;">
                                                    <%#Eval("UserName") %>&nbsp;
                                                </div>
                                                <div class="adminColumn" style="width: 30px; text-align: left;">
                                                    <asp:LinkButton ID="lbtAdd" runat="server" CssClass="add_icon" ToolTip="Thêm" CommandName="add"
                                                        CommandArgument='<%#Eval("AdminID") %>'>
                                                    </asp:LinkButton>&nbsp;
                                                </div>
                                            </div>
                                        </ItemTemplate>
                                        <AlternatingItemTemplate>
                                            <div class="adminListRow-even" id="divListRow" runat="server">
                                                <div class="adminColumn" style="width: 30px; text-align: left; padding-left: 15px;">
                                                    <%#Eval("RowNumber") %>&nbsp;
                                                </div>
                                                <div class="adminColumn" style="width: 200px; text-align: left;">
                                                    <%#Eval("UserName") %>&nbsp;
                                                </div>
                                                <div class="adminColumn" style="width: 30px; text-align: left;">
                                                    <asp:LinkButton ID="lbtAdd" runat="server" CssClass="add_icon" ToolTip="Thêm" CommandName="add"
                                                        CommandArgument='<%#Eval("AdminID") %>'>
                                                    </asp:LinkButton>&nbsp;
                                                </div>
                                            </div>
                                        </AlternatingItemTemplate>
                                        <FooterTemplate>
                                            </table>
                                        </FooterTemplate>
                                    </asp:Repeater>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
