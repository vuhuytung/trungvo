<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="pages_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    .box_login
    {
        float:left;
        width:350px;
        height:220px;
        background:#CFCFCF;
        margin:30px 300px;
    }
    .tbl_login
    {
        margin:10px 55px;
        width: 242px;
    }
    .button
    {
        text-align:center;
        padding:10px 0 10px 50px;
    }
    .head_login
    {
        float:left;
        text-align:center;
        width:100%;
        padding:10px 0;
    }
    .head_login h1
    {
        color:Blue;
        font-size:18px;
    }
    .ft_login
    {
        width:100%;
    
        text-align:center;
    }
    .ft_login a
    {
        color:Red;
    }
    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" Runat="Server">
<div class="bodyContent">

     <div class="box_login">
        <div class="head_login">
            <h1>Đăng nhập vào Website</h1>
        </div>
        <table cellspacing="10" class="tbl_login">
            <tr>
                <td>Tên đăng nhập</td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server" Height="18"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Mật khẩu</td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server" Height="18" TextMode="Password"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="button">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Width="56px" />
                </td>
            </tr>
        </table>
        <div class="ft_login">
            <a href="../Registor.aspx" >Bạn chưa có tài khoản, click vào đây để đăng ký tài khoản !</a>
        </div>
     </div>
       
     <div class="clear">
     </div>
        <!--End body content-->
  </div>
</asp:Content>

