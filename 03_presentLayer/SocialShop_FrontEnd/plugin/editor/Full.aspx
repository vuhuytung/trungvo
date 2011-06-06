<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Full.aspx.cs" Inherits="plugin_editor_Full" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="/css/popup.css" rel="stylesheet" type="text/css" />
    <link href="/plugin/editor/tiny_mce/plugins/imagemanager/css/imagemanager.css" rel="stylesheet" type="text/css" />
    
    <script type="text/javascript" src="/js/framework/jquery-1.4.1.min.js"></script>
    <script type="text/javascript" src="/js/framework/jquery-jtemplates.js"></script>
    <script src="/js/framework/jquery.jCache.js" type="text/javascript"></script>
    <script src="/plugin/alert/js/jquery.alerts.js" type="text/javascript"></script>
    <script type="text/javascript" src="/js/CONSTANT.js"></script>
    <script src="/js/framework/swfobject.js" type="text/javascript"></script>
    <script src="/js/framework/swfupload.js" type="text/javascript"></script>
    <script src="/js/framework/fileprogress.js" type="text/javascript"></script>
    <script src="/js/framework/jquery.ui.core.js" type="text/javascript"></script>
    <script src="/js/framework/jquery.ui.widget.js" type="text/javascript"></script>
    <script src="/js/framework/jquery.ui.mouse.js" type="text/javascript"></script>
    <script src="/js/framework/jquery.ui.draggable.js" type="text/javascript"></script>
    <script type="text/javascript" src="/plugin/editor/tiny_mce/tiny_mce.js"></script>
    <script src="/plugin/editor/tiny_mce/plugins/imagemanager/js/handlers.js" type="text/javascript"></script>
    
    <script type="text/javascript" src="/plugin/editor/tiny_mce/plugins/imagemanager/js/imageManager.js"></script>
    <script src="/js/socialshop-common.js" type="text/javascript"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            tinyMCE.init({
                // General options
                mode: "exact",
                elements: "<%= txtComment.ClientID %>",
                theme: "advanced",
                plugins: "pagebreak,table,advhr,advimage,advlink,inlinepopups,preview,searchreplace,contextmenu,paste,fullscreen,noneditable,visualchars",
                language: "vi",

                // Theme options
                theme_advanced_buttons1: "bold,italic,underline,strikethrough,|,justifyleft,justifycenter,justifyright,justifyfull,fontselect,fontsizeselect",
                theme_advanced_buttons2: "cut,copy,paste,pastetext,|,search,replace,|,bullist,numlist,|,outdent,indent,|,undo,redo,|,link,unlink,image,cleanup,|,preview,|,forecolor,backcolor",
                theme_advanced_buttons3: "tablecontrols,|,hr,removeformat,visualaid,|,sub,sup,|,charmap,advhr,|,fullscreen",
                theme_advanced_buttons4: "",
                theme_advanced_toolbar_location: "top",
                theme_advanced_toolbar_align: "left",
                theme_advanced_statusbar_location: "",
                theme_advanced_resizing: false,
                init_instance_callback: function () {
                    tinyMCE.execInstanceCommand("<%= txtComment.ClientID %>", "mceFocus");
                }
            });
            

            $(document).click(function (e) {
                var _obj = $("#" + "<%= txtComment.ClientID %>" + "_parent");
                var _l = _obj.position().left;
                var _t = _obj.position().top;
                var _w = _obj.width();
                var _h = _obj.height();
                if ((e.clientX < _l) || (e.clientX > _l + _w) || (e.clientY < _t) || (e.clientY > _t + _h)) {
                    blurComment();
                }
            });

        });

        function openImageManager() {
            loadUpload();
            ImageManager.openImageManager();
            
        }
        function loadUpload() {
            var swfu;
            swfu = new SWFUpload({
                // Backend Settings
                upload_url: "/handler/HandlerImageManager.ashx?action=upload",
                post_params: {
                    "ASPSESSID": "<%=Session.SessionID %>"
                },
                // File Upload Settings
                file_size_limit: "2048", //2M
                file_types: "*.jpg;*.png;*.gif",
                file_upload_limit: 0,
                file_queue_limit: 0,
                file_types_description: "Images File",

                // Event Handler Settings - these functions as defined in Handlers.js
                //  The handlers are not part of SWFUpload but are part of my website and control how
                //  my website reacts to the SWFUpload events.
                swfupload_preload_handler:ImageManager.preLoad,
                file_queued_handler:ImageManager.fileQueued,
                swfupload_load_failed_handler: ImageManager.loadFailed,
                file_queue_error_handler: ImageManager.fileQueueError,
                file_dialog_complete_handler: ImageManager.fileDialogComplete,
                upload_progress_handler: ImageManager.uploadProgress,
                upload_error_handler: ImageManager.uploadError,
                upload_success_handler: ImageManager.uploadSuccess,
                upload_complete_handler: ImageManager.uploadComplete,

                // Button settings
                button_placeholder_id: "btnSelect",
                button_image_url: "/images/chon_file1.png",
                button_width: 70,
                button_height: 23,
                button_cursor: SWFUpload.CURSOR.HAND,
                button_window_mode: SWFUpload.WINDOW_MODE.TRANSPARENT,
                button_action: SWFUpload.BUTTON_ACTION.SELECT_FILE,

                // Flash Settings
                flash_url: "/flash/swfupload.swf", // Relative to this file
                flash9_url: "/flash/swfupload_FP9.swf", // Relative to this file

                // Debug Settings
                debug: false
            });
            $('#btnUpload').live('click', function () {
                var imageName = $("#txtFileName").val();
                var type = $("#selType").val();
                swfu.setPostParams({t: type,  ImageName: imageName, action: 'upload' });
                swfu.startUpload();
            });
        }

        function focusComment() {
            $("#txtComementNotFocus").hide();
            $("#" + "<%= txtComment.ClientID %>" + "_parent").show();
        };

        function blurComment() {
            $("#txtComementNotFocus").show();
            $("#" + "<%= txtComment.ClientID %>" + "_parent").hide();
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <b>Editor dùng cho form WantAds</b></div>
    <div>
        <input id="txtComementNotFocus" onfocus="focusComment()" style="width:300px" value="Nhập thông tin..."/>
        <textarea id="txtComment" runat="server" rows="15" cols="80" width="518px" height="100px"></textarea>
        <hr />dsdsdsa sadsa dsa dá sad<br />
        dsadadss
    </div>
    </form>
</body>
</html>
