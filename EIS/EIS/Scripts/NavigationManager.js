/// <reference path="MenuManager.js" />
/// <reference path="LayoutManager.js" />


function NavigationManager(menuManager, layoutManager, route, formMapping) {
    this.menu_ = menuManager;
    this.layout_ = layoutManager;
    this.route_ = route;
    this.formMapping_ = formMapping;
    $(menuManager).on("menuClicked", $.proxy(this.onMenuClicked_, this));
}

NavigationManager.prototype.menu_ = null;

NavigationManager.prototype.layout_ = null;

NavigationManager.prototype.route_ = null;

NavigationManager.prototype.formMapping_ = null;

NavigationManager.prototype.currentPageManager_ = null;

NavigationManager.prototype.Initialize = function () {
    $(window).resize($.proxy(this.onWindowResized, this));
}

NavigationManager.prototype.onWindowResized = function () {
    if (this.currentPageManager_ != null) {
        this.currentPageManager_.WindowResized();
    }
}

NavigationManager.prototype.onMenuClicked_ = function (event, clickedMenu) {
    var selectedMenu = null;
    for (var menuItem in this.route_) {
        var menu = this.route_[menuItem];
        if (menu.name != clickedMenu) {
            $("#" + menu.titlePanel).hide();
            $("#" + menu.mainPanel).hide();
        } else {
            selectedMenu = menu;
        }
    }
    if (selectedMenu != null) {
        $("#" + selectedMenu.titlePanel).show();
        $("#" + selectedMenu.mainPanel).show();
        if (!selectedMenu.manager) {
            selectedMenu.manager = new window[selectedMenu.managerClass](selectedMenu.titlePanel, selectedMenu.mainPanel, selectedMenu.name, this.formMapping_);
            selectedMenu.manager.Initialize();
        } else {
            selectedMenu.manager.Reload();
        }
        this.currentPageManager_ = selectedMenu.manager;
        this.layout_.ResizeAll();
    }
}