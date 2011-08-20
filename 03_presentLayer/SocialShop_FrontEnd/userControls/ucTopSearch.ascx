<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucTopSearch.ascx.cs" Inherits="userControls_ucTopSearch" %>
<div class="search">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table class="tbSearch">
                <tr>
                    <td style="width:118px;">
                        Tìm tại
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProvince" runat="server" CssClass="ddl" Width="135px" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Quận/Huyện
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDistrict" CssClass="ddl" runat="server" AutoPostBack="true" Height="22px"
                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="135px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <%--<tr>
                    <td>
                        Phường/Xã
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlVillage" CssClass="ddl" runat="server" Width="135px">
                        </asp:DropDownList>
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        Loại BĐS
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTypeBDS" CssClass="ddl" runat="server" Width="135px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Khoảng Giá
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlPrice" CssClass="ddl" runat="server" Width="135px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" style="text-align:center; padding-top:23px;">
                        <asp:ImageButton ID="ImgSearch" ImageUrl="~/images/btnSearch.png" 
                            runat="server" onclick="ImgSearch_Click" />
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers><asp:PostBackTrigger ControlID="ImgSearch" /></Triggers>
    </asp:UpdatePanel>
</div>
