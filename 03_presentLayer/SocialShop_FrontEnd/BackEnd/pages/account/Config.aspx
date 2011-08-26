<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="Config.aspx.cs" Inherits="BackEnd_pages_account_Config" %>

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
    <center style="color: Red; line-height: 30px; font-size:16px; font-weight:bold">
        <asp:Label ID="lblMsg" CssClass="blink" runat="server"></asp:Label></center>    
        <div id="divNewsInfo" class="box" style="width: 920px">
            <div class="title">
                <span style="float: left" runat="server" id="spTitle">Thông tin chung</span>
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
                            Địa chỉ:
                        </td>
                        <td style="width: 160px" class="tdStyle" colspan="2">
                            <asp:TextBox ID="txtAddress" runat="server" Width="400px" MaxLength="250" CssClass="inputText"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 100px" class="tdStyle">
                            Email:
                        </td>
                        <td style="padding-top: 12px;" class="tdStyle">
                            <asp:TextBox ID="txtEmail" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>
                    </tr>                    
                    <tr>
                        <td class="tdStyle">
                            Điện thoại:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtPhone" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table>
                    <tr>
                        <td class="tdStyle">
                           Yahoo1:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtYahoo1" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>
                        <td class="tdStyle">
                           Nội dung Yahoo1:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtTextYahoo1" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                        <td class="tdStyle">
                           Yahoo2:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtYahoo2" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>
                        <td class="tdStyle">
                           Nội dung Yahoo2:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtTextYahoo2" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                        <td class="tdStyle">
                           Yahoo3:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtYahoo3" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>
                        <td class="tdStyle">
                           Nội dung Yahoo3:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtTextYahoo3" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>                        
                    </tr>
                    <tr>
                        <td class="tdStyle">
                           Skype1:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtSkype1" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>
                        <td class="tdStyle">
                           Nội dung Skype1:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtTextSkype1" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>                        
                    </tr>
                     <tr>
                        <td class="tdStyle">
                           Skype2:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtSkype2" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>
                        <td class="tdStyle">
                           Nội dung Skype2:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtTextSkype2" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>                        
                    </tr>
                     <tr>
                        <td class="tdStyle">
                           Skype3:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtSkype3" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>
                        <td class="tdStyle">
                           Nội dung Skype3:
                        </td>
                        <td class="tdStyle">
                            <asp:TextBox ID="txtTextSkype3" runat="server" Width="200px" MaxLength="50" CssClass="inputText"></asp:TextBox>
                        </td>                        
                    </tr>
                </table>
            </div>
        </div>
</asp:Content>
