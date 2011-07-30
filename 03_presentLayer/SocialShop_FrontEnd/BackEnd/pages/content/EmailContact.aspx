<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="EmailContact.aspx.cs" Inherits="BackEnd_pages_content_EmailContact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="Header" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box_body">
        <div style="text-align: center; width: 100%; float: left; padding-top: 10px;">
            <a style="font-size: 24px;">Quản lý Email</a>
        </div>
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <div class="box_hide">
                <div class="MK_edit">
                 <div class="Edit_Title">
                        <a>Thêm mới Email</a>
                    </div>
                    <table cellspacing="8" class="tbDoc_my">
                        
                        <tr>
                            <td>
                                Email:
                            </td>
                            <td style="padding: 5px 0;">
                                <asp:TextBox ID="txtEmail" runat="server" Width="150"></asp:TextBox>
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
                                <script type="text/javascript">
                                    function checkAdd() {
                                        var txtEmail = document.getElementById("ContentPlaceHolder1_txtEmail");

                                        if (txtEmail.value == "") {
                                            alert('Email được để trống !');
                                            return false;
                                        }
                                        else {
                                            if (!CheckMail(txtEmail.value)) {
                                                alert('Email không đúng định dạng!');
                                                return false;
                                            }
                                        }
                                        return true;
                                    }
                                    function CheckMail(str) {
                                        var RegExEmail = new RegExp("^[0-9a-z\\._]+@[0-9a-z]+\\..+$", "i");
                                        return RegExEmail.test(str);
                                    }
                                </script>
                                <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" OnClientClick="return checkAdd()"
                                    Width="70" />
                                <asp:Button ID="btnHuy" runat="server" Text="Thoát" OnClick="btnHuy1_Click" Width="70" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server">
            <div class="box" style="width: 940px; float: left;">
                <div class="title" style="width: 940px;">
                    <span>Danh sách Email</span>
                    <asp:LinkButton ID="lbtAddNew" runat="server" CssClass="title-addnew" OnClick="btnThemmoi_Click">
                <img src="/BackEnd/img/addnew_16.png" style="vertical-align: top" alt='Thêm mới' />
                Thêm mới
                    </asp:LinkButton>
                </div>
                <div class="content" style="width: 940px; float: left;">
                    <asp:Repeater ID="RptEmail" runat="server" OnItemCommand="RptEmail_ItemCommand">
                        <HeaderTemplate>
                            <table style="width: 940px; margin: auto; height: 70px;" class="tbl_doc">
                                <thead>
                                    <tr>
                                        <td>
                                            Email
                                        </td>
                                        <td>
                                            Trạng thái hiển thị
                                        </td>
                                        <td class="td1">
                                            chức năng
                                        </td>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 650px;">
                                    <div class="title_slide">
                                        <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>' Visible="true"></asp:Label>
                                        <asp:TextBox ID="txtEmail" runat="server" Visible="false" Text='<%#Eval("Email") %>'
                                            Width="300" Height="20"></asp:TextBox>
                                    </div>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkStatus" Checked='<%#Convert.ToBoolean(Eval("Status")) %>' runat="server" />
                                </td>
                                <td class="td2" style="width: 120px;">
                                    <asp:LinkButton ID="lbtEdit" runat="server" ToolTip="Sửa" CssClass="edit_icon" CommandName="Edit"
                                        Visible="true" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                                    <asp:LinkButton ID="lbtUpdate" runat="server" ToolTip="Cập nhật" Visible="false"
                                        CssClass="update_icon" CommandName="Update" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                                    <asp:LinkButton ID="lbtCancel" runat="server" ToolTip="Hủy" Visible="false" CssClass="cancel_icon"
                                        CommandName="Cancel" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                                    <script type="text/javascript">
                                        function confirm1() {
                                            return confirm("Bạn có muốn xóa Record này ko ?");
                                        }
                                    </script>
                                    <asp:LinkButton ID="lbtDelete" ToolTip="Xóa" CssClass="delete_icon" runat="server"
                                        CommandName="Delete" OnClientClick="return confirm1()" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
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
    </div>
</asp:Content>
