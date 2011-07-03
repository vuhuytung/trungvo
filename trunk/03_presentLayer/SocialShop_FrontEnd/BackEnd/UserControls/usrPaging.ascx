<%@ Control Language="C#" AutoEventWireup="true" CodeFile="usrPaging.ascx.cs" Inherits="userControls_ucPaging" %>
<style type="text/css">
    .pages
    {
        padding-top: 10px;
        padding-bottom: 10px;
    }
    .pages a:link, .pages a:visited, .pages .Current
    {
        border: solid 1px #bdbdbd;
        padding-top: 3px;
        padding-bottom: 3px;
        padding-left: 5px;
        padding-right: 5px;
        margin-left: 3px;
        margin-right: 3px;
        text-decoration: none;
    }
    .pages a:hover, .pages .current01
    {
        border: solid 1px #bdbdbd;
        padding-top: 3px;
        padding-bottom: 3px;
        padding-left: 5px;
        padding-right: 5px;
        margin-left: 3px;
        margin-right: 3px;
        background-color: #00aced;
        color: #FFFFFF;
        cursor: pointer;
    }
</style>
<div class="pages">
    <asp:Repeater ID="rptPaging" runat="server" OnItemDataBound="rptPaging_ItemDataBound"
        OnItemCommand="rptPaging_ItemCommand">
        <ItemTemplate>
                <asp:LinkButton ID="linkPage" runat="server" Text='<%#Eval("Name") %>' CommandName="changepage" CommandArgument='<%#Eval("PageNumber") %>'
                ToolTip='<%#"Trang " + Eval("PageNumber") %>'></asp:LinkButton>
        </ItemTemplate>
    </asp:Repeater>
</div>
