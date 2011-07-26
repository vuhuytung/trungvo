<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucContact.ascx.cs" Inherits="userControls_ucContact" %>
<script type="text/javascript">
    function Validate() {
        var txtname = document.getElementById("plhBody_ucContact1_txtName");
        if (txtname.value == "") {
            alert('Họ tên không được để trống !');
            return false;
        }
        return true;
    }

</script>
<table cellspacing="6" class="tbContact">
    <tr>
        <td>Họ tên</td>
        <td>
            <asp:TextBox ID="txtName" runat="server" Width="198px"></asp:TextBox><a>*</a></td>
    </tr>
    <tr>
        <td>Địa chỉ</td>
        <td>
            <asp:TextBox ID="txtAddress" runat="server" Width="342px"></asp:TextBox></td>
    </tr>
    <tr>
        <td>Email</td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server" Width="341px"></asp:TextBox><a>*</a>
        </td>
    </tr>
    <tr>
        <td>Điện thoại</td>
        <td>
            <asp:TextBox ID="txtPhone" runat="server" Width="195px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Tiêu đề</td>
        <td>
            <asp:TextBox ID="txtTitle" runat="server" Width="342px"></asp:TextBox><a>*</a>
        </td>
    </tr>
    <tr>
        <td>Nội dung</td>
        <td>
            <asp:TextBox ID="txtContent" runat="server" Height="160px" Width="342px" TextMode="MultiLine"></asp:TextBox><a>*</a>
        </td>
    </tr>
    <tr>
        <td colspan="2" style=" padding-left:150px; padding-top:20px;">
            <asp:Button ID="btnSend" CssClass="btnButton" runat="server" Text="Gửi" Width="66px"  
                OnClientClick="return Validate()" onclick="btnSend_Click"/>
            <asp:Button ID="btnCancel" CssClass="btnButton" runat="server" Text="hủy" Width="70px" 
                onclick="btnCancel_Click" />
        </td>
    </tr>

</table>