function MenuBar(elementId) {

    var _this = this;
    var _element = $("#" + elementId);
    var _isAtHome = false;

    this.Events = {
        MenuSelected: "MenuSelected"
    };

    this.Initialize = function () {
        hookTouchEvent(".buttonBack", buttonBackTouch, buttonBackTouchEnd);
        hookTouchEvent(".buttonHome", buttonHomeTouch, buttonHomeTouchEnd);
        hookTouchEvent(".buttonLogout", buttonLogoutTouch, buttonLogoutTouchEnd);
    };

    this.Show = function (callback) {
        _element.animate({
            top: 50
        }, 300, callback);
    }

    this.Hide = function (callback) {
        _element.animate({
            top: 8
        }, 300, callback);
    }

    function hookTouchEvent(selector, handler, endHandler) {
        $(selector).on("mousedown", handler)
                   .on("mouseup", endHandler)
                   .on("touchstart", handler)
                   .on("touchend", endHandler);
    }

    function buttonBackTouch(event) {
        $(this).toggleClass("buttonBackSelected");
    }

    function buttonBackTouchEnd(event) {
        $(this).toggleClass("buttonBackSelected");
        $(_this).trigger(_this.Events.MenuSelected, ["back"]);
    }

    function buttonHomeTouch(event) {
        $(this).toggleClass("buttonHomeSelected");
    }

    function buttonHomeTouchEnd(event) {
        $(this).toggleClass("buttonHomeSelected");
        $(_this).trigger(_this.Events.MenuSelected, ["home"]);
    }

    function buttonLogoutTouch(event) {
        $(this).toggleClass("buttonLogoutSelected");
    }

    function buttonLogoutTouchEnd(event) {
        $(this).toggleClass("buttonLogoutSelected");
        $(_this).trigger(_this.Events.MenuSelected, ["logout"]);
    }
}