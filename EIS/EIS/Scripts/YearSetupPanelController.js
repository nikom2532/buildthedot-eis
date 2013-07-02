function YearSetupPanelController(titleElement, contentElement) {
    this.titleElement_ = titleElement;
    this.contentElement_ = contentElement;
}

YearSetupPanelController.prototype.titleElement_ = null;

YearSetupPanelController.prototype.contentElement_ = null;

YearSetupPanelController.prototype.dataSource_ = null;

YearSetupPanelController.prototype.Initialize = function () {
    this.dataSource_ = new kendo.data.DataSource({
        transport: {
            read: {
                url: "api/availableyear/get",
                dataType: "json"
            }
        },
        change: $.proxy(this.dataSourceChanged_, this)
    });

    $("#yearListView").kendoListView({
        dataSource: this.dataSource_,
        template: kendo.template($("#yearItemTemplate").html()),
        selectable: "single"
    });

    $("#addYearButton").click($.proxy(this.addYear_, this));
    $("#removeYearButton").click($.proxy(this.removeYear_, this));
}

YearSetupPanelController.prototype.Reload = function () {
}

YearSetupPanelController.prototype.WindowResized = function () {
}

YearSetupPanelController.prototype.dataSourceChanged_ = function() {
    //alert("Data Source Changed");
}

YearSetupPanelController.prototype.addYear_ = function () {
    var newYear = $("#addYearField").val();
    if (newYear < 2500) {
        alert("กรุณาใส่ค่าเป็นปี พ.ศ.");
    } else {
        $.ajax("api/availableyear/create/?year=" + newYear)
         .done($.proxy(function (data) {
             if (data.Success == true) {
                 this.dataSource_.read();
             } else {
                 alert(data.Message);
             }
         },this))
         .fail(function () {
             alert("Server Error");
         });
    }
}

YearSetupPanelController.prototype.removeYear_ = function () {
    var listView = $("#yearListView").data("kendoListView");
    var selection = listView.select().index();
    var dataItem = this.dataSource_.view()[selection];
    if (confirm("คุณแน่ใจที่จะลบข้อมูลของปี " + dataItem.Year + "? เมื่อลบแล้วจะไม่สามารถกู้คืนได้")) {
        $.ajax("api/availableyear/delete/?year=" + dataItem.Year)
         .done($.proxy(function (data) {
             if (data.Success == true) {
                 this.dataSource_.read();
             } else {
                 alert(data.Message);
             }
         }, this))
         .fail(function () {
         });
    }
}