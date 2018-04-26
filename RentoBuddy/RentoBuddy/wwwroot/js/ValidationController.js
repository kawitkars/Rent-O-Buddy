var myApp = angular.module('ngApp', []);

myApp.controller('ValidationController', function ($scope) {

    //$scope.products = [
    //    { name: "Milk", price: "5", quantity: "0", tax: "" },
    //    { name: "Bread", price: "2", quantity: "0", tax: "" },
    //    { name: "Eggs", price: "5", quantity: "0", tax: "" },
    //    { name: "Cookies", price: "10", quantity: "0", tax: "" },
    //    { name: "Mayo", price: "8", quantity: "0", tax: "" },
    //    { name: "Butter", price: "10", quantity: "0", tax: "" },
    //    { name: "Cereal", price: "6", quantity: "0", tax: "" },
    //    { name: "Honey", price: "7", quantity: "0", tax: "" },
    //    { name: "Sauce", price: "10", quantity: "0", tax: "" }
    //];


    //$scope.removeItem = function (index) {
    //    $scope.products.splice(index, 1);
    //},

    //    $scope.total = function () {
    //        var total = 0;
    //        angular.forEach($scope.products, function (item) {
    //            total += item.quantity * item.price;
    //        })

    //        return total;
    //    }

    //$scope.taxApplied = 0;
    //$scope.totalAmount = 0;
    //$scope.discount = 0;
    //$scope.discountPercent = 0;

    //$scope.addToCart = function () {

    //    var total = $scope.total();
    //    var discountPer = $scope.discountPercent;
    //    $scope.taxApplied = 0.0625 * (total - (discountPer * total));
    //    $scope.discount = discountPer * total;
    //    $scope.totalAmount = 0.0625 * (total - (discountPer * total)) + (total - (discountPer * total));
    //}


    //$scope.applyDiscount = function (value) {
    //    if (value == "DISCOUNT5") {
    //        $scope.discountPercent = 0.05;
    //        alert("Discount of 5% was applied successfully");
    //        $scope.addToCart();
    //    }
    //    else if (value == "DISCOUNT10") {
    //        $scope.discountPercent = 0.10;
    //        alert("Discount of 10% was applied successfully");
    //        $scope.addToCart();
    //    }
    //    else if (value == "DISCOUNT15") {
    //        $scope.discountPercent = 0.15;
    //        alert("Discount of 15% was applied successfully");
    //        $scope.addToCart();
    //    }
    //    else if (value == "DISCOUNT20") {
    //        $scope.discountPercent = 0.20;
    //        alert("Discount of 20% was applied successfully");
    //        $scope.addToCart();
    //    }
    //    else {
    //        $scope.discountPercent = 0;
    //        alert("The entered Promo code is invalid");
    //    }



    //};

    //$scope.placeOrder = function () {
    //    if ($scope.totalAmount > 0) {
    //        alert("Order was successfully placed");
    //    }
    //    else {
    //        alert("Sorry! Order cannot be placed as the Cart is empty. Please add items to the cart");
    //    }
    //}

    $scope.sa = {};
    $scope.ba = {};

    $scope.update = function (sa) {
        $scope.ba = angular.copy($scope.sa);
    };



    //$scope.addItem = function () {
    //    $scope.invoice.items.push({
    //        qty: 1,
    //        description: '',
    //        cost: 0
    //    });
    //},


    //    $scope.remove = function (index) {
    //        $scope.cartData.splice(index, 1);
    //    }

    //$scope.add = function () {
    //    var newItem = {
    //        'name': $scope.item,
    //        'quantity': $scope.quantity,
    //        'price': $scope.price
    //    };






    //}
});