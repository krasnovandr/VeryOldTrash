var SearchForm = function (options) {
    var self = this;

    self.Model = ko.observable();
    self.Producer = ko.observable();
    self.GoodsCategory = ko.observable();
    self.MaxPrice = ko.observable();
    self.MinPrice = ko.observable();
};

var SearchViewModel = function (options) {
    var self = this;


    self.SearchForm = new SearchForm();
    self.GoodsCategories = ko.observableArray(["All", "Monitors", "Batteries", "MemoryCards", "Earphones"]);


    self.arr = ko.observableArray([]);

    self.standartMode = ko.observable(true);
    self.fullMode = ko.computed(function () {
        return !(self.standartMode());
    }, self);


    self.Full = function (data) {
        self.standartMode(false);
    };
    self.Cancel = function (data) {
        self.standartMode(true);
    };


    self.GetAll = function (data) {
        var json = ko.toJS(self.SearchForm);
        $.post(options.searchGetAll, json, function (returnedData) {
            if (returnedData)
                self.arr(returnedData);
        });
    };
}