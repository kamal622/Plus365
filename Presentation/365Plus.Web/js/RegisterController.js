SiteApp.controller("RegisterController", function ($scope, $http) {

    $scope.CodeType = "Google";

    $scope.CountryId = 0; $scope.LanguageId = 0;
    $scope.RegisterObj = { Id: 0, FirstName: "", PersonalEmail: "", UserName: "", Password: "", confirmPassword:"", ReferralCode: "", PromotionCode: "" };

    

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

    function RegisterClient() {
        var url = "/Home/RegisterClient";

       // debugger;
        $.ajax({
            dataType: "json",
            type: 'POST',
            url: url,
            data: { client: $scope.RegisterObj },
            success: function (response) {
               // debugger;
                window.location.replace('/Home/Index');
            },
            error: function (jqXHR, exception) {
               // debugger;
            }
        });
    }

	$scope.RegisterClientData = function (event) {
		event.preventDefault();
		//debugger;
		if ($scope.validator.validate()) {
			var url = "";
			var code = "";
			if ($scope.CodeType == 'referral') {
				url = "/Home/ValidateReferralCode";
				code = $scope.RegisterObj.ReferralCode;
			}
			else if ($scope.CodeType == 'promo') {
				url = "/Home/ValidatePromoCode";
				code = $scope.RegisterObj.PromotionCode;
			}
			if (url) {
				$.ajax({
					dataType: "json",
					type: 'GET',
					url: url,
					data: { code: code },
					success: function (response) {
						// debugger;
						var a = response.validate;
						// RegisterClient();
					},
					error: function (jqXHR, exception) {
						// debugger;
					}
				});
			}
		} else {

			$scope.validationMessage = "Oops! There is invalid data in the form.";
			$scope.validationClass = "invalid";
		}
	};

	$scope.onCancel = function () {
		window.location.replace('/Home/Register');
	};

	$scope.OnChangeCodetype = function (e) {

		$scope.RegisterObj.PromotionCode = "";
		$scope.RegisterObj.ReferralCode = "";
	};

 
});