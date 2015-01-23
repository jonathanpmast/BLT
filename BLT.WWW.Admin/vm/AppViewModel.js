var ko = require('knockout');
var navVM = require('./NavViewModel.js');

function AppViewModel() {
    this.CurrentViewModel = ko.observable({});
    this.CurrentTemplate = ko.observable('empty');
    this.NavViewModel = ko.observable(new navVM());
}

module.exports = AppViewModel;