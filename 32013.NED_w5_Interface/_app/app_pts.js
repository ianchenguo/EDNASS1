// JavaScript Document
(function () {
	//app.subject main subject of App
	angular.module('ptsApp.subject', ['ui.router', 'ptsApp.services', 'ptsApp.controllers', 'ptsApp.directives']);
	//ptsApp.services main services of ptsApp
	angular.module('ptsApp.services', []);
	//ptsApp.directives main directives of ptsApp
	angular.module('ptsApp.directives', ['ptsApp.services']);
	//ptsApp.controllers main controllers of ptsApp
	angular.module('ptsApp.controllers', ['ptsApp.services']);
})();