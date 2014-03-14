function Step(id, name, template, model) {
    var self = this;
    self.id = id;
    self.name = ko.observable(name);
    self.template = template;
    self.model = ko.observable(model);

    self.getTemplate = function () {
        return self.template;
    };
}






WizardModel = function (options) {
    var self = this;

    self.OrderModel = new OrderModel(options);


    self.stepModels = ko.observableArray([
        new Step(1, "Step1 Address", "addressTmpl", self.OrderModel),
        new Step(2, "Step 2 Delivery Methods", "deliveryMethodsTmpl", self.OrderModel),
        new Step(3, "Step3 Bank Card Number", "bankCardTmpl", self.OrderModel),
        new Step(4, "Step4 Confirmation", "confirmTmpl", self.OrderModel)
    ]);

    self.currentStep = ko.observable(self.stepModels()[0]);

    self.currentIndex = ko.computed(function () {
        return self.stepModels.indexOf(self.currentStep());
    });

    self.getTemplate = function (data) {
        return self.currentStep().template();
    };

    self.canGoNext = ko.computed(function () {
        return (self.currentIndex() < (self.stepModels().length - 1));
    });

    self.modelIsValid = function () {
        self.currentStep().model().isValid();
    };

    self.goNext = function () {
        if (((self.currentIndex() < self.stepModels().length - 1))) {
            self.currentStep(self.stepModels()[self.currentIndex() + 1]);
        }
    };

    self.canGoPrevious = ko.computed(function () {
        return self.currentIndex() > 0;
    });

    self.goPrevious = function () {
        if ((self.currentIndex() > 0)) {
            self.currentStep(self.stepModels()[self.currentIndex() - 1]);
        }
    };
};

OrderModel = function (options) {

    var self = this;
    self.DeliveryMethods = [
        "Courier",
        "Ordinary send by mail",
        "You take yourself",
        "Sending cash on delivery"
    ];

    self.choosenMethod = ko.observable(self.DeliveryMethods[2]);
    //if (window.vm) {
    //    self.TotalPrice = window.vm.CartViewModel.totalPrice();
    //    self.TotalCount = window.vm.CartViewModel.totalItems();
    //}
    self.TotalGoodsPrice = ko.observable();

    self.TotalCount = ko.observable();


    self.Discount = ko.computed(function () {
        if (self.TotalCount() > 10) return 30;
        if (self.TotalCount() > 5) return 10;
        if (self.TotalCount() > 2) return 5;
        return 0;
    });
    self.DeliveryPrice = ko.computed(function () {
        if (self.choosenMethod() == self.DeliveryMethods[0]) return 10;
        if (self.choosenMethod() == self.DeliveryMethods[1]) return 20;
        if (self.choosenMethod() == self.DeliveryMethods[3]) return 30;
        return 0;
    });

    self.TotalPrice = ko.computed(function () {
        return self.TotalGoodsPrice() + self.DeliveryPrice();
    });

    self.Email = ko.observable('');
    self.Street = ko.observable('');
    self.City = ko.observable('');
    self.House = ko.observable('');

    self.CardNumber = ko.observable();

    self.arr = ko.observableArray([]);

    self.GetAll = function () {
        $.ajax({
            type: 'GET',
            url: options.orderGet,
            success: onAjaxSuccess
        });
    };
    function onAjaxSuccess(data) {
        self.arr(data);
    }



    self.SubmitOrder = function () {
        var obj = {
            TotalGoodsPrice: self.TotalGoodsPrice,
            DeliveryPrice: self.DeliveryPrice,
            TotalCount: self.TotalCount,
            Discount: self.Discount,
            Email: self.Email,
            City: self.City,
            Street: self.Street,
            House: self.House,
            CardNumber: self.CardNumber
        };
        var json = ko.toJS(obj);
        $.post(options.orderAdd, json, function (returnedData) {
        });
    };

}