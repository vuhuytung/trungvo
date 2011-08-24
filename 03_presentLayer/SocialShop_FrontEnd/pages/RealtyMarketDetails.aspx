<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="RealtyMarketDetails.aspx.cs" Inherits="pages_RealtyMarketDetails" %>

<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/bds_detail.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .tblDetails
        {
            color:#666; border-collapse:collapse;
            width:100%;
        }
        .tblDetails td
        {
            padding:5px 5px 5px 20px;
            border:solid 1px #CCC;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <div class="bodyContent">
        <div class="leftMain nl">
            <div class="box" style="border: none;">
                <div class="topNews nl" style="width: 600px">
                    <p>
                        <span class="spTitle" style="font-size: 16px; color: #004175;" id="selTitle" runat="server">
                        </span><span class="spDate" runat="server" id="selCreateDate"></span>
                        <br />
                        <br />
                        <span runat="server" id="lblDescription" style="font-weight: normal; color: #5f5f5f;">
                        </span><br />
                        <br />
                    </p>
                    <table class="tblDetails" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="4" style="background:#EEE">
                                <a style="color: #459B30; font-size: 15px; font-weight: bold">Thông tin</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Địa điểm:
                            </td>
                            <td colspan="3">
                                <b>
                                    <asp:Label runat="server" ID="lblAddress"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Diện tích:
                            </td>
                            <td colspan="3">
                                <b>
                                    <asp:Label runat="server" ID="lblAreage"></asp:Label>
                                    </b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tình trạng pháp lý:
                            </td>
                            <td colspan="3">
                                <b>
                                    <asp:Label runat="server" ID="lblLegatStatus"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Giá:
                            </td>
                            <td colspan="3">
                                <b><asp:Label runat="server" ID="lblPrice"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Hướng:
                            </td>
                            <td colspan="3">
                                <b><asp:Label runat="server" ID="lblPosition"></asp:Label></b>
                            </td>                            
                        </tr>
                        <tr>
                            <td>
                                Số tầng:
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="lblFloor"></asp:Label></b>
                            </td>
                            <td>
                                Phòng khách:
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="lblClientRoom"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Phòng tắm:
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="lblBathRoom"></asp:Label></b>
                            </td> 
                            <td>
                                Phòng ngủ:
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="lblBedRoom"></asp:Label></b>
                            </td>                                                       
                        </tr>
                        <tr>
                            <td>
                                Gần chợ:
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="lblMarket"></asp:Label></b>
                            </td>                            
                            <td>
                                Gần trường trung học:
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="lblNearSchool"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Gần bệnh viện:
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="lblNearHospital"></asp:Label></b>
                            </td>
                            <td>
                                Gần trường mẫu giáo:
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="lblNearKindergarten"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Gần trường Đại học:
                            </td>
                            <td colspan="3">
                                <b>
                                    <asp:Label runat="server" ID="lblNearUniversity"></asp:Label></b>
                            </td>
                        </tr>                        
                    </table>
                    <table class="tblDetails" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="4" style="background:#EEE">
                                <a style="color: #459B30; background:#EEF; font-size: 15px; font-weight: bold">Thông tin người đăng</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Họ tên người đăng:
                            </td>
                            <td>
                                <b><asp:Label runat="server" ID="lblUser"></asp:Label></b>
                            </td>
                            <td>
                                Địa chỉ:
                            </td>
                            <td>
                                <b><asp:Label runat="server" ID="lblAddressStreet"></asp:Label></b>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Điện thoại:
                            </td>
                            <td>
                                <b><asp:Label runat="server" ID="lblPhone"></asp:Label></b>
                            </td>
                            <td>
                                Email:
                            </td>
                            <td>
                                <b><asp:Label runat="server" ID="lblEmail"></asp:Label></b>
                            </td>
                        </tr>
                    </table>
                    <center>
                        <img width="450" runat="server" id="selImage" class="clear" style="border: solid 1px #AAA;
                            margin: 30px 10px 0 10px;" />
                    </center>
                    <div class="clear">
                    </div>
                </div>
                <div class="clear">
                </div>
            </div>
            <div class="clear">
            </div>
            <div runat="server" id="divListOtherNews">
                <div class="box" style="border: none; padding-bottom: 0">
                    <div class="title">
                        <span><a>Các tin khác cùng loại</a></span>
                    </div>
                </div>
                <div style="position: relative; padding-left: 40px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="otherTopNews">
                                <ul>
                                    <asp:Repeater runat="server" ID="rptOther">
                                        <ItemTemplate>
                                            <%#(Convert.ToInt32(Eval("RealtyMarketID"))!=CurrentID)?
                                            "<li><a href='/realtymarketdetails/"+VTCO.Library.Lib.GetUrlText(Eval("Title").ToString())+"-"+Eval("Type")+"-"+Eval("RealtyMarketID")+"'>"
                                                +Eval("Title")+"</a><span class='spDate'>"
                                                +Eval("CreateDate","{0:dd/MM/yyyy}")+"</span></li>":"" %>
                                        </ItemTemplate>
                                    </asp:Repeater>
                                </ul>
                                <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                                    <ProgressTemplate>
                                        <center>
                                            <img src="/images/ajax-loader.gif" title="Loading..." alt="Loading..." /></center>
                                    </ProgressTemplate>
                                </asp:UpdateProgress>
                            </div>
                            <div id="divPaging" runat="server" class="paginator2 nr">
                                <uc1:ucPaging ID="ucPaging1" runat="server" />
                            </div>
                            <div class="clear">
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </div>
        <div class="rightMain nr">
            <uc2:ucDoitac runat="server" ID="ucDoitac1" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
</asp:Content>
