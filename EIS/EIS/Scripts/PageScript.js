/// <reference path="LayoutManager.js" />
/// <reference path="NavigationManager.js" />
/// <reference path="NavigationRoute.js" />
/// <reference path="MenuManager.js" />
/// <reference path="DataFormMapping.js" />

$(document).ready(function () {
    var layout = new LayoutManager();
    var menu = new MenuManager();
    layout.Initialize();
    menu.Initialize();
    var navigation = new NavigationManager(menu, layout, navigationRoute, dataFormMapping);
    navigation.Initialize();
});