<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="pages_Default" %>
 <%@ Register Src="~/userControls/ucSlide.ascx" TagName="slide" TagPrefix="uc" %>
<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<%@ Register Src="~/userControls/ucTopSearch.ascx" TagName="Search" TagPrefix="uc1" %>
<%@ Register src="~/userControls/ucWeather.ascx" tagname="ucWeather" tagprefix="uc4" %>
<%@ Register src="~/userControls/ucExRate.ascx" tagname="ucExRate" tagprefix="uc5" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <link href="/css/main.css" rel="stylesheet" type="text/css" />
 <script src="/csript/slide.js" type="text/javascript"></script>
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <div class="topSearch">
        <div class="containSubmenu">
        </div>
        <div class="leftTopSearch">
            <uc:slide  runat="server"/>
            <div class="clear">
            </div>
        </div>
        <div class="rightTopSearch">
            <div class="titleSearch png_bg">
                TÌM KIẾM NÂNG CAO
            </div>
            <uc1:Search runat="server" />
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
                            <%#Eval("Items[0].Img").ToString().Contains("noimage.jpg") ? "" : "<img src='" + Eval("Items[0].Img") + ".thumb' width='140' class='nl' style='border: solid 1px #AAA; margin: 10px; margin-top: 0' />"%>
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
            <uc4:ucWeather ID="ucWeather1" runat="server" />            
            <uc5:ucExRate ID="ucExRate1" runat="server" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
</asp:Content>
