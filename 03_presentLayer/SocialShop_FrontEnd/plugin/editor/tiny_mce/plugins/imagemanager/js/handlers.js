/// <reference path="/js/framework/jquery-1.4.1-vsdoc.js" />
/// <reference path="/js/framework/jquery-1.4.1.min.js" />
/// <reference path="/js/framework/jquery.jCache.js" />
/// <reference path="/plugin/editor/tiny_mce/plugins/imagemanager/js/imageManager.js" />


function preLoad() {
    if (!this.support.loading) {
        jAlert('Bạn cần Flash Player để sử dụng chức năng upload', 'Thông báo');
        return false;
    }
}
function loadFailed() {
    jAlert('Đã xảy ra lỗi trong quá trình tải trang, mời bạn thử lại', 'Thông báo');
}
function fileQueueError(file, errorCode, message) {
    try {
        switch (errorCode) {
            case SWFUpload.QUEUE_ERROR.FILE_EXCEEDS_SIZE_LIMIT:
                jAlert('Kích thước file quá lớn. Bạn vui lòng chọn file có kích thước dưới 2MB', 'Thông báo');
                break;
            case SWFUpload.QUEUE_ERROR.INVALID_FILETYPE:
                jAlert('File upload không thuộc định dạng file nhạc cho phép. Bạn vui lòng chọn file khác', 'Thông báo');
                break;
            default:
                jAlert('Lỗi xảy ra trong quá trình upload. Xin bạn vui lòng upload lại', 'Thông báo');
                break;
        }
    } catch (ex) {
        this.debug(ex);
    }

}
function clearQueue(obj) {
    var stats = obj.getStats();
    while (stats.files_queued > 0) {
        obj.cancelUpload();
        stats = obj.getStats();
    }
}
function fileQueued(file) {
    // check Exts
    var strfileExts = '*.jpg;*.png;*.gif';
    if (strfileExts.indexOf(file.type.toLowerCase()) == '-1') {
        jAlert('File upload không thuộc định dạng file cho phép. Bạn vui lòng chọn file khác', 'Thông báo');
        clearQueue(this);
        return;
    }

    // check file size
    var byteSize = Math.round(file.size / 1024 * 100) * .01;
    if (parseInt(byteSize) > 2048) {
        jAlert('Kích thước file quá lớn. Bạn vui lòng chọn file có kích thước dưới 2MB', 'Thông báo');
        clearQueue(this);
        return;
    }
    var fileName = '';
    if (file.name.length > 50) {
        fileName = file.name.substr(0, 50) + '...';
    } else {
        fileName = file.name;
    }

    $("#" + this.customSettings.fileName).html(fileName);
    var fileName1 = file.name.substring(0, file.name.lastIndexOf('.'));
    $("#" + this.customSettings.ImageName).val(fileName1);
}
function fileDialogComplete(numFilesSelected, numFilesQueued) {
    try {
        if (numFilesQueued > 1) {
            var stats = this.getStats();
            while (stats.files_queued > 0) {
                this.cancelUpload();
                stats = this.getStats();
            }
            alert('QUEUE_LIMIT_EXCEEDED');
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


}

function uploadProgress(file, bytesLoaded, bytesTotal) {
    var percent = Math.ceil((bytesLoaded / bytesTotal) * 100);
    var upload_message = Math.ceil(bytesLoaded / 1024) + 'kb/' + Math.ceil(bytesTotal / 1024) + 'kb';
    $('#' + this.customSettings.upload_status_bar).css('width', percent + '%');
    $('#' + this.customSettings.upload_message).html(upload_message);
    if (bytesLoaded == bytesTotal) {
        $('#' + this.customSettings.upload_message).html('watting...');
    }
}

function uploadSuccess(file, serverData) {
    if (serverData == '-2') {
        jAlert('Sai loại ảnh cho phép', 'Thông báo');
        return;
    }
    else if (serverData == '-1') {
        jAlert('File upload không thuộc định dạng file cho phép. Bạn vui lòng chọn file khác', 'Thông báo');
        return;
    }
    else {
        var strResponse = serverData.split('|');
        if (strResponse[0] == '1') {
            // removeCache
            var type = $('#selType').val();
            ImageManager.removeCache(type);

            // load data
            var name = strResponse[1];
            ImageManager.getImages(type, name);
            clearForm();
        }
    }
    
}
function clearForm() {
    $('#_fileName').html('');
    $('#txtFileName').val('');
    $('#upload_status_bar').css('width', '0%');
    $('#upload_message').html('');
}
function uploadComplete(file) {
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
}

function uploadError(file, errorCode, message) {
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
                jAlert('Lỗi: UPLOAD_LIMIT_EXCEEDED', 'Thông báo');
                break;
            case SWFUpload.UPLOAD_ERROR.HTTP_ERROR:
                jAlert('Lỗi: HTTP_ERROR', 'Thông báo');
                break;
            case SWFUpload.UPLOAD_ERROR.MISSING_UPLOAD_URL:
                jAlert('Lỗi: MISSING_UPLOAD_URL', 'Thông báo');
                break;
            case SWFUpload.UPLOAD_ERROR.IO_ERROR:
                jAlert('Lỗi: IO_ERROR', 'Thông báo');
                break;
            case SWFUpload.UPLOAD_ERROR.SECURITY_ERROR:
                jAlert('Lỗi: SECURITY_ERROR', 'Thông báo');
                break;
            case SWFUpload.UPLOAD_ERROR.UPLOAD_FAILED:
                jAlert('Lỗi: UPLOAD_FAILED', 'Thông báo');
                break;
            case SWFUpload.UPLOAD_ERROR.SPECIFIED_FILE_ID_NOT_FOUND:
                jAlert('Lỗi: SPECIFIED_FILE_ID_NOT_FOUND', 'Thông báo');
                break;
            case SWFUpload.UPLOAD_ERROR.FILE_VALIDATION_FAILED:
                jAlert('Lỗi: FILE_VALIDATION_FAILED', 'Thông báo');
                break;
            case SWFUpload.UPLOAD_ERROR.RESIZE:
                jAlert('Lỗi: RESIZE', 'Thông báo');
                break;
            default:
                jAlert('Lỗi: ' + message, 'Thông báo');
                break;
        }
    } catch (ex3) {
        this.debug(ex3);
    }

}
