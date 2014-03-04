var ViewModelShow = function () {

    var self = this;
    self.arr = ko.observableArray([]);



    self.subscribe = function () {
        var handler = self.AllBooks;
        setInterval(handler, 1000);

    };

    self.AllBooks = function (data) {
        if (window.flg == true) {
            $.ajax({
                type: 'GET',
                url: '/Home/GetBooks',
                success: onAjaxSuccess
            });
        }
        function onAjaxSuccess(data) {
            if (data.length != 0)
                self.arr().length = 0;;
            for (var i = 0; i < data.length; i++) {
                self.arr.push(data[i]);
            }
            window.flg = false;
        }
    };
}