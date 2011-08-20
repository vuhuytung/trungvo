<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="Document.aspx.cs" Inherits="BackEnd_pages_content_Document" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center style="color: Red; line-height: 30px;">
        <asp:Label ID="lblMsg" runat="server"></asp:Label></center>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <div class="box_hide">
            <div class="MK_edit">
                <div class="Edit_Title">
                    <a>Thêm mới tài liệu</a>
                </div>
                <table cellspacing="8" class="tbDoc_my">
                    <tr>
                        <td>
                            Tiêu đề:
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:TextBox ID="txtTitle" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mô tả:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Width="250" Height="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            File
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:FileUpload ID="fupload" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Chuyên mục
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTypeDoc1" runat="server">
                                <asp:ListItem Text="Bảng giá đất nhà nước" Value="21" />
                                <asp:ListItem Text="Văn kiện liên quan đến BĐS" Value="22" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Trạng thái hiển thị
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:CheckBox ID="chkstatus" BackColor="red" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding: 10px 100px;">
                            <script type="text/javascript">
                                function checkAdd() {
                                    var txtTitle = document.getElementById("ContentPlaceHolder1_txtTitle");
                                    var fupload = document.getElementById("ContentPlaceHolder1_fupload");
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
                            </script>
                            <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" OnClientClick="return checkAdd()"
                                Width="70" />
                            <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" Width="70" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div class="box_hide">
            <div class="MK_edit">
                <div class="Edit_Title">
                    <a>Sửa thông tin</a>
                </div>
                <asp:Repeater ID="RptDetail" runat="server">
                    <HeaderTemplate>
                        <table cellspacing="8" class="tbDoc_my">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                Tiêu đề:
                            </td>
                            <td style="padding: 5px 0;">
                                <asp:TextBox ID="txtTitle" runat="server" Text='<%#Eval("Title")%>' Width="250"></asp:TextBox>
                                <asp:Label ID="lblDocID" runat="server" Text='<%#Eval("DocumentID") %>' Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Mô tả:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Text='<%# HttpUtility.HtmlDecode(Eval("Description").ToString()).Replace("</br>", "\n") %>'
                                    Width="250" Height="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                File
                            </td>
                            <td style="padding: 5px 0;">
                                <asp:FileUpload ID="fupload" runat="server" />
                                <asp:Label ID="lblUrl" runat="server" Text='<%#Eval("URL") %>' Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Chuyên mục
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTypeDoc" runat="server">
                                    <asp:ListItem Text="Bảng giá đất nhà nước" Value="21" />
                                    <asp:ListItem Text="Văn kiện liên quan đến BĐS" Value="22" />
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Trạng thái hiển thị
                            </td>
                            <td style="padding: 5px 5px;">
                                <asp:CheckBox ID="chkstatus" BackColor="red" runat="server" Checked=' <%#Convert.ToBoolean(Eval("Status")) %>' />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding: 10px 100px;">
                                <script type="text/javascript">
                                    function checkAdd1() {
                                        var txtTitle = document.getElementById("ContentPlaceHolder1_RptDetail_txtTitle_0");
                                        if (txtTitle.value == "") {
                                            alert('Tiêu đề không được để trống !');
                                            return false;
                                        }

                                        return true;
                                    }
                                </script>
                                <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click"
                                    OnClientClick="return checkAdd1()" Width="70" />
                                <asp:Button ID="Button1" runat="server" Text="Hủy" OnClick="Button1_Click" Width="70" />
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server">
        <div class="box" id="divSearch" style="width: 920px;">
            <div class="title">
                <span>Tìm kiếm tài liệu</span>
            </div>
            <div class="content" style="width: 918px;">
                <table style="width: auto; margin: auto; height: 70px;">
                    <tr>
                        <td>
                            Loại tài liệu
                        </td>
                        <td style="padding: 4px 15px;">
                            <asp:DropDownList ID="ddlTypeDoc" runat="server">
                                <asp:ListItem Text="Bảng giá đất nhà nước" Value="21" />
                                <asp:ListItem Text="Văn kiện liên quan đến BĐS" Value="22" />
                            </asp:DropDownList>
                        </td>
                        <td style="padding: 4px 10px;">
                            Ngày tạo
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Calendar-CultureInfo="vi-VN"
                                DateInput-DateFormat="dd-MM-yyyy" Skin="WebBlue">
                                <Calendar ID="Calendar1" runat="server" Skin="WebBlue" UseColumnHeadersAsSelectors="False"
                                    UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                </Calendar>
                                <DateInput ID="DateInput1" runat="server" LabelCssClass="radLabelCss_WebBlue" Skin="WebBlue">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td style="padding: 4px 15px;">
                            Trạng thái
                        </td>
                        <td style="padding: 4px 15px;">
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="80">
                                <asp:ListItem Text="Tất cả" Value="2" Selected="True" />
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
                        <table cellspacing="0" class="tbl_doc" style="float: left; width:100%;">
                            <thead>
                                <tr class="adminListRow-Header">
                                    <td style="width: 20px;">
                                        <input type="checkbox" id="chkAll" />
                                    </td>
                                    <td style="width: 20px;">
                                        STT
                                    </td>
                                    <td>
                                        Tên tài liệu
                                    </td>
                                    <td>
                                        Ngày tạo
                                    </td>
                                    <td class="td1">
                                        Trạng thái
                                    </td>
                                    <td class="td1">
                                        Chức năng
                                    </td>
                                </tr>
                            </thead>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr runat="server" id="listRow">
                            <td>
                                <asp:CheckBox ID="chkDeleteAll" runat="server" />
                                <asp:HiddenField ID="hdID" runat="server" Value='<%#Eval("DocumentID") %>' />
                                <asp:HiddenField ID="hdFile" runat="server" Value='<%#Eval("Url") %>' />
                            </td>
                            <td>
                                <%#Eval("RowNumber")%>
                            </td>
                            <td style="width: 500px; text-align: left;">
                                <%#Eval("Title") %>
                            </td>
                            <td>
                                <%#Convert.ToDateTime(Eval("CreateDate")).ToString("dd-MM-yyyy")%>
                            </td>
                            <td class="td2">
                                <%#Convert.ToBoolean(Eval("Status")??false)?"Hoạt động":"Bị khóa" %>
                            </td>
                            <td class="td2">
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
                                                    <asp:LinkButton ID="lbtLock" runat="server" CssClass='lock_icon' ToolTip='Khóa'
                                                        CommandName="lockNews" CommandArgument='<%#Eval("DocumentID") %>' Text="Khóa">
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
                                                        OnClientClick="return ConfirmDelete()" CommandName="delete" CommandArgument='<%#Eval("DocumentID") %>' Text="Xóa">
                                                    </asp:LinkButton>
                                                </li>
                                                <%} %>
                                            </ul>
                                        </li>
                                    </ul>
                                </div>
                            <%} %>
                            </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div id="divPaging" runat="server" class="paginator2 nr">
            <uc1:ucPaging ID="ucPaging1" runat="server" />
        </div>
    </asp:Panel>
</asp:Content>
