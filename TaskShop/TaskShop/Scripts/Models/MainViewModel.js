

function MainViewModel() {
    var self = this;

    self.BatteryViewModel = new BatteryViewModel();
    self.MonitorViewModel = new MonitorViewModel();
    self.CartViewModel = new CartViewModel();
    self.WizardModel = new WizardModel();

    self.currentView = ko.observable();

    self.views = ko.observableArray(["Home", "Monitors", "Batteries", "MemoryCards", "Earphones", "Cart", "Wizard"]);

    self.goTopage = function (page) { location.hash = page; };

    self.show_Batteries = ko.computed(function () {
        self.BatteryViewModel.GetAll();
        return self.currentView() === "Batteries" ? true : false;
    });
    self.show_Monitors = ko.computed(function () {
        self.MonitorViewModel.GetAll();
        return self.currentView() === "Monitors" ? true : false;
    });
    self.show_MemoryCards = ko.computed(function () {
        return self.currentView() === "MemoryCards" ? true : false;
    });
    self.show_Earphones = ko.computed(function () {
        return self.currentView() === "Earphones" ? true : false;
    });

    self.show_Home = ko.computed(function () {
        return self.currentView() === "Home" ? true : false;
    });

    self.show_Cart = ko.computed(function () {
        self.CartViewModel.GetAll();
        return self.currentView() === "Cart" ? true : false;
    });

    self.show_Wizard = ko.computed(function () {
        self.CartViewModel.GetAll();
        return self.currentView() === "Wizard" ? true : false;
    });

    self.goTopage("Wizard");


};



