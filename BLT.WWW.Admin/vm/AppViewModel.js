var ko = require('knockout');
var navVM = require('./NavViewModel.js');
var postal = require('postal');
function AppViewModel() {
    var self = this;
    this.CurrentViewModel = ko.observable({});
    this.CurrentTemplate = ko.observable('empty');
    this.NavViewModel = ko.observable(new navVM());

    var routeChangedSub = postal.subscribe({
        channel: "navigation",
        topic: "changed",
        callback: function routeChanged(data) {
            //self.CurrentTemplate('empty');
            //self.C
            self.CurrentViewModel(data.viewModel);
            self.CurrentTemplate(data.template);
        }
    });

}

module.exports = AppViewModel;