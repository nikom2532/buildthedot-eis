function MenuManager() { }

MenuManager.prototype.currentSelected_ = null;

MenuManager.prototype.Initialize = function () {
    var me = this;
    $(".menuItem").click(function () {
        var menuRel = $(this).attr("rel");
        if (menuRel != me.currentSelected_) {
            $(this).toggleClass("menuSelected");
            $("[rel=" + me.currentSelected_ + "]").toggleClass("menuSelected");
            me.currentSelected_ = menuRel;
            $(me).trigger("menuClicked", menuRel);
        }
    });
}