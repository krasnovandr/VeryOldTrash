var CalculatorModel = function () {

    var self = this;

    self.commands = ko.observableArray([
    { command: 'MR' },
    { command: 'MS' },
    { command: 'M+' },
    { command: 'M-' },
    { command: 'MC' },
    { command: 'C' }

    ]);
    self.numbers = ko.observableArray([
    { val: 1 },
    { val: 2 },
    { val: 3 },
    { val: 4 },
    { val: 5 },
    { val: 6 },
    { val: 7 },
    { val: 8 },
    { val: 9 },
    { val: 0 },
    ]);
    self.current = ko.observable('');
    self.dataInMem = ko.observable('');

    self.addNumber = function (data) {
        var oldValue = self.current();
        var newValue = parseInt(oldValue + '' + data.val); 
        self.current(newValue);
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
        var inf = { "current": self.current() }
        $.ajax({
            type: 'POST',
            url: '/api/values/PostMS',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MS POST Recieved: " + data);
            self.current(data);
            self.dataInMem("M");
        }
    };


    self.McFunction = function () {
        var inf = { "current": 0 }
        $.ajax({
            type: 'POST',
            url: '/api/values/PostMC',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MC POST Recieved" + data);
            self.dataInMem("");
            self.current(data);
        }

    };

    self.MrFunction = function () {
        $.ajax({
            type: 'GET',
            url: '/api/values/GetMR',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MR GET" + data);
            self.current(data);
        }

    };

    self.MplusFunction = function () {
        var inf = { "current": self.current() }
        var context = this;
        $.ajax({
            type: 'POST',
            url: '/api/values/PostMplus',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("Mplus POST" + data);
            self.current(data);
        }
    };

    self.ClearFunction = function () {
        self.current('');
    };

    self.MminusFunction = function () {
        var inf = { "current": self.current() }
        $.ajax({
            type: 'POST',
            url: '/api/values/PostMinus',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("Mminus POST" + data);
            self.current(data);
        }
    };

}


