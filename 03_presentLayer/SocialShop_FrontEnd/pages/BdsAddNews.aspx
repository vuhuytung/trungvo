<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true" CodeFile="BdsAddNews.aspx.cs" Inherits="pages_Bds_AddNews" %>

<%@ Register src="~/userControls/ucAddNewBDS.ascx" tagname="ucAddNewBDS" tagprefix="uc1" %>
<%@ Register src="~/userControls/ucDoitac.ascx" tagname="ucDoitac" tagprefix="uc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="/css/bds_detail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" Runat="Server">
<div class="bodyContent">
        
            <div class="clear">
                <uc1:ucAddNewBDS ID="ucAddNewBDS1" runat="server" />
            </div>
            <hr style="margin-top: 30px;" />
      
        
        <div class="clear">
        </div>
        <!--End body content-->
  </div>
</asp:Content>

