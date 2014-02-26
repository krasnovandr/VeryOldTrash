var calcModel = {
    current: 0,
    dataInMem: "",
    ev: EventMixin,

    MS: function () {
        var inf = { "current": this.current }
        var context = this;
        $.ajax({
            type: 'POST',
            url: '/api/values/PostMS',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MS POST Recieved: " + data);
            context.dataInMem = "M";
            context.ev.trigger('modelChanged');
        }

    },

    MC: function () {

        var inf = { "current": 0 }
        var context = this;
        $.ajax({
            type: 'POST',
            url: '/api/values/PostMC',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MC POST Recieved" + data);
            context.dataInMem = "";
            context.ev.trigger('modelChanged');
        }

    },

    MR: function () {
        var context = this;
        $.ajax({
            type: 'GET',
            url: '/api/values/GetMR',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MR GET" + data);
            context.current = data;
            console.log(context.current);
            context.ev.trigger('modelChanged');
        }

    },

    Mplus: function () {
        var inf = { "current": this.current }
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
            context.current = data;
            console.log(context.current);
            context.ev.trigger('modelChanged');
        }
    },

    C: function () {
        this.current = 0;
        //console.log(context.current);
        this.ev.trigger('modelChanged');
    },

    Mminus: function () {
        var inf = { "current": this.current }
        var context = this;
        $.ajax({
            type: 'POST',
            url: '/api/values/PostMinus',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("Mminus POST" + data);
            context.current = data;
            console.log(context.current);
            context.ev.trigger('modelChanged');
        }
    }
}

