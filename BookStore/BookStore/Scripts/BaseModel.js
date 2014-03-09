var BaseModel = function () {

    var self = this;
    self.title = ko.observable('');
    self.author = ko.observable('');
    self.year = ko.observable('');
    self.pageCount = ko.observable('');
    self.description = ko.observable('');
    self.arr = ko.observableArray([]);
  
    self.errors = ko.observableArray([]);
    
}