var ViewModelAdd = function (options) {

    var self = this;
    self.Model = new BaseModel();



    self.AddBook = function (data) {
        var jsonData = ko.toJS(self.Model);

        $.post(options.urlAdd, jsonData, function(returnedData) {
            if (returnedData["item"] == "Added") {
                self.Model.errors([]);
                } else {
                self.Model.errors(returnedData);
            }
        });
    };


}