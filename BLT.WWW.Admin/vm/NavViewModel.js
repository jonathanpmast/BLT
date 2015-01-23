var ko = require('knockout');
var postal = require('postal');
function NavViewModel() {
    this.navLinks = ko.observableArray([
        { title: "Test 1", url: '/test1' },
        { title: "Test 2", url: '/test2' },
        { title: "Test 3", url: '/test3' }
    ]);

    this.go = function (link) {
        
        postal.publish({
            channel: "navigation",
            topic: "change",
            data: {
                url: link.url
            }
        });
    };
}

module.exports = NavViewModel;