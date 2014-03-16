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

    self.modelIsValid = ko.computed(function () {
        if (self.currentStep().id == 1) {
            if (self.OrderModel.ValidateFieldsStep1.errors().length == 0) {
                return true;
            } else {
                return false;
            }
        }
        if (self.currentStep().id == 2) {
            return true;
        }
        if (self.currentStep().id == 3) {
            if (self.OrderModel.ValidateFieldsStep3.errors().length == 0) {
                return true;
            } else {
                return false;
            }
        }
        return false;

    });
    self.canGoNext = ko.computed(function () {
        return (self.currentIndex() < (self.stepModels().length - 1) );
    });



    self.goNext = function () {
        if ((self.currentIndex() < self.stepModels().length - 1) ) {
            self.currentStep(self.stepModels()[self.currentIndex() + 1]);
        }
    };



    self.canGoPrevious = ko.computed(function () {
        return (self.currentIndex() > 0);
    });

    self.goPrevious = function () {
        if ((self.currentIndex() > 0)) {
            self.currentStep(self.stepModels()[self.currentIndex() - 1]);
        }
    };
};

