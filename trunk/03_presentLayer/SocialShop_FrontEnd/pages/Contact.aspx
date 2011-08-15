<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="pages_Contact" %>

<%@ Register Src="~/userControls/ucContact.ascx" TagName="ucContact" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../css/bds_detail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <div style="padding-left: 200px; font: 12px Arial;">
        <div class="contact_title">
            <a>Quý khách có những thắc mắc cần giải đáp xin điền đầy đủ thông tin vào form dưới
                đây, chúng tôi sẻ xem xét trả lời trong thời gian sớm nhất !</a><br />
            <a>Những ô gắn dấu * là thông tin bắt buộc</a>
        </div>
        <div class="contact_tb">
            <script type="text/javascript">
                function Validate() {
                    var txtname = document.getElementById("plhBody_txtName");
                    var Email = document.getElementById("plhBody_txtEmail");
                    var Title = document.getElementById("plhBody_txtTitle");
                    var content = document.getElementById("plhBody_txtContent");
                    if (txtname.value == "") {
                        alert('Họ tên không được để trống !');
                        return false;
                    }
                    if (Email.value == "") {
                        alert('Email không được để trống !');
                        return false;
                    }
                    if (Email.value != "") {
                        if (!CheckMail(Email.value)) {
                            alert('Email không đúng định dạng !');
                            return false;
                        }
                    }
                    if (Title.value == "") {
                        alert('Tiêu đề không được để trống !');
                        return false;
                    }
                    if (content.value == "") {
                        alert('Nội dung không được để trống !');
                        return false;
                    }
                   
                    return true;
                }
                function CheckMail(str) {
                    var RegExEmail = new RegExp("^[0-9a-z\\._]+@[0-9a-z]+\\..+$", "i");
                    return RegExEmail.test(str);
                }

            </script>
            <table cellspacing="6" class="tbContact">
                <tr>
                    <td>
                        Họ tên
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server" Width="198px"></asp:TextBox><a>*</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Địa chỉ
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" Width="342px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Email
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Width="341px"></asp:TextBox><a>*</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Điện thoại
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" Width="195px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tiêu đề
                    </td>
                    <td>
                        <asp:TextBox ID="txtTitle" runat="server" Width="342px"></asp:TextBox><a>*</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Nội dung
                    </td>
                    <td>
                        <asp:TextBox ID="txtContent" runat="server" Height="160px" Width="342px" TextMode="MultiLine"></asp:TextBox><a>*</a>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="padding-left: 150px; padding-top: 20px;">
                        <asp:Button ID="btnSend" CssClass="btnButton" runat="server" Text="Gửi" Width="66px"
                            OnClientClick="return Validate()" OnClick="btnSend_Click" />
                        <asp:Button ID="btnCancel" CssClass="btnButton" runat="server" Text="hủy" Width="70px"
                            OnClick="btnCancel_Click" />
                    </td>
                </tr>
            </table>
        </div>
    </div>
</asp:Content>
