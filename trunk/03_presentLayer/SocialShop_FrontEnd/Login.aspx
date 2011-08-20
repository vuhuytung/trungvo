<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    td
    {
        padding:5px;
    }
    .require
    {
        color:Red;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" Runat="Server">

<center>
    <table width="350px" style="margin:auto; text-align:left; background:#FFF; border:#B0E5F7 solid 3px; border-top-width:10px;border-bottom-width:10px;">
        <tr>
            <td style="text-transform:uppercase; font-weight:bold; font-size:14px; color:#FFF; text-align:center; background:#BBD37E" colspan="2">Đăng nhập</td>
        </tr>
        <tr>
            <td>Tên đăng nhập:</td>
            <td><asp:TextBox runat="server" ID="txtUserName" CssClass="inputText" Width="165"></asp:TextBox>
            </td>            
        </tr>
        <tr>
            <td>Mật khẩu:</td>
            <td><asp:TextBox runat="server" ID="txtPassword"  CssClass="inputText" Width="165" TextMode="Password" ></asp:TextBox>
            </td>
        </tr>
        <tr>                       
            <td colspan="2" align="center">
                <asp:Label runat="server" ID="lblmsg" Font-Size="12px" ForeColor="Red"></asp:Label>
                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click"
                    Text="  Đăng nhập  "  /></td>
        </tr>
        <tr>                       
            <td colspan="2" align="right" style="font-size:12px">[ <a href="#">Quên mật khẩu?</a> ] Chưa có tài khoản? <a href="/register" style="color:#ff8040">Đăng ký</a></td>
        </tr>

    </table>
    </center>
</asp:Content>

