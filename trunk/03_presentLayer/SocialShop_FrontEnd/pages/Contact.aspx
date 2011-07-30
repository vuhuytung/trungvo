<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="pages_Contact" %>

<%@ Register src="~/userControls/ucContact.ascx" tagname="ucContact" tagprefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/bds_detail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" Runat="Server">
<div style=" padding-left:200px; font:12px Arial;">
    <div class="contact_title">
       <a> Quý khách có những thắc mắc cần giải đáp xin điền đầy đủ thông tin vào form dưới đây, chúng tôi sẻ xem xét trả lời trong thời gian sớm nhất !</a><br />
       <a>Những ô gắn dấu * là thông tin bắt buộc</a>
    </div>
    <uc1:ucContact ID="ucContact1" runat="server" />
</div>
</asp:Content>

