// jQuery Alert Dialogs Plugin
//
// Version 1.1
//
// Cory S.N. LaViska
// A Beautiful Site (http://abeautifulsite.net/)
// 14 May 2009
//
// Visit http://abeautifulsite.net/notebook/87 for more information
//
// Usage:
//		jAlert( message, [title, callback] )
//		jConfirm( message, [title, callback] )
//		jPrompt( message, [value, title, callback] )
// 
// History:
//
//		1.00 - Released (29 December 2008)
//
//		1.01 - Fixed bug where unbinding would destroy all resize events
//
// License:
// 
// This plugin is dual-licensed under the GNU General Public License and the MIT License and
// is copyright 2008 A Beautiful Site, LLC. 
//
(function ($) {

    $.alerts = {

        // These properties can be read/written by accessing $.alerts.propertyName from your scripts at any time

        verticalOffset: -75,                // vertical offset of the dialog from center screen, in pixels
        horizontalOffset: 0,                // horizontal offset of the dialog from center screen, in pixels/
        repositionOnResize: true,           // re-centers the dialog on window resize
        overlayOpacity: 0.6,                // transparency level of overlay
        overlayColor: '#aaa',               // base color of overlay
        draggable: true,                    // make the dialogs draggable (requires UI Draggables plugin)
        okButton: '&nbsp;OK&nbsp;',         // text for the OK button
        cancelButton: '&nbsp;Cancel&nbsp;', // text for the Cancel button
        dialogClass: null,                  // if specified, this class will be applied to all dialogs

        // Public methods

        alert: function (message, title, callback) {
            if (title == null) title = 'Thông báo';
            $.alerts._show(title, message, null, 'alert', function (result) {
                if (callback) callback(result);
            });
        },

        confirm: function (message, title, callback) {
            if (title == null) title = 'Confirm';
            $.alerts._show(title, message, null, 'confirm', function (result) {
                if (callback) callback(result);
            });
        },

        prompt: function (message, value, title, callback) {
            if (title == null) title = 'Prompt';
            $.alerts._show(title, message, value, 'prompt', function (result) {
                if (callback) callback(result);
            });
        },

        // Private methods

        _show: function (title, msg, value, type, callback) {

            $.alerts._hide();
            $.alerts._overlay('show');
            $("BODY").append('<div id="popup_container" style="width: 310px;" class="_divPopup_border">' +
                                '<div class="_divPopup_wrapper">'+
                                   '<div class="barpopup" style="height: 30px;">'+
                                        '<div id="popup_title" class="titlepopup" style="float: left;"></div>' +
                                            '<div id="popup_close" style="float: right;" class="close" title="Đóng">&nbsp;</div>' +
		                                '<div style="clear: both;"></div>'+
		                            '</div>'+
		                            '<div class="content_popup">'+
		                                '<div id="popup_message"></div>'+
		                                '<div id="divbotpopup" class="bottom-popup"></div>' +
		                        '<div style="clear: both;"></div>'+
		                        '</div></div></div>');



            if ($.alerts.dialogClass) $("#popup_container").addClass($.alerts.dialogClass);

            // IE6 Fix
            var pos = ($.browser.msie && parseInt($.browser.version) <= 6) ? 'absolute' : 'fixed';

            $("#popup_container").css({
                position: pos,
                zIndex: 99999,
                padding: 0,
                margin: 0
            });

            $("#popup_title").text(title);
            //$("#popup_message").addClass(type);
            $("#popup_message").text(msg);
            $("#popup_message").html($("#popup_message").text().replace(/\n/g, '<br />'));

            //            $("#popup_container").css({
            ////                minWidth: $("#popup_container").outerWidth(),
            ////                maxWidth: $("#popup_container").outerWidth()
            //                minWidth: $("#popup_container")[0].offsetWidth,
            //                maxWidth: $("#popup_container")[0].offsetWidth
            //            });

            $.alerts._reposition();
            $.alerts._maintainPosition(true);

            switch (type) {
                case 'alert':
                    $("#divbotpopup").html('<ul id="btn_comment" class="nr"><li><a id="popup_ok" href="javascript:;">Đóng</a></li></ul><div style="clear: both;"></div>');

                    $("#popup_close").click(function () {
                        $.alerts._hide();
                        callback(true);
                    });

                    $("#popup_ok").click(function () {
                        $.alerts._hide();
                        callback(true);
                    });
                    break;
                case 'confirm':
                    $("#divbotpopup").html('<ul id="btn_comment" class="nr"><li><a id="popup_ok" href="javascript:;">Đồng ý</a></li><li><a id="popup_cancel" href="javascript:;">Bỏ qua</a></li></ul><div style="clear: both;"></div>');
                    $("#popup_close").click(function () {
                        $.alerts._hide();
                    });

                    $("#popup_ok").click(function () {
                        $.alerts._hide();
                        if (callback) callback(true);
                    });
                    $("#popup_cancel").click(function () {
                        $.alerts._hide();
                        if (callback) callback(false);
                    });
                    //$("#popup_ok").focus();
                    $("#popup_ok, #popup_cancel").keypress(function (e) {
                        if (e.keyCode == 13) $("#popup_ok").trigger('click');
                        if (e.keyCode == 27) $("#popup_cancel").trigger('click');
                    });
                    break;
            }

            $('#popup_overlay').click(function () {
                $.alerts._hide();
            });
            // Make draggable
            if ($.alerts.draggable) {
                try {
                    $("#popup_container").draggable({ handle: $(".barpopup") });
                    $(".barpopup").css({ cursor: 'move' });
                } catch (e) { /* requires jQuery UI draggables */ }
            }
        },

        _hide: function () {
            $("#popup_container").remove();
            $.alerts._overlay('hide');
            $.alerts._maintainPosition(false);
        },

        _overlay: function (status) {
            switch (status) {
                case 'show':
                    $.alerts._overlay('hide');
                    $("BODY").append('<div id="popup_overlay"></div>');
                    $("#popup_overlay").css({
                        position: 'absolute',
                        zIndex: 99998,
                        top: '0px',
                        left: '0px',
                        width: '100%',
                        height: $(document).height(),
                        background: $.alerts.overlayColor,
                        opacity: $.alerts.overlayOpacity
                    });
                    break;
                case 'hide':
                    $("#popup_overlay").remove();
                    break;
            }
        },

        _reposition: function () {
            var top = (($(window).height() / 2) - ($("#popup_container").outerHeight() / 2)) + $.alerts.verticalOffset;
            var left = (($(window).width() / 2) - ($("#popup_container").outerWidth() / 2)) + $.alerts.horizontalOffset;
            if (top < 0) top = 0;
            if (left < 0) left = 0;

            // IE6 fix
            if ($.browser.msie && parseInt($.browser.version) <= 6) top = top + $(window).scrollTop();

            $("#popup_container").css({
                top: top + 'px',
                left: left + 'px'
            });
            $("#popup_overlay").height($(document).height());
        },

        _maintainPosition: function (status) {
            if ($.alerts.repositionOnResize) {
                switch (status) {
                    case true:
                        $(window).bind('resize', $.alerts._reposition);
                        break;
                    case false:
                        $(window).unbind('resize', $.alerts._reposition);
                        break;
                }
            }
        }

    }

    // Shortuct functions
    jAlert = function (message, title, callback) {
        $.alerts.alert(message, title, callback);
    }

    jConfirm = function (message, title, callback) {
        $.alerts.confirm(message, title, callback);
    };

    jPrompt = function (message, value, title, callback) {
        $.alerts.prompt(message, value, title, callback);
    };

})(jQuery);