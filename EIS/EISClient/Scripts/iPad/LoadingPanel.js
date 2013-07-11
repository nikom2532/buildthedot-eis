function LoadingPanel() {

    var _this = this;

    this.Initialize = function () {
    }

    this.Hide = function (callback) {
        $("#loadingPanel").fadeOut(200, callback);
    }

    this.ShowMessage = function (message) {
        $("#loadingMessage").text(message);
        $("#loadingPanel").show();
    }

}