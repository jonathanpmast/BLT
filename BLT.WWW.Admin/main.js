var ko = require('knockout');
var templateEngine = require('./koTemplateEngine.js');
var appvm = require('./vm/AppViewModel.js');
var koTemplates = require('./ko_templates.js');

templateEngine(ko);
koTemplates(ko)
var vm = new appvm();
ko.applyBindings(vm);