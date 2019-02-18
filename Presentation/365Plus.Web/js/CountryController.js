﻿SiteApp.controller("CountryController", function ($scope, $http) {
    //alert('hi country');
    $scope.IsDefaultLanguage = 0;
    $scope.IsNationalLanguage = 0;
    $scope.CountryObj = { Id: 0, LanguageId: 0, Id: "", Name: "", NationalLanguage: 0, OtherLanguages: [], CountryLanguages:[]};

    function refreshcountryGridData() {
		//debugger;

        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetAllCountries",
            success: function (data) {
				//debugger;
                countryGrid.clear();
                countryGrid.rows.add(data).draw();
            },
            error: function (jqXHR, exception) {

            }
        });
    }

    var countryGrid = $('#Countrytable').DataTable({
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
                { title: "Name", "data": "Name", "width": "296px" },
				{ title: "National Language", "data": "NationalLanguageName", "width": "296px" },
				{
					title: "Other Languages", "data": "OtherLanguages",
					"render": function (data, type, row, meta) {
						return (_.map(data, "LanguageName")).join(",");
					},
					"width": "296px"
				},
                { title: " ", "width": "10px" },
                { title: " ", "width": "10px" }
            ],
        "sorting": false
    });

    countryGrid.on('click', 'button.edit', function () {
        

        var countryGrid = $('#Countrytable').DataTable();
        var data = countryGrid.row($(this).parents('tr')).data();


        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetCountryByID",
            data: { Id: data.Id },
            success: function (response) {
               //
                $scope.winCountry.center().open();
                $scope.$apply(function () {
                    $scope.CountryObj = response;
                    var nationalLanguage = _.find(response.OtherLanguages, ["IsNationalLanguage", true]);
					$scope.CountryObj.OtherLanguages = _.map(_.filter(response.OtherLanguages, ["IsNationalLanguage", false]), "Id");
                    $scope.CountryObj.NationalLanguage = nationalLanguage ? nationalLanguage.LanguageId : 0;
                });
            },
            error: function (jqXHR, exception) {

               
            }
        });
    });

    refreshcountryGridData();

    $scope.Languagedata = new kendo.data.DataSource({

        transport: {
            read: {
                type: "GET",
                url: "/Admin/GetAllLanguages",
                dataType: "json",
                contentType: "application/json; charset=utf-8"

            }
        },
        error: function (e) {
            console.log(e.status); // displays "error"
        }

    });

	$scope.onAddCountryClick = function (e) {
		$scope.winCountry.center().open();
	};

	$scope.onCancel = function () {
		clearForm();
		$scope.winCountry.close();
	};

	$scope.saveCountryData = function (event) {

		event.preventDefault();

		if ($scope.validator.validate()) {
			var url = "/Admin/AddCountry";
			if ($scope.CountryObj.Id > 0)
				url = "/Admin/UpdateCountry";

			$scope.CountryObj.CountryLanguages.push({
				LanguageId: $scope.CountryObj.NationalLanguage,
				IsNationalLanguage: true,
				IsDefaultLanguage: true
			});

			_.forEach($scope.CountryObj.OtherLanguages, function (languageID) {
				$scope.CountryObj.CountryLanguages.push({
					LanguageId: languageID,
					IsNationalLanguage: false,
					IsDefaultLanguage: false
				});
			})

			$.ajax({
				dataType: "json",
				type: 'POST',
				url: url,
				data: { country: $scope.CountryObj },
				success: function (response) {

					clearForm();
					$scope.winCountry.close();
					refreshcountryGridData();
				},
				error: function (jqXHR, exception) {

					alert("error");
				}
			});
		}
	};

    function clearForm() {
        $scope.CountryObj = { Id: 0, LanguageId: 0, Id: "", Name: "", NationalLanguage: 0, OtherLanguages: [] };

    }
});