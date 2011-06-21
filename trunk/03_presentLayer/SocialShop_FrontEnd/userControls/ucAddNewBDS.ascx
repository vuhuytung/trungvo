<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucAddNewBDS.ascx.cs" Inherits="userControls_ucAddNewBDS" %>
<script type="text/javascript">
    function Validate() {
        var ddlTinh = document.getElementById("ctl03_ddlProvince");
        var ddlHuyen = document.getElementById("ctl03_ddlDistrict");
        var ddlXa = document.getElementById("ctl03_ddlVillage");
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
<table cellspacing="8">
    <tr>
        <td>Tiêu đề thông tin    
        </td>
        <td colspan="3">
            <asp:TextBox ID="txtTitle" runat="server" Width="492px"></asp:TextBox>*</td>
    </tr>
    <tr>
        <td>Họ tên </td>
        <td>
            <asp:TextBox ID="txtName" runat="server"></asp:TextBox>*</td>
    </tr>
    <tr>
        <td>Loại BĐS</td>
        <td>
            <asp:DropDownList ID="ddlTypeBDS" runat="server">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td>Địa chỉ</td>
        <td>Tỉnh/TP&nbsp;&nbsp;
            <asp:DropDownList ID="ddlProvince" runat="server" 
                onselectedindexchanged="ddlProvince_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>*
        </td>
        <td>&nbsp; Quận/Huyện&nbsp;&nbsp;
            <asp:DropDownList ID="ddlDistrict" runat="server" 
                onselectedindexchanged="ddlDistrict_SelectedIndexChanged" AutoPostBack="true">
            </asp:DropDownList>*
        </td>
        <td>&nbsp; Phường/xã&nbsp;&nbsp;
            <asp:DropDownList ID="ddlVillage" runat="server">
            </asp:DropDownList>*
        </td>
    </tr>
    <tr>
        <td>Điện thoại</td>
        <td>
            <asp:TextBox ID="txtPhone" runat="server"></asp:TextBox>*</td>
        <td>Email liên hệ</td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Tình trạng pháp lí</td>
        <td>
            <asp:TextBox ID="txtLegal" runat="server"></asp:TextBox>
        </td>
        <td>Diện tích</td>
        <td>
            <asp:TextBox ID="txtAcreage" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Số tầng</td>
        <td>
            <asp:TextBox ID="txtFloor" runat="server"></asp:TextBox>
        </td>
        <td>Số phòng khách</td>
        <td>
            <asp:TextBox ID="txtClientRoom" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>phòng ngủ</td>
        <td>
            <asp:TextBox ID="txtBedroom" runat="server"></asp:TextBox>
        </td>
        <td>Phòng tắm</td>
        <td>
            <asp:TextBox ID="txtBathroom" runat="server"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td>Hướng BĐS</td>
        <td>
            <asp:TextBox ID="txtPossition" runat="server"></asp:TextBox>
        </td>
        
    </tr>
    <tr>
        <td>Điều Hòa Nhiệt Độ</td>
        <td>
            <asp:CheckBox ID="ChkCooler" runat="server" />
        </td>
        <td>Truyền hình cáp</td>
        <td>
            <asp:CheckBox ID="chkCapTV" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Gần trường mẫu giáo</td>
        <td>
            <asp:CheckBox ID="chkMauGiao" runat="server" />
        </td>
        <td>Gần trường trung học</td>
        <td>
            <asp:CheckBox ID="chkTrunghoc" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Gần bệnh viện</td>
        <td>
            <asp:CheckBox ID="chkHospital" runat="server" />
        </td>
        <td>Gần chợ</td>
        <td>
            <asp:CheckBox ID="chkMarket" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Gần trường Đại học</td>
        <td>
            <asp:CheckBox ID="chkUniversity" runat="server" /></td>
        <td>Mạng Internet</td>
        <td>
            <asp:CheckBox ID="chkInternet" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Gần công viên</td>
        <td>
            <asp:CheckBox ID="chkPark" runat="server" />
        </td>
        <td>Gara Oto</td>
        <td>
            <asp:CheckBox ID="chkGara" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Giá BĐS</td>
        <td>
        
            <asp:TextBox ID="txtPrice" runat="server"></asp:TextBox></td>
        <td>Ảnh BĐS</td>
        <td>
            <asp:FileUpload ID="fuploadImg" runat="server" />
        </td>
    </tr>
    <tr>
        <td>Mô tả</td>
        <td colspan="3">
            <asp:TextBox ID="txtDesc" runat="server" TextMode="MultiLine" Height="135px" 
                Width="499px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="4" style=" text-align:center; padding-top:10px;">
            <asp:Button ID="btnsubmit" runat="server" Text="submit" Width="77px"  OnClientClick="return Validate()"/>
            &nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btncancel" runat="server" Text="cancel" Width="73px" />
        </td>
    </tr>

</table>