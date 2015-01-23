
function ViewModelManager() {
	var self = this;
	var _bindings = {};
	this.get = function _get(identifier) {
		if (typeof (_bindings[identifier]) !== 'undefined') {
			if (typeof (_bindings[identifier]['viewModel']) !== 'undefined')
				return _bindings[identifier].viewModel;
			else
				_bindings[identifier].viewModel = new _bindings[identifier].constructor();
		} else
			throw "Viewmodel not found for bindings: " + identifier;
	};

	this.register = function _register(identifier, viewModelConstructor) {
		_bindings[identifier] = {
			constructor: viewModelConstructor
		};
	};

	this.registerMany = function _register(objects) {
		for (var i = 0; i <= objects.length; i++) {
			self.register(objects[i].type, object[i].viewModelConstructor);
		}
	};

	this.remove = function _remove(identifier) {
		if (typeof (_bindings[identifier]) !== 'undefined')
			delete _bindings[indentifier];
	};
}

module.exports = new ViewModelManager();