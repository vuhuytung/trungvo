<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterFrontend.master" AutoEventWireup="true"
    CodeFile="BdsAddNews.aspx.cs" Inherits="pages_Bds_AddNews" %>

<%@ Register Src="~/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
            .tblAddNew
            {
                width:635px;
            }
            .tblAddNew .tdTitle
            {
                text-align: left; padding:5px 20px; background:#EEE;                
            }
            .tblAddNew .tdTitle a
            {
                color:#459B30; font-size: 16px; font-weight:bold
            }
    </style>
    <script type="text/javascript">
        function validateDigitQuantity(evt) {
            var keyCode = evt.keyCode ? evt.keyCode : evt.which;
            var arrCode = new Array(48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 8, 46, 36, 9, 46);
            if ($.browser.msie) {
                for (var i = 0; i < arrCode.length; i++) {
                    if (arrCode[i] == keyCode) {
                        return true;
                        break;
                    }
                }
                return false;
            }
            else {
                if (arrCode.indexOf(keyCode) > -1) return true;
                return false;
            }

        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
<div class="bodyContent">
        <div class="leftMain nl">
            <table cellspacing="8" class="tblAddNew">
                <tr>
                    <td colspan="4" class="tdTitle">
                        <a>Thông tin cơ bản</a>
                    </td>
                </tr>   
                <tr>
                    <td style="padding-left:20px;">
                        Tiêu đề:
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtTitle" runat="server" Text="" Width="350"></asp:TextBox><span style="color:Red;">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Mục bất động sản:
                    </td>
                    <td style="padding: 5px 0px;">
                        <asp:DropDownList ID="ddlTypeBDS" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Địa điểm bất động sản:
                    </td>
                    <td colspan="3">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlDistrict" runat="server" OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                                <asp:DropDownList ID="ddlVillage" runat="server">
                                </asp:DropDownList>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
                <tr>                    
                    <td style="padding-left:20px;">
                        Số nhà, Đường phố/Thôn-xóm:
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtStreet" runat="server" Width="400px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Diện tích:
                    </td>
                    <td>
                        <asp:TextBox ID="txtDientich" runat="server" Text=""></asp:TextBox> m²
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Tình trạng pháp lý:
                    </td>
                    <td>
                        <asp:TextBox ID="txtLegal" runat="server" Text=""></asp:TextBox><br /> 
                        <i>(Ví dụ: Sổ đỏ, sổ hồng,...)</i>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Giá bất động sản:
                    </td>
                    <td colspan="3">
                        <asp:TextBox ID="txtPrice" runat="server" Text="" onkeypress="return validateDigitQuantity(event)"></asp:TextBox> 
                        <asp:DropDownList ID="ddlDonVi" runat="server">
                            <asp:ListItem Value="0">Thỏa thuận</asp:ListItem>
                            <asp:ListItem Value="100000">Trăm nghìn</asp:ListItem>
                            <asp:ListItem Value="1000000">Triệu</asp:ListItem>                            
                            <asp:ListItem Value="1000000000">Tỷ</asp:ListItem>
                        </asp:DropDownList>
                         VNĐ
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Hình ảnh:
                    </td>
                    <td>
                        <asp:FileUpload ID="fupload" runat="server" CssClass="fupload" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Nội dung:
                    </td>
                    <td colspan="2">
                        <asp:TextBox ID="txtDesc" runat="server" Text="" TextMode="MultiLine" Width="450"
                            Height="200"></asp:TextBox>
                    </td>
                </tr>
            </table>
            <table cellspacing="8" class="tblAddNew" >
                <tr>
                    <td colspan="4" class="tdTitle">
                        <a>Thông tin thêm</a>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Hướng:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPosition" runat="server" Text=""></asp:TextBox> <br />
                        <i>(Ví dụ: Đông Bắc, Bắc,...)</i>
                    </td>
                    <td>
                        Số tầng:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFloor" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Phòng khách:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlClientRoom" runat="server">
                        </asp:DropDownList>
                    </td>
                    <td>
                        Phòng ngủ:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlBedRoom" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Phòng tắm:
                    </td>
                    <td>
                         <asp:DropDownList ID="ddlBathrooms" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Gần trường mẫu giáo:
                    </td>
                    <td>
                        <asp:CheckBox ID="chkMaugiao" runat="server" />
                    </td>
                    <td>
                        Gần trường trung học:
                    </td>
                    <td>
                        <asp:CheckBox ID="chkschool" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Gần bệnh viện:
                    </td>
                    <td>
                        <asp:CheckBox ID="chkHospital" runat="server" />
                    </td>
                    <td>
                        Gần chợ:
                    </td>
                    <td>
                        <asp:CheckBox ID="chkMarket" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Gần trường Đại học:
                    </td>
                    <td>
                        <asp:CheckBox ID="chkUniversity" runat="server" />
                    </td>
                </tr>
            </table>
            <table cellspacing="8" class="tblAddNew" >
                <tr>
                    <td colspan="4" class="tdTitle">
                        <a style="color:#459B30; font-size: 16px; font-weight:bold">Thông tin người đăng</a>
                    </td>
                </tr>                
                <tr>
                    <td style="padding-left:20px;">
                        Họ tên người đăng:
                    </td>
                    <td>
                        <asp:TextBox ID="txtUser" runat="server" Text=""></asp:TextBox><span style="color:Red;">*</span>
                    </td>
                    <td>
                        Địa chỉ:
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" runat="server" Text="" Width="200"></asp:TextBox><span style="color:Red;">*</span>
                    </td>
                </tr>
                <tr>
                    <td style="padding-left:20px;">
                        Điện thoại:
                    </td>
                    <td>
                        <asp:TextBox ID="txtPhone" runat="server" Text=""></asp:TextBox><span style="color:Red;">*</span>
                    </td>
                    <td>
                        Email:
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server" Text="" Width="200"></asp:TextBox><span style="color:Red;">*</span>
                    </td>
                </tr>
            </table>
            <table>
                <tr>
                    <td colspan="4" style="padding: 10px 300px;">
                        
                        <script type="text/javascript">
                            function checkAdd() {
                                var txtTitle =$('#<%=txtTitle.ClientID %>');
                                var txtUser = $('#<%=txtUser.ClientID %>');
                                var txtPhone = $('#<%=txtPhone.ClientID %>');
                                var txtAddress = $('#<%=txtAddress.ClientID %>');
                                var txtPrice = $('#<%=txtPrice.ClientID %>');
                                var txtEmail = $('#<%=txtEmail.ClientID %>');
                                var ddlLocation = $('#<%=ddlProvince.ClientID %>');
                                if ($.trim(txtTitle.val()) == "") {
                                    alert('Tiêu đề không được để trống !');
                                    txtTitle.focus();
                                    return false;
                                }
                                if (txtTitle.val().length <16) {
                                    alert('Tiêu đề phải có từ 16 ký tự trở lên !');
                                    txtTitle.focus();
                                    return false;
                                }                               
                                if ($.trim(txtPrice.val()) == "") {
                                    alert('Giá bán không được để trống !');
                                    txtPrice.focus();
                                    return false;
                                }
                                if (ddlLocation.val() == "-1") {
                                    alert('Bạn chưa chọn TP/Tỉnh !');
                                    ddlLocation.focus();
                                    return false;
                                }

                               if (isNaN(txtPrice.val())) {
                                   alert('Giá bất động sản phải là kiểu số !');
                                   txtPrice.focus();
                                   return false;
                               }

                               if ($.trim(txtUser.val()) == "") {
                                   alert('Họ tên không được để trống !');
                                   txtUser.focus();
                                   return false;
                               }
                               if ($.trim(txtPhone.val()) == "") {
                                   alert('Số điện thoại không được để trống !');
                                   txtPhone.focus();
                                   return false;
                               }
                               if ($.trim(txtAddress.val()) == "") {
                                   alert('Địa chỉ không được để trống !');
                                   txtAddress.focus();
                                   return false;
                               }
                               
                               if (txtEmail.val() != "") {
                                   if (!CheckMail(txtEmail.val())) {
                                       alert('Email không đúng định dạng !');
                                       txtEmail.focus();
                                       return false;
                                   }
                               }

                                return true;
                            }

                            function CheckMail(str) {
                                var RegExEmail = /^[_a-z0-9-]+(\.[_a-z0-9-]+)*@[a-z0-9-]+(\.[a-z0-9-]+)*(\.([a-z]){2,4})$/;
                                return RegExEmail.test(str);
                            }
                        </script>
                        <asp:Button ID="btnAdd" CssClass="btnButton" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" Width="70" OnClientClick="return checkAdd()" />
                        
                    </td>
                </tr>
            </table>
        </div>
        <div class="rightMain nr">
            <uc2:ucDoitac ID="ucDoitac1" runat="server" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
  </div>
  </asp:Content>