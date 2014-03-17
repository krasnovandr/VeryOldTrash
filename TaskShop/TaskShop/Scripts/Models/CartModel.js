var CartModel = function () {

    var self = this;

    self.GoodsId = ko.observable('');
    self.GoodsCategory = ko.observable('');

    self.Price = ko.observable('');
    self.Count = ko.observable('');

    self.arr = ko.observableArray([]);


};

var CartViewModel = function (options) {
    var self = this;



    self.CartModel = new CartModel();


    self.totalItems = ko.observable(0);
    self.totalPrice = ko.observable(0);

    self.checkoutReady = ko.computed(function () {
        if (self.CartModel.arr()) {
            if (self.CartModel.arr().length != 0)
            return true;
        }
          return false;
    });

    self.GetAll = function () {
        $.ajax({
            type: 'GET',
            url: options.cartGet,
            success: onGetSuccess
        });
    };
    function onGetSuccess(data) {
        self.CartModel.arr(data);
        var count = 0;
        var price = 0;

        if (data)
            for (var i = 0; i < self.CartModel.arr().length; i++) {
                count += parseInt(self.CartModel.arr()[i].Count);
                if (self.CartModel.arr()[i].Count == 1) {
                    price += parseInt(self.CartModel.arr()[i].Price);
                }
                else {
                    for (var j = 0; j < self.CartModel.arr()[i].Count; j++)
                        price += parseInt(self.CartModel.arr()[i].Price);

                }

            }

        self.totalItems(count);
        self.totalPrice(price);
        window.vm.WizardModel.OrderModel.TotalCount(count);
        window.vm.WizardModel.OrderModel.TotalGoodsPrice(price);
    }

    self.Delete = function (data) {
        var json = ko.toJS(data);
        $.post(options.cartDelete, json, function () {
            self.GetAll();
        });
    };
};