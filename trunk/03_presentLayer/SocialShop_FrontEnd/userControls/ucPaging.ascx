<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPaging.ascx.cs" Inherits="UserControls_ucPaging" %>
<asp:Repeater id="rptPaging" runat="server" 
    onitemcommand="rptPaging_ItemCommand" onitemdatabound="rptPaging_ItemDataBound">
    <ItemTemplate>
        <asp:LinkButton id="linkPage" runat="server" CommandName="changepage" CommandArgument='<%#Eval("PageNumber") %>' ToolTip='<%#"Trang " + Eval("PageNumber") %>' Text='<%#Eval("Name") %>'><%#Eval("Name") %></asp:LinkButton>
    </ItemTemplate>
</asp:Repeater> 