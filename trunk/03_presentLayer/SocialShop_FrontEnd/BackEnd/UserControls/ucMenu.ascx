<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMenu.ascx.cs" Inherits="backend_UserControls_ucMenu" %>
<ul class="group">
    <li class="first"><a id="0" href="/admin" class='<%=getHover("0")%>'>
        <div style="position: relative;">
            <span class="outer"><span style="background-image: url(/img/icon_dashboard.png);
                background-repeat: no-repeat;" class="inner homepage">Trang chủ</span> </span>
        </div>
    </a></li>
    <asp:Repeater runat="server" ID="rptMenuParent" OnItemDataBound="rptMenuParent_ItemDataBound">
        <ItemTemplate>
            <asp:HiddenField ID="hdfMenuID" runat="server" Value='<%#Eval("FunctionID")%>' />
            <asp:HiddenField ID="hdfName" runat="server" Value='<%#Eval("Name")%>' />
            <asp:HiddenField ID="hdfLink" runat="server" Value='<%#Eval("URL")%>' />
            <asp:HiddenField ID="hdfImage" runat="server" Value='<%#Eval("ParrentID")%>' />
            <asp:Literal ID="ltrItem" runat="server"></asp:Literal>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<div id="tabs">
    <asp:Repeater runat="server" ID="rptTab" OnItemDataBound="rptTab_ItemDataBound">
        <ItemTemplate>
            <asp:HiddenField ID="hdfMenuID" runat="server" Value='<%#Eval("FunctionID")%>' />
            <asp:Literal runat="server" ID="ltrDiv"></asp:Literal>
            <ul>
                <asp:Repeater runat="server" ID="rptMenuChild" OnItemDataBound="rptMenuChild_ItemDataBound">
                    <ItemTemplate>
                        <li>
                            <asp:HiddenField ID="hdfMenuID" runat="server" Value='<%#Eval("FunctionID")%>' />
                            <asp:HiddenField ID="hdfName" runat="server" Value='<%#Eval("Name")%>' />
                            <asp:HiddenField ID="hdfLink" runat="server" Value='<%#Eval("URL")%>' />
                            <asp:HiddenField ID="hdfImage" runat="server" Value='<%#Eval("ParrentID")%>' />
                            <asp:Literal runat="server" ID="ltrContent"></asp:Literal>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
