var SearchModel = function (options) {
    var self = this;
    self.GoodsId = ko.observable();
    self.Model = ko.observable();
    self.Producer = ko.observable();
    self.GoodsCategory = ko.observable();
    self.Price = ko.observable();
};

var SearchViewModel = function (options) {
    var self = this;
    self.SearchModel = new SearchModel();
    self.arr = ko.observableArray([]);
    self.searchString = ko.observable();


    self.GetAll = function (data) {
        var json = { modelName: data.searchString() };
        $.get(options.searchGetAll, json, function (returnedData) {
            if (returnedData)
                self.arr(returnedData);
        });
    };
}