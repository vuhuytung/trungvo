<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="Document.aspx.cs" Inherits="BackEnd_pages_content_Document" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <script type="text/javascript">
        function checkAdd() {
            var txtTitle = document.getElementById("<%=txtTitle.ClientID %>");
            var fupload = document.getElementById("<%=fupload.ClientID %>");
            if (txtTitle.value == "") {
                alert('Tiêu đề không được để trống !');
                return false;
            }
            else if (fupload.value == "") {
                alert('bạn chưa chọn đường dẩn tài liệu !');
                return false;
            }

            return true;
        }
        function checkAdd1() {
            var txtTitle = document.getElementById("<%=txtTitleEdit.ClientID %>");
            if (txtTitle.value == "") {
                alert('Tiêu đề không được để trống !');
                return false;
            }

            return true;
        }
    </script>
    <center style="color: Red; line-height: 30px;">
        <asp:Label ID="lblMsg" runat="server"></asp:Label></center>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <div class="box" style="width: 920px;">
            <div class="title">
                <span>Thêm mới tài liệu</span>
                <asp:LinkButton ID="lbtCancel" runat="server" CssClass="title-addnew" OnClick="btnHuy_Click">
                    <img src="/BackEnd/img/cancel.png" style="vertical-align: top" alt='' />
                    Bỏ qua
                </asp:LinkButton>
                <asp:LinkButton ID="lbtSave" runat="server" CssClass="title-addnew" OnClick="btnAdd_Click" OnClientClick="return checkAdd()">
                    <img src="/BackEnd/img/page_save.png" style="vertical-align: top" alt='' />
                    Lưu
                </asp:LinkButton>
            </div>
            <div class="content" style="width: 918px;">
                <table cellspacing="8">
                    <tr>
                        <td>
                            Tiêu đề:
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:TextBox ID="txtTitle" runat="server" Width="400" CssClass="inputText"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mô tả:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="450" Height="100"
                                CssClass="inputText"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tệp:
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:FileUpload ID="fupload" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Chuyên mục:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTypeDoc1" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Trạng thái:
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlStatusNew" runat="server" Width="80">
                                <asp:ListItem Text="Hiển thị" Value="1" />
                                <asp:ListItem Text="Ẩn" Value="0" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div class="box" style="width: 920px;">
            <div class="title">
                <span>Sửa tài liệu</span>
                 <asp:LinkButton ID="LinkButton1" runat="server" CssClass="title-addnew" OnClick="Button1_Click">
                    <img src="/BackEnd/img/cancel.png" style="vertical-align: top" alt='' />
                    Bỏ qua
                </asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="title-addnew" OnClick="btnUpdate_Click" OnClientClick="return checkAdd1()">
                    <img src="/BackEnd/img/page_save.png" style="vertical-align: top" alt='' />
                    Lưu
                </asp:LinkButton>
            </div>
            <div class="content" style="width: 918px;">
                <table cellspacing="8">
                    <tr>
                        <td>
                            Tiêu đề:
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:TextBox ID="txtTitleEdit" runat="server" CssClass="inputText" Width="400"></asp:TextBox>                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mô tả:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescEdit" runat="server" TextMode="MultiLine"  CssClass="inputText"
                                Width="450" Height="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            File:
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:FileUpload ID="fuploadEdit" runat="server" />                            
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Chuyên mục:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTypeDocEdit" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Trạng thái:
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlStatusEdit" runat="server" Width="80">
                                <asp:ListItem Text="Hiển thị" Value="1" />
                                <asp:ListItem Text="Ẩn" Value="0" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server">
        <div class="box" id="divSearch" style="width: 920px;">
            <div class="title">
                <span>Tìm kiếm tài liệu</span>
            </div>
            <div class="content" style="width: 918px;">
                <table style="width: auto; margin: auto; height: 70px;" cellspacing="5">
                    <tr>
                        <td>
                            Từ khóa:
                        </td>
                        <td>
                            <asp:TextBox runat="server" Width="150px" ID="txtKeyWord" CssClass="inputText"></asp:TextBox>
                        </td>
                        <td>
                            Loại tài liệu
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTypeDoc" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td colspan="3">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Từ ngày
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="rdpFromDate" runat="server" Calendar-CultureInfo="vi-VN"
                                DateInput-DateFormat="dd-MM-yyyy" Skin="WebBlue">
                                <Calendar ID="Calendar1" runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                    UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput ID="DateInput1" runat="server" LabelCssClass="radLabelCss_WebBlue" Skin="WebBlue">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            Đến ngày
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="rdpToDate" runat="server" Calendar-CultureInfo="vi-VN"
                                DateInput-DateFormat="dd-MM-yyyy" Skin="WebBlue">
                                <Calendar ID="Calendar2" runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                    UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput ID="DateInput2" runat="server" LabelCssClass="radLabelCss_WebBlue" Skin="WebBlue">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            Trạng thái
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="80">
                                <asp:ListItem Text="--Tất cả--" Value="-1" />
                                <asp:ListItem Text="Hiển thị" Value="1" />
                                <asp:ListItem Text="Ẩn" Value="0" />
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: center; padding: 4px 0;">
                            <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="clearn">
        </div>
        <div class="box" style="width: 920px;">
            <div class="title">
                <span style="float: left">Danh sách tài liệu</span>
                <asp:LinkButton ID="lbtAddNew" runat="server" CssClass="title-addnew" OnClick="btnThemmoi_Click">
                <img src="/BackEnd/img/addnew_16.png" style="vertical-align: top" alt='Thêm mới' />
                Thêm mới
                </asp:LinkButton>
                <asp:LinkButton ID="lbtDeleteAll" OnClientClick="return ConfirmDelete();" runat="server"
                    CssClass="title-addnew" OnClick="lbtDeleteAll_Click">
                <img src="/BackEnd/img/icon-delete.png" style="vertical-align: top" alt='Xóa' />
                Xóa
                </asp:LinkButton>
            </div>
            <div class="clearn">
            </div>
            <div class="content" style="width: 100% !important">
                <asp:Repeater ID="RptDocument" runat="server" OnItemCommand="RptDocument_ItemCommand"
                    OnItemDataBound="RptDocument_ItemDataBound">
                    <HeaderTemplate>
                        <div class="adminListRow-Header">
                            <div class="adminColumn" style="width: 20px;">
                                <input type="checkbox" id="chkAll" />
                            </div>
                            <div class="adminColumn" style="width: 30px">
                                STT
                            </div>
                            <div class="adminColumn" style="width: 500px; margin-left: 20px; text-align: left;">
                                Tên tài liệu
                            </div>
                            <div class="adminColumn" style="width: 80px;">
                                Cập nhật
                            </div>
                            <div class="adminColumn" style="width: 80px;">
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
                            <div class="adminColumn" id="divCheckbox" style="width: 20px; vertical-align: bottom;">
                                <asp:CheckBox ID="chkDeleteAll" runat="server" />
                                <asp:HiddenField ID="hdID" runat="server" Value='<%#Eval("DocumentID") %>' />
                            </div>
                            <div class="adminColumn" style="width: 30px;">
                                <%#Eval("RowNumber")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 520px; text-align: left">
                                <%#Eval("Title") %>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 80px;">
                                <%#Convert.ToDateTime(Eval("CreateDate")).ToString("dd/MM/yyyy")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 80px;">
                                <%#Convert.ToBoolean(Eval("Status")??false)?"Hoạt động":"Bị khóa" %>&nbsp;
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
                                                        CommandArgument='<%#Eval("DocumentID") %>' Text="Sửa">
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="lbtLock" runat="server" CssClass='lock_icon' ToolTip='Khóa' CommandName="lockNews"
                                                        CommandArgument='<%#Eval("DocumentID") %>' Text="Khóa">
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="lbtUnLock" runat="server" CssClass='checked_icon' ToolTip='Kích hoạt'
                                                        CommandName="unlockNews" CommandArgument='<%#Eval("DocumentID") %>' Text="Kích hoạt">
                                                    </asp:LinkButton>
                                                </li>
                                                <%}%>
                                                <%if ((permission & VTCO.Config.Constants.PERMISSION_DELETE) == VTCO.Config.Constants.PERMISSION_DELETE)
                                                  { %>
                                                <li>
                                                    <asp:LinkButton ID="lbtDelete" runat="server" CssClass="delete_icon" ToolTip="Xóa"
                                                        OnClientClick="return ConfirmDelete()" CommandName="delete" CommandArgument='<%#Eval("DocumentID") %>'
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
                <div class="clearn">
                </div>
                <div id="divPaging" runat="server" class="paginator2 nr">
                    <uc1:ucPaging ID="ucPaging1" runat="server" />
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
