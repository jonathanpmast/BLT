var director = require('director');
var postal = require('postal');
var router = function () {
    var dRouter;
    var routeChangeSub
    function navigateTo(url) {
        //todo: listen to postal message and when navigation event fires... do stuff.
        if (!dRouter)
            throw "router not initialized.  :(";
        dRouter.setRoute(url);
    };

    function debug(arg1, arg2, arg3) {
        console.log(arg1);
        console.log(arg2);
        console.log(arg3);
    }

    function init() {
        var routes = {
            '/test1': debug,
            '/test2': debug,
            '/test3': debug
        };
        dRouter = new director.Router(routes);
        dRouter.configure({
            on: debug
        });

        routeChangeSub = postal.subscribe({
            channel: "navigation",
            topic: "change",
            callback: function routeChangeCallback(data) {
                alert('worked');
                navigateTo(data.url);
            }
        });

        dRouter.init();
    }
};

module.exports = router;