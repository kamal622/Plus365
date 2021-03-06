﻿SiteApp.controller("AdvisorController", function ($scope, $http) {
    //alert('hi advisor');
    $scope.AdvisorObj = { Id: 0, CountryId: 0, LanguageId: 0 ,FirstName: "", LastName: "", PersonalEmail: "", MobileNo: "", username: "", Password: "" };

    $scope.Countrydata = new kendo.data.DataSource({

        transport: {
            read: {
                type: "GET",
                url: "/Admin/GetAllCountries",
                dataType: "json",
                contentType: "application/json; charset=utf-8"

            }
        },
        error: function (e) {
            console.log(e.status); // displays "error"
        }

    });

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
    var dataset = [{
        "FirstName": "Ruju",
        "LastName": "Desai",
        "PersonalEmail": "ruju@gmail.com",
        "MobileNo": "0987654321",
        "Username": "Ruju",
        "Password": "ruju@123"
    }, {
        "FirstName": "abc",
        "LastName": "123",
        "PersonalEmail": "abc@gmail.com",
        "MobileNo": "22222222",
        "Username": "abcabc",
        "Password": "abc123"
    }, {
        "FirstName": "xyz",
        "LastName": "456",
        "PersonalEmail": "xyz@gmail.com",
        "MobileNo": "343454546",
        "Username": "xyzxyz",
        "Password": "xyz123"
    }];
    var advisor = $('#advisor').DataTable({
        "data": dataset,
        "paging": false,
        "bSort": false,
        "bInfo": false, // hide Showing 1 of N entries
        "columnDefs": [
            {
                "targets": 6,
                "data": null,
                "width": "50px",
                "defaultContent":
                    "<button  class='btn btn-sm'><i class='glyphicon glyphicon-edit'></i></button>"
            },
            {
                "targets": 7,
                "data": null,
                "width": "50px",
                "defaultContent":
                    "<button  class='btn btn-sm'><i class='glyphicon glyphicon-trash'></i></button>"
            }
        ],
        "columns":
            [
                { title: "FirstName", "data": "FirstName", "width": "138px"  },
                { title: "LastName", "data": "LastName", "width": "138px"  },
                { title: "PersonalEmail", "data": "PersonalEmail", "width": "140px"  },
                { title: "MobileNo", "data": "MobileNo", "width": "137px"  },
                { title: "Username", "data": "Username", "width": "138px"  },
                { title: "Password", "data": "Password", "width": "137px"  },
                { title: " ", "width": "12px" },
                { title: " ", "width": "12px" }
            ],
        "sorting": false,
        "dom": '<"toolbar advisor">frtip'
    });

	$scope.onAddAdvisorClick = function (e) {
		$scope.winAdvisor.center().open();
	};
	$scope.onCancel = function () {
		window.location.replace('/Admin/Advisor');
	};

	$scope.saveAdvisorData = function (event) {
		event.preventDefault();

		var url = $scope.AdvisorObj.Id == 0 ? '/Admin/AddAdvisor' : '/Admin/AddAdvisor';
		if ($scope.validator.validate()) {


			$.ajax({
				dataType: "json",
				type: 'POST',
				url: url,
				data: { advisor: $scope.AdvisorObj },
				success: function (response) {

					alert("success");
					window.location.replace('/Admin/Advisor');
				},
				error: function (jqXHR, exception) {


				}
			});
		} else {

			$scope.validationMessage = "Oops! There is invalid data in the form.";
			$scope.validationClass = "invalid";
		}
	};

});