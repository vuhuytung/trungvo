<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDoitac.ascx.cs" Inherits="userControls_ucDoitacl" %>
<%@ Register src="~/userControls/ucLogin.ascx" tagname="ucLogin" tagprefix="uc1" %>
<%@ Register src="~/userControls/ucWeather.ascx" tagname="ucWeather" tagprefix="uc4" %>
<%@ Register src="~/userControls/ucExRate.ascx" tagname="ucExRate" tagprefix="uc5" %>
<%@ Register src="~/userControls/ucSuport.ascx" tagname="ucSuport" tagprefix="uc6" %>
<uc1:ucLogin ID="ucLogin1" runat="server" />
<div class="box clear" style="border:none; background-color:#FFF; margin-top:10px" id="divDoitac" runat="server">
     <div class="title" style="margin-bottom:0;">
         <span><a>Đối tác</a></span>
      </div>
    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    <div class="clear"></div>
</div>
<uc4:ucWeather ID="ucWeather1" runat="server" />            
<uc5:ucExRate ID="ucExRate1" runat="server" />
<uc6:ucSuport ID="ucSuport1" runat="server" />