/*
Author: hoan.trinh
Create Date: 2010-03-29
Description: các scrip thông dụng thường sử dụng
*/
/// <reference path="/js/framework/jquery-1.4.1-vsdoc.js" />
/// <reference path="/js/framework/jquery-1.4.1.min.js" />
COMMON = new function () {
    // Hàm convert chuỗi json Datetime sang Date
    // value: chuỗi jSon datetime
    this.jSonToDate = function (value) {
        value = value.replace('/Date(', '');
        value = value.replace(')/', '');
        var expDate = new Date(parseInt(value));
        return expDate;
    }

    // Hàm convert chuỗi json Datetime sang chuối ngày tháng
    // value: chuỗi jSon datetime
    // option:
    //      0: dd/MM/yyyy hh:mm:ss
    //      1: dd/MM/yyyy
    //      2: hh:mm:ss dd/MM/yyyy
    this.jSonDateToString = function (value, option) {
        if (typeof (option) == 'undefined') {
            option = 0;
        }
        var expDate = COMMON.jSonToDate(value);
        var _day = expDate.getDate();
        var _month = expDate.getMonth() + 1;
        var _year = expDate.getFullYear();
        var _hour = expDate.getHours();
        var _minute = expDate.getMinutes();
        var _second = expDate.getSeconds();
        if (_day < 10) _day = "0" + _day;
        if (_month < 10) _month = "0" + _month;
        if (_hour < 10) _hour = "0" + _hour;
        if (_minute < 10) _minute = "0" + _minute;
        if (_second < 10) _second = "0" + _second;
        switch (option) {
            case 0:
                return _day + '/' + _month + '/' + _year + ' ' + _hour + ':' + _minute + ':' + _second;
                break;
            case 1:
                return _day + '/' + _month + '/' + _year;
                break;
            case 2:
                return _hour + ':' + _minute + ':' + _second + ' ' + _day + '/' + _month + '/' + _year;
                break;
            default:
                return expDate.toString();
                break;
        }
    }

    // Hàm lấy xâu con của 1 xâu + phần mở rộng
    // VD: COMMON.subString('hoan.trinh',4,'...') --> return: 'hoan...'
    this.subString = function (value, length, extend) {
        if (typeof (value) == 'undefined') {
            return '';
        }
        if (value.length < length) {
            return value;
        }
        return value.substr(0, length) + extend;

    }

    // Hàm lấy url từ chuỗi Unicode
    // mục đích: phục vụ cho SEO
    this.getUrlText = function (plainText) {
        var _URL_CHARS_UNICODE = "AÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴBCDĐEÉÈẸẺẼÊẾỀỆỂỄFGHIÍÌỊỈĨJKLMNOÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠPQRSTUÚÙỤỦŨƯỨỪỰỬỮVWXYÝỲỴỶỸZaáàạảãâấầậẩẫăắằặẳẵbcdđeéèẹẻẽêếềệểễfghiíìịỉĩjklmnoóòọỏõôốồộổỗơớờợởỡpqrstuúùụủũưứừựửữvwxyýỳỵỷỹz0123456789_";
        var _URL_CHARS_ANSI = "AAAAAAAAAAAAAAAAAABCDDEEEEEEEEEEEEFGHIIIIIIJKLMNOOOOOOOOOOOOOOOOOOPQRSTUUUUUUUUUUUUVWXYYYYYYZaaaaaaaaaaaaaaaaaabcddeeeeeeeeeeeefghiiiiiijklmnoooooooooooooooooopqrstuuuuuuuuuuuuvwxyyyyyyz0123456789_";
        var _URL_CHARS_BASE = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_";

        var _strTemp = "";
        var _iLength = plainText.length;

        var _iIndex = 0;

        // Loại bỏ các ký tự có dấu
        for (var i = 0; i < _iLength; i++) {
            iIndex = _URL_CHARS_UNICODE.indexOf(plainText.charAt(i));
            if (iIndex == -1)
                _strTemp += plainText.charAt(i);
            else
                _strTemp += _URL_CHARS_ANSI.charAt(iIndex);
        }
        var _strReturn = "";

        // Loại bỏ các ký tự lạ
        for (var i = 0; i < _iLength; i++) {
            if (_URL_CHARS_BASE.indexOf(_strTemp.charAt(i)) == -1) {
                _strReturn += '-';
            }
            else {
                _strReturn += _strTemp.charAt(i);
            }
        }

        while (_strReturn.indexOf("--") != -1) {
            _strReturn = _strReturn.replace('--', '-');
        }

        if ((_strReturn.length > 0) && (_strReturn.charAt(0) == '-')) {
            _strReturn = _strReturn.substr(1);
        }

        if ((_strReturn.length > 0) && (_strReturn.charAt(_strReturn.length - 1) == '-')) {
            _strReturn = _strReturn.substr(0, _strReturn.length - 1);
        }

        return _strReturn;
    }

    // Hàm load file css
    this.loadcssfile = function (filename) {

        var fileref = document.createElement("link")
        fileref.setAttribute("rel", "stylesheet")
        fileref.setAttribute("type", "text/css")
        fileref.setAttribute("href", filename)
        if (typeof fileref != "undefined")
            document.getElementsByTagName("head")[0].appendChild(fileref)
    }

    // Chỉ cho nhập vào các kí tự từ 0 => 9, backspace, del,tab, dấu chấm
    this.validateDigitQuantity = function (evt) {
        var keyCode = evt.keyCode ? evt.keyCode : evt.which;
        var arrCode = new Array(48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 8, 46, 36, 9, 46);
        if ($.browser.msie) {
            for (var i = 0; i < arrCode.length; i++) {
                if (arrCode[i] == keyCode) {
                    return true;
                    break;
                }
            }
            return false;
        }
        else {
            if (arrCode.indexOf(keyCode) > -1) return true;
            return false;
        }

    }

    // Hàm lấy xâu định dạng theo kiểu tiền tệ: 1234123 --> 1,234,123
    this.formatMoney = function (argValue) {
        var _comma = (1 / 2 + '').charAt(1);
        var _digit = '.';
        if (_comma == '.') {
            _digit = ',';
        }

        var _sSign = "";
        if (argValue < 0) {
            _sSign = "-";
            argValue = -argValue;
        }

        var _sTemp = "" + argValue;
        var _index = _sTemp.indexOf(_comma);
        var _digitExt = "";
        if (_index != -1) {
            _digitExt = _sTemp.substring(_index + 1);
            _sTemp = _sTemp.substring(0, _index);
        }

        var _sReturn = "";
        while (_sTemp.length > 3) {
            _sReturn = _digit + _sTemp.substring(_sTemp.length - 3) + _sReturn;
            _sTemp = _sTemp.substring(0, _sTemp.length - 3);
        }
        _sReturn = _sSign + _sTemp + _sReturn;
        if (_digitExt.length > 0) {
            _sReturn += _comma + _digitExt;
        }
        return _sReturn;
    }

    this.formatCurrent = function (num) {
        num = num.toString().replace(/\$|\,/g, '');
        if (isNaN(num))
            num = "0";
        sign = (num == (num = Math.abs(num)));
        num = Math.floor(num * 100 + 0.50000000001);
        cents = num % 100;
        num = Math.floor(num / 100).toString();
        if (cents < 10)
            cents = "0" + cents;
        for (var i = 0; i < Math.floor((num.length - (1 + i)) / 3); i++)
            num = num.substring(0, num.length - (4 * i + 3)) + '.' +
                num.substring(num.length - (4 * i + 3));
        var currency = (((sign) ? '' : '-') + num);
        return currency;
    }

    this.CaculatorTime = function (totalSeconds) {
        if (totalSeconds <= 0)
            return "00 : 00 : 00";
        hour = parseInt(totalSeconds / 3600);
        minute = parseInt((totalSeconds - hour * 3600) / 60);
        second = totalSeconds - hour * 3600 - minute * 60;
        if (hour < 10)
            _hour = "0" + hour.toString();
        else _hour = hour.toString();
        if (minute < 10)
            _minute = "0" + minute.toString();
        else _minute = minute.toString();
        if (second < 10)
            _second = "0" + second.toString();
        else _second = second.toString();
        return _hour + " : " + _minute + " : " + _second;
    }

    this.setStyleRow = function (m_selParent) {
        var m_stt = 0;
        $('#divItem', m_selParent).each(function () {
            m_stt++;
            if ((m_stt % 2) == 0) {
                $(this).addClass('adminListRow-even');
            }
            else {
                $(this).addClass('adminListRow-odd');
            }
        });
    };

    this.switch_display = function (_control1, _control2, _bool) {
        if (_bool) {
            $(_control1).show('slow');
            $(_control2).hide('slow');
        }
        else {
            $(_control1).hide('slow');
            $(_control2).show('slow');
        }
    };

    this.switch_display_1 = function (obj) {
        if (obj.style.display == 'none') {
            obj.style.display = '';
        }
        else {
            obj.style.display = 'none';
        }
    }

    this.switch_display_2 = function (_control1, _control2, _bool, _speed) {
        if (_bool) {
            $(_control1).slideUp(_speed, function () {
                $(_control2).slideDown(_speed);
            });
        }
        else {
            $(_control2).slideUp(_speed, function () {
                $(_control1).slideDown(_speed);
            });
        }
    };
}
if (!Array.indexOf) {
    Array.prototype.indexOf = function (obj, start) {
        start = (start == null) ? 0 : start;
        for (var i = start; i < this.length; i++)
            if (this[i] == obj) {
                return i;
            }
        return -1;
    }
}