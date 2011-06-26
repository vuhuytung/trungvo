<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDocument.ascx.cs" Inherits="userControls_ucDocument" %>
    <div class="wrapper">
        <asp:Repeater ID="RptDocument" runat="server">
            <ItemTemplate>
                <div class="doc_wrap">
                    <div  class="doc_title">
                        <a><%#Eval("Title") %></a>
                    </div>
                    <div class="doc_desc">
                        <a><%#Eval("Description") %></a>
                    </div>
                    <div class="doc_download">
                        <a href='download.aspx?file=<%#Eval("Url") %>'>Download tài liệu này !</a>
                    </div>
                </div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
     <div class="doc_page">
        <asp:Literal ID="Literal1" runat="server"></asp:Literal>
    </div>