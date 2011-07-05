<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="pages_Contact" %>

<%@ Register src="../userControls/ucContact.ascx" tagname="ucContact" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" Runat="Server">
<div style=" padding-left:200px;">
    <uc1:ucContact ID="ucContact1" runat="server" />
</div>
</asp:Content>

