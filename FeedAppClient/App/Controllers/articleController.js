angular.module("FeedApp").controller("articleController", articleController);

function articleController($routeParams, articleService) {
    var vm = this;
    vm.dataLoading = true;
    vm.title = "Articles";
    vm.errorMessage = "";
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
            vm.errorMessage = "";
        }, function(reason) {
            vm.errorMessage = "Failed to retrieve articles. " + reason.statusText;
            if (reason.data.ExceptionMessage) {
                vm.errorMessage = vm.errorMessage + "\n" + reason.data.ExceptionMessage;
            }
        }).finally(function () {
            vm.dataLoading = false;
        });
    }

    function getArticleById(id) {
        articleService.getArticleById(id).then(function(resp) {
            vm.article = resp.data;
            vm.errorMessage = "";
        }, function (reason) {
            vm.errorMessage = "Failed to retrieve article. " + reason.statusText;
            if (reason.data.ExceptionMessage) {
                vm.errorMessage = vm.errorMessage + "\n" + reason.data.ExceptionMessage;
            }
        }).finally(function() {
            vm.dataLoading = false;
        });
    }

    function popupArticle(id) {
        window.open("/#!/article/" + id);
    }
}