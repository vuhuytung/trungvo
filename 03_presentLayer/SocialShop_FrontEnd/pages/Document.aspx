<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true" CodeFile="Document.aspx.cs" Inherits="pages_Document" %>

<%@ Register src="~/userControls/ucDocument.ascx" tagname="ucDocument" tagprefix="uc1" %>
<%@ Register src="~/userControls/ucPaging.ascx" tagname="ucPaging" tagprefix="uc2" %>
<%@ Register src="~/userControls/ucDoitac.ascx" tagname="ucDoitac" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/css/document.css" rel="stylesheet" type="text/css" />
    <link href="/css/paging.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" Runat="Server">
<div class="bodyContent">
        <div class="leftMain nl">
            <uc1:ucDocument ID="ucDocument1" runat="server" />
            
            <div class="clear">
            </div>
            <hr style="margin-top: 30px;" />
        </div>
        <div class="rightMain nr">
            <uc3:ucDoitac ID="ucDoitac1" runat="server" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
  </div>
</asp:Content>

