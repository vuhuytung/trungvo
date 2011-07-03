
$(document).ready(function () {
    $(".container").mouseover(function () {
        activeMenu();
    });
    function activeMenu() {
        try
        {
        var currPage = VtcMusic_Cookies.$Get('current_page');
        var currTab = VtcMusic_Cookies.$Get('current_tab');        
        $("ul.group li a.hover").removeClass("hover");
        $("ul li a.current").removeClass("current");
        $(".subMenu").attr("style", "display:none");

        $("#" + currPage).addClass("hover");
        $("#tab_" + currTab).addClass("current");
        

        $("#subMenu_" + currPage).attr("style", "display:inherit");
        }catch(e){}
    }

    $("ul.group li a").hover(
         function () {
             var currTab = VtcMusic_Cookies.$Get('current_tab');
             $("ul li a.current").removeClass("current");
             $("#tab_" + currTab).addClass("current");
             if ($(this).attr("class") != "hover") {
                 // switch all tabs off
                 $("ul.group li a.hover").removeClass("hover");

                 // switch this tab on
                 $(this).addClass("hover");
                 var id = $(this).attr("id");
                 $(".subMenu").attr("style", "display:none");
                 $("#subMenu_" + id).attr("style", "display:inherit");

             }
         }
    );

    $(".subMenu ul li a").hover(
        function () {
            $("ul li a.current").removeClass("current");
            $(this).addClass("current");
        });

    // For ManagementMobileSMS

    // bắt keycode

    $(".KieuInt input").keyup(function () {
        var val = $(this).val();
        if (!val.match(/^\d{1,}$/))
            $(this).val("");
        //$(this).val(val.substring(0,val.length-1));                    

    });


});
