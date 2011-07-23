<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTopSearch.ascx.cs" Inherits="userControls_ucTopSearch" %>
<div class="search">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tbSearch">
                <tr>
                    <td>
                        Tìm tại:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Quận/Huyện
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" Height="22px"
                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="136px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Phường/Xã
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlVillage" runat="server" Width="136px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Loại BĐS
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTypeBDS" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Khoảng Giá
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPrice" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style=" text-align:center;">
                        <asp:ImageButton ID="ImgSearch" ImageUrl="~/images/btnSearch.png" 
                            runat="server" onclick="ImgSearch_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</div>
