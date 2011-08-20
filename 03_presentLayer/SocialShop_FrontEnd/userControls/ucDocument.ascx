<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucDocument.ascx.cs" Inherits="userControls_ucDocument" %>
<%@ Register Src="ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<div >
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
                           <a><%#Eval("Description") %></a>
                        </div>
                        <div class="doc_download">
                            <a href='../pages/download.aspx?file=<%#Eval("Url") %>'>Download tài liệu này !&nbsp;&nbsp;<img src="../images/download1.gif" alt="anh" /> </a>
                            
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
           
        </ContentTemplate>
    </asp:UpdatePanel>
       <div id="divPaging" runat="server" class="paginator2 nr">
                <uc1:ucPaging ID="ucPaging1" runat="server" />
       </div>
</div>
