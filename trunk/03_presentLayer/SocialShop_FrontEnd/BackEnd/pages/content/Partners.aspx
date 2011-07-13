<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="Partners.aspx.cs" Inherits="BackEnd_pages_content_Partners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <div class="box_hide">
            <div class="box_edit">
                <table cellspacing="8">
                    <tr>
                        <td colspan="2" style="text-align: center; padding: 5px 0;">
                            <a style="color: Red; font-size: 16px;">Thêm đối tác mới</a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Name:
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:TextBox ID="txtName" runat="server" Width="150"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Logo:
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:FileUpload ID="fuploadLogo" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Website đối tác
                        </td>
                        <td>
                            <asp:TextBox ID="txtWeb" runat="server"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Trạng thái:
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:CheckBox ID="chkstatus" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding: 10px 100px;">
                            <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" Width="70" />
                            <asp:Button ID="btnHuy" runat="server" Text="Thoát" OnClick="btnHuy1_Click" Width="70" />
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
                                <a style="color: Red; font-size: 16px;">Sửa thông tin</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Name:
                            </td>
                            <td>
                                <asp:TextBox ID="txtName" runat="server" Text='<%#Eval("Name") %>' Width="250"></asp:TextBox>
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("PartnersID") %>' Visible="false"></asp:Label>
                                <asp:Label ID="lblImg" runat="server" Text='<%#Eval("Img") %>' Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Logo mới:
                            </td>
                            <td style="padding: 5px 0;">
                                <asp:FileUpload ID="fupload" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Website đối tác:
                            </td>
                            <td style="padding: 5px 5px;">
                                <asp:TextBox ID="txtWeb" runat="server" Text='<%#Eval("Website") %>' Width="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Trạng thái hiển thị
                            </td>
                            <td style="padding: 5px 15px;">
                                <asp:CheckBox ID="chkstatus" BackColor="red" runat="server" Checked=' <%#Eval("Status") %>' />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding: 10px 100px;">
                                <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click"
                                    Width="70" />
                                <asp:Button ID="btnHuy" runat="server" Text="Thoát" OnClick="btnHuy_Click" Width="70" />
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
    <div class="box_body">
        <div style="text-align: center; width: 100%; float: left;">
            <h1 style="color: Blue;">
                Quản lý đối tác của công ty</h1>
        </div>
        <div class="doc_content" style="float: left; width: 100%;">
            <div style="padding: 5px 0 10px 100px;">
                <asp:Button ID="btnThemmoi" runat="server" OnClick="btnThemmoi_Click" Text="Thêm mới đối tác của công ty" />
            </div>
            <asp:Repeater ID="RptPartner" runat="server" OnItemCommand="RptPartner_ItemCommand">
                <HeaderTemplate>
                    <table cellspacing="0" class="tbl_doc">
                        <thead>
                            <tr>
                                <td>
                                    TT
                                </td>
                                <td>
                                    Tiêu đề
                                </td>
                                <td>
                                    Trạng thái hiển thị
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
                        </td>
                        <td style="width: 500px;">
                            <div class="img_thumb">
                                <img src='<%#Eval("Img")%>' alt="anh" width="50" height="40" />
                            </div>
                            <div class="title_slide">
                                <a>
                                    <%#Eval("Name") %></a>
                            </div>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkStatus" Checked='<%#Eval("Status") %>' runat="server" Enabled="false" />
                        </td>
                        <td class="td2">
                            <asp:LinkButton ID="lbtEdit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("PartnersID") %>'>Sửa</asp:LinkButton>
                        </td>
                        <td class="td2">
                            <script type="text/javascript">
                                function confirm1() {
                                    return confirm("Bạn có muốn xóa Record này ko ?");
                                }
                            </script>
                            <asp:LinkButton ID="lbtDelete" CssClass="xoa" runat="server" CommandName="Delete"
                                OnClientClick="return confirm1()" CommandArgument='<%#Eval("PartnersID") %>'>Xóa</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>
