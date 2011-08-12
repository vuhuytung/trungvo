<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucHeader.ascx.cs" Inherits="UserControls_ucHeader" %>
<div class="logo">            
    Hệ thống quản trị website
</div>
<div class="user_tools">
    <span>Chào <a href="/BackEnd/ProfileAccount.aspx"><%=Session[VTCO.Config.Constants.SESSION_ADMIN_FULLNAME] == null ? Session[VTCO.Config.Constants.SESSION_ADMIN_NAME].ToString() : Session[VTCO.Config.Constants.SESSION_ADMIN_FULLNAME].ToString()%></a> | 
    <asp:LinkButton ID="linkLogout" runat="server" CausesValidation="false" onclick="linkLogout_Click">Thoát</asp:LinkButton> </span>
</div>