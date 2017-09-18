angular.module("FeedApp", ["ngRoute"]);

angular.module("FeedApp").config(function($routeProvider) {
    $routeProvider
        .when("/",
        {
            controller: "articleController",
            templateUrl: "Partials/articles.html"
        });

    $routeProvider.otherwise({ redirectTo: "/" });
});