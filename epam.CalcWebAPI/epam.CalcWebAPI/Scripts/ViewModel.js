var ViewModel = function (options) {

    var self = this;
    this.Model = new BaseModel();

    self.addNumber = function (data) {
        var oldValue = self.Model.current();

        var newValue = parseInt(oldValue + '' + data.val);
        self.Model.current(newValue);

    };

    self.newCommand = function (data) {
        if (data.command == 'MS') {
            self.MsFunction();
        }
        if (data.command == 'MR') {
            self.MrFunction();
        }
        if (data.command == 'M+') {
            self.MplusFunction();
        }
        if (data.command == 'M-') {
            self.MminusFunction();
        }
        if (data.command == 'MC') {
            self.McFunction();
        }
        if (data.command == 'C') {
            self.ClearFunction();
        }

    };

    self.MsFunction = function () {
        var inf = { "current": self.Model.current() }
        $.ajax({
            type: 'POST',
            url: options.urlMS,
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MS POST Recieved: " + data);
            self.Model.current(data);
            self.Model.dataInMem("M");
        }
    };


    self.McFunction = function () {
        var inf = { "current": 0 };
        $.ajax({
            type: 'POST',
            url: options.urlMC,
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MC POST Recieved" + data);
            self.Model.dataInMem("");
            self.Model.current(data);
        }

    };

    self.MrFunction = function () {
        $.ajax({
            type: 'GET',
            url: options.urlMR,
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MR GET" + data);
            self.Model.current(data);
        }

    };

    self.MplusFunction = function () {
        var inf = { "current": self.Model.current() };
   
        $.ajax({
            type: 'POST',
            url: options.urlMplus,
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("Mplus POST" + data);
            self.Model.current(data);
        }
    };

    self.ClearFunction = function () {
        self.Model.current('');
    };

    self.MminusFunction = function () {
        var inf = { "current": self.Model.current() };
        $.ajax({
            type: 'POST',
            url: options.urlMinus,
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("Mminus POST" + data);
            self.Model.current(data);
        }
    };

}