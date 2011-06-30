<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="test_Default2" %>

<%@ Register src="../userControls/ucRealtyMarket.ascx" tagname="ucRealtyMarket" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/paging.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .realty_item
        {
            float:left;
            width:100%;
            border-bottom:1px dotted #E8DC5C;
            padding:3px;
        }
        .img_item
        {
            width:100px;
            height:100px;
            float:left;
            margin-right:10px;
            border:1px dotted #CFCFCF;
        }
        .detail_item
        {
            float:left;
            height:70px;
        }
        .topsearch
        {
            width:100%;
            height:200px;
            background:gray;
        }
        a
        {
            text-decoration:none;
            color:Blue;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        
        <uc1:ucRealtyMarket ID="ucRealtyMarket1" runat="server" />
        
    </div>
    </form>
</body>
</html>
