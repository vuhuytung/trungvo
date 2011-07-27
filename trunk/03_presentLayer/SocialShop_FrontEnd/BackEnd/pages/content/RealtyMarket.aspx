<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="RealtyMarket.aspx.cs" Inherits="BackEnd_pages_content_RealtyMarket" %>

<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucpaging" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box_body">
        <asp:Panel ID="Panel2" runat="server" Visible="false">
            <div class="box_hide">
                <div class="MK_edit">
                    <table cellspacing="8" class="tbEdit">
                        <tr>
                            <td colspan="4" style="text-align: center; padding: 5px 0;">
                                <a style="color: blue; font-size: 16px;">Thêm thông tin</a>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Tiêu đề:
                            </td>
                            <td colspan="3">
                                <asp:TextBox ID="txtTitle" runat="server" Text="" Width="350"> 
                                </asp:TextBox><a>*</a>
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
                                <asp:TextBox ID="txtAddress" runat="server" Text=""></asp:TextBox><a>*</a>
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
                                <asp:TextBox ID="txtEmail" runat="server" Text=""></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Loại BĐS
                            </td>
                            <td style="padding: 5px 0px;">
                                <asp:DropDownList ID="ddlTypeBDSs2" runat="server">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Địa điểm BĐS
                            </td>
                            <td style="padding: 5px 0;">
                                <asp:DropDownList ID="ddlProvince2" runat="server" OnSelectedIndexChanged="ddlProvince2_SelectedIndexChanged"
                                    AutoPostBack="true" BorderColor="#ED8080" BorderWidth="1">
                                </asp:DropDownList>
                            </td>
                            <td style="padding: 5px 0;">
                                <asp:DropDownList ID="ddlDistrict2" runat="server" OnSelectedIndexChanged="ddlDistrict2_SelectedIndexChanged"
                                    AutoPostBack="true">
                                </asp:DropDownList>
                            </td>
                            <td style="padding: 5px 0;">
                                <asp:DropDownList ID="ddlVillage2" runat="server">
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
                                <asp:FileUpload ID="fupload" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Nội dung
                            </td>
                            <td colspan="2" style="padding: 5px 0;">
                                <asp:TextBox ID="txtDesc" runat="server" Text="" TextMode="MultiLine" Width="450"
                                    Height="100"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                Trạng thái hiển thị
                            </td>
                            <td>
                                <asp:CheckBox ID="chkStatus" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4" style="padding: 10px 300px;">
                                <script type="text/javascript">
                                    function checkAdd() {
                                        var txtTitle = document.getElementById("ContentPlaceHolder1_txtTitle");
                                        var txtName = document.getElementById("ContentPlaceHolder1_txtUser");
                                        var txtPhone = document.getElementById("ContentPlaceHolder1_txtPhone");
                                        var txtAddress = document.getElementById("ContentPlaceHolder1_txtAddress");
                                        var txtPrice = document.getElementById("ContentPlaceHolder1_txtPrice");
                                        var txtEmail = document.getElementById("ContentPlaceHolder1_txtEmail");
                                        var ddlLocation = document.getElementById("ContentPlaceHolder1_ddlProvince2");
                                        if (txtTitle.value == "") {
                                            alert('Tiêu đề không được để trống !');
                                            return false;
                                        }
                                        else if (txtName.value == "") {
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
                                <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAdd_Click" OnClientClick="return checkAdd()"
                                    Width="70" />
                                <asp:Button ID="btnThoat" runat="server" Text="Thoát" OnClick="btnThoat_Click" Width="70" />
                            </td>
                        </tr>
                    </table>
                </div>
            </div>
        </asp:Panel>
        <asp:Panel ID="Panel1" runat="server" Visible="false">
            <div class="box_hide">
                <div class="MK_edit">
                    <asp:Repeater ID="RptDetail" runat="server">
                        <HeaderTemplate>
                            <table cellspacing="8" class="tbEdit">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td colspan="4" style="text-align: center; padding: 5px 0;">
                                    <a style="color: blue; font-size: 16px;">Sửa thông tin</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tiêu đề:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtTitle" runat="server" Text='<%#Eval("Title") %>' Width="350"></asp:TextBox><a>*</a>
                                    <asp:HiddenField ID="Img" runat="server" Value='<%#Eval("Image") %>' />
                                    <asp:HiddenField ID="ImgThumb" runat="server" Value='<%#Eval("ImageThumb") %>' />
                                    <asp:HiddenField ID="fullAdd" runat="server" Value='<%#Eval("Street") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Họ tên người đăng:
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtUser" runat="server" Text='<%#Eval("UserPublish") %>'></asp:TextBox><a>*</a>
                                </td>
                                <td>
                                    Địa chỉ
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address") %>'></asp:TextBox><a>*</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Điện thoại
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtPhone" runat="server" Text='<%#Eval("Phone") %>'></asp:TextBox><a>*</a>
                                </td>
                                <td>
                                    Email
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtEmail" runat="server" Text='<%#Eval("Email") %>'></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Loại BĐS
                                </td>
                                <td style="padding: 5px 0px;">
                                    <asp:DropDownList ID="ddlTypeBDSs" runat="server">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <td>
                                Địa điểm BĐS
                            </td>
                            <td>
                                <%#Eval("Street").ToString().Substring(0, 1) != "-" ? Eval("Street").ToString() : Eval("Street").ToString().Substring(1)%>
                            </td>
                            <tr>
                                <td>
                                    Địa điểm BĐS mới
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:DropDownList ID="ddlProvince1" runat="server" OnSelectedIndexChanged="ddlProvince1_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:DropDownList ID="ddlDistrict1" runat="server" OnSelectedIndexChanged="ddlDistrict1_SelectedIndexChanged"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:DropDownList ID="ddlVillage1" runat="server">
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
                                    <asp:TextBox ID="txtDientich" runat="server" Text='<%#Eval("Acreage") %>'></asp:TextBox>
                                    <asp:HiddenField ID="hdLocation" runat="server" Value='<%#Eval("LocationID") %>' />
                                </td>
                                <td>
                                    Tình trạng pháp lý:
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtLegal" runat="server" Text='<%#Eval("LegalStatus") %>'></asp:TextBox>
                                    <asp:Label ID="lblID" runat="server" Text='<%#Eval("RealtyMarketID") %>' Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Hướng BĐS
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtPosition" runat="server" Text='<%#Eval("Position") %>'></asp:TextBox>
                                </td>
                                <td>
                                    Số tầng
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtFloor" runat="server" Text='<%#Eval("Floor") %>' Width="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phòng khách
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtClientRoom" runat="server" Text='<%#Eval("ClientRoom") %>' Width="50"></asp:TextBox>
                                </td>
                                <td>
                                    Phòng ngủ
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtBedRoom" runat="server" Text='<%#Eval("BedRoom") %>' Width="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Phòng tắm:
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtBathrooms" runat="server" Text='<%#Eval("Bathrooms") %>' Width="50"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Gần trường mẫu giáo
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:CheckBox ID="chkMaugiao" runat="server" Checked='<%#Eval("NearKindergarten") %>' />
                                </td>
                                <td>
                                    Gần trường trung học
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:CheckBox ID="chkschool" runat="server" Checked='<%#Eval("NearlySchool") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Gần bệnh viện
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:CheckBox ID="chkHospital" runat="server" Checked='<%#Eval("NearHospital") %>' />
                                </td>
                                <td>
                                    Gần chợ
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:CheckBox ID="chkMarket" runat="server" Checked='<%#Eval("NearlyMarket") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Gần trường Đại học
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:CheckBox ID="chkUniversity" runat="server" Checked='<%#Eval("NearlyUniversity") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Giá BĐS
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtPrice" runat="server" Text='<%#Eval("Price") %>'></asp:TextBox><a>*</a>vnđ
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
                                    <asp:TextBox ID="txtDesc" runat="server" Text='<%# HttpUtility.HtmlDecode(Eval("Descrition").ToString()).Replace("</br>", "\n") %>'
                                        TextMode="MultiLine" Width="450" Height="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Trạng thái hiển thị
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkStatus" runat="server" Checked='<%#Eval("Status") %>' />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="padding: 10px 300px;">
                                    <script type="text/javascript">
                                        function checkAdd1() {
                                            var txtTitle = document.getElementById("ContentPlaceHolder1_RptDetail_txtTitle_0");
                                            var txtName = document.getElementById("ContentPlaceHolder1_RptDetail_txtUser_0");
                                            var txtPhone = document.getElementById("ContentPlaceHolder1_RptDetail_txtPhone_0");
                                            var txtAddress = document.getElementById("ContentPlaceHolder1_RptDetail_txtAddress_0");
                                            var txtPrice = document.getElementById("ContentPlaceHolder1_RptDetail_txtPrice_0");
                                            var txtEmail = document.getElementById("ContentPlaceHolder1_RptDetail_txtEmail_0");
                                            if (txtTitle.value == "") {
                                                alert('Tiêu đề không được để trống !');
                                                return false;
                                            }
                                            else if (txtName.value == "") {
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
                                    <asp:Button ID="btnUpdate1" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click"
                                        OnClientClick="return checkAdd1()" Width="70" />
                                    <asp:Button ID="btnHuy1" runat="server" Text="Thoát" OnClick="btnHuy_Click" Width="70" />
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </asp:Panel>
        <div style="text-align: center; width: 100%; float: left;">
            <h1 style="color: Blue;">
                Quản lý thông tin Bất Động Sản</h1>
        </div>
        <div class="box" id="divSearch" style="width: 940px; float: left;">
            <div class="title" style="width: 960px;">
                <span>Tìm kiếm BĐS</span>
            </div>
            <div class="content1" style="width: 960px;">
                <table style="width: auto; margin: auto; height: 70px;">
                    <tr>
                        <td>
                            Tp/Tỉnh
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                        <td style="padding: 5px 5px;">
                            Quận/Huyện
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" Height="22px"
                                OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="136px">
                            </asp:DropDownList>
                        </td>
                        <td style="padding: 5px 5px;">
                            Phường/Xã
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlVillage" runat="server" Width="136px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Loại BĐS
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlTypeBDS" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td style="padding: 5px 5px;">
                            Khoảng Giá
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlPrice" runat="server">
                            </asp:DropDownList>
                        </td>
                        <td>
                            người đăng
                        </td>
                        <td >
                            <asp:DropDownList ID="ddlTypeUser" runat="server">
                                <asp:ListItem Text="Tất cả" Value="2" Selected="True"/>
                                <asp:ListItem Text="Ban quản trị" Value="1"/>
                                <asp:ListItem Text="Người dùng" Value="0"/>
                            </asp:DropDownList>
                        </td>
                        <td style="text-align: center; padding-top: 7px;">
                            <asp:Button ID="btnSearch" runat="server" Text="Tìm" Width="70px" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="doc_content" style="float: left; width: 978px;">
            <div class="box">
                <div class="title1" style="width: 978px;">
                    <span>Danh sách tin BĐS</span>
                    <asp:LinkButton ID="lbtAddNew" runat="server" CssClass="title-addnew1" OnClick="btnThemmoi_Click">
                <img src="/BackEnd/img/addnew_16.png" style="vertical-align: top" alt='Thêm mới' />
                Thêm mới
                    </asp:LinkButton>
                    <asp:LinkButton ID="lbtDeleteAll" OnClientClick="return ConfirmDelete();" runat="server"
                        CssClass="title-addnew1" OnClick="lbtDeleteAll_Click">
                        <img src="/BackEnd/img/icon-delete.png" style="vertical-align: top" alt='Xóa' />
                         Xóa
                    </asp:LinkButton>
                </div>
                <div class="content1" style="width: 978px; float: left;">
                    <asp:Repeater ID="RptReatyMarket" runat="server" OnItemCommand="RptReatyMarket_ItemCommand">
                        <HeaderTemplate>
                            <table class="tbl_doc" width="978">
                                <thead>
                                    <tr>
                                        <td>
                                        </td>
                                        <td>
                                            TT
                                        </td>
                                        <td>
                                            Tiêu đề
                                        </td>
                                        <td>
                                            phân quyền
                                        </td>
                                        <td>
                                            Người tạo
                                        </td>
                                        <td>
                                            Ngày tạo
                                        </td>
                                        <td class="td1">
                                            Trạng thái
                                        </td>
                                        <td class="td1">
                                            Chức năng
                                        </td>
                                    </tr>
                                </thead>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td style="width: 15px; text-align: center;">
                                    <asp:CheckBox ID="chkDeleteAll" runat="server" />
                                    <asp:HiddenField ID="hdID" runat="server" Value=' <%#Eval("RealtyMarketID") %>' />
                                    <asp:HiddenField ID="Img" runat="server" Value='<%#Eval("Image") %>' />
                                    <asp:HiddenField ID="ImgThumb" runat="server" Value='<%#Eval("ImageThumb") %>' />
                                </td>
                                <td>
                                    <%#Eval("RowNumber")%>
                                </td>
                                <td style="width: 500px; text-align: left;">
                                    <a>
                                        <%#Eval("Title") %></a>
                                </td>
                                <td>
                                    <a>
                                        <%#(Convert.ToInt32(Eval("Shower")) == 1) ? "Admin" : "User"%></a>
                                </td>
                                <td>
                                    <a>
                                        <%#Eval("UserPublish")%></a>
                                </td>
                                <td>
                                    <a>
                                        <%#Convert.ToDateTime(Eval("CreateDate")).ToString("dd-MM-yyyy")%></a>
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkStatus" runat="server" Checked='<%#Eval("Status") %>' />
                                </td>
                                <td class="td2">
                                    <asp:LinkButton ID="lbtEdit" runat="server" CommandName="Edit" CssClass="edit_icon"
                                        CommandArgument='<%#Eval("RealtyMarketID") %>' ToolTip="Sửa"></asp:LinkButton>
                                    <script type="text/javascript">
                                        function confirm1() {
                                            return confirm("Bạn có muốn xóa Record này ko ?");
                                        }
                                    </script>
                                    <asp:LinkButton ID="lbtDelete" runat="server" CommandName="Delete" OnClientClick="return confirm1()"
                                        CommandArgument='<%#Eval("RealtyMarketID") %>' ToolTip="Xóa" CssClass="delete_icon"></asp:LinkButton>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <FooterTemplate>
                            </table>
                        </FooterTemplate>
                    </asp:Repeater>
                </div>
            </div>
        </div>
    </div>
    <div id="divPaging" runat="server" class="paginator2 nr">
        <uc1:ucpaging ID="ucPaging1" runat="server" />
    </div>
</asp:Content>
