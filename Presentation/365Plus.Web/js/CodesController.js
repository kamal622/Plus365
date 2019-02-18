SiteApp.controller("CodesController", function ($scope, $http) {
	//alert('hi code');

	$scope.IsDefaultLanguage = 0;
	$scope.IsNationalLanguage = 0;
	$scope.CodesObj = { Id: 0, Code: "", Type: "Promotion", Points: "", IsActive: false };

	function refreshcodesGridData() {
		$.ajax({
			dataType: "json",
			type: 'GET',
			url: "/Admin/GetAllCodes",
			success: function (data) {
				codesGrid.clear();
				codesGrid.rows.add(data).draw();
			},
			error: function (jqXHR, exception) {
			}
		});
	}

	var codesGrid = $('#Codestable').DataTable({
		"data": [],
		"paging": false,
		"bSort": false,
		"bInfo": false, // hide Showing 1 of N entries
		"bFilter": false,
		"columnDefs": [
			{
				"targets": 4,
				"data": null,
				"width": "70px",
				"defaultContent":
					"<button  class='btn btn-sm edit'><i class='glyphicon glyphicon-pencil'></i></button>"
			},
			{
				"targets": 5,
				"data": null,
				"width": "70px",
				"defaultContent":
					"<button  class='btn btn-sm delete'><i class='glyphicon glyphicon-trash'></i></button>"
			}
		],
		"columns":
			[
				{ title: "Code", "data": "CodeValue", "width": "296px" },
				{ title: "Type", "data": "Type", "width": "296px" },
				{ title: "Points", "data": "Points", "width": "296px" },
				{ title: "IsActive", "data": "IsActive", "width": "296px" },
				{ title: " ", "width": "10px" },
				{ title: " ", "width": "10px" }
			],
		"sorting": false
	});

	$scope.Codedata = [
		{ Name: "Promotion", Id: "Promotion" },
		{ Name: "Referral", Id: "Referral" }];

	$scope.Type = 1;

	$scope.testBT = function () {
		//debugger;
	var value = $("#color").val();
	};

	codesGrid.on('click', 'button.edit', function () {
		//debugger;
		var codesGrid = $('#Codestable').DataTable();
		var data = codesGrid.row($(this).parents('tr')).data();
		$.ajax({
			dataType: "json",
			type: 'GET',
			url: "/Admin/GetCodesByID",
			data: { Id: data.Id },
			success: function (response) {
				//debugger;			
				clearForm();
				$scope.$apply(function () {
					$scope.CodesObj = response;
					$scope.winCodes.center().open();
					//debugger;
				});
			},
			error: function (jqXHR, exception) {
				//debugger;
			}
		});
	});

	refreshcodesGridData();

	$scope.onAddCodesClick = function (e) {
		//debugger;
		
		$scope.winCodes.center().open();	
		
	};

	$scope.onCancel = function () {
		clearForm();
		$scope.winCodes.close();
	};

	$scope.saveCodesData = function (event) {
		//debugger;
		event.preventDefault();

		if ($scope.validator.validate()) {
			var url = "/Admin/AddCodes";
			if ($scope.CodesObj.Id > 0)
				url = "/Admin/UpdateCodes";
			$.ajax({
				dataType: "json",
				type: 'POST',
				url: url,
				data: { code: $scope.CodesObj },
				success: function (response) {

					clearForm();
					$scope.winCodes.close();
					refreshcodesGridData();
				},
				error: function (jqXHR, exception) {

					alert("error");
				}
			});
		}
	};

	function clearForm() {
		$scope.CodesObj = { Id: 0, Code: "", Type: "Promotion", Points: "", IsActive: false};
	}

});