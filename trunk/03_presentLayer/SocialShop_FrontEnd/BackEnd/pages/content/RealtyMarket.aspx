<%@ Page Title="" Language="C#" MasterPageFile="~/master/masterBackend.master" AutoEventWireup="true"
    CodeFile="RealtyMarket.aspx.cs" Inherits="BackEnd_pages_content_RealtyMarket" %>

<%@ Register Src="~/userControls/ucPaging.ascx" TagName="ucpaging" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="topsearch">
        <div class="search">
            <h2>Tìm kiếm BĐS</h2>
            <table cellspacing="8">
                <tr>
                    <td>
                        Tìm tại:
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlProvince" runat="server" OnSelectedIndexChanged="ddlProvince_SelectedIndexChanged"
                            AutoPostBack="true">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Quận/Huyện
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlDistrict" runat="server" AutoPostBack="true" Height="22px"
                            OnSelectedIndexChanged="ddlDistrict_SelectedIndexChanged" Width="136px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Phường/Xã
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlVillage" runat="server" Width="136px">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Loại BĐS
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlTypeBDS" runat="server">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                        Khoảng Giá
                    </td>
                    <td>
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
    <div class="content">
        <div class="box_body">
            <div style="text-align: center; width: 100%; float: left;">
                <h1 style="color: Blue;">
                    Quản lý thông tin Bất Động Sản</h1>
            </div>
            <div class="doc_content" style="float: left; width: 100%;">
                <div style="padding: 5px 0 10px 100px;">
                    <asp:Button ID="Button1" runat="server" OnClick="btnThemmoi_Click" Text="Thêm mới thông tin Bất Động Sản" />
                </div>
                <asp:Repeater ID="RptReatyMarket" runat="server" 
                    onitemcommand="RptReatyMarket_ItemCommand" >
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
    </div>
</asp:Content>
