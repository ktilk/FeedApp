angular.module("FeedApp").factory("articleService", articleService);

function articleService($http) {
    var service = {
        getArticles: getArticles,
        getArticleById: getArticleById
        //getArticleViaMercury: getArticleViaMercury
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

    //function getArticleViaMercury(link) {
    //    var url = mercuryApiUrl + link;
    //    var resp = $http({
    //        method: "GET",
    //        url: url,
    //        headers: {
    //            "Content-Type": "application/json",
    //            "x-api-key": mercuryApiKey
    //        }
    //    });
    //    return resp;
    //}
}