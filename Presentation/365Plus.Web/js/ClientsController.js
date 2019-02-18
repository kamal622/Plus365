SiteApp.controller("ClientsController", function ($scope, $http) {
    
    //$scope.ClientObj = { Id: 0, Title: "", Status: "", IsActive: 0 };
    //$scope.Title = [];
    //$scope.Status = [];
    //$scope.IsActive = [];
    $scope.userSubscriptionList = [];
   

    function refreshClientsGridData() {
     // debugger;

        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetAllClients",
            success: function (data) {
                //debugger;
                ClientsGrid.clear();
                ClientsGrid.rows.add(data).draw();
            },
            error: function (jqXHR, exception) {
                //debugger; 
            }
        });
    }

    var ClientsGrid = $('#clientsTable').DataTable({
        "data": [],
        "paging": false,
        "bSort": false,
        "bInfo": false,
        "columnDefs": [
            {
                "targets":6,
                "data": null,
                //"width": "170px",
                "defaultContent":
                    '<button class="k-primary k-button subscribe" ng-click="onAddCountryClick()">Subscription</button>'
            }
        ],
        "columns":
            [
                { title: "First Name", "data": "FirstName", "width": "118px" },
                { title: "Email", "data": "PersonalEmail", "width": "120px" },
                { title: "User Name", "data": "UserName", "width": "118px" },
                { title: "Country", "data": "CountryName", "width": "120px" },
                { title: "Language", "data": "LanguageName", "width": "118px" },
                { title: "Referral Code", "data": "UserName", "width": "118px" },
                { title: "", "data": "", "width": "10px" }
            ],
        "sorting": false,
        "dom": '<"toolbar Clients">frtip'
    });

    refreshClientsGridData();


    //create getstaus 
    ClientsGrid.on('click', 'button.subscribe', function () {
        var data = ClientsGrid.row($(this).parents('tr')).data();
        //debugger;
        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetSubscriptionStatus",
            data: { userId: data.Id },
            success: function (data) {
               
                //debugger;
                $scope.$apply(function () {
                    $scope.userSubscriptionList = data.Data;
                    $scope.PersonalEmail = data.User.PersonalEmail;
                    $scope.UserName = data.User.UserName;
                    $scope.winClient.center().open();
                });
            },
            error: function (jqXHR, exception) {
               // debugger;
            }
        });
    });

	$scope.onCancel = function () {
		clearForm();
		$scope.winClient.close();
	};

	$scope.saveSubscriptionData = function (event) {

		event.preventDefault();

		if ($scope.validator.validate()) {
			var url = "/Admin/UpdateClientSubscriptionStatus";
			//debugger;

			$.ajax({
				dataType: "json",
				type: 'POST',
				url: url,
				data: { subscriptions: $scope.userSubscriptionList },
				success: function (response) {
					//debugger;
					clearForm();
					$scope.winClient.close();
					refreshClientsGridData();
				},
				error: function (jqXHR, exception) {
					// debugger;
					//alert("error");
				}
			});
		}
	};

    function clearForm() {
        $scope.ClientObj = { Id: 0, Title: "", Status: "", IsActive: 0 };
    }

    $scope.personalInfoForm = [];
    $scope.submitForm = function () {
        $scope.personalInfoForm.push({
            'FirstName': $scope.fName,
            'LastName': $scope.lName,
            'Age': $scope.age,
            'HighestQualification': $scope.hQualification,
            'InstituteName': $scope.instituteName
        });
        $scope.fName = '';
        $scope.lName = '';
        $scope.age = '';
        $scope.hQualification = '';
        $scope.instituteName = '';
    };
   

});