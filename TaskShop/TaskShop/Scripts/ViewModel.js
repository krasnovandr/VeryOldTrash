function ViewModel() {
    var self = this;
    self.currentView = ko.observable();
    self.views = ko.observableArray(["Home", "About", "Contact"]);
}


