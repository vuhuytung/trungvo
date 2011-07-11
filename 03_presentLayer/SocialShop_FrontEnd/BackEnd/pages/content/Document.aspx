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
        <div style="text-align: center; width: 100%; float: left;">
            <h1 style="color: Blue;">
                Quản lý tài liệu</h1>
        </div>
        <div class="box_search">
            <h3>
                Tìm kiếm</h3>
            <table cellspacing="7">
                <tr>
                    <td>
                        Loại tài liệu
                    </td>
                    <td style="padding: 4px 5px;">
                        <asp:DropDownList ID="ddlTypeDoc" runat="server">
                            <asp:ListItem Text="Bảng giá đất nhà nước" Value="21" />
                            <asp:ListItem Text="Văn kiện liên quan đến BĐS" Value="22" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="padding: 4px 0;">
                        Ngày tạo
                    </td>
                    <td>
                        <telerik:RadDatePicker ID="RadDatePicker1" runat="server" Calendar-CultureInfo="vi-VN" DateInput-DateFormat="dd-MM-yyyy">
                        </telerik:RadDatePicker>
                    </td>
                </tr>
                <tr>
                    <td>
                        Trạng thái
                    </td>
                    <td style="padding: 4px 5px;">
                        <asp:DropDownList ID="ddlStatus" runat="server" Width="80">
                            <asp:ListItem Text="Tất cả" Value="2" Selected="True" />
                            <asp:ListItem Text="Hiển thị" Value="1" />
                            <asp:ListItem Text="Ẩn" Value="0" />
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align: center; padding: 4px 0;">
                        <asp:Button ID="btnSearch" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <div class="doc_content" style="float: left; width: 100%;">
            <div style="padding: 5px 0 10px 100px;">
                <asp:Button ID="btnThemmoi" runat="server" OnClick="btnThemmoi_Click" Text="Thêm mới tài liệu" />
            </div>
            <asp:Repeater ID="RptDocument" runat="server" OnItemCommand="RptDocument_ItemCommand">
                <HeaderTemplate>
                    <table cellspacing="0" class="tbl_doc">
                        <thead>
                            <tr>
                                <td>
                                    TT
                                </td>
                                <td>
                                    Tên tài liệu
                                </td>
                                <td>
                                    Ngày tạo
                                </td>
                                <td class="td1">
                                    Chi tiết
                                </td>
                                <td class="td1">
                                    Sửa
                                </td>
                                <td class="td1">
                                    Xóa
                                </td>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%#Eval("RowNumber")%>
                        </td>
                        <td style="width: 500px;">
                            <%#Eval("Title") %>
                        </td>
                        <td>
                            <%#Convert.ToDateTime(Eval("CreateDate")).ToString("dd-MM-yyyy")%>
                        </td>
                        <td class="td2">
                            <asp:LinkButton ID="lbtDetail" runat="server" CommandName="Detail" CommandArgument='<%#Eval("DocumentID") %>'>Chi tiết</asp:LinkButton>
                        </td>
                        <td class="td2">
                            <asp:LinkButton ID="lbtEdit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("DocumentID") %>'>Sửa</asp:LinkButton>
                        </td>
                        <td class="td2">
                            <script type="text/javascript">
                                function confirm1() {
                                    return confirm("Bạn có muốn xóa Record này ko ?");
                                }
                            </script>
                            <asp:LinkButton ID="lbtDelete" CssClass="xoa" runat="server" CommandName="Delete"
                                OnClientClick="return confirm1()" CommandArgument='<%#Eval("DocumentID") %>'>Xóa</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <div id="divPaging" runat="server" class="paginator2 nr">
            <uc1:ucPaging ID="ucPaging1" runat="server" />
        </div>
    </div>
</asp:Content>
