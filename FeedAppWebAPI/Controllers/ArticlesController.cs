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

        /// <summary>
        /// Returns a list of articles
        /// </summary>
        /// <returns></returns>
        public List<Article> GetArticles()
        {
            return _repo.All;
        }

        /// <summary>
        /// Gets an article by ID via Mercury Web Parser API
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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
