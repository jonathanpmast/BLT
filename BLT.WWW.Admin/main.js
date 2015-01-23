var ko = require('knockout');
var templateEngine = require('./koTemplateEngine.js');
var appvm = require('./vm/AppViewModel.js');
var koTemplates = require('./ko_templates.js');
var routes = require('./routes.js');

var router = new routes();
templateEngine(ko);
koTemplates(ko)
router.init();

var vm = new appvm();
ko.applyBindings(vm);