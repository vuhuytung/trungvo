<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="realtymarket.aspx.cs" Inherits="pages_realtymarket" %>

<%@ Register src="../userControls/ucRealtyMarket.ascx" tagname="ucRealtyMarket" tagprefix="uc1" %>

<%@ Register src="../userControls/ucDoitac.ascx" tagname="ucDoitac" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/realtymarket.css" rel="stylesheet" type="text/css" />
    <link href="../css/paging.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" Runat="Server">
    <div class="bodyContent">
        <div class="leftMain nl">
            <uc1:ucRealtyMarket ID="ucRealtyMarket1" runat="server" />
           
            <div class="clear">
            </div>
            <hr style="margin-top: 30px;" />
        </div>
        <div class="rightMain nr">
            <uc2:ucDoitac ID="ucDoitac1" runat="server" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
    
</asp:Content>

