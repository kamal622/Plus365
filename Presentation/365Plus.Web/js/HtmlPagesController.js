SiteApp.controller("HtmlPagesController", function ($scope, $http) {
 // alert(' html');

	// Replace the <textarea id="editor1"> with a CKEditor
	// instance, using default configuration.
	var ckEditor = CKEDITOR.replace('editor1');
	CKEDITOR.config.uiColor = '#e1f3f4';

	// Set Data...
	ckEditor.setData("");

	$scope.HtmlObj = { Id: 0, Name: 0, Path: "", HTMLPageId:0, HTMLContent: "", LanguageId: 0};

	$scope.OnChangeLanguage = function (e) {
		
		refreshHtmlPagesGridData();
	};

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

   
    function refreshHtmlPagesGridData() {
        //

        $.ajax({
            dataType: "json",
            type: 'GET',
			url: "/Admin/GetAllHtmlPages",
			data: { languageId: $scope.HtmlObj.LanguageId },
            success: function (data) {
               // 
                HtmlPagesGrid.clear();
				HtmlPagesGrid.rows.add(data).draw();



            },
            error: function (jqXHR, exception) {

               // 
            }
        });
    }

    var HtmlPagesGrid = $('#HtmlPagesTable').DataTable({
        "data": [],
        "paging": false,
        "bSort": false,
        "bInfo": false, // hide Showing 1 of N entries
        "bFilter": false,
        "columnDefs": [
            {
                "targets": 1,
                "data": null,
                "width": "50px",
                "defaultContent":
                    "<button  class='btn btn-sm edit'><i class='glyphicon glyphicon-pencil'></i></button>"
            },
            {
                "targets": 2,
                "data": null,
                "width": "50px",
                "defaultContent":
                    "<button  class='btn btn-sm delete'><i class='glyphicon glyphicon-trash'></i></button>"
            }
        ],
        "columns":
            [
                { title: "Name", "data": "Name", "width": "950px" },
                //{ title: "Path", "data": "Path", "width": "248px" },
                //{ title: "Content", "data": "HTMLContent", "width": "248px" },
                { title: " ", "width": "10px" },
                { title: " ", "width": "10px" }
            ],
        "sorting": false,
        "dom": '<"toolbar HtmlPages">frtip'
    });

    HtmlPagesGrid.on('click', 'button.edit', function () {
        

        var HtmlPagesGrid = $('#HtmlPagesTable').DataTable();
        var data = HtmlPagesGrid.row($(this).parents('tr')).data();

        
        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetHtmlPageById",
            data: { Id: data.Id },
            success: function (response) {
                
                $scope.winHtmlPages.center().open();
                $scope.$apply(function () {
					$scope.HtmlObj = response;
					ckEditor.setData($scope.HtmlObj.HTMLContent);
                });
            },
            error: function (jqXHR, exception) {

                
            }
        });
    });

	refreshHtmlPagesGridData();

	$scope.onAddHtmlPageClick = function (e) {
		$scope.winHtmlPages.center().open();
	};

    $scope.SaveHtmlPageData = function (event) {
        
		event.preventDefault();
		if ($scope.validator.validate()) {
			var url = "/Admin/AddHtmlPages";
			if ($scope.HtmlObj.Id > 0)
                url = "/Admin/UpdateHtmlPages";
            
            $scope.HtmlObj.HTMLContent = ckEditor.getData();
			$.ajax({
				dataType: "json",
				type: 'POST',
				url: url,
                data: { hTMLPage: $scope.HtmlObj },
				success: function (response) {
					
                    clearForm();
                    $scope.winHtmlPages.close();
                    refreshHtmlPagesGridData();
				},
				error: function (jqXHR, exception) {
					
					//alert("error");
				}
			});
		}
	};

	$scope.onCancel = function () {
		clearForm();
		$scope.winHtmlPages.close();
	};

    function clearForm() {
		$scope.HtmlObj.Id = 0;
		$scope.HtmlObj.Name= "";
		$scope.HtmlObj.Path ="";
		$scope.HtmlObj.HTMLPageId = 0;
		$scope.HtmlObj.HTMLContent= "";
	};
});
