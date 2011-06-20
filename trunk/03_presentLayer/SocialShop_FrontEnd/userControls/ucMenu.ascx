<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMenu.ascx.cs" Inherits="userControls_ucMenu" %>
<script src="/js/menu.js" type="text/javascript"></script>
<div class="menutop">
    <div class="leftMenutop png_bg">
    </div>
    <div class="centerMenutop">
        <ul class="menu" id="menu">
            <li><a href="#" class="menulink">Dropdown One</a>
                <ul>
                    <li><a href="#">Navigation Item 1</a></li>
                    <li><a href="#" class="sub">Navigation Item 2</a>
                        <ul>
                            <li class="topline"><a href="#">Navigation Item 1</a></li>
                            <li><a href="#">Navigation Item 2</a></li>
                            <li><a href="#">Navigation Item 3</a></li>
                            <li><a href="#">Navigation Item 4</a></li>
                            <li><a href="#">Navigation Item 5</a></li>
                        </ul>
                    </li>
                    <li><a href="#" class="sub">Navigation Item 3</a>
                        <ul>
                            <li class="topline"><a href="#">Navigation Item 1</a></li>
                            <li><a href="#">Navigation Item 2</a></li>
                            <li><a href="#" class="sub">Navigation Item 3</a>
                                <ul>
                                    <li class="topline"><a href="#">Navigation Item 1</a></li>
                                    <li><a href="#">Navigation Item 2</a></li>
                                    <li><a href="#">Navigation Item 3</a></li>
                                    <li><a href="#">Navigation Item 4</a></li>
                                    <li><a href="#">Navigation Item 5</a></li>
                                    <li><a href="#">Navigation Item 6</a></li>
                                </ul>
                            </li>
                            <li><a href="#">Navigation Item 4</a></li>
                        </ul>
                    </li>
                    <li><a href="#">Navigation Item 4</a></li>
                    <li><a href="#">Navigation Item 5</a></li>
                </ul>
            </li>
            <li><a href="#" class="menulink">Non-Dropdown</a></li>
            <li><a href="#" class="menulink">Dropdown Two</a>
                <ul>
                    <li><a href="#">Navigation Item 1</a></li>
                    <li><a href="#" class="sub">Navigation Item 2</a>
                        <ul>
                            <li class="topline"><a href="#">Navigation Item 1</a></li>
                            <li><a href="#">Navigation Item 2</a></li>
                            <li><a href="#">Navigation Item 3</a></li>
                        </ul>
                    </li>
                </ul>
            </li>
            <li><a href="#" class="menulink">Dropdown Three</a>
                <ul>
                    <li><a href="#">Navigation Item 1</a></li>
                    <li><a href="#">Navigation Item 2</a></li>
                    <li><a href="#">Navigation Item 3</a></li>
                    <li><a href="#">Navigation Item 4</a></li>
                    <li><a href="#">Navigation Item 5</a></li>
                    <li><a href="#" class="sub">Navigation Item 6</a>
                        <ul>
                            <li class="topline"><a href="#">Navigation Item 1</a></li>
                            <li><a href="#">Navigation Item 2</a></li>
                        </ul>
                    </li>
                    <li><a href="#">Navigation Item 7</a></li>
                    <li><a href="#">Navigation Item 8</a></li>
                    <li><a href="#">Navigation Item 9</a></li>
                    <li><a href="#">Navigation Item 10</a></li>
                </ul>
            </li>
        </ul>
        <%--<asp:Literal ID="Literal1" runat="server"></asp:Literal>--%>
    </div>
    <div class="rightMenutop png_bg">
    </div>
    <div class="clear">
    </div>
    <!--End menutop-->
</div>
<script type="text/javascript">
    var menu = new menu.dd("menu");
    menu.init("menu", "menuhover");
</script>
