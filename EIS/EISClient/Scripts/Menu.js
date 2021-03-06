﻿function Menu(elementId) {
    var _this = this;
    var _element = $("#" + elementId);

    this.Events = {
        MenuSelected: "MenuSelected"
    }

    this.Initialize = function () {
        $(".menuItem").on("mousedown", menuTouch)
                      .on("mouseup", menuTouchEnd);
        $(".menuItem").on("touchstart", menuTouch)
                      .on("touchend", menuTouchEnd);
    }

    this.Show = function (callback) {
        _element.show();
        _element.animate({
            top: 92
        }, 500, callback);
    }

    this.Hide = function (callback) {
        _element.animate({
            top: -238
        }, 300, function () {
            _element.hide();
            if (callback) {
                callback();
            }
        });
    }

    function menuTouch() {
        $(this).toggleClass("menuItemSelected");
    }

    function menuTouchEnd() {
        $(this).toggleClass("menuItemSelected");
        var menuRel = $(this).attr("rel");
        $(_this).trigger(_this.Events.MenuSelected, [menuRel]);
        _this.Hide();
    }

}

