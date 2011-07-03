<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucHeader.ascx.cs" Inherits="UserControls_ucHeader" %>
<div class="logo">            
    Hệ thống quản trị website
</div>
<div class="user_tools">
    <span>Chào <%--<a href="/ProfileAccount.aspx"><%=Session[VTCO.Config.Constants.SESSION_USERNAME] == null ? "" : Session[VTCO.Config.Constants.SESSION_USERNAME].ToString() %></a>--%> | 
    <asp:LinkButton ID="linkLogout" runat="server" CausesValidation="false" onclick="linkLogout_Click">Thoát</asp:LinkButton> </span>
</div>