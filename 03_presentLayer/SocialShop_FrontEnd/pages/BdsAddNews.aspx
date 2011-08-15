<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="BdsAddNews.aspx.cs" Inherits="pages_Bds_AddNews" %>

<%@ Register Src="~/userControls/ucAddNewBDS.ascx" TagName="ucAddNewBDS" TagPrefix="uc1" %>
<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="/css/bds_detail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <div class="bodyContent">
        <div class="clear">
            <table cellspacing="8" style="margin-left: 80px;" class="myTable">
                <tr>
                    <td colspan="4" style="text-align: center; padding: 5px 0;">
                        <a style="color:Blue; font-size: 16px;">Nhập thông tin</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Tiêu đề:
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtTitle" runat="server" Text="" Width="350"></asp:TextBox><a>*</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Họ tên người đăng:
                    </td>
                    <td style="padding: 5px 0;">
                        <asp:TextBox ID="txtUser" runat="server" Text=""></asp:TextBox><a>*</a>
                    </td>
                    <td>
                        Địa chỉ
                    </td>
                    <td style="padding: 5px 0;">
                        <asp:TextBox ID="txtAddress" runat="server" Text="" Width="200"></asp:TextBox><a>*</a>
                    </td>
                </tr>
                <tr>
                    <td>
                        Điện thoại
                    </td>
                    <td style="padding: 5px 0;">
                        <asp:TextBox ID="txtPhone" runat="server" Text=""></asp:TextBox><a>*</a>
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
                            AutoPostBack="true">
                        </asp:DropDownList>
                        <a>*</a>
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
                        <asp:TextBox ID="txtPrice" runat="server" Text=""></asp:TextBox><a>*</a>vnđ
                    </td>
                </tr>
                <tr>
                    <td>
                        Ảnh BĐS
                    </td>
                    <td>
                        <asp:FileUpload ID="fupload" runat="server" CssClass="fupload" />
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
                        <script type="text/javascript">
                            function checkAdd() {
                                var txtTitle = document.getElementById("plhBody_txtTitle");
                                var txtUser = document.getElementById("plhBody_txtUser");
                                var txtPhone = document.getElementById("plhBody_txtPhone");
                                var txtAddress = document.getElementById("plhBody_txtAddress");
                                var txtPrice = document.getElementById("plhBody_txtPrice");
                                var txtEmail = document.getElementById("plhBody_txtEmail");
                                var ddlLocation = document.getElementById("plhBody_ddlProvince");
                                if (txtTitle.value == "") {
                                    alert('Tiêu đề không được để trống !');
                                    return false;
                                }
                                else if (txtUser.value == "") {
                                    alert('Họ tên không được để trống !');
                                    return false;
                                }
                                else if (txtPhone.value == "") {
                                    alert('Số điện thoại không được để trống !');
                                    return false;
                                }
                                else if (txtAddress.value == "") {
                                    alert('Địa chỉ không được để trống !');
                                    return false;
                                }
                                else if (txtPrice.value == "") {
                                    alert('Giá bán không được để trống !');
                                    return false;
                                }
                                else if (ddlLocation.value == -1) {
                                    alert('Bạn chưa chọn TP/Tỉnh !');
                                    return false;
                                }
                                else {
                                    if (isNaN(txtPrice.value)) {
                                        alert('Giá bất động sản phải là kiểu số !');
                                        return false;
                                    }
                                    if (isNaN(txtPhone.value)) {
                                        alert('Số điện thoại phải là kiểu số !');
                                        return false;
                                    }
                                    if (txtEmail.value != "") {
                                        if (!CheckMail(txtEmail.value)) {
                                            alert('Email không đúng định dạng !');
                                            return false;
                                        }
                                    }

                                }
                                return true;
                            }

                            function CheckMail(str) {
                                var RegExEmail = new RegExp("^[0-9a-z\\._]+@[0-9a-z]+\\..+$", "i");
                                return RegExEmail.test(str);
                            }
                        </script>
                        <asp:Button ID="btnAdd" CssClass="btnButton" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" Width="70" OnClientClick="return checkAdd()" />
                        
                    </td>
                </tr>
            </table>
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
</asp:Content>
