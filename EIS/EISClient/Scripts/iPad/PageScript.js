document.ontouchmove = function (e) {
    e.preventDefault();
}
var STATES = {
    INITIAL: 0,
    PATTERN_SET1: 1,
    PATTERN_SET2: 2,
    LOGGED_ON: 3,
    LOGGED_OFF: 4
}

var loadingPanel = null;
var passwordLoginPanel = null;
var patternLoginPanel = null;
var menu = null;
var menuBar = null;
var contentPanel = null;
var isAtHome = false;
var service = new Service();
var appState = STATES.INITIAL;
var tempReturnedKey = null;
var tempPattern = null;

$(document).ready(function () {

    loadingPanel = new LoadingPanel();
    loadingPanel.Initialize(); // initial action see in LoadingPanel.js

    passwordLoginPanel = new PasswordLoginPanel();
    passwordLoginPanel.Initialize(); // initial action see in PasswordLoginPanel.js
    $(passwordLoginPanel).on(passwordLoginPanel.Events.Entered, passwordEntered);

    patternLoginPanel = new PatternLoginPanel();
    patternLoginPanel.Initialize(); // initial action see in PatternLoginPanel.js
    $(patternLoginPanel).on(patternLoginPanel.Events.Entered, patternEntered);

    menu = new Menu("menuPanel");
    menu.Initialize(); // initial action see in Menu.js
    $(menu).on(menu.Events.MenuSelected, menuSelected);

    menuBar = new MenuBar("menuBar");
    menuBar.Initialize(); //see in MenuBar.js
    $(menuBar).on(menuBar.Events.MenuSelected, menuBarSelected);

    var today = new Date();
    var year = today.getFullYear();
    if (year < 2500) {
        year += 543;
    }
    contentPanel = new ContentPanel("contentPanel");
    contentPanel.Initialize(year);

    if (service.IsFirstTime()) {
        appState = STATES.INITIAL;
        passwordLoginPanel.Show();
    } else {
        appState = STATES.LOGGED_OFF;
        patternLoginPanel.Show();
    }
});

function passwordEntered(event, value) {
    service.Login(value, function (result) {
        if (result && result.success === true) {
            passwordLoginPanel.Hide(function () {
                tempReturnedKey = result.key;
                appState = STATES.PATTERN_SET1;
                patternLoginPanel.Show();
                patternLoginPanel.ShowMessage("กรุณาตั้งรหัสผ่านแบบสัมผัส");
            });
        } else {
            if (result && result.message) {
                passwordLoginPanel.ShowMessage(result.message);
            } else {
                passwordLoginPanel.ShowMessage("ระบบมีปัญหาไม่สามารถติดต่อเซิร์ฟเวอร์ได้");
            }
        }
    });
}

function patternEntered(event, values) {
    if (appState == STATES.PATTERN_SET1) {
        tempPattern = values;
        patternLoginPanel.ShowMessage("ยืนยันรหัสผ่านอีกครั้ง");
        appState = STATES.PATTERN_SET2;
    } else
    if (appState == STATES.PATTERN_SET2) {
        if (service.ComparePattern(tempPattern, values)) {
            service.SaveLoginPattern(values);
            service.SaveKey(tempReturnedKey);
            appState = STATES.LOGGED_ON;
            patternLoginPanel.Hide();
            $("#mainPanel").show();
            menuBar.Show(function () {
                menu.Show();
                isAtHome = true;
            });
        } else {
            appState = STATES.PATTERN_SET1;
            patternLoginPanel.ShowMessage("รหัสผ่านไม่ตรงกัน กรุณาตั้งรหัสใหม่");
        }
    } else
    if (appState == STATES.LOGGED_OFF) {
        if (service.CheckPattern(values)) {
            appState = STATES.LOGGED_ON;
            patternLoginPanel.Hide();
            $("#mainPanel").show();
            menuBar.Show(function () {
                menu.Show();
                isAtHome = true;
            });
        } else {
            patternLoginPanel.ShowMessage("รหัสผ่านไม่ถูกต้อง กรุณาลองอีกครั้ง");
            patternLoginPanel.ShowForgotPasswordDialog();
        }
    }
}

function menuBarSelected(event, selected) {
    if (selected == "home") {
        if (!isAtHome) {
            contentPanel.Hide(function () {
                menu.Show();
                isAtHome = true;
            });
        }
    } else
    if (selected == "logout") {
        appState = STATES.LOGGED_OFF;
        patternLoginPanel.HideMessage();
        patternLoginPanel.HideForgotPasswordDialog();
        menu.Hide(function () {
            contentPanel.Hide(function () {
                menuBar.Hide(function () {
                    $("#mainPanel").hide();
                    patternLoginPanel.Show();
                });
            });
        });
    } else
    if (selected == "back") {
        menu.Hide();
        contentPanel.Back();
    }
}

function menuSelected(event, selected) {
    contentPanel.LoadMenu(selected);
    isAtHome = false;
}
