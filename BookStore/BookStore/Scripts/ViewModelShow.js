var ViewModelShow = function (options) {

    var self = this;

    self.Model = new BaseModel();

    self.AllBooks = function (data) {
        $.ajax({
            type: 'GET',
            url: options.urlGet,
            success: onAjaxSuccess
        });
    }
    function onAjaxSuccess(data) {
        if (data.length != 0)
            self.Model.arr().length = 0;;
        for (var i = 0; i < data.length; i++) {
            self.Model.arr.push(data[i]);
        }
    };

    self.AllBooks();
}