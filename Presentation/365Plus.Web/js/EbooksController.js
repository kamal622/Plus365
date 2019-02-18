SiteApp.controller("EbooksController", function ($scope, $http) {
    $scope.EbookObj = { Id: 0,Title: "", Price: ""};

    function refreshEbookGridData() {
        
        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetAllEbooks",
            success: function (data) {
               // debugger;
                ebookgrid.clear();
                ebookgrid.rows.add(data).draw();
            },
            error: function (jqXHR, exception) {
              //  debugger; 
            }
        });
    }

    var ebookgrid = $('#ebooksTable').DataTable({
        "data": [],
        "paging": false,
        "bSort": false,
        "bInfo": false,
        "bFilter": false,
        "columnDefs": [
            {
                "targets": 2,
                "data": null,
                "width": "70px",
                "defaultContent":
                    "<button  class='btn btn-sm edit'><i class='glyphicon glyphicon-pencil'></i></button>"
            }
        ],
        "columns":
            [
                { title: "Ebooks", "data": "Title", "width": "195px" },
                { title: "Price", "data": "Price", "width": "195px" },
                { title: " ", "width": "10px" }
               
            ],
        "sorting": false,
        "dom": '<"toolbar Ebooks">frtip'
    });

    refreshEbookGridData();

    ebookgrid.on('click', 'button.edit', function () {
        
        var ebookgrid = $('#ebooksTable').DataTable();
        var data = ebookgrid.row($(this).parents('tr')).data();

        $.ajax({
            dataType: "json",
            type: 'GET',
            url: "/Admin/GetEbooksByID",
            data: { Id: data.Id },
            success: function (response) {
                

                $scope.winEbooks.center().open();
                $scope.$apply(function () {
                    $scope.EbookObj = response;
                });
            },
            error: function (jqXHR, exception) {
                
            }
        });
    });

    $scope.onAddEbookClick = function () {
        $scope.winEbooks.center().open();
    };

    $scope.saveEbookData = function (event) {
        
        event.preventDefault();
        if ($scope.validator.validate()) {
            
            var url = "/Admin/AddEbook";
            if ($scope.EbookObj.Id > 0)
                url = "/Admin/UpdateEbook";

            $.ajax({
                dataType: "json",
                type: 'POST',
                url: url,
                data: { ebook: $scope.EbookObj },
                success: function (response) {
                    
                    clearForm();
                    $scope.winEbooks.close();
                    refreshEbookGridData();
                },
                error: function (jqXHR, exception) {
                    
                }
            });
        }
    };

    $scope.onCancel = function () {
        clearForm();
        $scope.winEbooks.close();
    };

    function clearForm() {
        $scope.EbookObj = { Id: 0, Title: "", Price: "" };
    }
       
});