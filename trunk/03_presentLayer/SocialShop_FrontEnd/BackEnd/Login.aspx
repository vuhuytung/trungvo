<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="backend_Login" Title="Đăng nhập hệ thống quản trị website" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Đăng nhập hệ thống quản trị website</title>
</head>
<body>
    <form id="form1" runat="server" defaultfocus="txtusename">
        <div style="margin:100px auto; width:450px;background:#DDD9D8;">
            <div style="background:#666666">
            <div  style="position:relative; padding:10px 0px;">
                <div style="width:100%; color:White; text-align:center; font-weight:bold">Đăng nhập hệ thống quản trị</div>
                <div style="position:absolute;top:0px;right:0px;background:url(/images/mntr.jpg) no-repeat;width:6px;height:6px;"></div>
                <div style="position:absolute;top:0px;left:0px;background:url(/images/mntl.jpg) no-repeat;width:6px;height:6px;"></div>
            </div>   
        </div>
            <div style="background-image:url(/images/Login.jpg); width:100%; height:280px;">
                <div style="width:80%; margin-left:20px;">
                    <div style="padding-top:50px;"> 
                        <label style="float:left; width:100px; text-align:right;padding-right:5px;">User Name:</label> 
                        <asp:TextBox ID="txtusename" runat="server" Width="150px"/>  
                    </div>
                    <div style="padding:5px 0px;">
                        <label style="float:left; width:100px; text-align:right;padding-right:5px;">Password:</label> 
                        <asp:TextBox ID="txtpassword" runat="server" TextMode="Password" Width="150px"/>  
                    </div>                    
                    <div style="text-align:center; padding-top:10px">
                        <asp:Button Text="Đăng nhập" ID="btnclick" runat="server" 
                            onclick="btnclick_Click"/>
                    </div>
                    <div style="text-align:center;height:30px; padding-top:10px;">
                        <asp:Label ID="lblmsg" ForeColor="Red" runat="server" />
                    </div>
                    <div style="padding-left:20px; padding-top:20px;">
                        <a href="/index.htm" style="text-decoration:none">Trở về trang chủ</a>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
