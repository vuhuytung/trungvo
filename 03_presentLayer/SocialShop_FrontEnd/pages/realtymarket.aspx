<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
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
                            <table>
                                <tr>
                                    <td>
                                        Tìm tại:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Quận/Huyện
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" Height="22px"
                                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="136px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Phường/Xã
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlVillage" runat="server" Width="136px">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Loại BĐS
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlTypeBDS" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        Khoảng Giá
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlPrice" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2" style="text-align: center; padding-top: 7px;">
                                        <asp:Button ID="btnSearch" runat="server" Text="Tìm" Width="70px" OnClick="btnSearch_Click" />
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
                                        <img alt="anh" src="" />
                                    </div>
                                    <div class="detail_item">
                                        <a href="#">
                                            <%#Eval("Title")%></a>
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
