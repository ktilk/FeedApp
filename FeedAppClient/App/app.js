angular.module("FeedApp", ["ngRoute", "ngSanitize"]);

angular.module("FeedApp").config(function($routeProvider) {
    $routeProvider
        .when("/",
        {
            templateUrl: "Partials/articles.html"
        })
        .when("/article/:id",
        {
            templateUrl: "Partials/popupArticle.html"
        });

    $routeProvider.otherwise({ redirectTo: "/" });
});