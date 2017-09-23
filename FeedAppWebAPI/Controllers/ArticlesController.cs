using System;
using System.Collections.Generic;
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

        public IHttpActionResult GetByIdViaMercury(int id)
        {
            var article = _repo.GetByIdViaMercury(id);
            if (article == null)
            {
                return NotFound();
            }
            return Ok(article);
        }
    }
}
