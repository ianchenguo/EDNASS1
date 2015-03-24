// JavaScript Document
(function () {
	var uiM = angular.module('ptsApp.subject');

	uiM.config(['$stateProvider', '$urlRouterProvider', function ($stateProvider, $urlRouterProvider) {
		$urlRouterProvider.otherwise('/#');
		$stateProvider.state('login', {
			url: '/',
			templateUrl: './partial_32013/login.html',
			controller: 'loginCtrl'
		}).
		state('SR', {
			url: '/sr',
			templateUrl: './partial_32013/sr.html',
			controller: 'srCtrl'
		}).
		state('SR.send', {
			url: '/send',
			templateUrl: './partial_32013/send.html',
			controller: 'sendCtrl'
		}).
		state('receive', {
			url: '/receive',
			templateUrl: './partial_32013/receive.html',
			controller: 'receiveCtrl'
		}).
		state('distrb', {
			url: '/distrb',
			templateUrl: './partial_32013/distrb.html',
			controller: 'distrbCtrl'
		}).
		state('audit', {
			url: '/audit',
			templateUrl: './partial_32013/audit.html',
			controller: 'auditCtrl'
		}).
		state('rp', {
			url: '/rp',
			templateUrl: './partial_32013/report.html',
			controller: 'rpCtrl'
		});
	}]);
})();