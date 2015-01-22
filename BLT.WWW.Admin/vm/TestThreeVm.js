var ko = require('knockout');

function TestThreeVm() {
    this.Message = ko.observable("Test Three VM!");
};

module.exports = TestThreeVm;