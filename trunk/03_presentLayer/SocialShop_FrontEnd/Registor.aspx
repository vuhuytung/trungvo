<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true" CodeFile="Registor.aspx.cs" Inherits="Registor" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    td
    {
        padding:7px;
    }
    .require
    {
        color:Red;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" Runat="Server">
<center>
    <table width="500px" style="margin:auto; text-align:left">
        <tr>
            <td style="text-transform:uppercase; font-weight:bold; font-size:14px; color:#ff8040; padding:20px; padding-left:150px" colspan="2">Đăng ký thành viên</td>
        </tr>
        <tr>
            <td>Tên đăng nhập:</td>
            <td><asp:TextBox runat="server" ID="txtUserName" CssClass="inputText" Width="150"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" CssClass="require" ControlToValidate="txtUserName" ValidationGroup="Registor"></asp:RequiredFieldValidator>
            </td>            
        </tr>
        <tr>
            <td>Mật khẩu:</td>
            <td><asp:TextBox runat="server" ID="txtPassword"  CssClass="inputText" Width="150" TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" CssClass="require" ControlToValidate="txtPassword" ValidationGroup="Registor"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Gõ lại mật khẩu:</td>
            <td><asp:TextBox runat="server" ID="txtPasswordAgain" CssClass="inputText" Width="150"  TextMode="Password" ></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" CssClass="require" ControlToValidate="txtPasswordAgain" ValidationGroup="Registor"></asp:RequiredFieldValidator>
                <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu nhập lại chưa đúng!" CssClass="require" ControlToValidate="txtPasswordAgain" ControlToCompare="txtPassword" ValidationGroup="Registor"></asp:CompareValidator>
            </td>
        </tr>
        <tr>
            <td>Tên đầy đủ:</td>
            <td><asp:TextBox runat="server" ID="txtFullName" CssClass="inputText" Width="150"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="*" CssClass="require" ControlToValidate="txtFullName" ValidationGroup="Registor"></asp:RequiredFieldValidator>
            </td>
        </tr> 
        <tr>
            <td width="120px">Địa chỉ email:</td>
            <td><asp:TextBox runat="server" ID="txtEmail" CssClass="inputText" Width="150"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="*" CssClass="require" ControlToValidate="txtEmail" ValidationGroup="Registor"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email không đúng định dạng!" CssClass="require" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEmail" ValidationGroup="Registor"></asp:RegularExpressionValidator>
            </td>
        </tr>              
        <tr>
            <td>Ngày sinh:</td>
            <td>
                <div style="width: 150px">
                 <telerik:RadDatePicker ID="rdpBirthday" runat="server" Culture="vi-VN" Skin="WebBlue">
                        <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                            ViewSelectorText="x">
                        </Calendar>
                        <DateInput LabelCssClass="radLabelCss_WebBlue" Skin="WebBlue">
                        </DateInput>
                    </telerik:RadDatePicker>
               </div>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="*" CssClass="require" ControlToValidate="rdpBirthday" ValidationGroup="Registor"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Địa chỉ:</td>
            <td><asp:TextBox runat="server" ID="txtAddress" CssClass="inputText" Width="300"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="*" CssClass="require" ControlToValidate="txtAddress" ValidationGroup="Registor"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>Điện thoại:</td>
            <td><asp:TextBox runat="server" ID="txtMobile" CssClass="inputText" Width="150"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="*" CssClass="require" ControlToValidate="txtMobile" ValidationGroup="Registor"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>                       
            <td colspan="2" align="center"><asp:Button runat="server" ID="btnRegistor" 
                    Text="  Đăng ký  " ValidationGroup="Registor" onclick="btnRegistor_Click" /></td>
        </tr>
    </table>
    </center>
</asp:Content>

