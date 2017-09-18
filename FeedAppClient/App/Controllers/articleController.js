angular.module("FeedApp").controller("articleController", articleController);

function articleController($routeParams, articleService){
    var vm = this;
    vm.title = "Articles";
    vm.articles = [];

    init();

    function init() {
        getArticles();
    }

    function getArticles() {
        console.log("getArticles from controller");
        articleService.getArticles().then(function(resp) {
            vm.articles = resp.data;
        });
    }
}