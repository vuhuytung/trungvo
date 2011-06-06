jQuery.fn.maxLength = function(max) {
    this.each(function() {
        var valueTrim = new String();
        //  navigator.appCodeName;navigator.appName;navigator.appVersion;navigator.cookieEnabled;navigator.userAgent);
        if (navigator.userAgent.indexOf('MSIE 6.0') != -1) {
            // ie 6
            this.onchange = function() {
                //If the keypress fail and allow write more text that required, this event will remove it
                valueTrim = this.value;

                valueTrim = valueTrim.replace("  ", " ");
                //valueTrim = valueTrim.replace(/^\s+|\s+$/, '');
                this.value = valueTrim;
                if (valueTrim.length > max) {
                    this.value = valueTrim.substring(0, max);
                }

            };
        }
        else {
            //Get the type of the matched element
            var type = this.tagName.toLowerCase();
            //If the type property exists, save it in lower case
            var inputType = this.type ? this.type.toLowerCase() : null;

            //Check if is a input type=text OR type=password
            if (type == "input" && inputType == "text" || inputType == "password") {

                this.onkeypress = function(e) {
                    //Get the event object (for IE)
                    var ob = e || event;
                    //Get the code of key pressed
                    var keyCode = ob.keyCode;
                    //Check if it has a selected text
                    var hasSelection = document.selection ? document.selection.createRange().text.length > 0 : this.selectionStart != this.selectionEnd;
                    //return false if can't write more
                    valueTrim = this.value;
                    if (valueTrim.length >= max && (keyCode > 50 || keyCode == 32 || keyCode == 0 || keyCode == 13) && !ob.ctrlKey && !ob.altKey && !hasSelection)
                        return false;

                };

                this.onchange = function() {
                    //If the keypress fail and allow write more text that required, this event will remove it
                    valueTrim = this.value;

                    valueTrim = valueTrim.replace("&nbsp;&nbsp;", "&nbsp;");
                    valueTrim = valueTrim.replace(/^\s+|\s+$/, '');
                    this.value = valueTrim;
                    if (valueTrim.length > max) {
                        this.value = valueTrim.substring(0, max);
                    }

                };
            }
            //Check if the element is a textarea
            else if (type == "textarea") {
                $('#leftCharacter').html(max);
                //Add the key press event
                this.onkeypress = function(e) {
                    //Get the event object (for IE)
                    var ob = e || event;
                    //Get the code of key pressed
                    var keyCode = ob.keyCode;
                    //Check if it has a selected text
                    var hasSelection = document.selection ? document.selection.createRange().text.length > 0 : this.selectionStart != this.selectionEnd;
                    //return false if can't write more
                    valueTrim = this.value;
                    if (valueTrim.length >= max && (keyCode > 50 || keyCode == 32 || keyCode == 0 || keyCode == 13) && !ob.ctrlKey && !ob.altKey && !hasSelection)
                        return false;

                };

                //Add the key up event
                this.onkeyup = function() {
                    //If the keypress fail and allow write more text that required, this event will remove it
                    valueTrim = this.value;

                    if (valueTrim.length > max) {
                        this.value = valueTrim.substring(0, max);
                    }
                    else {
                        $('#leftCharacter, .leftCharacters').html(max - valueTrim.length);
                    }
                };
                this.onchange = function() {
                    //If the keypress fail and allow write more text that required, this event will remove it
                    valueTrim = this.value;

                    valueTrim = valueTrim.replace(/^\s+|\s+$/, '');
                    this.value = valueTrim;
                    if (valueTrim.length > max) {
                        this.value = valueTrim.substring(0, max);
                    }
                    else {
                        $('#leftCharacter, .leftCharacters').html(max - valueTrim.length);
                    }
                };
            }
        }
    });
};