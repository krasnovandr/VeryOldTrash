var MonitorModel = function () {

    var self = this;

    self.Producer = ko.observable('');
    self.Resolution = ko.observable('');
    self.Frequency = ko.observable('');
    self.MatrixType = ko.observable('');
    self.Price = ko.observable('');

    self.arr = ko.observableArray([]);

    self.maxPrice = ko.computed(function () {
        var m = 0;
        for (var i = 1; i < self.arr().length; i++) {
            if (self.arr()[i].Price > m)
                m = self.arr()[i].Price;
        }
        return m;
    }, self);


    self.minPrice = ko.computed(function () {
        var m = 9999;
        for (var i = 0; i < self.arr().length; i++) {
            if (self.arr()[i].Price < m)
                m = self.arr()[i].Price;
        }
        return m;
    }, self);

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