﻿angular.module("FeedApp").factory("articleService", articleService);

function articleService($http) {
    var service = {
        getArticles: getArticles,
        getArticleById: getArticleById
    };
    return service;

    function getArticles() {
        console.log("getArticles from service");
        var resp = $http.get(articlesApiUri);
        return resp;
    }

    function getArticleById(id) {
        var resp = $http.get(articlesApiUri + id);
        return resp;
    }
}