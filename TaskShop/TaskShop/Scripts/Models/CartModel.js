var CartModel = function () {

    var self = this;

    self.GoodsId = ko.observable('');
    self.GoodsCategory = ko.observable('');

    self.Price = ko.observable('');

    self.arr = ko.observableArray([]);


};

var CartViewModel = function () {
    var self = this;



    self.CartModel = new CartModel();

    //self.totalItems = ko.computed(function () {
    //    return self.CartModel.arr.length;
    //}, self);
    self.totalItems = ko.observable(0);

    self.totalPrice = ko.computed(function () {
        var sum = 0;
        for (var i = 0; i < self.CartModel.arr().length; i++)
            sum += parseInt(self.CartModel.arr()[i].Price);
        return sum;
    }, self);



    self.GetAll = function () {
        $.ajax({
            type: 'GET',
            url: "/Cart/Get",
            success: onGetSuccess
        });
    };
    function onGetSuccess(data) {
        self.CartModel.arr(data);
        self.totalItems(self.CartModel.arr().length);
    }

    self.Delete = function (data) {
        var item = data.Id;
        $.ajax({
            type: 'GET',
            url: "/Cart/Delete" + "/"+item,
            success: onDeleteSuccses
        });
    };
    function onDeleteSuccses(data) {
        if (data)self.GetAll();
    }



};