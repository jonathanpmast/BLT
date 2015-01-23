var director = require('director');
var postal = require('postal');
var vmm = require('./vm/ViewModelManager.js');
var router = function () {
    var dRouter;
    var routeChangeSub
    function navigateTo(url) {
        //todo: listen to postal message and when navigation event fires... do stuff.
        if (!dRouter)
            throw "router not initialized.  :(";
        dRouter.setRoute(url);
    };

    function debug() {
        console.log(this.getRoute());
    }

    function routeChange() {
        // get vm, push it to the channel
        var route = this.getRoute().join('/');
        var vm = vmm.get(route);
        postal.publish({
            channel: "navigation",
            topic: "changed",
            data: {
                template: route,
                viewModel: vm
            }
        });
    }

    this.init = function _init() {
        var routes = {
            '/test1': routeChange,
            '/test2': routeChange,
            '/test3': routeChange
        };
        dRouter = new director.Router(routes);
        dRouter.configure({

            html5history: false
        });

        routeChangeSub = postal.subscribe({
            channel: "navigation",
            topic: "change",
            callback: function routeChangeCallback(data) {
                navigateTo(data.url);
            }
        });

        dRouter.init();
    }
};

module.exports = router;