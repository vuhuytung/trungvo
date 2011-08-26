<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="Myrealtymarket.aspx.cs" Inherits="pages_Myrealtymarket" %>

<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/realtymarket.css" rel="stylesheet" type="text/css" />
    <link href="/css/paging.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <div class="bodyContent">
        <div class="leftMain nl" style="font-size: 12px;">
            <div class="topsearch">
                <div class="search">
                    <table class="tbMarket">
                        <tr>
                            <td>
                                TP/Tỉnh:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProvince" CssClass="ddl" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Quận/Huyện:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlDistrict" CssClass="ddl" runat="server" AutoPostBack="true"
                                    Height="22px" Width="136px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Danh mục:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTypeBDS" CssClass="ddl" runat="server">
                                </asp:DropDownList>
                            </td>
                            <td>
                                Khoảng Giá:
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlPrice" CssClass="ddl" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="text-align: center; padding-top: 7px;" colspan="4">
                                <asp:ImageButton ID="ImgSearch" ImageUrl="~/images/btnSearch.png" runat="server"
                                    OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
            <div class="content">
                <asp:Repeater ID="RptReatyMarket" runat="server" OnItemCommand="RptReatyMarket_ItemCommand">
                    <ItemTemplate>
                        <div class="realty_item">
                            <div class="img_item">
                                <img alt="noImage" width="110" style="margin: 5px" src="<%#Eval("Image").ToString().Trim()==""?"/images/nomarket.jpg":Eval("Image").ToString().Trim()+".thumb"%>" />
                            </div>
                            <div class="detail_item">
                                <div class="detail_item_title">
                                    <a href='/realtymarketdetails/<%#VTCO.Library.Lib.GetUrlText(Eval("Title").ToString()) %>-<%#Eval("Type")%>-<%#Eval("RealtyMarketID")%>'>
                                        <%#Eval("Title")%></a>
                                    <asp:Button ID="btnDelete" CommandName="delete" CommandArgument='<%#Eval("RealtyMarketID") %>'
                                        runat="server" Text="Xóa" CssClass="nr" />
                                </div>
                                <div class="detail_item_title">
                                    <%#Eval("Descrition").ToString().Length > 201 ? Eval("Descrition").ToString().Substring(0, 200) : Eval("Descrition")%></a>
                                </div>
                            </div>
                            <div class="clear">
                            </div>
                            <div style="margin: 10px">
                                Địa chỉ: <b style="margin-right: 10px">
                                    <%#market.GetFullAddressbyLocationID(Convert.ToInt32(Eval("LocationID"))) %></b>
                                <%#Convert.ToInt32(Eval("Acreage"))>0?"Diện tích: <b style='margin-right:10px'>"+Eval("Acreage")+" m²</b>":"" %>
                                Giá: <b style="margin-right: 10px">
                                    <%#getTextPrice(Convert.ToInt64(Eval("Price")))%></b> <span class="nr">
                                        <%#Convert.ToDateTime(Eval("CreateDate")).ToString("dd-MM-yyyy")%><br />
                                        <b>
                                            <%#Convert.ToInt32(Eval("Status") ?? 0) == 0 ? "Chờ duyệt" : Convert.ToInt32(Eval("Status") ?? 0)==1?"Đã duyệt":"Từ chối"%></b></span>
                                <div class="clear">
                                </div>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <center runat="server" id="ctNoFound" visible="false">Không tìm thấy!</center>
                <div id="divPaging" runat="server" class="paginator2 nr">
                    <uc1:ucPaging ID="ucPaging1" runat="server" />
                </div>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="rightMain nr">
            <uc2:ucDoitac ID="ucDoitac1" runat="server" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
    <div class="clear">
    </div>
</asp:Content>
