 <%@ Page Title="" Language="C#" MasterPageFile="~/masterBackend.master" AutoEventWireup="true" CodeFile="Document.aspx.cs" Inherits="BackEnd_pages_content_Document" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<div class="box_body">
    <div style=" text-align:center; width:100%; float:left;">
        <h1 style="color:Blue;">Quản lý tài liệu</h1>
    </div>
    <div class="box_search">
        <h3>Tìm kiếm</h3>
       <table cellspacing="7">
            <tr>
                <td>Loại tài liệu</td>
                <td>
                    <asp:DropDownList ID="ddlTypeDoc" runat="server">
                        <asp:ListItem Text="Bảng giá đất nhà nước" />
                        <asp:ListItem Text="Văn kiện liên quan đến BĐS" />
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>Ngày tạo</td>
            </tr>
            <tr>
                <td>Trạng thái</td>
                <td>
                    <asp:DropDownList ID="ddlStatus" runat="server">    
                        <asp:ListItem Text="Hiển thị"/>
                        <asp:ListItem Text="ẩn" />    
                    </asp:DropDownList>
                </td>
            </tr>
       </table>

    </div>
    <div class="doc_content" style=" float:left; width:100%;">
        <asp:Repeater ID="RptDocument" runat="server">
            <HeaderTemplate>
                <table cellspacing="0" class="tbl_doc" >
                    <thead>
                        <tr>
                            <td>Tên tài liệu</td>
                            <td class="td1">Chi tiết</td>
                            <td class="td1">Sửa</td>
                            <td class="td1">Xóa</td>
                        </tr>
                    </thead>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td style=" width:500px;"><%#Eval("Title") %></td>
                    <td class="td2">
                    
                        <asp:LinkButton ID="lbtDetail" runat="server">Chi tiết</asp:LinkButton>
                    <td class="td2">
                        <asp:LinkButton ID="lbtEdit" runat="server">Sửa</asp:LinkButton>
                    </td>
                    <td class="td2">
                        <asp:LinkButton ID="lbtDelete" CssClass="xoa" runat="server"  CommandArgument='<%#Eval("DocumentID") %>'>Xóa</asp:LinkButton>
                    </td>
                </tr>
            </ItemTemplate>
           <FooterTemplate>
                </table>
           </FooterTemplate>
        </asp:Repeater>
    </div>
     <div id="divPaging" runat="server" class="paginator2 nr">
         <uc1:ucPaging ID="ucPaging1" runat="server" />       
       </div>
</div>
</asp:Content>

