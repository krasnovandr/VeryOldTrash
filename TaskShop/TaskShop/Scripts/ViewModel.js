var BatteryModel = function () {

    var self = this;

    self.Producer = ko.observable('');
    self.Capacity = ko.observable('');
    self.Voltage = ko.observable('');
    self.Price = ko.observable('');

    self.arr = ko.observableArray([]);

    self.errors = ko.observableArray([]);

};



function ViewModel() {
    var self = this;
    self.Model = new BatteryModel();
    self.currentView = ko.observable();

    self.views = ko.observableArray(["Home", "About", "Battery"]);

    self.goTopage = function (page) { location.hash = page; };
    self.show_Battery = ko.computed(function () {
        return self.currentView() === "Battery" ? true : false;
    });
    self.show_Home = ko.computed(function () {
        return self.currentView() === "Home" ? true : false;
    });
    self.show_About = ko.computed(function () {
        return self.currentView() === "About" ? true : false;
    });


    self.Add = function (data) {
        var jsonData = ko.toJS(self.Model);

        $.post("/Batteries/AddBattery", jsonData, function (returnedData) {
            if (returnedData["item"] == "Added") {
                self.Model.errors([]);
            } else {
                self.Model.errors(returnedData);
            }
        });
    };

    self.AllBooks = function (data) {
        $.ajax({
            type: 'GET',
            url: "/Batteries/GetResult",
            success: onAjaxSuccess
        });
    };
    function onAjaxSuccess(data) {
        self.Model.arr(data);
    }
};



