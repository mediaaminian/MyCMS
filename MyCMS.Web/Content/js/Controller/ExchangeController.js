app.controller('ExchangeController', ["$scope", "serviceBaseAngular", "$compile", "$timeout", "$rootScope", function ($scope, serviceBaseAngular, $compile, timer, $rootScope) {

    $scope.CurrencyList = [];
    $scope.FromCurrency = "";
    $scope.ToCurrency = "";
    $scope.ChangedCurrency = 0;
    $scope.InputCurrency = 1;
    $scope.formatCurrency = function (number, unitName) {
        var n = number.toString().split('').reverse().join("");
        var n2 = n.replace(/\d\d\d(?!$)/g, "$&،");
        return n2.split('').reverse().join('') + ' ' + unitName;
    }
    $scope.GetCurrency = function () {
        SuccessMessage = function (result) {
            $scope.CurrencyList = result;
            if (result != null && result.length > 0) {
                $scope.ToCurrency = result[0];
                $scope.FromCurrency = result[0];
            }
        }
        ErrorMessage = function () {
        }
        var url = "/Currency/GetAllCurrencies"
        serviceBaseAngular.AjaxCall(url, null, SuccessMessage, ErrorMessage);
    }
    $scope.GetCurrency();
    $scope.Exchange = function () {
        var hasError = false;
        if ($scope.FromCurrency == "") { $('#FromCurrency').addClass('error'); hasError = true; } else {$('#FromCurrency').removeClass('error');}
        if ($scope.ToCurrency == "") { $('#ToCurrency').addClass('error'); hasError = true; } else { $('#ToCurrency').removeClass('error'); }
        if ($scope.InputCurrency == "") { $('#InputCurrency').addClass('error'); hasError = true; } else { $('#InputCurrency').removeClass('error'); }
        if (hasError) return;
      var from=  $scope.FromCurrency;
      var to = $scope.ToCurrency;
      var unit = from.Price / to.Price;
      $scope.ChangedCurrency = isNaN(Math.round($scope.InputCurrency * unit * 100))? "غیر قابل محاسبه": $scope.formatCurrency(Math.round($scope.InputCurrency * unit * 100) / 100, to.Title);
    }
}]);
