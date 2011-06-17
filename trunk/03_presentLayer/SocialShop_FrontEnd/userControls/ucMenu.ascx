<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucMenu.ascx.cs" Inherits="userControls_ucMenu" %>
<script type="text/javascript">
    $(function () {
        $(".menuParent").parent().hover(function () {
            $(this).find("ul").first().fadeIn(300); // css("display", "block");
            $(this).find("a").first().css("background", "#DCA322 !important");
        },
        function () {
            $(this).find("ul").first().css("display", "none");
            $(this).find("a").first().css("background", "url(/images/line-topmenu.png) no-repeat 0 10px !important;");
            $(this).find(".Menufirst").css("background", "none !important");
        });
        $(".menuChildren").parent().hover(function () {
            $(this).find("ul").first().fadeIn(100); // css("display", "block");
            $(this).find("a").first().css("background", "#FFF !important");
        },
        function () {
            $(this).find("ul").first().css("display", "none");
            $(this).find("a").first().css("background", "#DCA322 !important;");
        });
    });
    </script>
<div class="menutop">
    <div class="leftMenutop png_bg">
    </div>
    <div class="centerMenutop">
        <ul>
            <li class="liParent"><a href="#" class="menuParent Menufirst">Trang chủ</a>
                <ul style="display: none" class="ulChild1">
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                    <li class="liParent"><a href="#" class="menuChildren">Menu con</a>
                        <ul style="display: none" class="ulChild2">
                            <li><a href="#" class="menuChildren">Menu con 2</a></li>
                            <li><a href="#" class="menuChildren">Menu con</a></li>
                        </ul>
                    </li>
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                </ul>
            </li>
            <li class="liParent"><a href="#" class="menuParent">Trang chủ</a>
                <ul style="display: none" class="ulChild1">
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                </ul>
            </li>
            <li class="liParent"><a href="#" class="menuParent">Trang chủ</a>
                <ul style="display: none" class="ulChild1">
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                </ul>
            </li>
            <li class="liParent"><a href="#" class="menuParent">Trang chủ</a>
                <ul style="display: none" class="ulChild1">
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                </ul>
            </li>
            <li class="liParent"><a href="#" class="menuParent">Trang chủ</a>
                <ul style="display: none" class="ulChild1">
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                </ul>
            </li>
            <li class="liParent"><a href="#" class="menuParent">Trang chủ</a>
                <ul style="display: none" class="ulChild1">
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                </ul>
            </li>
            <li class="liParent"><a href="#" class="menuParent">Trang chủ</a>
                <ul style="display: none" class="ulChild1">
                    <li><a href="#" class="menuChildren">Menu con</a></li>
                </ul>
            </li>
        </ul>
    </div>
    <div class="rightMenutop png_bg">
    </div>
    <div class="clear">
    </div>
    <!--End menutop-->
</div>
