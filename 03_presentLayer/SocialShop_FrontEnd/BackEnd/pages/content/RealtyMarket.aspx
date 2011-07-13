﻿<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="RealtyMarket.aspx.cs" Inherits="BackEnd_pages_content_RealtyMarket" %>

<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucpaging" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="box_body">
    <asp:Panel ID="Panel2" runat="server" Visible="false">
            <div class="box_hide">
                <div class="MK_edit">
                            <table cellspacing="8">
                            <tr>
                                <td colspan="4" style="text-align: center; padding: 5px 0;">
                                    <a style="color: Red; font-size: 16px;">Thêm thông tin</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tiêu đề:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtTitle" runat="server" Text="" Width="350" BorderColor="#ED8080" BorderWidth="1"></asp:TextBox>
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
                                    <asp:TextBox ID="txtAddress" runat="server" Text="" BorderColor="#ED8080" BorderWidth="1" ></asp:TextBox>
                                    
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
                                    <asp:TextBox ID="txtEmail" runat="server" Text=""></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Loại BĐS
                                </td>
                                <td style="padding: 5px 0px;">
                                    <asp:DropDownList ID="ddlTypeBDSs2" runat="server">
                                        <asp:ListItem Text="Bất động sản cần bán" Value="21" />
                                        <asp:ListItem Text="Bất động sản cần mua" Value="22" />
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
                                    <asp:CheckBox ID="chkMaugiao" runat="server"  />
                                </td>
                                <td>
                                    Gần trường trung học
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:CheckBox ID="chkschool" runat="server"  />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Gần bệnh viện
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:CheckBox ID="chkHospital" runat="server"  />
                                </td>
                                <td>
                                    Gần chợ
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:CheckBox ID="chkMarket" runat="server"  />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Gần trường Đại học
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:CheckBox ID="chkUniversity" runat="server"  />
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
                                    <asp:TextBox ID="txtDesc" runat="server" Text="" TextMode="MultiLine" Width="450" Height="100"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Trạng thái hiển thị
                                </td>
                                <td>
                                    <asp:CheckBox ID="chkStatus" runat="server"  />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4" style="padding: 10px 300px;">
                                    <asp:Button ID="btnAdd" runat="server" Text="Thêm mới" OnClick="btnAdd_Click"
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
                            <table cellspacing="8">
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td colspan="4" style="text-align: center; padding: 5px 0;">
                                    <a style="color: Red; font-size: 16px;">Sửa thông tin</a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Tiêu đề:
                                </td>
                                <td colspan="3">
                                    <asp:TextBox ID="txtTitle" runat="server" Text='<%#Eval("Title") %>' Width="350" BorderColor="#ED8080" BorderWidth="1"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Họ tên người đăng:
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtUser" runat="server" Text='<%#Eval("UserPublish") %>' BorderColor="#ED8080" BorderWidth="1"></asp:TextBox>
                                </td>
                                <td>
                                    Địa chỉ
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtAddress" runat="server" Text='<%#Eval("Address") %>' BorderColor="#ED8080" BorderWidth="1" ></asp:TextBox>
                                    
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Điện thoại
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtPhone" runat="server" Text='<%#Eval("Phone") %>' BorderColor="#ED8080" BorderWidth="1"></asp:TextBox>
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
                                    <asp:DropDownList ID="ddlTypeBDS" runat="server">
                                        <asp:ListItem Text="Bất động sản cần bán" Value="21" />
                                        <asp:ListItem Text="Bất động sản cần mua" Value="22" />
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    Địa điểm BĐS
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
                                    Diện tích:
                                </td>
                                <td style="padding: 5px 0;">
                                    <asp:TextBox ID="txtDientich" runat="server" Text='<%#Eval("Acreage") %>'></asp:TextBox>
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
                                    <asp:TextBox ID="txtPrice" runat="server" Text='<%#Eval("Price") %>'></asp:TextBox>vnđ
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
                                    <asp:TextBox ID="txtDesc" runat="server" Text='<%# HttpUtility.HtmlDecode(Eval("Descrition").ToString()).Replace("</br>", "\n") %>' TextMode="MultiLine" Width="450" Height="100"></asp:TextBox>
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
                                    <asp:Button ID="btnUpdate1" runat="server" Text="Cập nhật" OnClick="btnUpdate_Click"
                                        Width="70" />
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
        <div class="topsearch">
            <div class="search">
                <h3 style="margin-left:50px;">
                    Tìm kiếm BĐS</h3>
                <table cellspacing="8" style="margin-left:15px;">
                    <tr>
                        <td>
                            Tp/Tỉnh
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                                AutoPostBack="true">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Quận/Huyện
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" Height="22px"
                                OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="136px">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
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
                    </tr>
                    <tr>
                        <td>
                            Khoảng Giá
                        </td>
                        <td style="padding: 5px 5px;">
                            <asp:DropDownList ID="ddlPrice" runat="server">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="text-align: center; padding-top: 7px;">
                            <asp:Button ID="btnSearch" runat="server" Text="Tìm" Width="70px" OnClick="btnSearch_Click" />
                        </td>
                    </tr>
                </table>
            </div>
        </div>
        <div class="doc_content" style="float: left; width: 100%;">
            <div style="padding: 5px 0 10px 100px;">
                <asp:Button ID="Button1" runat="server" OnClick="btnThemmoi_Click" Text="Thêm mới thông tin Bất Động Sản" />
            </div>
            <asp:Repeater ID="RptReatyMarket" runat="server" OnItemCommand="RptReatyMarket_ItemCommand">
                <HeaderTemplate>
                    <table cellspacing="0" class="tbl_doc">
                        <thead>
                            <tr>
                                <td>
                                    TT
                                </td>
                                <td>
                                    Tiêu đề
                                </td>
                                <td>
                                    Người đăng
                                </td>
                                <td class="td1">
                                    Sửa
                                </td>
                                <td class="td1">
                                    Xóa
                                </td>
                            </tr>
                        </thead>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                        </td>
                        <td style="width: 500px;">
                            <a>
                                <%#Eval("Title") %></a>
                        </td>
                        <td>
                            <a>
                                <%#Eval("UserPublish")%></a>
                        </td>
                        <td class="td2">
                            <asp:LinkButton ID="lbtEdit" runat="server" CommandName="Edit" CommandArgument='<%#Eval("RealtyMarketID") %>'>Sửa</asp:LinkButton>
                        </td>
                        <td class="td2">
                            <script type="text/javascript">
                                function confirm1() {
                                    return confirm("Bạn có muốn xóa Record này ko ?");
                                }
                            </script>
                            <asp:LinkButton ID="lbtDelete" CssClass="xoa" runat="server" CommandName="Delete"
                                OnClientClick="return confirm1()" CommandArgument='<%#Eval("RealtyMarketID") %>'>Xóa</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
    <div id="divPaging" runat="server" class="paginator2 nr">
        <uc1:ucpaging ID="ucPaging1" runat="server" />
    </div>
    
</asp:Content>