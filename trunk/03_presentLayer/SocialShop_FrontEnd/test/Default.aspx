﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="test_Default" %>
<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="doitac" TagPrefix="uc" %>
<%@ Register Src="~/userControls/ucContact.ascx" TagName="Contact" TagPrefix="uc" %>
<%@ Register Src="~/userControls/ucAddNewBDS.ascx" TagName="Add" TagPrefix="uc" %>
<%@ Register Src="~/userControls/ucTopSearch.ascx" TagName="doc" TagPrefix="uc" %>
<%@ Register src="../userControls/ucDocument.ascx" tagname="ucDocument" tagprefix="uc1" %>
<%@ Register Src="~/userControls/ucSlide.ascx" TagName="slide" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/framework/jquery-1.5.min.js" type="text/javascript"></script>
    <script src="../csript/slide.js" type="text/javascript"></script>
    <link href="../css/main.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
    <div>
       <uc:slide runat="server" />
       
    </div>
    
    </form>
</body>
</html>
