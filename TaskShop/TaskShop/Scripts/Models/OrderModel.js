
ko.validation.configure({
    insertMessages: true,
    messagesOnModified: false
    //decorateElement: true,
    //errorElementClass: 'error'
});

OrderModel = function (options) {

    var self = this;
    self.DeliveryMethods = [
        "Courier",
        "Ordinary send by mail",
        "You take yourself",
        "Sending cash on delivery"
    ];
    self.Id = ko.observable().extend({ min: 1, max: 1000 }).extend({ required: true });

    self.choosenMethod = ko.observable(self.DeliveryMethods[2]);

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
        var a = self.TotalGoodsPrice();
        var b = self.DeliveryPrice();
        var disc = 1 - (self.Discount() / 100);

        var value = parseFloat((a + b) * disc).toFixed(0);
        return value;
    });



    //self.Street = ko.observable('').extend({ required: true }).extend({ minLength: 2, maxLength: 10 });
    //self.City = ko.observable('').extend({ minLength: 2, maxLength: 10 }).extend({ required: true });
    //self.House = ko.observable('').extend({ min: 1, max: 1000 }).extend({ required: true });
    //self.Email = ko.observable('').extend({ email: true }).extend({ required: true });
    //self.CardNumber = ko.observable().extend({ required: true }).extend({ pattern: {
    //    message: 'Hey this doesnt match my pattern',
    //    params: '^[0-9]{12}$'
    //}});
    self.ValidateFieldsStep1 = {
        Street: ko.observable('').extend({ required: true }).extend({ minLength: 4, maxLength: 20 }),
        City: ko.observable('').extend({ minLength: 4, maxLength: 20 }).extend({ required: true }),
        House: ko.observable('').extend({ min: 1, max: 1000 }).extend({ required: true }),
        Email: ko.observable('').extend({ email: true }).extend({ required: true })

    };

    self.ValidateFieldsStep3 = {
        CardNumber: ko.observable().extend({ required: true }).extend({
            pattern: {
                message: 'Example:1111-1111-1111-1111',
                params: '^[0-9-]{19}$'
            }
        })
    };

    self.ValidateFieldsStep1.errors = ko.validation.group(self.ValidateFieldsStep1);
    self.ValidateFieldsStep3.errors = ko.validation.group(self.ValidateFieldsStep3);


 
    self.arr = ko.observableArray([]);
    //ko.validation.group(self);

    self.GetAll = function () {
        $.get(options.orderGetAll, function (returnedData) {
            if (returnedData)
                self.arr(returnedData);
        });
    };
    self.SubmitOrder = function () {
        window.vm.show_Wizard(false);

        var obj = {
            TotalGoodsPrice: self.TotalGoodsPrice,
            DeliveryPrice: self.DeliveryPrice,
            TotalCount: self.TotalCount,
            Discount: self.Discount,
            Email: self.ValidateFieldsStep1.Email,
            City: self.ValidateFieldsStep1.City,
            Street: self.ValidateFieldsStep1.Street,
            House: self.ValidateFieldsStep1.House,
            CardNumber: self.ValidateFieldsStep3.CardNumber,
            TotalPrice: self.TotalPrice
        };
        var json = ko.toJS(obj);
        $.post(options.orderAdd, json, function (returnedData) {
            window.vm.CartViewModel.GetAll();
        });
    };

}