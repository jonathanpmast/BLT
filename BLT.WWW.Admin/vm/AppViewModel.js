var ko = require('knockout');
var signals = require('signals');

function AppViewModel() {
    this.CurrentViewModel = ko.observable(null);
    this.CurrentTemplate = ko.observable('');
    
}

module.exports = AppViewModel;