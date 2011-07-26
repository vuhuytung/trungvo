﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="realtymarket.aspx.cs" Inherits="pages_realtymarket" %>

<%@ Register Src="~/userControls/ucRealtyMarket.ascx" TagName="ucRealtyMarket" TagPrefix="uc1" %>
<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/realtymarket.css" rel="stylesheet" type="text/css" />
    <link href="/css/paging.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="bodyContent">
                <div class="leftMain nl">
                    <div class="topsearch">
                        <div class="search">
                            <table class="tbMarket">
                                <tr>
                                    <td>
                                        TP/Tỉnh
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProvince" CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Quận/Huyện
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDistrict" CssClass="ddl"  runat="server" AutoPostBack="true" Height="22px"
                                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="136px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Phường/Xã
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlVillage" CssClass="ddl"  runat="server" Width="136px">
                                        </asp:DropDownList>
                                    </td>
                                    <td>
                                        Loại BĐS
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTypeBDS" CssClass="ddl"  runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Khoảng Giá
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPrice" CssClass="ddl" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                   
                                    <td style="text-align: center; padding-top: 7px;">
                                        <asp:Button ID="btnSearch" CssClass="btnButton" runat="server" Text="Tìm" Width="70px" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </div>
                    <div class="content">
                        <asp:Repeater ID="RptReatyMarket" runat="server">
                            <ItemTemplate>
                                <div class="realty_item">
                                    <div class="img_item">
                                        <img alt="noImage" src="<%#Eval("ImageThumb")%>" />
                                    </div>
                                    <div class="detail_item">
                                        <div class="detail_item_title">
                                            <a href='../pages/RealtyMarketDetails.aspx?ID=<%#Eval("RealtyMarketID")%>'>
                                                <%#Eval("Title")%></a>
                                        </div>
                                        <div class="detail_item_add">
                                            <a>Địa chỉ:&nbsp;&nbsp;<%#Eval("Street").ToString().Substring(0, 1) != "-" ? Eval("Street").ToString() : Eval("Street").ToString().Substring(1)%></a></div>
                                        <div class="detail_item_price">
                                            <a>Giá:&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; <%#string.Format("{0:0,0 vnđ}", Eval("Price"))%></a>
                                        </div>
                                        <div class="detail_item_date">
                                            <a><%#Convert.ToDateTime(Eval("CreateDate")).ToString("dd-MM-yyyy")%></a>
                                        </div>

                                    </div>
                                </div>
                            </ItemTemplate>
                        </asp:Repeater>
                        <div id="divPaging" runat="server" class="paginator2 nr">
                            <uc1:ucPaging ID="ucPaging1" runat="server" />
                        </div>
                    </div>
                    <div class="clear">
                    </div>
                    <hr style="margin-top: 30px;" />
                </div>
                <div class="rightMain nr">
                    <uc2:ucDoitac ID="ucDoitac1" runat="server" />
                </div>
                <div class="clear">
                    </div>
                <!--End body content-->
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
