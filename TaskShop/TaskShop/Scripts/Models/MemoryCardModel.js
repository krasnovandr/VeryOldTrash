var MemoryCardModel = function () {

    var self = this;
    self.Id = ko.observable('');
    self.Model = ko.observable('');
    self.Producer = ko.observable('');
    self.Size = ko.observable('');
    self.WriteSpeed = ko.observable('');
    self.ReadSpeed = ko.observable('');
    self.Price = ko.observable('');
};

var MemoryCardViewModel = function (options) {

    var self = this;

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


    self.MemoryCardModel = new MemoryCardModel();

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
        var jsonData = ko.toJS(self.MemoryCardModel);
        $.post(options.memoryCardAdd, jsonData, function (returnedData) {
            if (returnedData["item"] == "Added") {
                self.errors([]);
            } else {
                self.errors(returnedData);
            }
        });
    };

    self.GetAll = function (data) {
        $.ajax({
            type: 'GET',
            url: options.memoryCardGetAll,
            success: onAjaxSuccess
        });
    };

    function onAjaxSuccess(data) {
        self.arr(data);
    }


    self.AddToCart = function (data) {
        var json = ko.toJS(data);
        $.post(options.cartAddMemoryCard, json, function (returnedData) {
            var a = returnedData;
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
}