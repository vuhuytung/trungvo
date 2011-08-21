<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="BackEnd_pages_content_Contact" %>

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
                <span>Quản lý phản hồi</span>
            </div>
            <div class="content" style="width: 918px">
                <table style="width: auto; margin: auto; height: 70px;">                   
                    <tr>
                        <td style="width: 80px">
                            Từ ngày:
                        </td>
                        <td style="width: 200px">
                            <div style="width: 150px">
                                <telerik:RadDatePicker ID="rdpFromDate" runat="server" Culture="vi-VN" Skin="WebBlue">
                                </telerik:RadDatePicker>
                            </div>
                        </td>
                        <td style="width: 80px">
                            Đến ngày:
                        </td>
                        <td style="width: 200px">
                            <div style="width: 150px">
                                <telerik:RadDatePicker ID="rdpToDate" runat="server" Culture="vi-VN" Skin="WebBlue">
                                </telerik:RadDatePicker>
                            </div>
                        </td>
                        <td style="width: 70px">
                            Trạng thái:
                        </td>
                        <td style="width: 90px">
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="80px">
                                <asp:ListItem Value="-1" Text="Tất cả"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Đã đọc"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Chưa đọc"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 80px">
                            <div style="float: right; padding-left: 20px">
                                <asp:Button ID="btnSearch" runat="server" Text=" Tìm kiếm " ToolTip="Tìm kiếm" OnClick="btnSearch_Click1" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%--Danh sách tin tức--%>
        <div id="divListNews" runat="server" class="box" style="width: 920px;">
            <div class="title">
                <span style="float: left">Danh sách phản hồi </span>
                <asp:LinkButton ID="lbtDeleteAll" OnClientClick="return ConfirmDelete();" runat="server"
                    CssClass="title-addnew" OnClick="lbtDeleteAll_Click">
                <img src="/BackEnd/img/icon-delete.png" style="vertical-align: top" alt='Xóa' />
                Xóa
                </asp:LinkButton>
            </div>
            <div class="clearn">
            </div>
            <div class="content" style="width: 100% !important">
                <asp:Repeater ID="rptAllNews" runat="server" OnItemCommand="rptAllNews_ItemCommand"
                    OnItemDataBound="rptAllNews_ItemDataBound">
                    <HeaderTemplate>
                        <div class="adminListRow-Header">
                            <div class="adminColumn" style="width: 20px;">
                                <input type="checkbox" id="chkAll" />
                            </div>
                            <div class="adminColumn" style="width: 30px">
                                STT
                            </div>
                            <div class="adminColumn" style="width: 460px; padding-left: 20px; text-align: left;">
                                Nội dung
                            </div>
                            <div class="adminColumn" style="width: 80px;">
                                Ngày tạo
                            </div>
                            <div class="adminColumn" style="width: 200px;">
                                Người gửi
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
                            <div class="adminColumn" id="divCheckbox" style="width: 20px; vertical-align: bottom;">
                                <asp:CheckBox ID="cbxCheck" runat="server" />&nbsp;
                                <asp:HiddenField runat="server" ID="hdNewsID" Value='<%#Eval("ContactID")%>' />
                            </div>
                            <div class="adminColumn" style="width: 30px; text-align: left; padding-left: 15px;">
                                <%#Eval("RowNumber")%>&nbsp;
                            </div>
                            <div class="adminColumn" style='width: 460px; text-align: justify; font-weight:<%#Convert.ToBoolean(Eval("Status"))?"normal":"bold" %>'>                                
                                <%#Eval("Description")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 80px">
                                <%#Convert.ToDateTime(Eval("CreateDate")).ToString("dd/MM/yyyy")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 200px; text-align:left">
                                - Họ tên: <%#Eval("FullName") %>&nbsp;<br />
                                - Địa chỉ: <%#Eval("Address") %>&nbsp;<br />
                                - Điện thoại: <%#Eval("Phone") %>&nbsp;<br />
                                - Email: <%#Eval("Email") %>&nbsp;
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
                                                    <asp:LinkButton ID="lbtUnLock" runat="server" CssClass='checked_icon' ToolTip='Đánh dấu đã đọc'
                                                        CommandName="unlockNews" CommandArgument='<%#Eval("ContactID") %>' Text="Đánh dấu đã đọc">
                                                    </asp:LinkButton>
                                                </li>
                                                <%}%>
                                                <%if ((permission & VTCO.Config.Constants.PERMISSION_DELETE) == VTCO.Config.Constants.PERMISSION_DELETE)
                                                  { %>
                                                <li>
                                                    <asp:LinkButton ID="lbtDelete" runat="server" CssClass="delete_icon" ToolTip="Xóa"
                                                        OnClientClick="return ConfirmDelete()" CommandName="delete" CommandArgument='<%#Eval("ContactID") %>'
                                                        Text="Xóa">
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
</asp:Content>
