<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="Contact.aspx.cs" Inherits="pages_Contact" %>

<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<%@ Register Src="~/userControls/ucContact.ascx" TagName="ucContact" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <!--Begin body content-->
    <div class="bodyContent">
        <div class="leftMain nl">
                <div class="box" style="text-align: left;">
                    <div class="title">
                        <span><a>Liên hệ - Góp ý</a></span>
                    </div>
                    <div>
                        <div class="contact_tb">
                            <script type="text/javascript">
                                function Validate() {
                                    var txtname = $('#<%=txtName.ClientID %>');
                                    var Email = $('#<%=txtEmail.ClientID %>');
                                    var content = $('#<%=txtContent.ClientID %>');
                                    if (txtname.val() == "") {
                                        alert('Họ tên không được để trống !');
                                        txtname.focus();
                                        return false;
                                    }
                                    if (Email.val() == "") {
                                        alert('Email không được để trống !');
                                        Email.focus();
                                        return false;
                                    }
                                    if (Email.val() != "") {
                                        if (!CheckMail(Email.val())) {
                                            alert('Email không đúng định dạng !');
                                            Email.focus();
                                            return false;
                                        }
                                    }
                                    if (content.val() == "") {
                                        alert('Nội dung không được để trống !');
                                        content.focus();
                                        return false;
                                    }

                                    return true;
                                }
                                function CheckMail(str) {
                                    var RegExEmail = /^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.([a-z]){2,4})$/; //new RegExp("^[0-9a-z\\._]+@[0-9a-z]+\\.+$", "i");
                                    return RegExEmail.test(str);
                                }

                            </script>
                            <table cellspacing="6" style="margin-left:80px;">
                                <tr>
                                    <td colspan="2" style="padding: 20px; padding-top: 0; line-height: 25px;">
                                        <b style="text-transform: uppercase; color: #459B30;">Công ty cổ phần bất động sản Âu
                                            Lạc</b><br />
                                        Địa chỉ: <b>Xóm 15 - Nghi Kim - TP.Vinh - Nghệ An</b><br />
                                        Email: <b>votrongtrung@gmail.com</b><br />
                                        Điện thoại: <b>01682827659</b><br />
                                    </td>
                                </tr>
                                <tbody runat="server" id="tbdSuccess" visible="false">
                                    <tr>
                                        <td style="width:80px; color:#459B30; text-align:center" colspan="2">
                                           Ý kiến của bạn đã được gửi đi. Cảm ơn bạn đã góp ý!
                                        </td>
                                    </tr>
                                </tbody>
                                <tbody runat="server" id="tbdContact">
                                    <tr>
                                        <td style="width:80px">
                                            Họ tên:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtName" runat="server" Width="198px"></asp:TextBox><span style="color:Red">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Địa chỉ:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtAddress" runat="server" Width="342px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Email:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtEmail" runat="server" Width="341px"></asp:TextBox><span style="color:Red">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Điện thoại:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPhone" runat="server" Width="195px"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Nội dung:
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtContent" runat="server" Height="160px" Width="342px" TextMode="MultiLine"></asp:TextBox><span style="color:Red">*</span>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="2" style="padding-left: 150px; padding-top: 20px;">
                                            <asp:Button ID="btnSend" CssClass="btnButton" runat="server" Text=" Gửi " Width="66px"
                                                OnClientClick="return Validate()" OnClick="btnSend_Click" />
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                </div>
        </div>
        <div class="rightMain nr">
            <uc2:ucDoitac runat="server" ID="ucDoitac1" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
</asp:Content>
