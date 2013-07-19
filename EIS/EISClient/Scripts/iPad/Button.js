function ButtonA(name, parentId, x, y, width, height, cssClass, text) {

    var _this = this;
    var _name = name;
    var _x = x;
    var _y = y;
    var _width = width;
    var _height = height;
    var _cssClass = cssClass;
    var _text = (text)?text:"";
    var _element = null;
    
    this.Events = {
        Clicked: "Clicked"
    };

    this.Initialize = function (elementId, cssClass) {
        if (!elementId) {
            var parent = $("#" + parentId);
            _element = $('<span style="top: ' + _y + 'px; left: ' + _x + 'px; width: ' + _width + 'px; height: ' + _height + 'px; display:none;padding-top:50px;position:absolute;" class="' + _cssClass + '">' + _text + '</span>');
            parent.append(_element);
        } else {
            _element = $("#" + elementId);
            _cssClass = cssClass;
        }
        _element.on("mousedown", function () {
            _element.addClass(_cssClass + "Selected");
        });
        _element.on("mouseup", function () {
            _element.removeClass(_cssClass + "Selected");
            $(_this).trigger(_this.Events.Clicked, [_name]);
        });
//        _element.on("touchstart", function () {
//            _element.addClass(_cssClass + "Selected");
//        });
//        _element.on("touchend", function () {
//            _element.removeClass(_cssClass + "Selected");
//            $(_this).trigger(_this.Events.Clicked, [_name]);
//        });
    }

    this.Show = function () {
        _element.css("display","table-cell");
    }

    this.Hide = function () {
        _element.hide();
    }

    this.SetText = function (text) {
        _text = text;
        _element.html(text);
    }

    this.SetFontSize = function (size) {
        _element.css("font-size", size+"px");
    }

    this.GetWidth = function () {
        return _element.width();
    }
}
function Button(name, parentId, x, y, width, height, cssClass, text) {

    var _this = this;
    var _name = name;
    var _x = x;
    var _y = y;
    var _width = width;
    var _height = height;
    var _cssClass = cssClass;
    var _text = (text) ? text : "";
    var _element = null;

    this.Events = {
        Clicked: "Clicked"
    };

    this.Initialize = function (elementId, cssClass) {
        if (!elementId) {
            var parent = $("#" + parentId);
            _element = $('<span style="top: ' + _y + 'px; left: ' + _x + 'px; width: ' + _width + 'px; height: ' + _height + 'px; display:none;padding-top:40px;position:absolute;" class="' + _cssClass + '">' + _text + '</span>');
            parent.append(_element);
        } else {
            _element = $("#" + elementId);
            _cssClass = cssClass;
        }
        _element.on("mousedown", function () {
            _element.addClass(_cssClass + "Selected");
        });
        _element.on("mouseup", function () {
            _element.removeClass(_cssClass + "Selected");
            $(_this).trigger(_this.Events.Clicked, [_name]);
        });
        //        _element.on("touchstart", function () {
        //            _element.addClass(_cssClass + "Selected");
        //        });
        //        _element.on("touchend", function () {
        //            _element.removeClass(_cssClass + "Selected");
        //            $(_this).trigger(_this.Events.Clicked, [_name]);
        //        });
    }

    this.Show = function () {
        _element.css("display", "table-cell");
    }

    this.Hide = function () {
        _element.hide();
    }

    this.SetText = function (text) {
        _text = text;
        _element.html(text);
    }

    this.SetFontSize = function (size) {
        _element.css("font-size", size + "px");
    }

    this.GetWidth = function () {
        return _element.width();
    }
}