

function MainViewModel(options) {
    var self = this;

    self.BatteryViewModel = new BatteryViewModel(options);
    self.MonitorViewModel = new MonitorViewModel(options);
    self.MemoryCardViewModel = new MemoryCardViewModel(options);
    self.EarphoneViewModel = new EarphoneViewModel(options);
    self.CartViewModel = new CartViewModel(options);
    self.WizardModel = new WizardModel(options);
    self.SearchViewModel = new SearchViewModel(options);



    self.currentDeepView = ko.observable();
    self.currentData = ko.observable();
    self.currentMainView = ko.observable();
    self.views = ko.observableArray(["Home", "Monitors", "Batteries", "MemoryCards", "Earphones", "Cart", "Orders", "Search", "Error"]);
    self.arrData = ko.observable([]);

    self.Next = function () {
        $.get(options.homeGetNext, function(returnedData) {
            self.arrData(returnedData);
        });
    };

    self.Previous = function () {
        $.get(options.homeGetPrevious, function (returnedData) {
            self.arrData(returnedData);
        });
    };




    self.show_Battery = ko.computed(function () {
        return self.currentDeepView() === "Batteries" ? true : false;
    });
    self.show_Monitor = ko.computed(function () {
        return self.currentDeepView() === "Monitors" ? true : false;
    });
    self.show_Earphone = ko.computed(function () {
        return self.currentDeepView() === "Earphones" ? true : false;
    });
    self.show_MemoryCard = ko.computed(function () {
        return self.currentDeepView() === "MemoryCards" ? true : false;
    });
    self.show_Order = ko.computed(function () {
        return self.currentDeepView() === "Orders" ? true : false;
    });



    self.goTopage = function (page) {
        location.hash = page;
    };

    self.goToPageItem = function (item) {
        location.hash = self.currentMainView() + '/' + item.Id;
    };

    self.searchOrder = function (item) {
        location.hash = self.currentMainView() + '/' + item.Id();
    };

    self.goToPageCategoryItem = function (item) {
        var a = item.GoodsCategory + '/' + item.GoodsId;
        location.hash = a;
    };



    self.currentView = function (category, item) {
        self.currentMainView(false);
        self.currentDeepView(false);
        self.currentData(item);
        self.currentDeepView(category);
    };

    self.currentMainViewFunc = function (viewName) {
        self.currentDeepView(false);
        self.currentMainView(viewName);
        //location.hash = viewName;
    };

    self.show_Error = ko.computed(function () {
        self.currentDeepView(false);
        return self.currentMainView() === "Error" ? true : false;
    });

    self.show_Batteries = ko.computed(function () {
        return self.currentMainView() === "Batteries" ? true : false;
    });
    self.show_Search = ko.computed(function () {
        return self.currentMainView() === "Search" ? true : false;
    });
    self.show_Monitors = ko.computed(function () {
        return self.currentMainView() === "Monitors" ? true : false;
    });
    self.show_MemoryCards = ko.computed(function () {
        return self.currentMainView() === "MemoryCards" ? true : false;
    });
    self.show_Earphones = ko.computed(function () {
        return self.currentMainView() === "Earphones" ? true : false;
    });
    self.show_Home = ko.computed(function () {
        return self.currentMainView() === "Home" ? true : false;
    });
    self.show_Cart = ko.computed(function () {
        return self.currentMainView() === "Cart" ? true : false;
    });
    self.show_Orders = ko.computed(function () {
        return self.currentMainView() === "Orders" ? true : false;
    });


    self.show_Wizard = ko.observable(false);

    self.wizardOpen = function () {
        self.show_Wizard(true);
    };



};



