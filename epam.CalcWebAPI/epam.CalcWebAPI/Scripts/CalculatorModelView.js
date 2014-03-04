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

   

}


