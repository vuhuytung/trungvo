 <%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true" CodeFile="Document.aspx.cs" Inherits="BackEnd_pages_content_Document" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
   
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
  <ContentTemplate>
<div class="box_body">
 <asp:Panel ID="Panel1" runat="server" Visible="false" >
        <div class="box_hide"  >
           <div class="box_edit">
               <asp:Repeater ID="RptDetail" runat="server">
                <HeaderTemplate>
                    <table cellspacing="8">
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>Tiêu đề:</td>
                        <td>
                            <asp:TextBox ID="txtTitle" runat="server" Text='<%#Eval("Title")%>' Width="250"></asp:TextBox>
                            <asp:Label ID="lblDocID" runat="server" Text='<%#Eval("DocID") %>' Visible="false"></asp:Label>
                             <asp:Label ID="lblUrl" runat="server" Text='<%#Eval("URL") %>' Visible="false"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mô tả:
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Text='<%#Eval("Desc") %>' Width="250" Height="100"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>File</td>
                        <td>
                            <asp:FileUpload ID="fupload" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>Chuyên mục</td>
                        <td>
                            <asp:DropDownList ID="ddlTypeDoc" runat="server">
                                <asp:ListItem Text="Bảng giá đất nhà nước" Value="21" />
                                <asp:ListItem Text="Văn kiện liên quan đến BĐS" Value="22" />
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>Trạng thái</td>
                        <td>
                            <asp:CheckBox ID="chkstatus" runat="server" Checked=' <%#Convert.ToBoolean(Eval("Status")) %>' />                    
                            
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style=" padding:10px 100px;">
                            <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" onclick="btnUpdate_Click"  Width="70" />
                            <asp:Button ID="Button1" runat="server" Text="Hủy" onclick="Button1_Click" Width="70" />
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
               </asp:Repeater>
           </div>
          
        </div>
    </asp:Panel>
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
        <asp:Repeater ID="RptDocument" runat="server" 
            onitemcommand="RptDocument_ItemCommand">
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
                    
                        <asp:LinkButton ID="lbtDetail" runat="server" CommandName="Detail"  CommandArgument='<%#Eval("DocumentID") %>'>Chi tiết</asp:LinkButton>
                    <td class="td2">
                        <asp:LinkButton ID="lbtEdit" runat="server" CommandName="Edit"  CommandArgument='<%#Eval("DocumentID") %>'>Sửa</asp:LinkButton>
                    </td>
                    <td class="td2">
                        <asp:LinkButton ID="lbtDelete" CssClass="xoa" runat="server" CommandName="Delete"  CommandArgument='<%#Eval("DocumentID") %>'>Xóa</asp:LinkButton>
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
</ContentTemplate>
  </asp:UpdatePanel>
</asp:Content>

