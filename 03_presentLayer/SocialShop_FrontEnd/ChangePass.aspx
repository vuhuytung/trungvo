<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="ChangePass.aspx.cs" Inherits="ChangePass" %>
    <%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        td
        {
            padding: 5px;
        }
        .require
        {
            color: Red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <div class="bodyContent">
        <div class="leftMain nl">
            <center>
                <table width="450px" style="margin: auto; text-align: left; background: #FFF; border: #B0E5F7 solid 3px; margin-top:50px;
                    border-top-width: 10px; border-bottom-width: 10px;">
                    <tr>
                        <td style="text-transform: uppercase; font-weight: bold; font-size: 14px; color: #FFF;
                            text-align: center; background: #BBD37E" colspan="2">
                            Đổi mật khẩu
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mật khẩu cũ:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPassOld" CssClass="inputText" Width="165" TextMode="Password"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Mật khẩu mới:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPassword" CssClass="inputText" Width="165" TextMode="Password"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                                CssClass="require" ControlToValidate="txtPassword" ValidationGroup="Registor"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Nhập lại mật khẩu mới:
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtPassAgain" CssClass="inputText" Width="165" TextMode="Password"></asp:TextBox>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="*"
                                CssClass="require" ControlToValidate="txtPassAgain" ValidationGroup="Registor"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="*"
                                CssClass="require" ControlToValidate="txtPassAgain" ControlToCompare="txtPassword"
                                ValidationGroup="Registor"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label runat="server" ID="lblmsg" Font-Size="12px" ForeColor="Red"></asp:Label>
                            <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="  Đồng ý  " ValidationGroup="Registor" />
                        </td>
                    </tr>
                </table>
            </center>
        </div>
        <div class="rightMain nr">
            <uc2:ucdoitac runat="server" id="ucDoitac1" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
</asp:Content>
