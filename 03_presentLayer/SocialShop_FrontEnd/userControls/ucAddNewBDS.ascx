<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAddNewBDS.ascx.cs" Inherits="userControls_ucAddNewBDS" %>
<script type="text/javascript">
    function Validate() {
        var ddlTinh = document.getElementById("plhBody_ucAddNewBDS1_ddlProvince");
        var ddlHuyen = document.getElementById("plhBody_ucAddNewBDS1_ddlDistrict");
        var ddlXa = document.getElementById("plhBody_ucAddNewBDS1_ddlVillage");
        if (ddlTinh.value == -1) {
            alert('Bạn chưa chọn tỉnh/TP !');
            return false;
        }
        if (ddlHuyen.value == -1) {
            alert('Bạn chưa chọn Quận/Huyện !');
            return false;
        }
        if (ddlXa.value == -1) {
            alert('Bạn chưa chọn Phường/Xã !');
            return false;
        }
        return true;
    }
</script>
<table cellspacing="8" style="margin-left: 80px; font:12px Arial;">
    <tr>
        <td colspan="4" style="text-align: center; padding: 5px 0;">
            <a style="color: Red; font-size: 16px;">Nhập thông tin</a>
        </td>
    </tr>
    <tr>
        <td>
            Tiêu đề:
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtTitle" runat="server" Text="" Width="350" BorderColor="#ED8080"
                BorderWidth="1"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Họ tên người đăng:
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtUser" runat="server" Text="" BorderColor="#ED8080" BorderWidth="1"></asp:TextBox>
        </td>
        <td>
            Địa chỉ
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtAddress" runat="server" Text="" BorderColor="#ED8080" BorderWidth="1"
                Width="200"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Điện thoại
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtPhone" runat="server" Text="" BorderColor="#ED8080" BorderWidth="1"></asp:TextBox>
        </td>
        <td>
            Email
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtEmail" runat="server" Text="" Width="200"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Loại BĐS
        </td>
        <td style="padding: 5px 0px;">
            <asp:DropDownList ID="ddlTypeBDS" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
            Địa điểm BĐS
        </td>
        <td style="padding: 5px 0;">
            <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                AutoPostBack="true" BorderColor="#ED8080" BorderWidth="1">
            </asp:DropDownList>
        </td>
        <td style="padding: 5px 0;">
            <asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                AutoPostBack="true">
            </asp:DropDownList>
        </td>
        <td style="padding: 5px 0;">
            <asp:DropDownList ID="ddlVillage" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>
        </td>
        <td>
        </td>
        <td style="padding: 10px 0;">
            số nhà,Đường phố/thôn-xóm:
        </td>
        <td>
            <asp:TextBox ID="txtStreet" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Diện tích:
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtDientich" runat="server" Text=""></asp:TextBox>
        </td>
        <td>
            Tình trạng pháp lý:
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtLegal" runat="server" Text=""></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Hướng BĐS
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtPosition" runat="server" Text=""></asp:TextBox>
        </td>
        <td>
            Số tầng
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtFloor" runat="server" Text="" Width="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Phòng khách
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtClientRoom" runat="server" Text="" Width="50"></asp:TextBox>
        </td>
        <td>
            Phòng ngủ
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtBedRoom" runat="server" Text="" Width="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Phòng tắm:
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtBathrooms" runat="server" Text="" Width="50"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>
            Gần trường mẫu giáo
        </td>
        <td style="padding: 5px 0;">
            <asp:CheckBox ID="chkMaugiao" runat="server" />
        </td>
        <td>
            Gần trường trung học
        </td>
        <td style="padding: 5px 0;">
            <asp:CheckBox ID="chkschool" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Gần bệnh viện
        </td>
        <td style="padding: 5px 0;">
            <asp:CheckBox ID="chkHospital" runat="server" />
        </td>
        <td>
            Gần chợ
        </td>
        <td style="padding: 5px 0;">
            <asp:CheckBox ID="chkMarket" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Gần trường Đại học
        </td>
        <td style="padding: 5px 0;">
            <asp:CheckBox ID="chkUniversity" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Giá BĐS
        </td>
        <td style="padding: 5px 0;">
            <asp:TextBox ID="txtPrice" runat="server" Text=""></asp:TextBox>vnđ
        </td>
    </tr>
    <tr>
        <td>
            Ảnh BĐS
        </td>
        <td>
            <asp:FileUpload ID="fupload" runat="server" />
        </td>
    </tr>
    <tr>
        <td>
            Nội dung
        </td>
        <td colspan="2" style="padding: 5px 0;">
            <asp:TextBox ID="txtDesc" runat="server" Text="" TextMode="MultiLine" Width="450"
                Height="200"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style="padding: 10px 300px;">
            <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" Width="70" />
            <asp:Button ID="btnThoat" runat="server" Text="Thoát" Width="70" />
        </td>
    </tr>
</table>
