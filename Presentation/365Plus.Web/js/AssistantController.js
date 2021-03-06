﻿SiteApp.controller("AssistantController", function ($scope, $http) {
    //alert('hi Assistant');

    $scope.CountryId = 0; $scope.LanguageId = 0;
    $scope.AssistantObj = { Id: 0, FirstName: "", LastName: "", PersonalEmail: "", MobileNo: "", UserName: "", Password: "" };

    function refreshAssistantGridData() {
         
        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetAllAssistant",
            success: function (data) {
                 
                AssistantGrid.clear();
                AssistantGrid.rows.add(data).draw();
            },
            error: function (jqXHR, exception) {
                
            }
        });
    }

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
   
    var AssistantGrid = $('#assistantTable').DataTable({
        "data": [],
        "paging": false,
        "bSort": false,
        "bInfo": false, // hide Showing 1 of N entries
       
        "columns":
            [
                { title: "First Name", "data": "FirstName" },
                { title: "Last Name", "data": "LastName" },
                { title: "Email", "data": "PersonalEmail", "width": "120px" },
                { title: "Mobile No", "data": "MobileNo", "width": "117px" },
                { title: "User Name", "data": "UserName", "width": "118px" }
            ],
        "sorting": false,
        "dom": '<"toolbar Assistant">frtip'
    });

    AssistantGrid.on('click', 'button.edit', function () {
        // alert('AssistantGrid');
        

        var AssistantGrid = $('#assistantTable').DataTable();
        var data = AssistantGrid.row($(this).parents('tr')).data();

        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetAssistantByID",
            data: { Id: data.Id },
            success: function (response) {
                
                $scope.winAssistant.center().open();
                $scope.$apply(function () {
                    $scope.AssistantObj = response;
                });
            },
            error: function (jqXHR, exception) {
                
                 
            }
        });
    });

    refreshAssistantGridData();

	$scope.onAddAssistantClick = function (e) {
		$scope.winAssistant.center().open();
	};

	$scope.onCancel = function () {
		clearForm();
		$scope.winAssistant.close();
	};

    function clearForm() {
        $scope.AssistantObj = { Id: 0, FirstName: "", LastName: "", PersonalEmail: "", MobileNo: "", UserName: "", Password: "" };
    }

	$scope.saveAssistantData = function (event) {
		event.preventDefault();

		//var url = $scope.AssistantObj.Id == 0 ? '/Admin/AddAssistant' : '/Admin/UpdateAssistant';
		if ($scope.validator.validate()) {

			var url = "/Admin/AddAssistant";
			if ($scope.AssistantObj.Id > 0)
				url = "/Admin/UpdateAssistant";

			$.ajax({
				dataType: "json",
				type: 'POST',
				url: url,
				data: { assistant: $scope.AssistantObj },
				success: function (response) {

					clearForm();
					$scope.winAssistant.close();
					refreshAssistantGridData();
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