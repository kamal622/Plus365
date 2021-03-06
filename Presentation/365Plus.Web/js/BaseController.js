﻿//"kendo.directives"
var SiteApp = angular.module("SiteApp", ["kendo.directives"]).factory('$exceptionHandler', function () {
	return function (exception, cause) {
		exception.message += ' (caused by "' + cause + '")';
		throw exception;
	};
});


/*********************************      BASE CONTROLLER START          ******************************************/
SiteApp.controller("BaseController", function ($scope, $http) {
    //alert('hi');

    //$('#btnTemp').kendoButton();

    var showProgress = function () {
        $.blockUI({
            css: {
                border: 'none',
                padding: '15px',
                backgroundColor: '#000',
                '-webkit-border-radius': '10px',
                '-moz-border-radius': '10px',
                opacity: .5,
                color: '#fff',
                baseZ: 9999
            }
        });
    };

    $(document).ajaxStart(function () {
        showProgress();
    }).ajaxStop($.unblockUI);
});