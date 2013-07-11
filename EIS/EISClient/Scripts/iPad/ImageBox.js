function ImageBox(elementId) {

    var _this = this;
    var _element = $("#"+elementId);
    var _imgElement = null;
    var _currentImgHeight = 290; 

    this.Initialize = function () {
        _element.width(320).height(290);
        _imgElement = $("<img width='320' height='290' style='display:none; position:absolute; top: 0px;' class='imageBox'/>");
        _element.append(_imgElement);
        _imgElement.on("load", onImageLoaded.bind(this));
        _imgElement.draggable({ axis: "y", stop: onImageDragStop.bind(this) });
    }

    this.LoadImage = function (url, draggable, height) {
        var imgHeight = 290;
        if (height) {
            imgHeight = imgHeight * height;
        }
        _currentImgHeight = imgHeight;

        _element.addClass("imageBoxLoading");
        _imgElement.attr("src", url);
        if (draggable) {
            _imgElement.draggable("enable");
        } else {
            _imgElement.draggable("disable");
        }
    }

    this.Hide = function () {
        _element.hide();
    }

    this.Show = function () {
        _element.show();
    }

    function onImageLoaded() {
        _element.removeClass("imageBoxLoading");
        _imgElement.css({ top: '0px', height: _currentImgHeight + 'px' });
        _imgElement.show();
    }

    function onImageDragStop() {
        if (_imgElement.position().top > 0) {
            _imgElement.animate({
                top: 0
            }, 200);
        } else
        if (_imgElement.position().top + _imgElement.height() < 290) {
            var expectedTop = -1 * (_imgElement.height() - 290);
            _imgElement.animate({
                top: expectedTop
            }, 200);
        }
    }

}