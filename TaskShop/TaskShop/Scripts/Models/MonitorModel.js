var MonitorModel = function () {

    var self = this;

    self.Producer = ko.observable('');
    self.Resolution = ko.observable('');
    self.Frequency = ko.observable('');
    self.MatrixType = ko.observable('');
    self.Price = ko.observable('');

    self.arr = ko.observableArray([]);

    self.errors = ko.observableArray([]);

};

var MonitorViewModel = function () {
    var self = this;

    self.isReadMode = ko.observable(true);
    self.isEditMode = ko.computed(function () {
        return !(self.isReadMode());
    }, self);


    self.Create = function (data) {
        self.isReadMode(false);
    };
    self.Cancel = function (data) {
        self.isReadMode(true);
    };


    self.MonitorModel = new MonitorModel();

    self.Add = function (data) {
        var jsonData = ko.toJS(self.MonitorModel);

        $.post("/Monitors/Add", jsonData, function (returnedData) {
            if (returnedData["item"] == "Added") {
                self.MonitorModel.errors([]);
            } else {
                self.MonitorModel.errors(returnedData);
            }
        });
    };

    self.GetAll = function (data) {
        $.ajax({
            type: 'GET',
            url: "/Monitors/Get",
            success: onAjaxSuccess
        });
    };
    function onAjaxSuccess(data) {
        self.MonitorModel.arr(data);
    }

    self.AddToCart = function (data) {
        var json = ko.toJS(data);
        $.post("/Cart/AddMonitor", json, function (returnedData) {
            if (returnedData["item"] == "Added") {
                self.MonitorModel.errors([]);
            } else {
                self.MonitorModel.errors(returnedData);
            }
        });
    };
};