function LayoutManager() { }

LayoutManager.prototype.layout_ = null;

LayoutManager.prototype.Initialize = function () {
    this.layout_ = $("body").layout({
        spacing_open: 0,
        resizable: false,
        closable: false,
        west__size: 200
    });
}

LayoutManager.prototype.ResizeAll = function (panelId) {
    this.layout_.resizeAll();
}