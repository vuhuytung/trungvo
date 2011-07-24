<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="BdsAddNews.aspx.cs" Inherits="pages_Bds_AddNews" %>

<%@ Register Src="~/userControls/ucAddNewBDS.ascx" TagName="ucAddNewBDS" TagPrefix="uc1" %>
<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/bds_detail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <div class="bodyContent">
        <div class="clear">
            <uc1:ucAddNewBDS ID="ucAddNewBDS1" runat="server" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
</asp:Content>
