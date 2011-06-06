<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="plugin_AlertBox_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/popup.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="/js/framework/jquery-1.4.1-vsdoc.js"></script>
    <script type="text/javascript" src="/js/framework/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="/plugin/alert/js/jquery.alerts.js"></script>
     <script src="/js/framework/jquery.ui.core.js" type="text/javascript"></script>
    <script src="/js/framework/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="/js/framework/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="/js/framework/jquery.ui.draggable.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#divalert").click(function () {
                jAlert("Hello Word", "Thông báo", function () {
                    $("#divResult").text("done");

                });

            });

            $("#divConfirm").click(function () {
                jConfirm("Bạn có chắc chắn xóa bản ghi này không? Bạn có chắc chắn xóa bản ghi này không? Bạn có chắc chắn xóa bản ghi này không?", "Thông báo", function (r) {
                    if (r) {
                        $("#divResult").text("đã xóa");
                    }

                });

            });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div id="divalert">
        Alert
    </div>
    <div id="divConfirm">
        Xóa
    </div>
    <div id="divResult">
    </div>
    </form>
</body>
</html>
