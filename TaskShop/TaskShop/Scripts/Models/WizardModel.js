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

    self.nameModel = ko.observable(new NameModel(model));
    self.addressModel = ko.observable(new AddressModel(model));

    self.stepModels = ko.observableArray([
        new Step(1, "Step1", "addressTmpl", self.nameModel()),
        new Step(2, "Step2", "deliveryMethodsTmpl", self.addressModel()),
         new Step(2, "Step3`", "bankCardTmpl", self.addressModel()),
        new Step(3, "Confirmation", "confirmTmpl", { NameModel: self.nameModel(), AddressModel: self.addressModel() })
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

NameModel = function (model) {
    var self = this;

    //Observables
    //self.FirstName = ko.observable(model.FirstName).extend({ required: true });
    //self.LastName = ko.observable(model.LastName).extend({ required: true });

    return self;
};

AddressModel = function (model) {
    var self = this;

    //Observables
    //self.Address = ko.observable(model.Address).extend({ required: true });;
    //self.PostalCode = ko.observable(model.PostalCode).extend({ required: true });;
    //self.City = ko.observable(model.City).extend({ required: true });;

    return self;
};