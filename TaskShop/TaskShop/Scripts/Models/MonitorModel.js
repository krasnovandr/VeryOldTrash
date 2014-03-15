var MonitorModel = function () {

    var self = this;
    self.Id = ko.observable('');
    self.Producer = ko.observable('');
    self.Model = ko.observable('');
    self.Resolution = ko.observable('');
    self.Frequency = ko.observable('');
    self.MatrixType = ko.observable('');
    self.Price = ko.observable('');



};

var MonitorViewModel = function (options) {
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

    self.Add = function (data) {
        var jsonData = ko.toJS(self.MonitorModel);

        $.post(options.monitorAdd, jsonData, function (returnedData) {
            if (returnedData["item"] == "Added") {
                var tmp = window.vm.CartViewModel.totalItems();
                tmp++;
                window.vm.CartViewModel.totalItems(tmp);
                self.errors([]);
            } else {
                self.errors(returnedData);
            }
        });
    };

    self.GetAll = function() {
        $.get(options.monitorGetAll, function(returnedData) {
            if (returnedData)
                self.arr(returnedData);
        });
    };

    self.AddToCart = function (data) {
        var json = ko.toJS(data);
        $.post(options.cartAddMonitor, json, function (returnedData) {
            if (returnedData["item"] == "Added") {
                var tmp = window.vm.CartViewModel.totalItems();
                tmp++;
                window.vm.CartViewModel.totalItems(tmp);
                self.errors([]);
            } else {
                self.errors(returnedData);
            }
        });
    };
};