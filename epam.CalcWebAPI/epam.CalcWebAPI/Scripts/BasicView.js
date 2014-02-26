var BasicView = {
    run: function () {
        for (var e in this.events) {
            var reg = /\s/;
            var eventName = e.split(reg)[0];
            var selector = e.split(reg)[1];
            var handler = this[this.events[e]];
            $('#Container').on(eventName, selector, handler.bind(this));
        }
        this.subscribe();
        this.render();
    },
};

var View = _.extend(BasicView, {
    model: calcModel,

    events: {
        "click .digit": "onDigitClick",
        "click .operator": "onOperatorClick"
    },


    render: function () {

        this.baseContainer = $('#Container');
        var templateHtml = $('#calculatorTemplate').html();
        var calculatorHtml = _.template(templateHtml, this.model);
        this.baseContainer.html(calculatorHtml);

    },

    subscribe: function () {
        var model = this['model'];
        var handler = this['update'];
        model.ev.on('modelChanged', handler, this);
    },
    update: function () {
        this.render();
    },

    onDigitClick: function (e) {

        var pushedDigit = e.target.innerHTML;
        var model = this.model;
        model.current = parseInt(model.current + '' + pushedDigit);
        console.log(model.current);

        this.render();
    },

    onOperatorClick: function (e) {

        var pushedButton = e.target.innerHTML;
        var model = this.model;

        if (pushedButton == 'MR') {
            model.MR();
        }
        if (pushedButton == 'MS') {
            model.MS();
            model.C();
        }
        if (pushedButton == 'M+') {
            model.Mplus();
            model.C();
        }
        if (pushedButton == 'MC') {
            model.MC();
        }
        if (pushedButton == 'M-') {
            model.Mminus();
            model.C();
        }
        if (pushedButton == 'C') {
            model.C();
        }
    }
});