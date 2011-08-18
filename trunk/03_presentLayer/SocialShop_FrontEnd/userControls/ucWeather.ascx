<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucWeather.ascx.cs" Inherits="userControls_ucWeather" %>
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
 <div class="box clear" style="border:none; background-color:#FFF; margin-top:10px" id="divWeather" runat="server">
     <div class="title" style="margin-bottom:0;">
         <span><a>Thông tin thời tiết</a></span>
         <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged" Font-Names="Tahoma" Font-Size="11px" Width="112px">
             <asp:ListItem Selected="True" Value="Hanoi.xml">H&#224; Nội</asp:ListItem>
             <asp:ListItem Value="Haiphong.xml">Hải Ph&#242;ng</asp:ListItem>
             <asp:ListItem Value="HCM.xml">TP HCM</asp:ListItem>
             <asp:ListItem Value="Danang.xml">Đ&#224; Nẵng</asp:ListItem>
             <asp:ListItem Value="Sonla.xml">Sơn La</asp:ListItem>
             <asp:ListItem Value="Viettri.xml">Việt Tr&#236;</asp:ListItem>
             <asp:ListItem Value="Vinh.xml">Vinh</asp:ListItem>
             <asp:ListItem Value="Nhatrang.xml">Nha Trang</asp:ListItem>
             <asp:ListItem Value="Pleicu.xml">Pleicu</asp:ListItem>
         </asp:DropDownList>
     </div>
     <div style="background:url('http://vnexpress.net/Images/Background/WHead.gif') repeat-x left top; line-height:28px; height:28px">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
     </div>                        
     <div class="clear">
     </div>
 </div>
 </ContentTemplate>
</asp:UpdatePanel>
