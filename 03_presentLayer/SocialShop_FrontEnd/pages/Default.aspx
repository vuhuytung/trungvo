<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="pages_Default" %>

<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <div class="topSearch">
        <div class="containSubmenu">
        </div>
        <div class="leftTopSearch">
            <div class="showImage">
                <div>
                    <div style="height: 185px;">
                        <img src="/images/duan.png" width="427" height="185" />
                    </div>
                    <div style="height: 46px; margin-top: 15px; text-align: left; color: #ff8040;">
                        <div class="nl" style="width: 317px; font-weight: bold; font-family: Tahoma; margin: 0 10px;">
                            Căn hộ cao cấp ngoại ô thành phố Vinh</div>
                        <div class="nl">
                            <a href="#">
                                <img src="/images/btnChitiet.png" /></a></div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
            <div class="listImage">
                <table>
                    <tr>
                        <td valign="middle" class="titleListImage">
                            Căn hộ tại chung cư TECCO
                        </td>
                        <td class="frameListImage png_bg" valign="middle" align="center">
                            <img src="/images/duan1.png" width="110" height="67" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" class="titleListImage">
                            Căn hộ tại chung cư TECCO
                        </td>
                        <td class="frameListImage png_bg" valign="middle" align="center">
                            <img src="/images/duan1.png" width="110" height="67" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="rightTopSearch">
            <div class="titleSearch png_bg">
                TÌM KIẾM NÂNG CAO
            </div>
            <div>
                <div class="label nl">
                    Tìm tại</div>
                <div class="value nr">
                    <select class="inputText" style="width: 80px;">
                        <option>Vinh</option>
                    </select></div>
                <div class="clear">
                </div>
                <div class="label nl">
                    Phường / Xã</div>
                <div class="value nr">
                    <select class="inputText" style="width: 100px;">
                        <option>[--Tất cả--]</option>
                    </select></div>
                <div class="clear">
                </div>
                <div class="label nl">
                    Loại hình</div>
                <div class="value nr">
                    <select class="inputText" style="width: 100px;">
                        <option>[--Tất cả--]</option>
                    </select></div>
                <div class="clear">
                </div>
                <div class="label nl">
                    Khoảng giá</div>
                <div class="value nr">
                    <select class="inputText" style="width: 80px;">
                        <option>[--Tất cả--]</option>
                    </select></div>
                <div class="clear">
                </div>
            </div>
            <div style="text-align: center; padding: 10px;">
                <a href="#">
                    <img src="/images/btnSearch.png" /></a>
            </div>
        </div>
        <div class="clear">
        </div>
        <!--End top search-->
    </div>
    <div class="clear">
        </div>
    <!--Begin body content-->
    <div class="bodyContent">
        <div class="leftMain nl">
            <asp:Repeater ID="rptContent" runat="server" >
                <ItemTemplate>
                    <div class="box">
                        <div class="title">
                            <span><a href='/news/<%#VTCO.Library.Lib.GetUrlText(Eval("Info.Name").ToString()) %>-<%#Eval("Info.CategoryID") %>'><%#Eval("Info.Name") %></a></span>
                        </div>
                        <div class="topNews nl">
                            <img src="<%#Eval("Items[0].Img") %>.thumb" width="140" class="nl" style="border: solid 1px #AAA;
                                margin: 10px; margin-top:0;" />
                            <p>
                                <span class="spTitle"><a href='/news/<%#VTCO.Library.Lib.GetUrlText(Eval("Items[0].CategoryName").ToString()) %>-<%#Eval("Items[0].CategoryID") %>/<%#VTCO.Library.Lib.GetUrlText(Eval("Items[0].Title").ToString()) %>-<%#Eval("Items[0].NewsID") %>'><%#Eval("Items[0].Title") %></a></span>
                                <span class="spDate"><%#Eval("Items[0].CreateDate","{0:dd/MM/yyyy}") %></span>
                                <br />
                                <br />
                                <p style="text-indent:15px;">
                                    <%#Eval("Items[0].Description") %>
                                </p>
                            </p>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="otherTopNews nr">
                            <ul>
                                <% ktra = 0; %>                                
                                <asp:Repeater runat="server" ID="rptList" DataSource='<%#Eval("Items") %>'>
                                    <ItemTemplate>
                                        <%if (ktra != 0)
                                          { %>
                                        <li class="listHome"><a href='/news/<%#VTCO.Library.Lib.GetUrlText(Eval("CategoryName").ToString()) %>-<%#Eval("CategoryID") %>/<%#VTCO.Library.Lib.GetUrlText(Eval("Title").ToString()) %>-<%#Eval("NewsID") %>'><%#Eval("Title") %></a></li>
                                        <%}
                                            ktra = 1;
                                            %>
                                    </ItemTemplate>
                                </asp:Repeater>                                
                            </ul>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
        <div class="rightMain nr">
            <uc2:ucDoitac runat="server" ID="ucDoitac1" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
</asp:Content>
