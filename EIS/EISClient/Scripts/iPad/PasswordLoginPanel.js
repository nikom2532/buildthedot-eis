function PasswordLoginPanel() {

    var _okButton = null;

    this.Events = {
        Entered: "Entered"
    }

    this.Initialize = function () {
        _okButton = new Button();
        _okButton.Initialize("okButton", "okButton");
        $(_okButton).on(_okButton.Events.Clicked, okButtonClicked.bind(this));
    }

    this.Show = function (callback) {
        $("#loginPasswordPanel").fadeIn(300, callback);
    }

    this.ShowMessage = function (message) {
        $("#loginPasswordMessage").text(message);
    }

    this.Hide = function (callback) {
        $("#loginPasswordPanel").fadeOut(200, callback);
    }

    function okButtonClicked(event) {
        var password = $("#passwordInput").val();
        $(this).trigger(this.Events.Entered, [password]);
    }
}