var calcModel = {
    current: 0,
    ev:EventMixin,

    MS:function(){
        var inf = {"current": this.current}
        $.ajax({
            type: 'POST',
            url: 'http://localhost:63769/api/values/PostMS',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MS POST" + data);
        }

    },

    MC:function(){
        
        var inf = { "current": 0 }

        $.ajax({
            type: 'POST',
            url: 'http://localhost:63769/api/values/PostMC',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MC POST" + data);
        }

    },
    MR: function () {
        var context = this;
        $.ajax({
            type: 'GET',
            url: 'http://localhost:63769/api/values/GetMR',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("MR GET" + data);
            context.current = data;
            console.log(context.current);
            context.ev.trigger('modelChanged',context);
        }

    },

    Mplus: function () {
        var inf = { "current": this.current }
        var context = this;
        $.ajax({
            type: 'POST',
            url: 'http://localhost:63769/api/values/PostMplus',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("Mplus POST" + data);
            context.current = data;
            console.log(context.current);
            context.ev.trigger('modelChanged', context);
        }
    },

    C:function(){
        this.current = 0;
        //console.log(context.current);
        this.ev.trigger('modelChanged', this);
    },

    Mminus: function () {
        var inf = { "current": this.current }
        var context = this;
        $.ajax({
            type: 'POST',
            url: 'http://localhost:63769/api/values/PostMinus',
            data: inf,
            dataType: 'json',
            success: onAjaxSuccess
        });
        function onAjaxSuccess(data) {
            console.log("Mminus POST" + data);
            context.current = data;
            console.log(context.current);
            context.ev.trigger('modelChanged', context);
        }
    }
}

