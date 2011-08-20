<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="Partners.aspx.cs" Inherits="BackEnd_pages_content_Partners" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center style="color: Red; line-height: 30px;">
        <asp:Label ID="lblMsg" runat="server"></asp:Label></center>
    <asp:Panel ID="Panel2" runat="server" Visible="false">
       <div class="box" style="width: 920px">
            <div class="title">
                <span style="float:left">Thêm mới</span>
                <asp:LinkButton ID="LinkButton1" runat="server" CssClass="title-addnew" OnClick="btnHuy1_Click">
                    <img src="/BackEnd/img/cancel.png" style="vertical-align: top" alt='' />
                    Bỏ qua
                </asp:LinkButton>
                <asp:LinkButton ID="LinkButton2" runat="server" CssClass="title-addnew" OnClick="btnAdd_Click" ValidationGroup="addPat">
                    <img src="/BackEnd/img/page_save.png" style="vertical-align: top" alt='' />
                    Lưu
                </asp:LinkButton>
                <div class="clearn">
                </div>
            </div>            
            <div class="content">
                <table cellspacing="8" class="tbDoc_my">
                    <tr>
                        <td style="width:150px">
                            Tên:
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="180" CssClass="inputbox" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtName" ValidationGroup="addPat"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Logo:
                        </td>
                        <td style="padding: 5px 0;">
                            <asp:FileUpload ID="fuploadLogo" runat="server" CssClass="inputbox" />
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="fuploadLogo" ValidationGroup="addPat"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Website đối tác
                        </td>
                        <td>
                            <asp:TextBox ID="txtWeb" runat="server" CssClass="inputbox" Width="180px" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Trạng thái:
                        </td>
                        <td>
                                <asp:DropDownList ID="ddlStatus" runat="server" Width="80px">
                                    <asp:ListItem Value="1" Text="Hoạt động"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="Bị khóa"></asp:ListItem>
                                </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div class="box" style="width: 920px">
            <div class="title">
                <span style="float:left">Chi tiết</span>
                <asp:LinkButton ID="lbtHuy" runat="server" CssClass="title-addnew" OnClick="btnHuy_Click">
                    <img src="/BackEnd/img/cancel.png" style="vertical-align: top" alt='' />
                    Bỏ qua
                </asp:LinkButton>
                <asp:LinkButton ID="lbtUpdate" runat="server" CssClass="title-addnew" OnClick="btnUpdate_Click" ValidationGroup="editPat">
                    <img src="/BackEnd/img/page_save.png" style="vertical-align: top" alt='' />
                    Lưu
                </asp:LinkButton>
                <div class="clearn">
                </div>
            </div>            
            <div class="content">                
                <div>
                    <table cellspacing="8" class=" tbDoc_my">
                        <tr>
                            <td style="width:150px;">
                                Tên:
                            </td>
                            <td>
                                <asp:TextBox ID="txtNameEdit" runat="server" Text='' Width="250" CssClass="inputbox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*" ForeColor="Red" ControlToValidate="txtNameEdit" ValidationGroup="editPat"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Logo mới:
                            </td>
                            <td>
                                <asp:FileUpload ID="fuploadEdit" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Website đối tác:
                            </td>
                            <td>
                                <asp:TextBox ID="txtWebEdit" runat="server" Text='' Width="180" CssClass="inputbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Trạng thái hiển thị
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlStatusEdit" runat="server" Width="80px">
                                    <asp:ListItem Value="1" Text="Hoạt động"></asp:ListItem>
                                    <asp:ListItem Value="0" Text="Bị khóa"></asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server">
        <div class="box" style="width: 920px;">
            <div class="title">
                <span>Danh sách đối tác</span>
                <asp:LinkButton ID="lbtAddNew" runat="server" CssClass="title-addnew" OnClick="btnThemmoi_Click">
                <img src="/BackEnd/img/addnew_16.png" style="vertical-align: top" alt='Thêm mới' />
                Thêm mới
                </asp:LinkButton>
            </div>
            <div class="content">
                <asp:Repeater ID="RptPartner" runat="server" OnItemCommand="RptPartner_ItemCommand"
                    OnItemDataBound="RptPartner_ItemDataBound">
                    <HeaderTemplate>
                        <div class="adminListRow-Header">
                            <div class="adminColumn" style="width: 30px">
                                STT
                            </div>
                            <div class="adminColumn" style="width: 170px; padding-left: 20px;">
                                Logo
                            </div>
                            <div class="adminColumn" style="width: 500px; text-align: left">
                                Tên
                            </div>
                            <div class="adminColumn" style="width: 80px;">
                                Trạng thái
                            </div>
                            <div class="adminColumn" style="width: 92px; float: right">
                                &nbsp;
                            </div>
                            <div class="clearn">
                            </div>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <div class="adminListRow-odd" id="divListRow" runat="server">
                            <div class="adminColumn" id="divCheckbox" style="width: 30px; vertical-align: bottom;">
                                <span id="spSTT" runat="server"></span>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 170px; text-align: center; padding-left: 15px;">
                                <img src='<%#Eval("Img")%>' alt="anh" width="150" height="100" />
                                &nbsp;
                            </div>
                            <div class="adminColumn" style="width: 500px; text-align: justify;">
                                <%#Eval("Name")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 80px; text-align: center;">
                                <%#Convert.ToBoolean(Eval("Status")??false)?"Hoạt động":"Bị khóa" %>
                            </div>
                            <div class="adminColumn" style="width: 92px; float: right">
                                <%if ((permission | VTCO.Config.Constants.PERMISSION_READ) != VTCO.Config.Constants.PERMISSION_READ)
                                  { %>
                                <div class="function">
                                    <ul>
                                        <li><a id="aContextMenu" href="javascript:;"><span style="float: left;">Chức năng</span>
                                            <span class="drop">
                                                <img src="/BackEnd/img/down.gif" /></span>
                                            <div class="clear">
                                            </div>
                                        </a>
                                            <ul class="context-menu">
                                                <%if ((permission & VTCO.Config.Constants.PERMISSION_EDIT) == VTCO.Config.Constants.PERMISSION_EDIT)
                                                  { %>
                                                <li>
                                                    <asp:LinkButton ID="lbtEdit" runat="server" CssClass="edit_icon" ToolTip="Sửa" CommandName="edit"
                                                        CommandArgument='<%#Eval("PartnersID") %>' Text="Sửa">
                                                    </asp:LinkButton>
                                                </li>
                                                <li>
                                                    <asp:LinkButton ID="lbtLock" runat="server" CssClass='lock_icon' ToolTip='Khóa' CommandName="lockNews"
                                                        CommandArgument='<%#Eval("PartnersID") %>' Text="Khóa">
                                                    </asp:LinkButton>
                                                    <asp:LinkButton ID="lbtUnLock" runat="server" CssClass='checked_icon' ToolTip='Kích hoạt'
                                                        CommandName="unlockNews" CommandArgument='<%#Eval("PartnersID") %>' Text="Kích hoạt">
                                                    </asp:LinkButton>
                                                </li>
                                                <%}%>
                                                <%if ((permission & VTCO.Config.Constants.PERMISSION_DELETE) == VTCO.Config.Constants.PERMISSION_DELETE)
                                                  { %>
                                                <li>
                                                    <asp:LinkButton ID="lbtDelete" runat="server" CssClass="delete_icon" ToolTip="Xóa"
                                                        OnClientClick="return ConfirmDelete()" CommandName="delete" CommandArgument='<%#Eval("PartnersID") %>'
                                                        Text="Xóa">
                                                    </asp:LinkButton>
                                                </li>
                                                <%} %>
                                            </ul>
                                        </li>
                                    </ul>
                                </div>
                                <%} %>
                            </div>
                            <div class="clearn">
                            </div>
                        </div>
                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
