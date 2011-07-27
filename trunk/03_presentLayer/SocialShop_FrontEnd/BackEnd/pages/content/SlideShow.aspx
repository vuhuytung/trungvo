<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="SlideShow.aspx.cs" Inherits="BackEnd_pages_content_SlideShow" %>
    <%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel2" runat="server" Visible="false">
        <div class="box_hide">
            <div class="box_edit">
                <table cellspacing="8">
                    <tr>
                        <td colspan="2" style="text-align: center; padding: 5px 0;">
                            <asp:Label ID="lblTitle" runat="server" Text="Thêm mới hình ảnh" Font-Size="18px"
                                ForeColor="red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Tiêu đề:
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:TextBox ID="txtTitle" runat="server" Width="250"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Ảnh
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:FileUpload ID="FileUpload1" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Trạng thái hiển thị
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:CheckBox ID="chkstatus" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="padding: 10px 100px;">
                            <script type="text/javascript">
                                function checkAdd() {
                                    var txtTitle = document.getElementById("ContentPlaceHolder1_txtTitle");
                                    var fupload = document.getElementById("ContentPlaceHolder1_FileUpload1");

                                    if (txtTitle.value == "") {
                                        alert('Tiêu đề không được để trống !');
                                        return false;
                                    }
                                    else if (fupload.value == "") {
                                        alert('bạn chưa chọn đường dẩn ảnh !');
                                        return false;
                                    }
                                  
                                    return true;
                                }
                                </script>
                            <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" OnClientClick="return checkAdd()" Width="70" />
                            <asp:Button ID="btnHuy" runat="server" Text="Thoát" OnClick="btnHuy_Click" Width="70" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div class="box_hide">
            <div class="box_edit">
                <asp:Repeater ID="RptDetail" runat="server">
                    <HeaderTemplate>
                        <table cellspacing="8">
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td colspan="2" style="text-align: center; padding: 5px 0;">
                                <asp:Label ID="lblTitle" runat="server" Text="Sửa thông tin" Font-Size="18px" ForeColor="red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            
                            <td style="padding: 5px 0;">
                                <asp:Image ID="Image1" runat="server"  ImageUrl='<%#Eval("Img") %>' Visible="false" />
                                <asp:HiddenField ID="ImgThumb" runat="server" Value='<%#Eval("ImgThumb") %>' />
                                <asp:Label ID="lblID" runat="server" Text='<%#Eval("ID") %>' Visible="false"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tiêu đề:
                            </td>
                            <td>
                                <asp:TextBox ID="txtDesc" runat="server" Text='<%#Eval("Title") %>' Width="250"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Ảnh mới:
                            </td>
                            <td style="padding: 5px 0;">
                                <asp:FileUpload ID="fupload" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Trạng thái hiển thị
                            </td>
                            <td style="padding: 5px 15px;">
                                <asp:CheckBox ID="chkstatus" BackColor="red" runat="server" Checked=' <%#Convert.ToBoolean(Eval("Status")) %>' />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2" style="padding: 10px 100px;">
                             <script type="text/javascript">
                                 function checkAdd1() {
                                     var txtTitle = document.getElementById("ContentPlaceHolder1_RptDetail_txtDesc_0");
                                     if (txtTitle.value == "") {
                                         alert('Tiêu đề không được để trống !');
                                         return false;
                                     }

                                     return true;
                                 }
                                </script>
                                <asp:Button ID="btnUpdate" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click" OnClientClick="return checkAdd1()"
                                    Width="70" />
                                <asp:Button ID="Button1" runat="server" Text="Thoát" OnClick="Button1_Click" Width="70" />
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
    <div class="box_body">
        <div style="text-align: center; width: 100%; float: left;">
            <h1 style="color: Blue;">
                Quản lý SlideShow ảnh</h1>
        </div>
         <div class="box" style="width: 940px; float: left;">
            <div class="title1" style="width: 960px;">
                <span>Danh sách hình ảnh</span>
                <asp:LinkButton ID="lbtAddNew" runat="server" CssClass="title-addnew" OnClick="btnThemmoi_Click">
                <img src="/BackEnd/img/addnew_16.png" style="vertical-align: top" alt='Thêm mới' />
                Thêm mới
                </asp:LinkButton>
                <asp:LinkButton ID="lbtDeleteAll" OnClientClick="return ConfirmDelete();" runat="server"
                    CssClass="title-addnew" OnClick="lbtDeleteAll_Click">
                <img src="/BackEnd/img/icon-delete.png" style="vertical-align: top" alt='Xóa' />
                Xóa
                </asp:LinkButton>
            </div>
        <div class="content1" style="width: 960px; float: left;">
            <asp:Repeater ID="RptSlide" runat="server" OnItemCommand="RptSlide_ItemCommand">
                <HeaderTemplate>
                    <table style="width: auto; margin: auto; height: 70px;" class="tbl_doc">
                        <thead>
                            <tr>
                                <td>
                                </td>
                                <td>
                                    TT
                                </td>
                                <td>
                                    Tiêu đề
                                </td>
                                <td>
                                    Trạng thái hiển thị
                                </td>
                                <td class="td1" >
                                    chức năng
                                </td>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td style=" width:20px; text-align:center;">
                            <asp:CheckBox ID="chkDeleteAll" runat="server" />
                        </td>
                        <td style=" width:40px;">
                            <%#Eval("RowNumber")%>
                        </td>
                        <td style="width:650px;">
                            <div class="img_thumb">
                                <img src='<%#Eval("ImgThumb")%>' alt="anh"  width="150" height="100" />
                                <asp:HiddenField ID="Img" runat="server" Value='<%#Eval("Img")%>' />
                                <asp:HiddenField ID="ImgThumb" runat="server" Value='<%#Eval("ImgThumb")%>' />
                                <asp:HiddenField ID="slID" runat="server" Value='<%#Eval("ID")%>' />
                            </div>
                            <div class="title_slide">
                                <a>
                                    <%#Eval("Title") %>
                                </a>
                            </div>
                        </td>
                        <td>
                            <asp:CheckBox ID="chkStatus" Checked='<%#Convert.ToBoolean(Eval("Status")) %>' runat="server"
                                Enabled="false" />
                        </td>
                        <td class="td2" style=" width:120px;">
                            <asp:LinkButton ID="lbtEdit" runat="server" ToolTip="Sửa" CssClass="edit_icon" CommandName="Edit" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
                            <script type="text/javascript">
                                function confirm1() {
                                    return confirm("Bạn có muốn xóa Record này ko ?");
                                }
                            </script>
                            <asp:LinkButton ID="lbtDelete" ToolTip="Xóa" CssClass="delete_icon" runat="server" CommandName="Delete"
                                OnClientClick="return confirm1()" CommandArgument='<%#Eval("ID") %>'></asp:LinkButton>
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
    </div>
</asp:Content>
