function PatternLoginPanel() {

    var _this = this;

    this.Events = {
        Entered: "Entered"
    };

    this.Initialize = function () {
        $("#patternPanel").patternInput({
            verticalDots: 3,
            horizontalDots: 3,
            width: 450,//iphone 250
            height: 450,//iphone 250
            autoClear: true,
            onFinish: onPatternFinish
        });
    }

    this.Hide = function (callback) {
        $("#loginPatternPanel").fadeOut(300,callback);
    }

    this.Show = function (callback) {
        $("#loginPatternPanel").fadeIn(300,callback);
    }

    this.ShowMessage = function (message) {
        $("#patternMessage").text(message);
        $("#patternMessageBox").show();
    }

    this.HideMessage = function () {
        $("#patternMessageBox").hide();
    }

    this.ShowForgotPasswordDialog = function () {
        $("#patternForget").show();
    }

    this.HideForgotPasswordDialog = function () {
        $("#patternForget").hide();
    }

    function onPatternFinish(values) {
        $(_this).trigger(_this.Events.Entered, [values]);
    }

}