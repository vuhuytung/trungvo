<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="User.aspx.cs" Inherits="BackEnd_pages_account_User" %>

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
        <div id="divSearch" class="box" style="width: 920px">
            <div class="title">
                <span>Quản lý người dùng</span>
            </div>
            <div class="content" style="width: 918px">
                <table style="width: auto; margin: auto; height: 70px;">
                    <tr>
                        <td style="width: 80px;">
                            Tài khoản:
                        </td>
                        <td style="width: 220px;" colspan="2">
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="inputbox" Width="200px"></asp:TextBox>
                        </td>
                        <td style="width: 80px">
                            Trạng thái:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="150px">
                                <asp:ListItem Text="Tất cả" Value="-1"></asp:ListItem>
                                <asp:ListItem Text="Kích hoạt" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Khóa" Value="0"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 80px">
                            <div style="float: right; padding-left: 20px">
                                <asp:Button ID="btnSearch" runat="server" Text=" Tìm kiếm " ToolTip="Tìm kiếm" OnClick="btnSearch_Click" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%--Danh sách tin tức--%>
        <div id="divListNews" runat="server" class="box" style="width: 920px;">
            <div class="title">
                <span style="float: left">Danh sách người dùng</span>
            </div>
            <div class="clearn">
            </div>
            <div class="content" style="width: 100% !important">
                <asp:Repeater ID="rptAdmin" runat="server" OnItemCommand="rptAdmin_ItemCommand" OnItemDataBound="rptAdmin_ItemDataBound">
                    <HeaderTemplate>
                        <div class="adminListRow-Header">
                            <div class="adminColumn" style="width: 30px">
                                STT
                            </div>
                            <div class="adminColumn" style="width: 150px; text-align: left;">
                                Tài khoản
                            </div>
                            <div class="adminColumn" style="width: 180px; text-align: left;">
                                Họ và tên
                            </div>
                            <div class="adminColumn" style="width: 80px; text-align: left;">
                                Ngày sinh
                            </div>
                            <div class="adminColumn" style="width: 180px; text-align: left;">
                                Email
                            </div>
                            <div class="adminColumn" style="width: 100px; text-align: left;">
                                Điện thoại
                            </div>
                            <div class="adminColumn" style="width: 70px;">
                                Trạng thái
                            </div>
                            <div class="adminColumn" style="width: 92px; float: right">
                                &nbsp;
                            </div>
                            <div class="clearn">
                            </div>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="adminListRow-odd" id="divListRow" runat="server">
                            <div class="adminColumn" style="width: 30px; text-align: left; padding-left: 15px;">
                                <%#Eval("RowNumber")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 150px; text-align: left;">
                                <%#VTCO.Library.HtmlUtility.HtmlEncode(Eval("UserName").ToString())%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 180px; text-align: left;">
                                <%#Eval("FullName")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 80px; text-align: left;">
                                <%#Convert.ToDateTime(Eval("Birthday")).ToString("dd/MM/yyyy")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 180px; text-align: left;">
                                <%#Eval("Email") %>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 100px; text-align: left;">
                                <%#Eval("Phone") %>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 70px; text-align: center;">
                                <%#Convert.ToBoolean(Eval("Status")??false)?"Hoạt động":"Bị khóa" %>
                            </div>
                            <div class="adminColumn" style="width: 92px; float: right">
                            <%if ((permission | VTCO.Config.Constants.PERMISSION_READ) != VTCO.Config.Constants.PERMISSION_READ)
                              { %>
                                <div class="function">
                                    <ul>
                                        <li><a id="aContextMenu" href="javascript:;"><span style="float: left;">Chức năng</span>
                                            <span class="drop">
                                                <img src="/BackEnd/img/down.gif" /></span>
                                            <div class="clear">
                                            </div>
                                        </a>
                                            <ul class="context-menu">
                                                <%if ((permission & VTCO.Config.Constants.PERMISSION_EDIT) == VTCO.Config.Constants.PERMISSION_EDIT)
                                                  { %>
                                                <li>
                                                    <asp:LinkButton ID="lbtEdit" runat="server" CssClass="edit_icon" ToolTip="Sửa" CommandName="edit"
                                                        CommandArgument='<%#Eval("UserID") %>' Text="Sửa">
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="lbtLock" runat="server" CssClass='lock_icon' ToolTip='Khóa'
                                                        CommandName="lockNews" CommandArgument='<%#Eval("UserID") %>' Text="Khóa">
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="lbtUnLock" runat="server" CssClass='checked_icon' ToolTip='Kích hoạt'
                                                        CommandName="unlockNews" CommandArgument='<%#Eval("UserID") %>' Text="Kích hoạt">
                                                    </asp:LinkButton>
                                                </li>
                                                <%}%>
                                                <%if ((permission & VTCO.Config.Constants.PERMISSION_DELETE) == VTCO.Config.Constants.PERMISSION_DELETE)
                                                  { %>
                                                <li>
                                                    <asp:LinkButton ID="lbtDelete" runat="server" CssClass="delete_icon" ToolTip="Xóa"
                                                        OnClientClick="return ConfirmDelete()" CommandName="delete" CommandArgument='<%#Eval("UserID") %>' Text="Xóa">
                                                    </asp:LinkButton>
                                                </li>
                                                <%} %>
                                            </ul>
                                        </li>
                                    </ul>
                                </div>
                                <%} %>
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
                <div id="divPaging" runat="server" class="paginator2 nr">
                    <uc1:ucPaging ID="ucPaging1" runat="server" />
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
                <table>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Tên đăng nhập:
                        </td>
                        <td style="width: 160px" class="tdStyle" colspan="2">
                            <asp:Label ID="lblUserName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Tên đầy đủ:
                        </td>
                        <td style="padding-top: 12px;" class="tdStyle" colspan="2">
                            <asp:Label ID="lblFullName" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Email:
                        </td>
                        <td class="tdStyle">
                            <asp:Label ID="lblEmail" runat="server"></asp:Label>
                        </td>
                        <td style="" class="tdStyle" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Địa chỉ:
                        </td>
                        <td class="tdStyle">
                            <asp:Label ID="lblAddress" runat="server"></asp:Label>
                        </td>
                        <td style="" class="tdStyle" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Điện thoại:
                        </td>
                        <td class="tdStyle">
                            <asp:Label ID="lblPhone" runat="server"></asp:Label>
                        </td>
                        <td class="tdStyle">
                            Ngày đăng ký:
                        </td>
                        <td class="tdStyle">
                            <asp:Label runat="server" ID="lblCreateDate"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Ngày sinh:
                        </td>
                        <td class="tdStyle">
                            <asp:Label ID="lblBirthday" runat="server"></asp:Label>
                        </td>
                        <td class="tdStyle">
                            Trạng thái:
                        </td>
                        <td class="tdStyle">
                            <asp:DropDownList runat="server" ID="ddlStatusEdit">
                                <asp:ListItem Value="1" Text="Hoạt động"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Khóa"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>                    
                </table>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
