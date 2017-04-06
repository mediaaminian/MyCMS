app.controller('DuctyCurrencyCalculatorController', ["$scope", "serviceBaseAngular", "$compile", "$timeout", "$rootScope", function ($scope, serviceBaseAngular, $compile, timer, $rootScope) {

    $scope.CurrencyList = [];
    $scope.PartCurrency = "";
    $scope.TransferCurrency = "";
    $scope.SourcePercent = 4;
    $scope.VatPercent = 9;
    $scope.ResultCalculation = 0;
    $scope.PartCost = 1;
    $scope.TransferCost = 1;
    $scope.CustomSourceCost = 1;
    $scope.VATCost = 1;
    $scope.formatCurrency = function (number, unitName) {
        var n = number.split('').reverse().join("");
        var n2 = n.replace(/\d\d\d(?!$)/g, "$&،");
        return n2.split('').reverse().join('') + ' ' + unitName;
    }
    $scope.GetCurrency = function () {
        SuccessMessage = function (result) {
            $scope.CurrencyList = result;
        }
        ErrorMessage = function () {
        }
        var url = "/Currency/GetAllCurrencies"
        serviceBaseAngular.AjaxCall(url, null, SuccessMessage, ErrorMessage);
    }
    $scope.GetCurrency();
    $scope.DuctyCurrencyCalculator = function () {
        var partCurrency = $scope.PartCurrency;
        var transferCurrency = $scope.TransferCurrency;

        var InsurancePart = Math.round(((partCurrency.Price * $scope.PartCost) + (transferCurrency.Price * $scope.TransferCost)) * 5 / 1000);
        var SeifPart = (partCurrency.Price * $scope.PartCost) + (transferCurrency.Price * $scope.TransferCost) + InsurancePart;

        $scope.CustomSourceCost = Math.round((SeifPart * $scope.SourcePercent) / 100);
        $scope.VATCost = Math.round(((SeifPart + $scope.CustomSourceCost) * $scope.VatPercent) / 100);

        $scope.ResultCalculation = $scope.formatCurrency(Math.round($scope.CustomSourceCost + $scope.VATCost),"");
        $('html, body').animate({
            scrollTop: $("#divDutyCalculator").offset().top - 20
        }, 2000);
    }
}]);
