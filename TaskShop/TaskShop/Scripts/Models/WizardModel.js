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






WizardModel = function (model) {
    var self = this;

    self.OrderModel = new OrderModel();


    self.stepModels = ko.observableArray([
        new Step(1, "Step1 Address", "addressTmpl", self.OrderModel),
        new Step(2, "Step 2 Delivery Methods", "deliveryMethodsTmpl", self.OrderModel),
        new Step(3, "Step3 Bank Card Number", "bankCardTmpl", self.OrderModel),
        new Step(4, "Confirmation", "confirmTmpl", self.OrderModel)
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

OrderModel = function () {

    var self = this;
    self.TotalPrice = ko.observable(0);
    self.TotalCount = ko.observable(0);
    self.Discount = ko.observable(0);
    self.DeliveryPrice = ko.observable(0);

    self.Email = ko.observable('');
    self.Street = ko.observable('');
    self.City = ko.observable('');
    self.House = ko.observable('');

    self.CardNumber = ko.observable();

    self.DeliveryMethods = ko.observableArray([
     { method: "Courier" },
     { method: "Ordinary send by mail" },
     { method: "You take yourself" },
     { method: "Sending cash on delivery" }
    ]);
    self.chosenMethod = ko.observable("Courier");

    self.DeliveryPrice = ko.computed(function () {
        if (self.chosenMethod == self.DeliveryMethods()[0])
            return 0;
        if (self.chosenMethod == self.DeliveryMethods()[1])
            return 1;
        if (self.chosenMethod == self.DeliveryMethods()[2])
            return 2;
        if (self.chosenMethod == self.DeliveryMethods()[3])
            return 3;
        return 0;
    });
    //self.deliveryModel = new DeliveryModel();
    //self.addressModel = new AddressModel();
    //self.bankCardModel = new BankCardModel();
};


//DeliveryModel = function (model) {
//    var self = this;

//    //Observables
//    //self.FirstName = ko.observable(model.FirstName).extend({ required: true });
//    //self.LastName = ko.observable(model.LastName).extend({ required: true });


//};

//AddressModel = function (model) {
//    var self = this;

//    //Observables
//    //self.Address = ko.observable(model.Address).extend({ required: true });;
//    //self.PostalCode = ko.observable(model.PostalCode).extend({ required: true });;
//    //self.City = ko.observable(model.City).extend({ required: true });;


//};

//BankCardModel = function (model) {
//    var self = this;
//    self.CardNumber = ko.observable();

//};

