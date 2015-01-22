// contains all of the knockout template files.  This is automatically built during the build process
// you shouldn't edit any of the data between the begin and end template comments below.
//var ko = require('knockout');

module.exports = function (ko) {
    //-begin template injection

    ko.templates["test1"] = '<p class=\x22active\x22>This is an example template for test 1</p>';

    ko.templates["test2"] = '<p>This is an example template Test 2.</p>';

    ko.templates["test3"] = '<p>This is an example template.  Test 3</p>';

    //-end template injection
}