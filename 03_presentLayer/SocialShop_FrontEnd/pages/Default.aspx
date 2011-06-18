<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="pages_Default" %>

<%@ Register Src="/userControls/ucDoitac.ascx" TagName="ucDoitac" TagPrefix="uc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="plhBody" runat="Server">
    <div class="topSearch">
        <div class="containSubmenu">
        </div>
        <div class="leftTopSearch">
            <div class="showImage">
                <div>
                    <div style="height: 185px;">
                        <img src="/images/duan.png" width="427" height="185" />
                    </div>
                    <div style="height: 46px; margin-top: 15px; text-align: left; color: #ff8040;">
                        <div class="nl" style="width: 317px; font-weight: bold; font-family: Tahoma; margin: 0 10px;">
                            Căn hộ cao cấp ngoại ô thành phố Vinh</div>
                        <div class="nl">
                            <a href="#">
                                <img src="/images/btnChitiet.png" /></a></div>
                        <div class="clear">
                        </div>
                    </div>
                </div>
            </div>
            <div class="listImage">
                <table>
                    <tr>
                        <td valign="middle" class="titleListImage">
                            Căn hộ tại chung cư TECCO
                        </td>
                        <td class="frameListImage png_bg" valign="middle" align="center">
                            <img src="/images/duan1.png" width="110" height="67" />
                        </td>
                    </tr>
                    <tr>
                        <td valign="middle" class="titleListImage">
                            Căn hộ tại chung cư TECCO
                        </td>
                        <td class="frameListImage png_bg" valign="middle" align="center">
                            <img src="/images/duan1.png" width="110" height="67" />
                        </td>
                    </tr>
                </table>
            </div>
            <div class="clear">
            </div>
        </div>
        <div class="rightTopSearch">
            <div class="titleSearch png_bg">
                TÌM KIẾM NÂNG CAO
            </div>
            <div>
                <div class="label nl">
                    Tìm tại</div>
                <div class="value nr">
                    <select class="inputText" style="width: 80px;">
                        <option>Vinh</option>
                    </select></div>
                <div class="clear">
                </div>
                <div class="label nl">
                    Phường / Xã</div>
                <div class="value nr">
                    <select class="inputText" style="width: 100px;">
                        <option>[--Tất cả--]</option>
                    </select></div>
                <div class="clear">
                </div>
                <div class="label nl">
                    Loại hình</div>
                <div class="value nr">
                    <select class="inputText" style="width: 100px;">
                        <option>[--Tất cả--]</option>
                    </select></div>
                <div class="clear">
                </div>
                <div class="label nl">
                    Khoảng giá</div>
                <div class="value nr">
                    <select class="inputText" style="width: 80px;">
                        <option>[--Tất cả--]</option>
                    </select></div>
                <div class="clear">
                </div>
            </div>
            <div style="text-align: center; padding: 10px;">
                <a href="#">
                    <img src="/images/btnSearch.png" /></a>
            </div>
        </div>
        <div class="clear">
        </div>
        <!--End top search-->
    </div>
    <!--Begin body content-->
    <div class="bodyContent">
        <div class="leftMain nl">
            <div class="box">
                <div class="title">
                    Sàn giao dịch</div>
                <div class="topNews nl">
                    <img src="/images/Doitac.png" width="140" class="nl" style="border: solid 1px #AAA;
                        margin: 10px;" />
                    <p>
                        <span class="spTitle" style="color:#ff8040">Bàn đọc sách không nên đối diện với cổng ra vào</span> <span
                            class="spDate">07/06/2011</span>
                            <br /><br />
                        <p>
                            Thông thường khi nhắc đến phong thủy cho một ngôi nhà người ta hay quan tâm đến
                            phòng khách, phòng ngủ và bếp hơn là không gian đọc sách. Thế nhưng nếu có thể tuân
                            theo các nguyên tắc phong thủy cho phòng đọc sẽ tạo nên sự thoải mái, thư giãn lý
                            tưởng.
                        </p>
                    </p>
                    <div class="clear">
                    </div>
                </div>
                <div class="otherTopNedws nr">
                    <ul>
                        <li><a href="#">abc</a></li>
                    </ul>
                </div>
                <div class="clear">
                </div>
            </div>
        </div>
        <div class="rightMain nr">
            <uc2:ucDoitac runat="server" ID="ucDoitac1" />
        </div>
        <div class="clear">
        </div>
        <!--End body content-->
    </div>
</asp:Content>
