using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Services;
using Domain;
using Newtonsoft.Json.Linq;

namespace DAL.Repositories
{
    public class ArticleRepository
    {
        private readonly DataContext _dataContext;
        private readonly ArticleService _articleService;

        public ArticleRepository()
        {
            _dataContext = new DataContext();
            _articleService = new ArticleService();
        }

        public List<Article> All => _dataContext.Articles;

        public Article GetById(int id)
        {
            return _dataContext.Articles.Find(x => x.ArticleId == id);
        }

        public JObject GetByIdViaMercury(int id)
        {
            var article = GetById(id);
            return article == null ? null : _articleService.GetArticleViaMercury(article.Link);
        }
    }
}
