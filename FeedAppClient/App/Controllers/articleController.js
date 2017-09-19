angular.module("FeedApp").controller("articleController", articleController);

function articleController($routeParams, articleService) {
    var vm = this;
    vm.title = "Articles";
    vm.articles = [];
    vm.popupArticle = popupArticle;
    vm.article = {};

    var articleId = $routeParams.id;

    init();

    function init() {
        if (articleId) {
            getArticleById(articleId);
        } else {
            getArticles();
        }
    }

    function getArticles() {
        articleService.getArticles().then(function (resp) {
            console.log("getArticles from controller");
            vm.articles = resp.data;
        });
    }

    function getArticleById(id) {
        articleService.getArticleById(id).then(function(resp) {
            vm.article = resp.data;
        });
    }

    function popupArticle(id) {
        window.open("/#!/article/" + id);
    }
}