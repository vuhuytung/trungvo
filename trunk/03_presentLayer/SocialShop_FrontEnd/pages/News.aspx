<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="News.aspx.cs" Inherits="pages_News" %>

<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/paging.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div class="bodyContent">
        <div class="leftMain nl">
            <asp:Repeater ID="rptContent" runat="server">
                <ItemTemplate>
                    <div class="box" style="border: none; border-bottom: solid 1px #EEE;">
                        <%--<div class="title">
                            <span><a href="#"><%#Eval("Info.Name") %></a></span>
                        </div>--%>
                        <div class="topNews nl" style="width: 100%">
                            <img src="<%#Eval("Img") %>.thumb" width="120" class="nl" style="border: solid 1px #AAA;
                                margin: 10px; margin-top: 0" />
                            <p>
                                <span class="spTitle"><a href='/news/<%#VTCO.Library.Lib.GetUrlText(Eval("CategoryName").ToString()) %>-<%#Eval("CategoryID") %>/<%#VTCO.Library.Lib.GetUrlText(Eval("Title").ToString()) %>-<%#Eval("NewsID") %>'>
                                    <%#Eval("Title") %></a></span> <span class="spDate">
                                        <%#Eval("CreateDate","{0:dd/MM/yyyy}") %></span>
                                <%#(Convert.ToBoolean(Eval("IsHot")))?"<img src='/images/hot.gif' />":"" %>
                                <br />
                                <br />
                                <p style="text-indent: 15px;">
                                    <%#Eval("Description") %>
                                </p>
                            </p>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <center runat="server" id="ctNoRecord">
                Đang cập nhật
            </center>
            <div class="clear">
            </div>
            <div runat="server" id="divListOtherNews" visible="false">
                <div class="box" style="border: none; padding-bottom: 0">
                    <div class="title">
                        <span><a>Các tin khác cùng chuyên mục</a></span>
                    </div>
                </div>
                <div style="position: relative; padding-left: 20px;">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <div class="otherTopNews">
                                <ul>
                                    <asp:Repeater runat="server" ID="rptOther">
                                        <ItemTemplate>
                                            <li><a href='/news/<%#VTCO.Library.Lib.GetUrlText(Eval("CategoryName").ToString()) %>-<%#Eval("CategoryID") %>/<%#VTCO.Library.Lib.GetUrlText(Eval("Title").ToString()) %>-<%#Eval("NewsID") %>'>
                                                <%#Eval("Title") %></a><span class="spDate">
                                                <%#Eval("CreateDate","{0:dd/MM/yyyy}") %></span>
                                                <%#(Convert.ToBoolean(Eval("IsHot")))?"<img src='/images/hot.gif' />":"" %>
                                            </li>
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
    <div class="rightMain nr"> <uc2:ucDoitac runat="server" ID="ucDoitac1" /> </div>
    <div class="clear"> </div> <!--End body content--> </div>
</asp:Content>
