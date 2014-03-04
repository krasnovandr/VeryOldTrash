var EventsFactory = {

    on: function (eventName, handler, context) {
        if (!this._eventHandlers) {
            this._eventHandlers = [];
        }
        if (!this._eventHandlers[eventName]) {
            this._eventHandlers[eventName] = [];
        }
        this._eventHandlers[eventName].push({ handler: handler, context: context });
    },


    off: function (eventName, handler) {
        var handlers = this._eventHandlers[eventName];
        if (!handlers) return;
        for (var i = 0; i < handlers.length; i++) {
            if (handlers[i] == handler) {
                handlers.splice(i--, 1);
            }
        }
    },

    trigger: function (eventName, context) {

        if (!this._eventHandlers[eventName]) {
            return;
        }

        var handlers = this._eventHandlers[eventName];
        for (var i = 0; i < handlers.length; i++) {
            handlers[i].handler.apply(handlers[i].context);
        }

    }
}
