<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucHeader.ascx.cs" Inherits="UserControls_ucHeader" %>
<div class="logo">            
    Hệ thống quản trị website bất động sản Âu Lạc
</div>
<div class="user_tools">
    <span>Chào <a><b><%=Session[VTCO.Config.Constants.SESSION_ADMIN_FULLNAME] == null ? Session[VTCO.Config.Constants.SESSION_ADMIN_NAME]??"".ToString() : Session[VTCO.Config.Constants.SESSION_ADMIN_FULLNAME].ToString()%></b></a> |
    <a href="/admin/profile">Thông tin cá nhân</a>
    |
    <a href="/admin/changepass">Đổi mật khẩu</a> 
    |
    <asp:LinkButton ID="linkLogout" runat="server" CausesValidation="false" onclick="linkLogout_Click">Đăng xuất</asp:LinkButton> </span>
</div>