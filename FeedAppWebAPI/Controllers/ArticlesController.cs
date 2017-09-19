using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DAL.Repositories;
using Domain;
using Newtonsoft.Json.Linq;

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

        public JObject GetByIdViaMercury(int id)
        {
            var articleUrl = _repo.GetById(id).Link;
            var request = (HttpWebRequest)WebRequest.Create("https://mercury.postlight.com/parser?url=" + articleUrl);
            request.Method = "Get";
            request.ContentType = "appication/json";
            request.Headers.Add("x-api-key", "drj0lrkvHoW8NUYhP7zR4YGvzLpF5rIhEGfZdjJd");

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            var myResponse = "";
            using (System.IO.StreamReader sr = new System.IO.StreamReader(response.GetResponseStream()))
            {
                myResponse = sr.ReadToEnd();
            }
            return JObject.Parse(myResponse);
        }
    }
}
