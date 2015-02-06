var ko = require('knockout');
var navVM = require('./nav/NavViewModel.js');
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
            
            self.CurrentViewModel(data.viewModel);
            self.CurrentTemplate(data.template);
        }
    });

}

module.exports = AppViewModel;