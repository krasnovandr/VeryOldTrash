var ViewModelAdd = function (options) {

    var self = this;
    self.Model = new BaseModel();


    self.isReadMode = ko.observable(true);
    self.isEditMode = ko.computed(function () {
        return !(self.isReadMode());
    }, self);


    self.createBook = function (data) {
        self.isReadMode(false);
    };
    self.Cancel = function (data) {
        self.isReadMode(true);
    };

    self.AddBook = function (data) {
        var jsonData = ko.toJS(self.Model);

        $.post(options.urlAdd, jsonData, function (returnedData) {
            if (returnedData["item"] == "Added") {
                self.Model.errors([]);
                window.viewModelShow.AllBooks();
            }
            else {
                self.Model.errors(returnedData);
            }
        })
    };


}