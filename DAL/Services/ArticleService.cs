using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Domain;
using Newtonsoft.Json.Linq;

namespace DAL.Services
{
    public class ArticleService
    {
        /// <summary>
        /// Creates an article from SyndicationItem data.
        /// </summary>
        /// <param name="item"></param>
        /// <param name="itemId"></param>
        /// <returns></returns>
        public Article CreateArticle(SyndicationItem item, int itemId)
        {
            var article = new Article();
            var author = item.Authors.FirstOrDefault();
            if (author != null)
                article.Author = author.Email;
            var category = item.Categories.FirstOrDefault();
            if (category != null)
                article.Category = category.Name;
            article.Description = StripHtml(item.Summary.Text);
            var link = item.Links.FirstOrDefault();
            if (link != null)
                article.Link = link.Uri.AbsoluteUri;
            article.PublishDate = item.PublishDate.DateTime;
            article.Title = item.Title.Text;
            article.ArticleId = itemId;

            return article;
        }

        /// <summary>
        /// Returns JSON of an article fetched via Mercury Web Parser API
        /// </summary>
        /// <param name="articleUrl"></param>
        /// <returns></returns>
        public JObject GetArticleViaMercury(string articleUrl)
        {
            var request = (HttpWebRequest)WebRequest.Create("https://mercury.postlight.com/parser?url=" + articleUrl);
            request.Method = "Get";
            request.ContentType = "appication/json";
            request.Headers.Add("x-api-key", "drj0lrkvHoW8NUYhP7zR4YGvzLpF5rIhEGfZdjJd");

            var response = (HttpWebResponse)request.GetResponse();
            var myResponse = "";
            using (var sr = new System.IO.StreamReader(response.GetResponseStream()))
            {
                myResponse = sr.ReadToEnd();
            }
            return JObject.Parse(myResponse);
        }

        private string StripHtml(string html)
        {
            var stripped = WebUtility.HtmlDecode(html);
            stripped = Regex.Replace(Regex.Replace(stripped, "<.*?>", " "), " {2,}", " "); //replace html tags and remove whitespace
            return stripped;
        }
    }
}
