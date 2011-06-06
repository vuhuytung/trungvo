/// <reference path="framework/jquery-1.4.1.min.js" />

/*
Author: hoan.trinh
Create Date: 2010-03-29
Description: các scrip thông dụng thường sử dụng
*/
// Phân trang loại nhỏ
// argIdContainer:  id chứa phân trang
// argBackAction:   function nút trang trước
// argNextAction:   function nút trang tiếp
// argPageSize:        kích thước trang

function VtcPagingSmall(argIdContainer, argBackAction, argNextAction, argPageSize) {
    this.currentPage = 1;
    this.totalPage = 1;
    this.idContainer = argIdContainer;
    this.nextAction = argNextAction;
    this.backAction = argBackAction;
    this.pageSize = argPageSize;

    this.bindPaging = function (totalRecord) {
        // Load css
        // Sử dụng: /js/socialshop-common.js
        COMMON.loadcssfile('/css/paging.css');

        if ($('#' + this.idContainer).length == 0) {
            return;
        }
        if (totalRecord <= 0) {
            this.totalPage = 1;
        }
        this.totalPage = Math.floor((totalRecord - 1) / argPageSize) + 1;
        var _sHtml = '<div class="pagingCssSmall"><div class="pageNumber" >Trang ' + this.currentPage + '/' + this.totalPage + '</div>';
        if (this.currentPage < this.totalPage) {
            _sHtml += '<div class="next" onclick="' + this.nextAction + '();">&nbsp;</div>';
        }
        else {
            _sHtml += '<div class="none">&nbsp;</div>';
        }

        if (this.currentPage > 1) {
            _sHtml += '<div class="back" onclick="' + this.backAction + '();">&nbsp;</div>';
        }
        else {
            _sHtml += '<div class="none">&nbsp;</div>';
        }
        _sHtml += '</div>';
        $("#" + this.idContainer).html(_sHtml);
    }
}