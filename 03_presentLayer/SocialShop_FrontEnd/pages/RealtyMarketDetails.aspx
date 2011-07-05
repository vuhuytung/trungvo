<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RealtyMarketDetails.aspx.cs" Inherits="pages_RealtyMarketDetails" %>
<%@ Register Src="/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <link href="../css/bds_detail.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" Runat="Server">
<div class="bodyContent">
        <div class="leftMain nl">
            <asp:Repeater ID="RptDetail" runat="server">
            <ItemTemplate>
                <div class="bds_info">
                    <h2>Thông tin về Bất Động Sản</h2>
                    <div class="bds_desc">
                        <%#Eval("Descrition") %>
                    </div>
                    <div class="bds_other">
                        <table cellspacing="8" class="tblDetail" >
                            <tr>
                                <td>Diện tích</td><td > <a><%#Eval("Acreage") %>m2</a></td>
                                <td>Hướng bds</td><td><a> <%#Eval("Position") %></a></td>
                            </tr>
                            <tr>
                                <td>Tình trạng pháp lý</td><td><a> <%#Eval("legalStatus") %></a></td>
                                <td>Số tầng</td><td><a> <%#Eval("Floor") %></a></td>
                            </tr>
                            <tr>
                                <td>Phòng khách</td><td><a> <%#Eval("ClientRoom") %></a></td>
                                <td>Phòng ngủ</td><td><a><%#Eval("BedRoom") %></a></td>
                                
                            </tr>
                            <tr>
                                <td>Phòng tắm</td><td><a> <%#Eval("BathRooms") %></a></td>
                                <td>máy điều hòa</td><td><a> <%#Eval("Cooler") %></a></td>
                                
                            </tr>
                            <tr>
                                <td>Truyền hình cáp</td>
                                <td> 
                                    <asp:CheckBox ID="CheckBox1" runat="server"  Enabled="false"  Checked='<%#Eval("CableTv") %>' /> 
                                </td>
                                <td>Gần trường mẫu giáo</td><td> <asp:CheckBox ID="CheckBox2" runat="server" Enabled="false"  Checked='<%#Eval("NearKindergarten") %>'/> </td>
                                
                            </tr>
                            <tr>
                                <td>Gần trường trung học</td><td><asp:CheckBox ID="CheckBox3" runat="server"  Enabled="false"  Checked='<%#Eval("NearlySchool") %>'/></td>
                                <td>Gần bệnh viện</td><td><asp:CheckBox ID="CheckBox4" runat="server" Enabled="false"   Checked='<%#Eval("NearHospital") %>'/></td>
                                
                            </tr>
                            <tr>
                                <td>Gần trường Đại Học</td><td><asp:CheckBox ID="CheckBox5" runat="server" Enabled="false"   Checked='<%#Eval("NearlyUniversity") %>'/></td>
                                <td>Gần chợ</td><td><asp:CheckBox ID="CheckBox6" runat="server" Enabled="false"  Checked='<%#Eval("NearlyMarket") %>'/></td>
                                
                            </tr>
                            <tr>
                                <td>Gần công viên</td><td><asp:CheckBox ID="CheckBox7"   runat="server" Enabled="false"   Checked='<%#Eval("NearlyPark") %>'/></td>
                                <td>Mạng internet</td><td><asp:CheckBox ID="CheckBox9" runat="server" Enabled="false"  Checked='<%#Eval("Internet") %>'/></td>
                            </tr>
                            <tr>
                                <td>Gara oto</td><td><asp:CheckBox ID="CheckBox8" runat="server" Enabled="false"  Checked='<%#Eval("GaraOto") %>'/></td>
                                <td>Giá bán</td><td><%#Eval("Price") %></td>
                            </tr>

                        </table>
                    </div>
                </div>
                <div class="bds_contact">
                    <h2>Liên hệ</h2>
                    <table  cellspacing="8" class="tbl_contact">
                        <tr>
                            <td>Người liên hệ</td>
                            <td>
                                <%#Eval("UserPublish")%>
                            </td>
                        </tr>
                        <tr>
                            <td>Địa chỉ</td>
                            <td>
                                 <%#Eval("Address")%>
                            </td>
                        </tr>
                        <tr>
                            <td>Điện thoại</td>
                            <td>
                                <%#Eval("Phone")%>
                            </td>
                        </tr>
                        <tr>
                            <td>Email</td>
                            <td>
                                <%#Eval("Email")%>
                            </td>
                        </tr>
                    </table>

                </div>
                <div class="bds_img">
                    <h2>Hình ảnh</h2>
                    <img src='../<%#Eval("Image") %>' width="500" height="300" alt="ảnh" />
                </div>
            </ItemTemplate>
             </asp:Repeater>





            <div class="clear">
            </div>
            <hr style="margin-top: 30px;" />
        </div>
        <div class="rightMain nr">
            <uc2:ucDoitac runat="server" ID="ucDoitac1" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>


</asp:Content>

