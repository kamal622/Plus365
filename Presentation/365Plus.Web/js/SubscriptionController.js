﻿SiteApp.controller("SubscriptionController", function ($scope, $http) {

    $scope.Points = "";
    $scope.FirstName = "";
    function getClientsPoints() {
        
        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Subscription/getClientsPoints",
            success: function (data) {
                //debugger;
                $scope.$apply(function () {
                    $scope.Points = data;
                });
              
            },
            error: function (jqXHR, exception) {
                //debugger
            }
        });
    }
    getClientsPoints();

    function getClientsName() {

        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Subscription/getClientsName",
            success: function (data) {
                //debugger;
                $scope.$apply(function () {
                    $scope.FirstName = data;
                });
            },
            error: function (jqXHR, exception) {
                //debugger
            }
        });
    }
    getClientsName();

    function refreshsubscriptionGridData() {

        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Subscription/GetAllEbooks",
            success: function (data) {
               // debugger;
                subscriptiongrid.clear();
                subscriptiongrid.rows.add(data).draw();
            },
            error: function (jqXHR, exception) {
               // debugger
            }
        });
    }

    
    //var dataset = [
    //    {
    //        "Ebooks": "Book1",
    //        "Price": "50$",
    //        "Status": "Active"
    //    }, {
    //        "Ebooks": "Book2",
    //        "Price": "70$",
    //        "Status": "Active"
    //    }];
    var subscriptiongrid = $('#subscriptionTable').DataTable({
        "data": [],
        "paging": false,
        "bSort": false,
        "bInfo": false,
        "bFilter": false,
        "columnDefs": [
            {
                "targets":3,
                "data": null,
                "width": "70px",
                "defaultContent":
                    '<button  class= "k-primary k-button subscribe">Subscribe</button>'
            }
        ],
        "columns":
            [
                { title: "Ebooks", "data": "Title", "width": "195px" },
                { title: "Price", "data": "Price", "width": "195px" },
                { title: "Status", "data": "Status", "width": "225px" },
                { title: " ", "width": "30px" }
            ],
        "sorting": false,
        "dom": '<"toolbar Subscription">frtip'
    });
    refreshsubscriptionGridData();

    subscriptiongrid.on('click', 'button.subscribe', function () {
        alert('subscribe');

    });

});