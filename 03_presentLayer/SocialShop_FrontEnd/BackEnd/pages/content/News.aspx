<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="News.aspx.cs" Inherits="BackEnd_pages_content_News" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<asp:Content ID="contentHead" runat="server" ContentPlaceHolderID="Header">
    <script type="text/javascript">
        $(function () {
            $("#chkAll").click(function () { 
                $(".adminListRow-odd, .adminListRow-even").find("input:checkbox").attr("checked",$(this).attr("checked"));
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <center style="color: Red; line-height: 30px;">
        <asp:Label ID="lblMsg" runat="server"></asp:Label></center>
    <asp:Panel ID="pnlManager" runat="server">
        <div id="divSearch" class="box" style="width: 920px">
            <div class="title">
                <span>Quản lý tin tức</span>
            </div>
            <div class="content" style="width: 918px">
                <table style="width: auto; margin: auto; height: 70px;">
                    <tr>
                        <td style="width: 80px">
                            Chuyên mục:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlCategory" runat="server" Width="150px">
                            </asp:DropDownList>
                        </td>
                        <td style="width: 80px;">
                            Tiêu đề:
                        </td>
                        <td style="width: 220px;" colspan="2">
                            <asp:TextBox ID="txtKeyword" runat="server" CssClass="inputbox" Width="200px"></asp:TextBox>
                        </td>
                        <td colspan="2">
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 80px">
                            Từ ngày:
                        </td>
                        <td style="width: 200px">
                            <div style="width: 150px">
                                <telerik:RadDatePicker ID="rdpFromDate" runat="server" Culture="vi-VN" Skin="WebBlue">
                                </telerik:RadDatePicker>
                            </div>
                        </td>
                        <td style="width: 80px">
                            Đến ngày:
                        </td>
                        <td style="width: 200px">
                            <div style="width: 150px">
                                <telerik:RadDatePicker ID="rdpToDate" runat="server" Culture="vi-VN" Skin="WebBlue">
                                </telerik:RadDatePicker>
                            </div>
                        </td>
                        <td style="width: 70px">
                            Trạng thái:
                        </td>
                        <td style="width: 90px">
                            <asp:DropDownList ID="ddlStatus" runat="server" Width="80px">
                                <asp:ListItem Value="-1" Text="Tất cả"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Hoạt động"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Bị khóa"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 50px">
                            Tin hot:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlIsHot" runat="server">
                                <asp:ListItem Value="-1" Text="Tất cả"></asp:ListItem>
                                <asp:ListItem Value="1" Text="Có"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Không"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="width: 80px">
                            <div style="float: right; padding-left: 20px">
                                <asp:Button ID="btnSearch" runat="server" Text=" Tìm kiếm " ToolTip="Tìm kiếm" OnClick="btnSearch_Click1" />
                            </div>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <%--Danh sách tin tức--%>
        <div id="divListNews" runat="server" class="box" style="width: 920px;">
            <div class="title">
                <span style="float: left">Danh sách tin tức </span>
                <asp:LinkButton ID="lbtAddNew" runat="server" CssClass="title-addnew" OnClick="lbtAddNew_Click">
                <img src="/BackEnd/img/addnew_16.png" style="vertical-align: top" alt='Thêm mới' />
                Thêm mới
                </asp:LinkButton>
                <asp:LinkButton ID="lbtDeleteAll" OnClientClick="return ConfirmDelete();" runat="server"
                    CssClass="title-addnew" OnClick="lbtDeleteAll_Click">
                <img src="/BackEnd/img/icon-delete.png" style="vertical-align: top" alt='Xóa' />
                Xóa
                </asp:LinkButton>
            </div>
            <div class="clearn">
            </div>
            <div class="content" style="width: 100% !important">
                <asp:Repeater ID="rptAllNews" runat="server" OnItemCommand="rptAllNews_ItemCommand"
                    OnItemDataBound="rptAllNews_ItemDataBound">
                    <HeaderTemplate>
                        <div class="adminListRow-Header">
                            <div class="adminColumn" style="width: 20px;">
                                <input type="checkbox" id="chkAll" />
                            </div>
                            <div class="adminColumn" style="width: 30px">
                                STT
                            </div>
                            <div class="adminColumn" style="width: 520px; padding-left:20px; text-align:left;">
                                Tiêu đề
                            </div>
                            <div class="adminColumn" style="width: 80px;">
                                Ngày tạo
                            </div>
                            <div class="adminColumn" style="width: 80px;">
                                Ngày đăng
                            </div>
                            <div class="adminColumn" style="width: 80px;">
                                Trạng thái
                            </div>
                            <div class="adminColumn" style="width: 80px; float: right">
                                Chức năng
                            </div>
                            <div class="clearn">
                            </div>
                        </div>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <asp:HiddenField ID="hdfNews" runat="server" Value='<%#Eval("NewsID") %>' />
                        <div class="adminListRow-odd" id="divListRow" runat="server">
                            <div class="adminColumn" id="divCheckbox" style="width: 20px; vertical-align: bottom;">
                                <asp:CheckBox ID="cbxCheck" runat="server" />&nbsp;
                                <asp:HiddenField runat="server" ID="hdNewsID" Value='<%#Eval("NewsID")%>' />
                            </div>
                            <div class="adminColumn" style="width: 30px; text-align: left; padding-left: 15px;">
                                <%#Eval("RowNumber")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 520px; text-align: justify;">
                                <%#Eval("Title")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 80px">
                                <%#Convert.ToDateTime(Eval("CreateDate")).ToString("dd/MM/yyyy")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 80px">
                                <%#Convert.ToDateTime(Eval("PublishDate")).ToString("dd/MM/yyyy")%>&nbsp;
                            </div>
                            <div class="adminColumn" style="width: 80px; text-align: center;">
                                <asp:LinkButton ID="lbtUnHot" runat="server" CssClass='unhot_action' ToolTip='Tin thường'
                                    CommandName="hotNews" CommandArgument='<%#Eval("NewsID") %>'>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtHot" runat="server" CssClass='hot_action' ToolTip='Tin hot'
                                    CommandName="unhotNews" CommandArgument='<%#Eval("NewsID") %>'>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtLock" runat="server" CssClass='lock_icon' ToolTip='Bị khóa'
                                    CommandName="unlockNews" CommandArgument='<%#Eval("NewsID") %>'>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtUnLock" runat="server" CssClass='checked_icon' ToolTip='Đang hoạt động'
                                    CommandName="lockNews" CommandArgument='<%#Eval("NewsID") %>'>
                                </asp:LinkButton>
                            </div>
                            <div class="adminColumn" style="width: 80px; float: right">
                                <asp:LinkButton ID="lbtEdit" runat="server" CssClass="edit_icon" ToolTip="Sửa" CommandName="edit"
                                    CommandArgument='<%#Eval("NewsID") %>'>
                                </asp:LinkButton>
                                <asp:LinkButton ID="lbtDelete" runat="server" CssClass="delete_icon" ToolTip="Xóa"
                                    OnClientClick="return ConfirmDelete()" CommandName="delete" CommandArgument='<%#Eval("NewsID") %>'>
                                </asp:LinkButton>&nbsp;
                            </div>
                            <div class="clearn">
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
                <p runat="server" id="pNoRow" style="text-align: center" visible="false">
                    Không tìm thấy bản ghi nào!</p>
                <div class="clearn">
                </div>
                <div id="divPaging" runat="server" class="paginator2 nr">
                    <uc1:ucPaging ID="ucPaging1" runat="server" />
                </div>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlDetail">
        <div id="divNewsInfo" class="box" style="width: 920px">
            <div class="title">
                <span style="float: left" runat="server" id="spTitle">Chi tiết</span>
                <asp:LinkButton ID="lbtCancel" runat="server" CssClass="title-addnew" OnClick="lbtCancel_Click">
                    <img src="/BackEnd/img/cancel.png" style="vertical-align: top" alt='' />
                    Bỏ qua
                </asp:LinkButton>
                <asp:LinkButton ID="lbtSave" runat="server" CssClass="title-addnew" ValidationGroup="news"
                    OnClick="lbtSave_Click">
                    <img src="/BackEnd/img/page_save.png" style="vertical-align: top" alt='' />
                    Lưu
                </asp:LinkButton>
                <asp:LinkButton ID="LinkView" runat="server" CssClass="title-addnew" ValidationGroup="valSave"
                    OnClick="LinkView_Click">
                    <img src="/BackEnd/img/page_save.png" style="vertical-align: top" alt='' />
                    Xem trước
                </asp:LinkButton>
            </div>
            <div class="content">
                <table>
                    <tr runat="server" id="trAdmin">
                        <td style="width: 100px" class="tdStyle">
                            Người tạo:
                        </td>
                        <td style="width: 160px" class="tdStyle">
                            <asp:Label ID="lbAccountEdit" runat="server" Text="" Font-Bold="True"></asp:Label>
                        </td>
                        <td class="tdStyle" style="width: 150px">
                            &nbsp;
                        </td>
                        <td style="width: 100px" class="tdStyle">
                            Người sửa:
                        </td>
                        <td style="width: 300px" class="tdStyle">
                            <asp:Label ID="lblAccountModifyEdit" runat="server" Text="" Font-Bold="True"></asp:Label>
                        </td>
                        <td style="" class="tdStyle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr runat="server" id="trDate">
                        <td style="width: 100px" class="tdStyle">
                            Ngày tạo:
                        </td>
                        <td style="width: 160px" class="tdStyle">
                            <asp:Label ID="lbCreateDateEdit" runat="server" Font-Bold="True"></asp:Label>
                        </td>
                        <td class="tdStyle" style="width: 150px">
                            &nbsp;
                        </td>
                        <td style="width: 100px" class="tdStyle">
                            Ngày sửa:
                        </td>
                        <td style="width: 300px" class="tdStyle">
                            <asp:Label ID="lblLastModifyEdit" runat="server" Text="" Font-Bold="True"></asp:Label>
                        </td>
                        <td style="" class="tdStyle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Ngày đăng:
                        </td>
                        <td style="width: 160px" class="tdStyle">
                            <div style="width: 150px">
                                <telerik:RadDatePicker ID="rdpPublishDateEdit" runat="server" Culture="vi-VN" Skin="WebBlue">
                                    <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput LabelCssClass="radLabelCss_WebBlue" Skin="WebBlue">
                                    </DateInput>
                                </telerik:RadDatePicker>
                            </div>
                        </td>
                        <td class="tdStyle" style="width: 150px">
                            &nbsp;
                        </td>
                        <td class="tdStyle" style="width: 100px">
                            Trạng thái:
                        </td>
                        <td style="width: 300px" class="tdStyle">
                            <asp:DropDownList runat="server" ID="ddlStatusEdit">
                                <asp:ListItem Value="1" Text="Hoạt động"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Khóa"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="" class="tdStyle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Chuyên mục:
                        </td>
                        <td style="width: 160px" class="tdStyle">
                            <asp:DropDownList ID="ddlNewsMenu" runat="server" Width="150">
                            </asp:DropDownList>
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="ddlNewsMenu"
                                ErrorMessage="*" ValidationExpression="[1-9][0-9]*" ValidationGroup="news" SetFocusOnError="True"
                                Font-Bold="True"></asp:RegularExpressionValidator>
                        </td>
                        <td class="tdStyle" style="width: 150px">
                            &nbsp;
                        </td>
                        <td class="tdStyle" style="width: 100px">
                            Tin nóng:
                        </td>
                        <td style="width: 300px" class="tdStyle">
                            <asp:DropDownList runat="server" ID="ddlIsHotEdit">
                                <asp:ListItem Value="1" Text="Tin hot"></asp:ListItem>
                                <asp:ListItem Value="0" Text="Tin thường"></asp:ListItem>
                            </asp:DropDownList>
                        </td>
                        <td style="" class="tdStyle">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Tiêu đề
                        </td>
                        <td colspan="5" class="tdStyle" style="width: 720px">
                            <asp:TextBox ID="txtTitle" runat="server" Width="450px" MaxLength="100" CssClass="inputText"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Mô tả
                        </td>
                        <td colspan="5" class="tdStyle">
                            <asp:TextBox ID="txtAbstract" runat="server" Width="500px" MaxLength="250" Height="100px"
                                CssClass="inputText" TextMode="MultiLine" Rows="2" Font-Names="Arial" Font-Size="13px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr valign="top">
                        <td style="width: 100px" class="tdStyle">
                            Ảnh đại diện
                        </td>
                        <td class="tdStyle">
                            <div style="border: 1px solid #E2E5E6; max-height: 150px; max-width: 150px">
                                <img width="150" style="max-height: 150px; max-width: 150px" alt="" runat="server"
                                    id="imgNews" src="~/BackEnd/img/noimage.jpg" />
                            </div>
                        </td>
                        <td class="tdStyle" colspan="4">
                            <asp:FileUpload ID="UploadImage" runat="server" Width="220" /><br />
                            <asp:RegularExpressionValidator ID="vldUploadImage1" runat="server" ControlToValidate="UploadImage"
                                ValidationExpression="(.*\.([gG][iI][fF]|[jJ][pP][gG]|[jJ][pP][eE][gG]|[pP][nN][gG])$)"
                                Display="Dynamic" ErrorMessage="File *.Gif, *.Jpg, *.Jpeg, *.Png" ValidationGroup="news"
                                Enabled="true" SetFocusOnError="True"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle" style="vertical-align: top; width: 100px">
                            Nội dung:
                        </td>
                        <td colspan="5" class="tdStyle" style="width: 600px;">
                            <telerik:RadEditor ID="radContent" runat="server" ContentFilters="FixEnclosingP" AutoResizeHeight="True" EnableResize="False" Width="600px" 
                            ImageManager-DeletePaths="~/images/news" ImageManager-ViewPaths="~/images/news" ImageManager-UploadPaths="~/images/news" ToolsFile="~/App_Data/ToolsFile.xml"
                            FlashManager-ViewPaths="~/images/news" FlashManager-UploadPaths="~/images/news" FlashManager-DeletePaths="~/images/news" 
                            MediaManager-ViewPaths="~/images/news" MediaManager-UploadPaths="~/images/news" MediaManager-DeletePaths="~/images/news">
                            </telerik:RadEditor>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="radContent"
                                ErrorMessage="Chưa nhập nội dung" SetFocusOnError="True" ValidationGroup="news"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Nguồn trích dẫn:
                        </td>
                        <td colspan="5" class="tdStyle">
                            <asp:TextBox ID="txtResource" runat="server" Width="400px" MaxLength="250" CssClass="inputText"
                                Font-Names="Arial" Font-Size="13px"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </asp:Panel>
    <asp:Panel runat="server" ID="pnlView">
        <div class="box">
            <div class="title">
                Xem trước
                <asp:LinkButton ID="linkBack" runat="server" CssClass="title-addnew" OnClick="linkBack_Click">
                    <img alt="" src="/BackEnd/img/left_32.png" style="vertical-align: top" width="16px" height="16px" />
                    Quay lại
                </asp:LinkButton>
                <span class="title-addnew">&nbsp;&nbsp;&nbsp;&nbsp;</span>
            </div>
            <div class="content">
                <div class="Container_body">
                    <div class="body_content" style="padding: 5px; padding-bottom: 20px">
                        <div class="box_content_left_music nr">
                            Phần bên phải trang
                        </div>
                        <div class="box_content_center_music nl">
                            <div class="titel_lager" style="font-size: 13px;">
                                <asp:Literal runat="server" ID="ltrTitleTemp"></asp:Literal>
                            </div>
                            <div style="color: #aaa; font-size: 13px;">
                                <asp:Literal runat="server" ID="ltrCreateDateTemp"></asp:Literal>
                            </div>
                            <div class="titel_tomtat" style="width: auto; color: #5f5f5f; font-size: 13px;">
                                <asp:Literal runat="server" ID="ltrAbstractTemp"></asp:Literal>
                            </div>
                            <br />
                            <br />
                            <div style="text-align: center">
                                <img style="width: 450px" alt="" runat="server" id="imgNewsTemp" src="" />
                            </div>
                            <div style="clear: both">
                                &nbsp;</div>
                            <div>
                                <asp:Literal runat="server" ID="ltrContentTemp"></asp:Literal>
                            </div>
                        </div>
                        <div class="clearn">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </asp:Panel>
</asp:Content>
