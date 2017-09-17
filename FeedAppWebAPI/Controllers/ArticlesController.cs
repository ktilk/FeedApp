using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Repositories;
using Domain;

namespace FeedAppWebAPI.Controllers
{
    public class ArticlesController : ApiController
    {
        private readonly ArticleRepository _repo;

        public ArticlesController()
        {
            _repo = new ArticleRepository();
        }

        public List<Article> GetArticles()
        {
            return _repo.All;
        }

        public Article GetById(int id)
        {
            return _repo.GetById(id);
        }
    }
}
