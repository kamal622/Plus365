﻿SiteApp.controller("LanguageController", function ($scope, $http) {
    //alert('hi language');

    $scope.Languageobj = { Id: 0, Name: "", Culture: ""};

    function refreshlanguageGridData() {
        //
      
        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetAllLanguages",
            success: function (data) {
                //
                languageGrid.clear();
                languageGrid.rows.add(data).draw();
            },
            error: function (jqXHR, exception) {

                //
            }
        });

       
    }

    var languageGrid = $('#Languagetable').DataTable({
        "data": [],
        "paging": false,
        "bSort": false,
        "bInfo": false, // hide Showing 1 of N entries
        "bFilter": false,
        "columnDefs": [
            {
                "targets": 3,
                "data": null,
                "width": "70px",
                "defaultContent":
                    "<button  class='btn btn-sm edit'><i class='glyphicon glyphicon-pencil'></i></button>"
            },
            {
                "targets": 4,
                "data": null,
                "width": "70px",
                "defaultContent":
                    "<button  class='btn btn-sm delete'><i class='glyphicon glyphicon-trash'></i></button>"
            }
        ],
        "columns":
            [
                { title: "Name", "data": "Name", "width": "486px" },
                { title: "Culture", "data": "Culture", "width": "486px" },
                { title: "Active?", "data": "IsActive", "width": "50px" },
                { title: " ", "width": "10px" },
                { title: " ", "width": "10px" }
            ],
        "sorting": false,
        "dom": '<"toolbar Language">frtip'
    });

    languageGrid.on('click', 'button.edit', function () {
        //alert('language');
       // 

        var languageGrid = $('#Languagetable').DataTable();
        var data = languageGrid.row($(this).parents('tr')).data();


        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetLanguageById",
            data: { Id: data.Id },
            success: function (response) {
                //
                clearForm();
                $scope.winLanguage.center().open();
                $scope.$apply(function () {
                    $scope.Languageobj = response;
                });
            },
            error: function (jqXHR, exception) {

                //
            }
        });
    });

    refreshlanguageGridData();

	$scope.onAddLanguageClick = function (e) {
		$scope.winLanguage.center().open();
	};

	$scope.onCancel = function () {
		clearForm();
		$scope.winLanguage.close();
	};

    function clearForm() {
        $scope.Languageobj = { Id: 0, Name: "", Culture: "" };
    }

	$scope.saveLanguageData = function (event) {

		event.preventDefault();
		if ($scope.validator.validate()) {

			var url = "/Admin/AddLanguage";
			if ($scope.Languageobj.Id > 0)
				url = "/Admin/UpdateLanguage";

			$.ajax({
				dataType: "json",
				type: 'POST',
				url: url,
				data: { language: $scope.Languageobj },
				success: function (response) {

					clearForm();
					$scope.winLanguage.close();
					refreshlanguageGridData();
				},
				error: function (jqXHR, exception) {

					//alert("error");
				}
			});
		}
	};

});



