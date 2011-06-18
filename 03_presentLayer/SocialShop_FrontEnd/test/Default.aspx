<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="test_Default" %>
<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="doitac" TagPrefix="uc" %>
<%@ Register Src="~/userControls/Slide.ascx" TagName="slide" TagPrefix="uc" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../js/jqfootball.js" type="text/javascript"></script>
    <link href="../css/cssTrangchu.css" rel="stylesheet" type="text/css" />
    <script src="../js/framework/jquery-1.5.min.js" type="text/javascript"></script>
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server">

        </asp:GridView>
        <uc:doitac runat="server" />
        <uc:slide runat="server" />
    </div>
    </form>
</body>
</html>
