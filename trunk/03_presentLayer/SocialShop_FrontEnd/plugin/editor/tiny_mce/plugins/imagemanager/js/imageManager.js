/// <reference path="/js/framework/jquery-1.4.1-vsdoc.js" />
/// <reference path="/js/framework/jquery-1.4.1.min.js" />
/// <reference path="/js/framework/jquery.jCache.js" />
/// <reference path="/js/framework/jquery-jtemplates.js" />
/// <reference path="/plugin/alert/js/jquery.alerts.js" />
/// <reference path="/js/Message.js" />
/// <reference path="/js/popup/Loading.js" />
/// <reference path="/js/socialshop-common.js" />
/// <reference path="/plugin/datepicker/js/jquery.ui.datepicker.js" />
/// <reference path="/js/vtc-paging.js" />
/// <reference path="/js/socialshop-utils.js" />
/// <reference path="/js/vtc-HtmlEncoder.js" />
ImageManager = new function () {

    this.htmlTag = new function () {
        this.divImageMgr = '#divImageMgr';
        this.divPopup_ImageManager = '#divPopup_ImageManager';
        this.divlistImages = '#divlistImages';
        this.imgCurrent = '#imgCurrent';
        this.divItemImage = '#divItemImage';
        this.divFileName = '#divFileName';
        this.txtImageName = '#txtImageName';
        this.divUploadStatusBar = '#divUploadStatusBar';
        this.divUploadMessage = '#divUploadMessage';
        this.btnUpload = '#btnUpload';
        this.imageCurrent = '.imageCurrent';
    };

    this.KeyCache = new function () {
        this.m_news = "Images_News";
    }
    this.Type = new function () {
        this.m_wantAds = 1;
        this.m_news = 2;
    }

    // Open form quản lý ảnh
    this.openImageManager = function () {
        $(this.htmlTag.divImageMgr).css("display", "");
        var top = (($(window).height() / 2) - ($(this.htmlTag.divPopup_ImageManager, this.htmlTag.divImageMgr).outerHeight() / 2));
        var left = (($(window).width() / 2) - ($(this.htmlTag.divPopup_ImageManager, this.htmlTag.divImageMgr).outerWidth() / 2));
        if (top < 0) top = 0;
        if (left < 0) left = 0;
        // IE6 fix
        if ($.browser.msie && parseInt($.browser.version) <= 6) top = top + $(window).scrollTop();

        $(this.htmlTag.divPopup_ImageManager).css({
            top: top + 'px',
            left: left + 'px',
            display: 'block'
        });

        try {
            $(this.htmlTag.divPopup_ImageManager, this.htmlTag.divImageMgr).draggable({ handle: $('.barpopup', this.htmlTag.divPopup_ImageManager) });
            $('.barpopup', this.htmlTag.divPopup_ImageManager).css({ cursor: 'move' });
        } catch (e) { /* requires jQuery UI draggables */ }

        this.getImages('');
    }

    // Lấy danh sách ảnh theo loại ảnh
    this.getImages = function (name) {
        $(this.htmlTag.divlistImages, this.htmlTag.divImageMgr).html(CONSTANT.TAG_IMAGE_LOADING);
        this.ShowPreviewImage('', '');
        var strKeyCache = this.KeyCache.m_news;
        if ($.jCache.hasItem(strKeyCache)) {
            var _data = $.jCache.getItem(strKeyCache);
            this.bindData(_data, name);
        }
        else {

            $.ajax({
                type: "GET",
                url: "/handler/HandlerImageManager.ashx",
                data: { action: "get" },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                cache: false,
                success: function (data) {
                    ImageManager.bindData(data, name);
                    $.jCache.setItem(strKeyCache, data);
                }
            });
        }
    }


    this.bindData = function (data, name) {

        $(this.htmlTag.divlistImages, this.htmlTag.divImageMgr).setTemplateURL("/plugin/editor/tiny_mce/plugins/imagemanager/listImages.htm");
        $(this.htmlTag.divlistImages, this.htmlTag.divImageMgr).processTemplate(data);
        if (data.length == 0) return;
        var id = '';
        if (name == '') {
            id = data[0]["Id"];
        }
        else {
            for (var i = 0; i < data.length; i++) {
                if (name == data[i]['Name']) {
                    id = data[i]['Id'];
                    break;
                }
            }
        }
        if (id == '') return;

        $('.' + id).addClass("imageCurrent");
        var i = id.substring(id.lastIndexOf('_') + 1);
        var src = data[i - 1]['URL'];
        var name = data[i - 1]['Name'];
        this.ShowPreviewImage(src, name);

    }

    // Close form quản lý ảnh
    this.Close = function () {
        $(this.htmlTag.divImageMgr).css("display", "none");
    }

    // Chèn ảnh
    this.Insert = function () {
        var value = $(this.htmlTag.imgCurrent, this.htmlTag.divImageMgr).attr("src");
        $("._ifr").contents().find("._ImageURL").val(value);
        $("._ifr").contents().find("#prev").html('<img id="previewImg" src="' + value + '" border="0" onload="ImageDialog.updateImageData(this);" onerror="ImageDialog.resetImageData();" />');
        this.Close();
    }

    this.ShowPreviewImage = function (src, name) {
        $(this.htmlTag.imgCurrent, this.htmlTag.divImageMgr).attr("src", src);
        $(this.htmlTag.imgCurrent, this.htmlTag.divImageMgr).attr("alt", name);

    }

    this.Delete = function () {
        jConfirm("Bạn có chắc chắn xóa ảnh này không?", "Thông báo", function (s) {
            if (s) {
                var _name = $(ImageManager.htmlTag.imgCurrent, ImageManager.htmlTag.divImageMgr).attr("alt");

                if (_name == "") {
                    jAlert("Bạn chưa chọn ảnh để xóa", "Thông báo");
                    return;
                }

                $.ajax({
                    type: "GET",
                    url: "/handler/HandlerImageManager.ashx",
                    data: { name: _name, action: "del" },
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    cache: false,
                    success: function (data) {
                        // Thành công
                        if (data == "1") {
                            // remove cache
                            ImageManager.removeCache();
                            var objCurrent = $(ImageManager.htmlTag.imageCurrent, ImageManager.htmlTag.divImageMgr);

                            if ($(objCurrent).next().length > 0) {
                                var htmTemp = $(objCurrent).next().html();
                                htmTemp = htmTemp.substring(htmTemp.indexOf('(') + 1, htmTemp.indexOf(')'));
                                var arr = htmTemp.split(',');
                                ImageManager.ShowPreviewImage(arr[0].replace(/'/g, ''), arr[1].replace(/'/g, ''));
                                $(objCurrent).next().addClass("imageCurrent");
                            }
                            else if ($(objCurrent).prev().length > 0) {
                                var htmTemp = $(objCurrent).prev().html();
                                htmTemp = htmTemp.substring(htmTemp.indexOf('(') + 1, htmTemp.indexOf(')'));
                                var arr = htmTemp.split(',');
                                ImageManager.ShowPreviewImage(arr[0].replace(/'/g, ''), arr[1].replace(/'/g, ''));
                                $(objCurrent).prev().addClass("imageCurrent");
                            }
                            $(objCurrent).remove();
                        }
                    }
                });



            }
        });
    }

    this.removeCache = function () {
        var strKeyCache = ImageManager.KeyCache.m_news;
        $.jCache.removeItem(strKeyCache);
    }

    $(this.htmlTag.divItemImage, this.htmlTag.divImageMgr).live("click", function () {
        $("#divlistImages > div").removeClass("imageCurrent");

        $(this).addClass("imageCurrent");
    });

    this.preLoad = function () {
        if (!this.support.loading) {
            jAlert(MESSAGE.UploadLogo.notPlayer, MESSAGE.title);
            return false;
        }
    };

    this.loadFailed = function () {
        jAlert(MESSAGE.UploadLogo.loadFailed, MESSAGE.title);
    };

    this.fileQueueError = function (file, errorCode, message) {
        try {
            switch (errorCode) {
                case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
                    jAlert(MESSAGE.UploadLogo.sizeLimit, MESSAGE.title);
                    break;
                case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
                    jAlert(MESSAGE.UploadLogo.notExts, MESSAGE.title);
                    break;
                default:
                    jAlert(MESSAGE.UploadLogo.queueError, MESSAGE.title);
                    break;
            }
        } catch (ex) {
            this.debug(ex);
        }

    };

    this.clearQueue = function (obj) {
        var stats = obj.getStats();
        while (stats.files_queued > 0) {
            obj.cancelUpload();
            stats = obj.getStats();
        }
    };
    this.fileQueued = function (file) {
        // check Exts
        var strfileExts = '*.jpg;*.png;*.gif';
        if (strfileExts.indexOf(file.type.toLowerCase()) == '-1') {
            jAlert(MESSAGE.UploadLogo.notExts, MESSAGE.title);
            ImageManager.clearQueue(this);
            return;
        }

        // check file size
        var byteSize = Math.round(file.size / 1024 * 100) * .01;
        if (parseInt(byteSize) > 2048) {
            jAlert(MESSAGE.UploadLogo.sizeLimit, MESSAGE.title);
            ImageManager.clearQueue(this);
            return;
        }
        $(ImageManager.htmlTag.divFileName, ImageManager.htmlTag.divImageMgr).html(file.name);
        var fileName1 = file.name.substring(0, file.name.lastIndexOf('.'));
        $(ImageManager.htmlTag.txtImageName, ImageManager.htmlTag.divImageMgr).val(fileName1);
    };

    this.fileDialogComplete = function (numFilesSelected, numFilesQueued) {
        try {
            if (numFilesQueued > 1) {
                var stats = this.getStats();
                while (stats.files_queued > 0) {
                    this.cancelUpload();
                    stats = this.getStats();
                }
            }
            else {
                var stats = this.getStats();
                while (stats.files_queued > 1) {
                    this.cancelUpload();
                    stats = this.getStats();
                }
            }
        }
        catch (ex) {
            this.debug(ex);
        }
    };


    this.uploadProgress = function (file, bytesLoaded, bytesTotal) {
        var percent = Math.ceil((bytesLoaded / bytesTotal) * 100);
        var upload_message = Math.ceil(bytesLoaded / 1024) + 'kb/' + Math.ceil(bytesTotal / 1024) + 'kb';
        $(ImageManager.htmlTag.divUploadStatusBar, ImageManager.htmlTag.divImageMgr).css('width', percent + '%');
        $(ImageManager.htmlTag.divUploadMessage, ImageManager.htmlTag.divImageMgr).html(upload_message);
        if (bytesLoaded == bytesTotal) {
            $(ImageManager.htmlTag.divUploadMessage, ImageManager.htmlTag.divImageMgr).html('watting...');
        }
    };
    this.uploadSuccess = function (file, serverData) {
        if (serverData == '-1') {
            jAlert(MESSAGE.UploadLogo.notExts, MESSAGE.title);
            return;
        }
        else {
            var strResponse = serverData.split('|');
            if (strResponse[0] == '1') {
                // removeCache
                ImageManager.removeCache();

                // load data
                var name = strResponse[1];
                ImageManager.getImages(name);
                ImageManager.clearForm();
            }
        }
    };
    this.uploadComplete = function (file) {
        try {

            var progress = new FileProgress(file, this.customSettings.upload_target);
            progress.setComplete();
            progress.toggleCancel(false);
            //        /*  I want the next upload to continue automatically so I'll call startUpload here */
            //        if (this.getStats().files_queued > 0) {
            //            this.startUpload();
            //        } else {
            //            var progress = new FileProgress(file, this.customSettings.upload_target);
            //            progress.setComplete();
            //            progress.toggleCancel(false);



            //        }
        } catch (ex) {
            this.debug(ex);
        }
    };
    this.uploadError = function (file, errorCode, message) {
        var progress;
        try {
            switch (errorCode) {
                case SWFUpload.UPLOAD_ERROR.FILE_CANCELLED:
                    try {
                        progress = new FileProgress(file, this.customSettings.upload_target);
                        progress.setCancelled();
                        progress.setStatus("Cancelled");
                        progress.toggleCancel(false);
                    }
                    catch (ex1) {
                        this.debug(ex1);
                    }
                    break;
                case SWFUpload.UPLOAD_ERROR.UPLOAD_STOPPED:
                    try {
                        progress = new FileProgress(file, this.customSettings.upload_target);
                        progress.setCancelled();
                        progress.setStatus("Stopped");
                        progress.toggleCancel(true);
                    }
                    catch (ex2) {
                        this.debug(ex2);
                    }
                case SWFUpload.UPLOAD_ERROR.UPLOAD_LIMIT_EXCEEDED:
                    jAlert(MESSAGE.UploadLogo.uploadLimitExceeded, MESSAGE.title);
                    break;
                case SWFUpload.UPLOAD_ERROR.HTTP_ERROR:
                    jAlert(MESSAGE.UploadLogo.httpError, MESSAGE.title);
                    break;
                case SWFUpload.UPLOAD_ERROR.MISSING_UPLOAD_URL:
                    jAlert(MESSAGE.UploadLogo.missingUploadUrl, MESSAGE.title);
                    break;
                case SWFUpload.UPLOAD_ERROR.IO_ERROR:
                    jAlert(MESSAGE.UploadLogo.ioError, MESSAGE.title);
                    break;
                case SWFUpload.UPLOAD_ERROR.SECURITY_ERROR:
                    jAlert(MESSAGE.UploadLogo.securityError, MESSAGE.title);
                    break;
                case SWFUpload.UPLOAD_ERROR.UPLOAD_FAILED:
                    jAlert(MESSAGE.UploadLogo.uploadFailed, MESSAGE.title);
                    break;
                default:
                    jAlert(MESSAGE.UploadLogo.error + message, MESSAGE.title);
                    break;
            }
        } catch (ex3) {
            this.debug(ex3);
        }

    };
    this.clearForm = function () {
        $(this.htmlTag.divFileName, this.htmlTag.divImageMgr).html('');
        $(this.htmlTag.txtImageName, this.htmlTag.divImageMgr).val('');
        $(this.htmlTag.divUploadStatusBar, this.htmlTag.divImageMgr).css('width', '0%');
        $(this.htmlTag.divUploadMessage, this.htmlTag.divImageMgr).html('');
    };
}
