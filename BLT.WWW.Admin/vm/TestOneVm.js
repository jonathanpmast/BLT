var ko = require('knockout');

function TestOneVm() {
    this.Message = ko.observable("Test One VM!");
};

module.exports = TestOneVm;