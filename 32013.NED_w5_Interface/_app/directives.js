// JavaScript Document
(function () {
	var dircM = angular.module('ptsApp.directives');
	dircM.directive('fixedTitleCharity', [function(){
		
		return {
			// name: '',
			// priority: 1,
			// terminal: true,
			scope: true, // {} = isolate, true = child, false/undefined = no change
			/*controller: function($scope, $element, $attrs, $transclude) {
				console.log("directive_Scope"+$scope);
			},*/
			// require: 'ngModel', // Array = multiple requires, ? = optional, ^ = check parent elements
			// restrict: 'A', // E = Element, A = Attribute, C = Class, M = Comment
			template: '<div><div class="navbar-header"><i class="fa fa-medkit fa-2x"></i>'+
			'</div><div><p>ENET Care <span>Package Tracing</span> System</p>'+
			'</div><div><ul class="nav navbar-nav"><li class=" dropdown">'+
			'<a class="dropdown-toggle" data-toggle = "dropdown" ng-href="#">'+
			'<i class="fa fa-user-md fa-lg"></i> StaffInfo'+
			'<strong class = "caret"></strong></a>'+
			'<ul class="dropdown-menu"><li><a ui-sref="distrb">distribution</a></li>'+
			'<li class="divider"></li><li><a ui-sref="audit">Audit</a></li>'+
			'<li class="divider"></li><li><a ui-sref="rp">Report</a></li>'+
			'</ul></li></ul></div></div>',
			// templateUrl: '',
			replace: true,
			// transclude: true,
			// compile: function(tElement, tAttrs, function transclude(function(scope, cloneLinkingFn){ return function linking(scope, elm, attrs){}})),
			link: function($scope, iElm, iAttrs, controller) {
				
			}
		};
	}]);
	
	dircM.directive('tdBlocks', [function(){
		
		return {
			// name: '',
			// priority: 1,
			// terminal: true,
			scope: {}, // {} = isolate, true = child, false/undefined = no change
			/*controller: function($scope, $element, $attrs, $transclude) {
				console.log("directive_Scope"+$scope);
			},*/
			// require: 'ngModel', // Array = multiple requires, ? = optional, ^ = check parent elements
			restrict: 'A', // E = Element, A = Attribute, C = Class, M = Comment
			template: '<td>&nbsp</td> <td ui-view></td> <td>&nbsp</td>',
			// templateUrl: '',
			// replace: true,
			// transclude: true,
			// compile: function(tElement, tAttrs, function transclude(function(scope, cloneLinkingFn){ return function linking(scope, elm, attrs){}})),
			link: function($scope, iElm, iAttrs, controller) {
				
			}
		};
	}]);

	dircM.directive('srTab', [function(){
		
		return {
			// name: '',
			// priority: 1,
			// terminal: true,
			scope: {}, // {} = isolate, true = child, false/undefined = no change
			/*controller: function($scope, $element, $attrs, $transclude) {
				console.log("directive_Scope"+$scope);
			},*/
			// require: 'ngModel', // Array = multiple requires, ? = optional, ^ = check parent elements
			// restrict: 'A', // E = Element, A = Attribute, C = Class, M = Comment
			template: '<div class="panel panel-default"><div class="panel-heading">'+
			'<h2 class="panel-title">Sending And Receiving</h2>'+
			'</div><div class="panel-body row"><div class="col-md-12">'+
			'<ul class="nav nav-tabs"><li class="active">'+
			'<a data-toggle = "tab" ui-sref=".send">Sending</a>'+
			'</li><li class="pull-right TagReceive">'+
			'<a data-toggle = "tab" ui-sref="receive">Receiving</a>'+
			'</li></ul></div></div></div>',
			// templateUrl: '',
			// replace: true,
			// transclude: true,
			// compile: function(tElement, tAttrs, function transclude(function(scope, cloneLinkingFn){ return function linking(scope, elm, attrs){}})),
			link: function($scope, iElm, iAttrs, controller) {
				
			}
		};
	}]);

	dircM.directive('fixedFooter', [function(){
		
		return {
			// name: '',
			// priority: 1,
			// terminal: true,
			scope: true, // {} = isolate, true = child, false/undefined = no change
			/*controller: function($scope, $element, $attrs, $transclude) {
				console.log("directive_Scope"+$scope);
			},*/
			// require: 'ngModel', // Array = multiple requires, ? = optional, ^ = check parent elements
			// restrict: 'A', // E = Element, A = Attribute, C = Class, M = Comment
			template: '<table><tr><td>Contact us</td>'+
				'<td>Copyright <i class="fa fa-copyright fa-lg"> ENET Care</i>  All Rights Reserved</td>'+
				'<td><i class="fa fa-h-square fa-lg"></i></td></tr></table>',
			// templateUrl: '',
			// replace: true,
			// transclude: true,
			// compile: function(tElement, tAttrs, function transclude(function(scope, cloneLinkingFn){ return function linking(scope, elm, attrs){}})),
			link: function($scope, iElm, iAttrs, controller) {
				
			}
		};
	}]);

})();

