<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucRealtyMarket.ascx.cs" Inherits="userControls_ucRealtyMarket" %>
<%@ Register src="ucPaging.ascx" tagname="ucPaging" tagprefix="uc1" %>
<%@ Register src="ucTopSearch.ascx" tagname="ucTopSearch" tagprefix="uc2" %>
<div>
    <div class="topsearch">
        <uc2:ucTopSearch ID="ucTopSearch1" runat="server" />
    </div>    
    <asp:Repeater ID="RptReatyMarket" runat="server">
        <ItemTemplate>
            <div class="realty_item">
                <div class="img_item">
                    <img alt="anh" src="" />
                </div>
                <div class="detail_item">
                    <a href="#"><%#Eval("Title")%></a>
                </div>
            </div>

        </ItemTemplate>
    </asp:Repeater>

    <div id="divPaging" runat="server" class="paginator2 nr">
        <uc1:ucPaging id="ucPaging1" runat="server" />
    </div>
</div>