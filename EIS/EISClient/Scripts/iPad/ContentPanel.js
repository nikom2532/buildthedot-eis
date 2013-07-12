function ContentPanel(elementId) { // elementId = contentPanel

    var _this = this;
    var _elementId = elementId;
    var _imgBox1 = null;
    var _imgBox2 = null;
    var _currentImgBox = null;
    var _theOtherImgBox = null;
    var _currentYear = null;
    var _currentContent = null;
    var _historyStack = [];
    var _historyPointer = -1;
    var _buttons = {};
    var _atSubMenu = false;

    function onButtonClicked(event, buttonName) {
        var buttonContent = _currentContent.buttons[buttonName];
        if (buttonContent) {
            loadImage(buttonContent.imageUrl, buttonContent.draggable, buttonContent.height);
            $("#titleLabel").text(buttonContent.title);
            _atSubMenu = true;
            if (buttonContent.hideYear) {
                $("#yearLabel").hide();
            } else {
                var offset = 0;
                if (buttonContent.yearOffset) {
                    offset += buttonContent.yearOffset;
                }
                $("#yearLabel").show();
                $("#yearText").text(_currentYear + offset);
            }
        }
    }

    function loadImage(url, draggable, height) {
        //Swap current and the other
        var tmp = _currentImgBox;
        _currentImgBox = _theOtherImgBox;
        _theOtherImgBox = tmp;

        _theOtherImgBox.Hide();
        _currentImgBox.LoadImage(url + "?year=" + _currentYear, draggable, height);
        _currentImgBox.Show();
    }

    this.Initialize = function (year) {
        _currentYear = year;
        _imgBox1 = new ImageBox("imageBox");
        _imgBox1.Initialize();
        _imgBox2 = new ImageBox("imageBox2");
        _imgBox2.Initialize();
        _currentImgBox = _imgBox2;
        _theOtherImgBox = _imgBox1;
        _buttons["detail"] = new Button("detail", "bottomBarInner", 159, 0, 131, 50, "buttonDetail");
        _buttons["compare"] = new Button("compare", "bottomBarInner", 30, 0, 131, 50, "buttonCompare");
        _buttons["compareonly"] = new Button("compareonly", "bottomBarInner", 94, 0, 131, 50, "buttonCompare");
        _buttons["one"] = new Button("one", "bottomBarInner", 2, 0, 77, 50, "buttonEmpty", "1");
        _buttons["two"] = new Button("two", "bottomBarInner", 81, 0, 77, 50, "buttonEmpty", "2");
        _buttons["three"] = new Button("three", "bottomBarInner", 160, 0, 77, 50, "buttonEmpty", "3");
        _buttons["four"] = new Button("four", "bottomBarInner", 239, 0, 77, 50, "buttonEmpty", "4");
        for (var button in _buttons) {
            _buttons[button].Initialize();
            $(_buttons[button]).on(_buttons[button].Events.Clicked, onButtonClicked);
        }
    }

    this.LoadMenu = function (menu, fromBackButton) {

        _atSubMenu = false;

        //Move contentPanel, bottomBar out
        _this.Hide(function () {
            //Show related graph & buttons
            _currentContent = ContentRouting[menu];
            if (_currentContent) {
                $("#titleLabel").text(_currentContent.title);
                if (_currentContent.hideYear) {
                    $("#yearLabel").hide();
                } else {
                    var offset = 0;
                    if (_currentContent.yearOffset) {
                        offset += _currentContent.yearOffset;
                    }
                    $("#yearLabel").show();
                    $("#yearText").text(_currentYear + offset);
                }

                //Hide all buttons and choose only the configured button
                for (var button in _buttons) {
                    _buttons[button].Hide();
                }
                var sumWidth = 0;
                for (var button in _currentContent.buttons) {
                    _buttons[button].Show();
                    _buttons[button].SetText(_currentContent.buttons[button].buttonText);
                    _buttons[button].SetFontSize(_currentContent.buttons[button].fontSize);
                    sumWidth += _buttons[button].GetWidth();
                }
                var padding = (800 - sumWidth) / 2;
                $("#bottomBarInner").css("padding-left", padding+"px");

                loadImage(_currentContent.imageUrl, _currentContent.draggable, _currentContent.height);

                if (!fromBackButton) {
                    if (_historyPointer == -1) {
                        _historyPointer++;
                        _historyStack[_historyPointer] = menu;
                    } else
                        if (_historyPointer > -1 && _historyStack[_historyPointer] != menu) {
                            _historyPointer++;
                            _historyStack[_historyPointer] = menu;
                        }
                }
            }

            //Move the contentPanel, buttomBar in
            _this.Show();
        });
    }

    this.Back = function () {
        if (!_atSubMenu) {
            if (_historyPointer > 0) {
                _historyPointer--;
                _this.LoadMenu(_historyStack[_historyPointer], true);
            }
        } else {
            _this.LoadMenu(_historyStack[_historyPointer], true);            
        }
    }

    this.Show = function (callback) {
        //move in
        $("#contentPanel").animate({
            left: 80 // iphone 0
        }, 500);
        $("#bottomBar").animate({
            top: -250,//410
            left: 500
        }, 500, callback);
    }

    this.Hide = function (callback) {
        //move out
        $("#contentPanel").animate({
            left: 1024//iphone 320
        }, 500);
        $("#bottomBar").animate({
            top: 769,
            left: 700
        }, 500, callback);
    }
}