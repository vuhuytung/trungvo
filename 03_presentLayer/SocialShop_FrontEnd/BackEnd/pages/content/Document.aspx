<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="Document.aspx.cs" Inherits="BackEnd_pages_content_Document" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="box_body">
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <div class="box_hide">
                <div class="box_edit">
                    <table cellspacing="8">
                        <tr>
                            <td colspan="2" style="text-align: center; padding: 5px 0;">
                                <asp:Label ID="lblTitle" runat="server" Text="Thêm mới tài liệu" Font-Size="18px"
                                    ForeColor="red"></asp:Label>
                            </td>
                        </tr>
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
                                <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" Width="70" />
                                <asp:Button ID="btnHuy" runat="server" Text="Hủy" OnClick="btnHuy_Click" Width="70" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div class="box_hide">
                <div class="box_edit">
                    <asp:Repeater ID="RptDetail" runat="server">
                        <HeaderTemplate>
                            <table cellspacing="8">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td colspan="2" style="text-align: center; padding: 5px 0;">
                                    <asp:Label ID="lblTitle" runat="server" Text="Sửa thông tin" Font-Size="18px" ForeColor="red"></asp:Label>
                                </td>
                            </tr>
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
                                    <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click"
                                        Width="70" />
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
        <div style="text-align: center; width: 900px; float: left;">
            <h1 style="color: Blue;">
                Quản lý tài liệu</h1>
        </div>
        <div class="box" id="divSearch" style="width: 940px; float: left;">
            <div class="title" style="width: 960px;">
                <span>Tìm kiếm tài liệu</span>
            </div>
            <div class="content">
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
        <div class="doc_content" style="float: left; width: 100%;">
            <div class="box">
                <div class="title" style="width: 960px;">
                    <span>Danh sach tài liệu</span>
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
                <div class="content">
                    <asp:Repeater ID="RptDocument" runat="server" OnItemCommand="RptDocument_ItemCommand"
                        OnItemDataBound="RptDocument_ItemDataBound">
                        <HeaderTemplate>
                            <table cellspacing="0" class="tbl_doc" width="100%">
                                <thead>
                                    <tr>
                                        <td style="width: 20px;">
                                        </td>
                                        <td style="width: 20px;">
                                            TT
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
                            <tr>
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
                                    <asp:CheckBox ID="chkStatus" runat="server" Checked='<%#Convert.ToBoolean(Eval("Status")) %>' />
                                </td>
                                <td class="td2">
                                    <asp:LinkButton ID="lbtEdit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("DocumentID") %>'
                                        CssClass="edit_icon" ToolTip="Sửa"></asp:LinkButton>
                                    <script type="text/javascript">
                                        function confirm1() {
                                            return confirm("Bạn có muốn xóa Record này ko ?");
                                        }
                                    </script>
                                    <asp:LinkButton ID="lbtDelete" runat="server" CommandName="Delete" OnClientClick="return confirm1()"
                                        CommandArgument='<%#Eval("DocumentID") %>' ToolTip="Xóa" CssClass="delete_icon"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
        <div id="divPaging" runat="server" class="paginator2 nr">
            <uc1:ucPaging ID="ucPaging1" runat="server" />
        </div>
    </div>
</asp:Content>
