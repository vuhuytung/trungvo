<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="AdminInfo.aspx.cs" Inherits="BackEnd_pages_account_AdminInfo" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucPaging" TagPrefix="uc1" %>
<asp:Content ID="contentHead" runat="server" ContentPlaceHolderID="Header">
    <script type="text/javascript">
        function blink(classname) {
            setTimeout('$(".' + classname + '").css("color", "Red")', 300);
            setTimeout('$(".' + classname + '").css("color", "Yellow")', 700);
            //setTimeout('$(".' + classname + '").css("color", "Green")', 900);
            setTimeout('blink("' + classname + '")', 800);
        }
        $(function () {
            $("#chkAll").click(function () {
                $(".adminListRow-odd, .adminListRow-even").find("input:checkbox").attr("checked", $(this).attr("checked"));
            });
            blink("blink");
        });
    </script>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <telerik:RadScriptManager ID="RadScriptManager1" runat="server">
    </telerik:RadScriptManager>
    <center style="color: Red; line-height: 30px; font-size:16px; font-weight:bold">
        <asp:Label ID="lblMsg" CssClass="blink" runat="server"></asp:Label></center>    
        <div id="divNewsInfo" class="box" style="width: 920px">
            <div class="title">
                <span style="float: left" runat="server" id="spTitle">Thông tin tài khoản</span>
                <asp:LinkButton ID="lbtSave" runat="server" CssClass="title-addnew" ValidationGroup="news"
                    OnClick="lbtSave_Click">
                    <img src="/BackEnd/img/page_save.png" style="vertical-align: top" alt='' />
                    Lưu
                </asp:LinkButton>
            </div>
            <div class="content">
                <table>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Tên đăng nhập:
                        </td>
                        <td style="width: 160px" class="tdStyle" colspan="2">
                            <asp:TextBox ID="txtUserName" runat="server" Width="200px" MaxLength="100" CssClass="inputText"></asp:TextBox>
                            <asp:Label runat="server" ID="lblUserName"></asp:Label>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ValidationGroup="news"
                                ForeColor="Red" ErrorMessage="*" ControlToValidate="txtUserName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Tên đầy đủ:
                        </td>
                        <td style="padding-top: 12px;" class="tdStyle" colspan="2">
                            <asp:TextBox ID="txtFullName" runat="server" Width="200px" MaxLength="100" CssClass="inputText"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="news"
                                ForeColor="Red" ErrorMessage="*" ControlToValidate="txtFullName"></asp:RequiredFieldValidator>
                        </td>
                    </tr>                    
                    <tr>
                        <td class="tdStyle">
                            Email:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtEmail" runat="server" Width="200px" MaxLength="100" CssClass="inputText"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ValidationGroup="news"
                                ForeColor="Red" ErrorMessage="*" ControlToValidate="txtEmail"></asp:RequiredFieldValidator>
                        </td>
                        <td style="" class="tdStyle" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Điện thoại:
                        </td>
                        <td class="tdStyle" colspan="3">
                            <asp:TextBox ID="txtTelephone" runat="server" Width="200px" MaxLength="100" CssClass="inputText"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ValidationGroup="news"
                                ForeColor="Red" ErrorMessage="*" ControlToValidate="txtTelephone"></asp:RequiredFieldValidator>
                        </td>                        
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Ngày sinh:
                        </td>
                        <td class="tdStyle">
                            <div style="width: 150px">
                                <telerik:RadDatePicker ID="rdpBirthday" runat="server" Culture="vi-VN" Skin="WebBlue">
                                    <Calendar Skin="WebBlue" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                        ViewSelectorText="x">
                                    </Calendar>
                                    <DateInput LabelCssClass="radLabelCss_WebBlue" Skin="WebBlue">
                                    </DateInput>
                                </telerik:RadDatePicker>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red"
                                    ErrorMessage="*" ValidationGroup="news" ControlToValidate="rdpBirthday"></asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td class="tdStyle">
                            Ngày tạo:
                        </td>
                        <td class="tdStyle">
                            <asp:Label runat="server" ID="lblCreateDate"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td class="tdStyle">
                            Mô tả
                        </td>
                        <td colspan="3" class="tdStyle">
                            <asp:TextBox ID="txtAbstract" runat="server" Width="500px" MaxLength="250" Height="100px"
                                CssClass="inputText" TextMode="MultiLine" Rows="2" Font-Names="Arial" Font-Size="13px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ValidationGroup="news"
                                ForeColor="Red" ErrorMessage="*" ControlToValidate="txtAbstract"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
</asp:Content>
