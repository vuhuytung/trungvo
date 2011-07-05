<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="pages_login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<style type="text/css">
    .box_login
    {
        float:left;
        width:350px;
        height:200px;
        background:#CFCFCF;
        margin:30px 300px;
    }
    .tbl_login
    {
        margin:30px 50px;
    }
    .button
    {
        text-align:center;
        padding:10px 0 10px 50px;
    }
    
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" Runat="Server">
<div class="bodyContent">
     <div class="box_login">
        <table cellspacing="10" class="tbl_login">
            <tr>
                <td>User</td>
                <td>
                    <asp:TextBox ID="txtUser" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>PassWord</td>
                <td>
                    <asp:TextBox ID="txtPass" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" class="button">
                    <asp:Button ID="btnLogin" runat="server" Text="Login" Width="56px" />
                </td>
            </tr>
        </table>
     </div>
       
     <div class="clear">
     </div>
        <!--End body content-->
  </div>
</asp:Content>

