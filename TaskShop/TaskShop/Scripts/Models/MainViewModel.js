

function MainViewModel(options) {
    var self = this;

    self.BatteryViewModel = new BatteryViewModel(options);
    self.MonitorViewModel = new MonitorViewModel(options);
    self.CartViewModel = new CartViewModel(options);
    self.WizardModel = new WizardModel(options);

    self.currentView = ko.observable();
    self.currentDeep = ko.observable();

    self.views = ko.observableArray(["Home", "Monitors", "Batteries", "MemoryCards", "Earphones", "Cart", "Orders"]);

    self.chosenData = ko.observable();

    self.show_Battery = ko.computed(function () {
        return self.currentDeep() === "Batteries" ? true : false;
    });
    self.show_Monitor = ko.computed(function () {
        return self.currentDeep() === "Monitors" ? true : false;
    });

    self.goTopage = function (page) { location.hash = page; };
    self.goToItem = function (item) {
        location.hash = self.currentView() + '/' + item.Id;
    };

 

    self.goToPageItem = function (category, item) {
        self.currentView(false);

        if (category == "Monitors")
            self.currentDeep("Monitors");
        if (category == "Batteries") {
            self.BatteryViewModel.BatteryModel.Id(item.Id);
            self.BatteryViewModel.BatteryModel.Producer(item.Producer);
            self.BatteryViewModel.BatteryModel.Capacity(item.Capacity);
            self.BatteryViewModel.BatteryModel.Voltage(item.Voltage);
            self.BatteryViewModel.BatteryModel.Price(item.Price);
            self.currentDeep("Batteries");
       
        }

    };

    self.show_Batteries = ko.computed(function () {
        self.currentDeep(false);
        self.BatteryViewModel.GetAll();
        return self.currentView() === "Batteries" ? true : false;
    });
    self.show_Monitors = ko.computed(function () {
        self.currentDeep(false);
        self.MonitorViewModel.GetAll();


        return self.currentView() === "Monitors" ? true : false;
    });
    self.show_MemoryCards = ko.computed(function () {
        self.currentDeep(false);
        return self.currentView() === "MemoryCards" ? true : false;
    });
    self.show_Earphones = ko.computed(function () {
        self.currentDeep(false);
        return self.currentView() === "Earphones" ? true : false;
    });

    self.show_Home = ko.computed(function () {
        self.currentDeep(false);
        return self.currentView() === "Home" ? true : false;
    });
    self.show_Cart = ko.computed(function () {
        self.currentDeep(false);
        self.CartViewModel.GetAll();
        return self.currentView() === "Cart" ? true : false;
    });
    self.show_Orders = ko.computed(function () {
        self.currentDeep(false);
        self.WizardModel.OrderModel.GetAll();
        return self.currentView() === "Orders" ? true : false;
    });


    self.show_Wizard = ko.observable(false);

    self.wizardOpen = function (data) {
        self.show_Wizard(true);
    };



};



