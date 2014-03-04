var ViewModelAdd = function () {

    var self = this;
    self.Model = new BaseModel();
  

    window.flg = false;
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
        $.post("/Home/AddBook", jsonData, function (returnedData) {
            console.log("POST Recieved: " + returnedData);
             window.flg = true;

        })
    };

   
}