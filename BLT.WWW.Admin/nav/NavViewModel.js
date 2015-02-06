var ko = require('knockout');
var postal = require('postal');
function NavViewModel() {
    var curActive;
    this.navLinks = ko.observableArray([
        { title: "Upload Loot Wheel (KSK)", url: '/upload_ksk', active: false },
        { title: "Test 2", url: '/test2', action: false },
        { title: "Test 3", url: '/test3', active: false }
    ]);

    this.go = function (link) {
        if (!curActive) {
            curActive = link;
            link.active = true;
        }
        else {
            curActive.active = false;
            curActive = link;
            link.active = true;
        }
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