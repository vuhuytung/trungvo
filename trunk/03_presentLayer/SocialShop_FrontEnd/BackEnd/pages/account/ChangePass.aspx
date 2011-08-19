<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="ChangePass.aspx.cs" Inherits="BackEnd_pages_account_ChangePass" %>

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
                <span style="float: left" runat="server" id="spTitle">Đổi mật khẩu</span>
                <asp:LinkButton ID="lbtSave" runat="server" CssClass="title-addnew" ValidationGroup="changepass"
                    OnClick="lbtSave_Click">
                    <img src="/BackEnd/img/page_save.png" style="vertical-align: top" alt='' />
                    Cập nhật
                </asp:LinkButton>
            </div>
            <div class="content">
                <table>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Mật khẩu cũ:
                        </td>
                        <td style="width: 160px" class="tdStyle" colspan="2">
                            <asp:TextBox ID="txtPassword" TextMode="Password" runat="server" Width="200px" MaxLength="100" CssClass="inputText"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Mật khẩu mới:
                        </td>
                        <td style="padding-top: 12px;" class="tdStyle" colspan="2">
                            <asp:TextBox ID="txtPasswordNew" TextMode="Password" runat="server" Width="200px" MaxLength="100" CssClass="inputText"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ValidationGroup="changepass"
                                ForeColor="Red" ErrorMessage="*" ControlToValidate="txtPasswordNew"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr runat="server" id="trPass">
                        <td class="tdStyle">
                            Nhập lại mật khẩu mới:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtPasswordNewAgain" TextMode="Password" runat="server" Width="200px" MaxLength="100" CssClass="inputText"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ValidationGroup="changepass"
                                ForeColor="Red" ErrorMessage="*" ControlToValidate="txtPasswordNewAgain"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ValidationGroup="changepass"
                                ForeColor="Red" ErrorMessage="*" ControlToValidate="txtPasswordNewAgain" ControlToCompare="txtPasswordNew" ></asp:CompareValidator>
                        </td>
                        <td class="tdStyle" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </div>
        </div>
</asp:Content>
