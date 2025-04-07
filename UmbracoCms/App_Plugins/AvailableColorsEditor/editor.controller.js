(function () {
  'use strict';

  angular
    .module('umbraco')
    .controller('AvailableColorsEditorController', AvailableColorsEditorController);

  AvailableColorsEditorController.$inject = ['$scope'];

  function AvailableColorsEditorController($scope) {
    var vm = this;

    // Initialize the model
    vm.model = $scope.model;

    // Add a new color object (name, hex)
    vm.addColor = function () {
      if (!vm.model.value) {
        vm.model.value = [];
      }
      vm.model.value.push({
        name: '',
        hex: '#000000' // Default to black
      });
    };

    // Remove a color from the list
    vm.removeColor = function (index) {
      vm.model.value.splice(index, 1);
    };
  }
})();
