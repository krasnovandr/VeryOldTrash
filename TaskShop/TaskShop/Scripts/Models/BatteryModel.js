var BatteryModel = function () {

    var self = this;

    self.Producer = ko.observable('');
    self.Capacity = ko.observable('');
    self.Voltage = ko.observable('');
    self.Price = ko.observable('');

    self.arr = ko.observableArray([]);

    self.errors = ko.observableArray([]);

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
};

var BatteryViewModel = function () {
    var self = this;
    self.BatteryModel = new BatteryModel();

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





    self.Add = function (data) {
        var jsonData = ko.toJS(self.BatteryModel);

        $.post("/Batteries/Add", jsonData, function (returnedData) {
            if (returnedData["item"] == "Added") {
                self.BatteryModel.errors([]);
            } else {
                self.BatteryModel.errors(returnedData);
            }
        });
    };

    self.GetAll = function (data) {
        $.ajax({
            type: 'GET',
            url: "/Batteries/Get",
            success: onAjaxSuccess
        });
    };
    function onAjaxSuccess(data) {
        self.BatteryModel.arr(data);
    }

    self.AddToCart = function (data) {
        var json = ko.toJS(data);
        $.post("/Cart/AddBattery", json, function (returnedData) {
            if (returnedData["item"] == "Added") {
                var tmp = window.vm.CartViewModel.totalItems();
                tmp++;
                window.vm.CartViewModel.totalItems(tmp);
                self.BatteryModel.errors([]);
            } else {
                self.BatteryModel.errors(returnedData);
            }
        });
    };


};
