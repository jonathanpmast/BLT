var ko = require('knockout');

function TestTwoVm() {
    this.Message = ko.observable("Test Two VM!");
};

module.exports = TestTwoVm;