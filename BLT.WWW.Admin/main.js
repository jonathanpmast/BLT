var ko = require('knockout');
var templateEngine = require('./koTemplateEngine.js');
var appvm = require('./AppViewModel.js');
var koTemplates = require('./ko_templates.js');
var router = require('./routes.js');
router = new router();
var vmm = require('./vm/ViewModelManager.js');

vmm.register('test1', require('./vm/TestOneVm.js'));
vmm.register('test2', require('./vm/TestTwoVm.js'));
vmm.register('test3', require('./vm/TestThreeVm.js'));

templateEngine(ko);
koTemplates(ko)
router.init();

var vm = new appvm();
ko.applyBindings(vm);