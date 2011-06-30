<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDocument.ascx.cs" Inherits="userControls_ucDocument" %>
<%@ Register Src="ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<div class="wrapper">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <asp:Repeater ID="RptDocument" runat="server">
                <ItemTemplate>
                    <div class="doc_wrap">
                        <div class="doc_title">
                            <a>
                                <%#Eval("Title") %></a>
                        </div>
                        <div class="doc_desc">
                            <a>
                                <%#Eval("Description") %></a>
                        </div>
                        <div class="doc_download">
                            <a href='download.aspx?file=<%#Eval("Url") %>'>Download tài liệu này !</a>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            </div>
            <div id="divPaging" runat="server" class="paginator2 nr">
                <uc1:ucPaging ID="ucPaging1" runat="server" />
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
    <div class="clear">
    </div>
</div>
