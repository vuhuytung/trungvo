<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Slide.ascx.cs" Inherits="userControls_Slide" %>
<div class="slideshow">
<asp:Literal ID="Literal1" runat="server"></asp:Literal>
</div>
<div class="search">
    <table>
        <tr>
            <td>Tìm tại:</td>
            <td>
                <asp:DropDownList ID="DropDownProvince" runat="server" 
                    onselectedindexchanged="DropDownProvince_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Quận/Huyện</td>
            <td>
                <asp:DropDownList ID="DropDownDistrict" runat="server"  AutoPostBack="true" 
                    Height="16px" onselectedindexchanged="DropDownDistrict_SelectedIndexChanged" 
                    Width="136px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td> Phường/Xã            
            </td>
            <td>
                <asp:DropDownList ID="DropDownVillage" runat="server" Width="136px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>Loại BĐS</td>
            <td>
                <asp:DropDownList ID="DropDownTypeBDS" runat="server">
                </asp:DropDownList>
            </td>
        </tr>
    </table>

</div>
