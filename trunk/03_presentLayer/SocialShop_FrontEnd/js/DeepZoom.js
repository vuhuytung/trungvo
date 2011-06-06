DeepZoom = new function () {
    this.m_deepZoomID = '';
    this.thisMovie = function (movieName) {
        if (window.document[movieName]) {
            return window.document[movieName];
        }
        if (navigator.appName.indexOf("Microsoft Internet") == -1) {
            if (document.embeds && document.embeds[movieName])
                return document.embeds[movieName];
        }
        else // if (navigator.appName.indexOf("Microsoft Internet")!=-1)
        {
            return document.getElementById(movieName);
        }
    };
    this.sendToActionScript = function (value) {
        if (this.thisMovie(this.m_deepZoomID) != null) {
            this.thisMovie(this.m_deepZoomID).sendToActionScript(value);
        }
    };
    this.ActiveMouseWheel = function () {
        /** IE/Opera. */
        window.onmousewheel = document.onmousewheel = function () { return true; }

        /** DOMMouseScroll is for mozilla. */
        if (window.removeEventListener)
            window.removeEventListener('DOMMouseScroll', this.handleWheelEvent, false);
    };
    this.DeactiveMouseWheel = function () {
        /** IE/Opera. */
        window.onmousewheel = document.onmousewheel = this.handleWheelEvent;

        /** DOMMouseScroll is for mozilla. */
        if (window.addEventListener)
            window.addEventListener('DOMMouseScroll', this.handleWheelEvent, false);

        this.thisMovie(this.m_deepZoomID).focus();
    };
    this.handleWheelEvent = function (event) {
        //re-calculate the delta 
        var delta = 0;
        if (!event) /* For IE. */
            event = window.event;
        if (event.wheelDelta) { /* IE/Opera. */
            delta = event.wheelDelta / 40;
            /** In Opera 9, delta differs in sign as compared to IE.
            */
            if (window.opera)
                delta = -delta * 3;
        } else if (event.detail) { /** Mozilla case. */
            /** In Mozilla, sign of delta is different than in IE.
            * Also, delta is multiple of 3.
            */
            delta = -event.detail;
        }

        var o = { x: 0, y: 0,
            delta: delta,
            ctrlKey: event.ctrlKey, altKey: event.altKey,
            shiftKey: event.shiftKey
        }

        DeepZoom.thisMovie(DeepZoom.m_deepZoomID).handleWheel(o);
        /** Prevent default actions caused by mouse wheel.
        * That might be ugly, but we handle scrolls somehow
        * anyway, so don't bother here..
        */
        if (event.preventDefault)
            event.preventDefault();
        event.returnValue = false;
    };
    this.getFlashVersion = function () {
        // ie 
        try {
            try {
                // avoid fp6 minor version lookup issues 
                // see: http://blog.deconcept.com/2006/01/11/getvariable-setvariable-crash-internet-explorer-flash-6/ 
                var axo = new ActiveXObject('ShockwaveFlash.ShockwaveFlash.6');
                try { axo.AllowScriptAccess = 'always'; }
                catch (e) { return '6,0,0'; }
            } catch (e) { }
            return new ActiveXObject('ShockwaveFlash.ShockwaveFlash').GetVariable('$version').replace(/\D+/g, ',').match(/^,?(.+),?$/)[1];
            // other browsers 
        } catch (e) {
            try {
                if (navigator.mimeTypes["application/x-shockwave-flash"].enabledPlugin) {
                    return (navigator.plugins["Shockwave Flash 2.0"] || navigator.plugins["Shockwave Flash"]).description.replace(/\D+/g, ",").match(/^,?(.+),?$/)[1];
                }
            } catch (e) { }
        }
        return '0,0,0';
    };
    this.CheckFlashVersion = function () {
        var version = this.getFlashVersion().split(',').shift();
        if (version < 9) {
            return false;
        }
        else {
            return true;

        }
    };
};