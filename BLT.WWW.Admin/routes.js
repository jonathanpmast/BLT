var signals = require('signals');
var crossroads = require('crossroads');

var router = function () {
    function onRouteChanged(newUrl) {
        crossroads.parse(newUrl);
    };


    function init() {
        crossroads.routed.add(function (data) {
            console.log(data);
        });

        crossroads.addRoute('/test1');
        crossroads.addRoute('/test2');
        crossroads.addRoute('/test3');

        window.addEventListener("popstate", onRouteChanged, false);
    }
};

module.exports = router;