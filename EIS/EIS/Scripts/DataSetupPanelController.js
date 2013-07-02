function DataSetupPanelController(titleElement, contentElement, name, formMapping) {
    this.titleElement_ = titleElement;
    this.contentElement_ = contentElement;
    this.formName_ = name;
    this.formMapping_ = formMapping;
}

DataSetupPanelController.prototype.titleElement_ = null;
DataSetupPanelController.prototype.contentElement_ = null;
DataSetupPanelController.prototype.formName_ = null;
DataSetupPanelController.prototype.formMapping_ = null;
DataSetupPanelController.prototype.yearSource_ = null;
DataSetupPanelController.prototype.dataSource_ = null;
DataSetupPanelController.prototype.gridInit_ = false;

DataSetupPanelController.prototype.Initialize = function () {
    this.yearSource_ = new kendo.data.DataSource({
        transport: {
            read: {
                url: "api/availableyear/get",
                dataType: "json"
            }
        }
    });

    $("#" + this.formName_ + "SelectedYearField").kendoDropDownList({
        dataSource: this.yearSource_,
        dataTextField: "Year",
        dataValueField: "Year"
    });

    $("#" + this.formName_ + "SelectYearButton").click($.proxy(this.selectYear_, this));
}

DataSetupPanelController.prototype.Reload = function () {
    this.yearSource_.read();
}

DataSetupPanelController.prototype.WindowResized = function () {
}

DataSetupPanelController.prototype.selectYear_ = function () {
    //Create a new data source
    var me = this;
    this.dataSource_ = new kendo.data.DataSource({
        transport: {
            read: {
                url: this.formMapping_[this.formName_].apiUrl + "/get",
                data: $.proxy(function () {
                    return {
                        year: this.getSelectedYear_()
                    };
                }, this),
                dataType: "json"
            },
            update: {
                url: this.formMapping_[this.formName_].apiUrl + "/update",
                dataType: "json",
                type: "PUT",
                contentType: "application/json"
            },
            parameterMap: function (obj, operation) {
                if (operation == "read") {
                    return "year=" + me.getSelectedYear_();
                } else
                if (operation == "update") {
                    return kendo.stringify(obj);
                }
            }
        },
        schema: {
            model: {
                id: "Id",
                fields: this.formMapping_[this.formName_].fields
            }
        }
    });

    //Show the section
    $("#" + this.formName_ + "ContentPanel").show();

    //Init the grid if it hasn't been init yet
    if (!this.gridInit_) {
        $("#" + this.formName_ + "Grid").kendoGrid({
            autoBind: false,
            columns: this.formMapping_[this.formName_].columns,
            dataSource: this.dataSource_,
            scrollable: true,
            editable: {
                update: true,
                mode: "incell"
            },
            navigatable: true,
            toolbar: ["save", "cancel"]
        });
    } else {
        $("#" + this.formName_ + "Grid").data("kendoGrid").setDataSource(this.dataSource_);
    }

    //Read data from data source
    this.dataSource_.read();

}

DataSetupPanelController.prototype.getSelectedYear_ = function () {
    return $("#" + this.formName_ + "SelectedYearField").val();
}