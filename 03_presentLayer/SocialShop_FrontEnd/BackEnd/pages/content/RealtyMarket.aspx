<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="RealtyMarket.aspx.cs" Inherits="BackEnd_pages_content_RealtyMarket" %>

<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucpaging" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center style="color: Red; line-height: 30px;">
        <asp:Label ID="lblMsg" runat="server"></asp:Label></center>
    <asp:Panel ID="Panel1" runat="server" Visible="false">
        <div id="divNewsInfo" class="box" style="width: 920px">
            <div class="title">
                <span style="float: left" runat="server" id="spTitle">Chi tiết</span>
                <asp:LinkButton ID="btnHuy1" runat="server" CssClass="title-addnew" OnClick="btnHuy_Click">
                    <img src="/BackEnd/img/cancel.png" style="vertical-align: top" alt='' />
                    Bỏ qua
                </asp:LinkButton>
                <asp:LinkButton ID="lbtSave" runat="server" CssClass="title-addnew" 
                    OnClick="btnUpdate_Click">
                    <img src="/BackEnd/img/page_save.png" style="vertical-align: top" alt='' />
                    Lưu
                </asp:LinkButton>                
            </div>
            <div class="content">
                <table cellspacing="8" class="tbEdit">
                    <tr>
                        <td>
                            Tiêu đề:
                        </td>
                        <td colspan="3">
                            <b><asp:Label runat="server" ID="lblTitle"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Người đăng:
                        </td>
                        <td style="padding: 5px 0;">                            
                            <b><asp:Label runat="server" ID="lblUser"></asp:Label></b>
                        </td>
                        <td>
                            Địa điểm:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblAddress"></asp:Label></b>
                        </td>
                    </tr>                    
                    <tr>
                        <td>
                            Danh mục:
                        </td>
                        <td style="padding: 5px 0px;">
                           <b><asp:Label runat="server" ID="lblCategory"></asp:Label></b>
                        </td>
                        <td>
                            Địa chỉ:
                        </td>
                        <td>
                            <b><asp:Label runat="server" ID="lblAddressStreet"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Điện thoại:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblPhone"></asp:Label></b>
                        </td>
                        <td>
                            Email:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblEmail"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Diện tích:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblAreage"></asp:Label> m²</b>
                        </td>
                        <td>
                            Tình trạng pháp lý:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblLegatStatus"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Hướng Bất động sản:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblPosition"></asp:Label></b>
                        </td>
                        <td>
                            Số tầng:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblFloor"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phòng khách:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblClientRoom"></asp:Label></b>
                        </td>
                        <td>
                            Phòng ngủ:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblBedRoom"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Phòng tắm:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblBathRoom"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Gần trường mẫu giáo:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblNearKindergarten"></asp:Label></b>
                        </td>
                        <td>
                            Gần trường trung học:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblNearSchool"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Gần bệnh viện:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblNearHospital"></asp:Label></b>
                        </td>
                        <td>
                            Gần chợ:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblMarket"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Gần trường Đại học:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblNearUniversity"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Giá BĐS:
                        </td>
                        <td style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblPrice"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Hình ảnh:
                        </td>
                        <td>
                            <asp:Image runat="server" ID="imgImage" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mô tả:
                        </td>
                        <td colspan="2" style="padding: 5px 0;">
                            <b><asp:Label runat="server" ID="lblDescription"></asp:Label></b>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Trạng thái hiển thị
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlStatus">
                                <asp:ListItem Value="1" Text="Hoạt động"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Khóa"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server">
        <div id="divSearch" class="box" style="width: 920px">
            <div class="title">
                <span>Quản lý bất động sản</span>
            </div>
            <div class="content" style="width: 918px">
                <table style="margin: auto; height: 70px;">
                    <tr>
                        <td>
                            Tp/Tỉnh
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td style="padding: 5px 5px;">
                            Quận/Huyện
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" Height="22px"
                                Width="136px">
                            </asp:DropDownList>
                        </td>
                        <td style="padding: 5px 5px;">
                            <%--Phường/Xã--%>
                        </td>
                        <td style="padding: 5px 5px;">
                            <%--<asp:DropDownList ID="ddlVillage" runat="server" Width="136px">
                                </asp:DropDownList>--%>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Danh mục
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlTypeBDS" runat="server" Width="140px">
                            </asp:DropDownList>
                        </td>
                        <td style="padding: 5px 5px;">
                            Khoảng Giá
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlPrice" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            Trạng thái
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlStatusSearch" runat="server">
                                <asp:ListItem Text="Tất cả" Value="-1"/>
                                <asp:ListItem Text="Chưa duyệt" Value="0" />
                                <asp:ListItem Text="Chấp nhận" Value="1" />
                                <asp:ListItem Text="Từ chối" Value="2" />
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: center; padding-top: 7px;">
                            <asp:Button ID="btnSearch" runat="server" Text="Tìm" Width="70px" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div id="divListNews" runat="server" class="box" style="width: 920px;">
            <div class="title">
                <span style="float: left">Danh sách bất động sản </span>
                <asp:LinkButton ID="LinkButton2" OnClientClick="return ConfirmDelete();" runat="server"
                    CssClass="title-addnew" OnClick="lbtDeleteAll_Click">
                <img src="/BackEnd/img/icon-delete.png" style="vertical-align: top" alt='Xóa' />
                Xóa
                </asp:LinkButton>
            </div>
            <div class="clearn">
            </div>
            <div class="content" style="width: 100% !important">
                <asp:Repeater ID="RptReatyMarket" runat="server" OnItemCommand="RptReatyMarket_ItemCommand"
                    OnItemDataBound="RptReatyMarket_ItemDataBound">
                    <HeaderTemplate>
                        <div class="adminListRow-Header">
                            <div class="adminColumn" style="width: 20px;">
                                <input type="checkbox" id="chkAll" />
                            </div>
                            <div class="adminColumn" style="width: 30px">
                                STT
                            </div>
                            <div class="adminColumn" style="width: 370px; padding-left: 20px; text-align: left;">
                                Tiêu đề
                            </div>
                            <div class="adminColumn" style="width: 120px; text-align:left">
                                Người đăng
                            </div>
                            <div class="adminColumn" style="width: 80px; text-align:left">
                                Ngày tạo
                            </div>
                            <div class="adminColumn" style="width: 120px; text-align:left">
                                Người dùng
                            </div>
                            <div class="adminColumn" style="width: 65px; text-align:left">
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
                            <div class="adminColumn" id="divCheckbox" style="width: 20px; vertical-align: bottom;">
                                    <asp:CheckBox ID="chkDeleteAll" runat="server" />
                                    <asp:HiddenField ID="hdID" runat="server" Value=' <%#Eval("RealtyMarketID") %>' />
                            </div>
                            <div class="adminColumn" style="width: 30px; text-align: left; padding-left: 15px;">
                                <%#Eval("RowNumber")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 370px; text-align: justify;">
                                <%#Eval("Title")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 120px; text-align:left">
                                <b><%#Eval("UserPublish") %></b>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 80px">
                                <%#Convert.ToDateTime(Eval("CreateDate")).ToString("dd/MM/yyyy")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 120px; text-align:left">
                                <%#Eval("UserName") %>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 65px; text-align: center;">
                                <%#Convert.ToInt32(Eval("Status")??0)==0?"Chưa duyệt":(Convert.ToInt32(Eval("Status")??0)==1?"Chấp nhận":"Từ chối") %>
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
                                                        CommandArgument='<%#Eval("RealtyMarketID") %>' Text="Sửa">
                                                    </asp:LinkButton>
                                                </li>
                                                <li id="liLock" runat="server">
                                                    <asp:LinkButton ID="lbtLock" runat="server" CssClass='lock_icon' ToolTip='Từ chối' CommandName="lockNews"
                                                        CommandArgument='<%#Eval("RealtyMarketID") %>' Text="Từ chối">
                                                    </asp:LinkButton>
                                                </li>
                                                <li id="liUnLock" runat="server">
                                                    <asp:LinkButton ID="lbtUnLock" runat="server" CssClass='checked_icon' ToolTip='Chấp nhận'
                                                        CommandName="unlockNews" CommandArgument='<%#Eval("RealtyMarketID") %>' Text="Chấp nhận">
                                                    </asp:LinkButton>
                                                </li>
                                                <%}%>
                                                <%if ((permission & VTCO.Config.Constants.PERMISSION_DELETE) == VTCO.Config.Constants.PERMISSION_DELETE)
                                                  { %>
                                                <li>
                                                    <asp:LinkButton ID="lbtDelete" runat="server" CssClass="delete_icon" ToolTip="Xóa"
                                                        OnClientClick="return ConfirmDelete()" CommandName="delete" CommandArgument='<%#Eval("RealtyMarketID") %>'
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
                </asp:Repeater>
                <div class="clearn">
                </div>
                <div id="divPaging" runat="server" class="paginator2 nr">
                    <uc1:ucpaging ID="ucPaging1" runat="server" />
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
