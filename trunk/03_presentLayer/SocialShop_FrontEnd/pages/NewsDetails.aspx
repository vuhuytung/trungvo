﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="NewsDetails.aspx.cs" Inherits="pages_NewsDetails" %>

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
                    <div class="box" style="border:none; padding:20px; padding-top:0;">
                        <div class="topNews nl" style="width: 100%">                            
                            <p>
                                <span class="spTitle" style="font-size:19px; color:#004175;" id="selTitle" runat="server"></span> 
                                <span class="spDate" runat="server" id="selCreateDate"></span>
                                <br />
                                <br />
                                <span runat="server" id="selDescription" style="font-weight:bold; color:#5f5f5f;">                                   
                                </span>
                            </p>
                            <center>
                            <img width="450" runat="server" id="selImage" class="clear" style="border: solid 1px #AAA; margin:30px 10px;" />                
                            </center>     
                            <p runat="server" id="selContent"></p>
                            <p style="text-align:right; font-style:italic; padding:10px;" id="selResource" runat="server"></p>
                            <div class="clear">
                            </div>
                        </div>
                        <div class="clear">
                        </div>
                    </div>
            <div class="clear">
            </div>            
            <div class="listOtherNews">Các tin
                khác cùng chuyên mục:</div>
            <div style="position: relative; padding-left: 40px;">
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                        <div class="otherTopNews">
                            <ul>
                                <asp:Repeater runat="server" ID="rptOther">
                                    <ItemTemplate>
                                        <li><a href='/news/<%#VTCO.Library.Lib.GetUrlText(Eval("CategoryName").ToString()) %>-<%#Eval("CategoryID") %>/<%#VTCO.Library.Lib.GetUrlText(Eval("Title").ToString()) %>-<%#Eval("NewsID") %>'>
                                            <%#Eval("Title") %></a></li>
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
        <div class="rightMain nr">
            <uc2:ucDoitac runat="server" ID="ucDoitac1" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
</asp:Content>
