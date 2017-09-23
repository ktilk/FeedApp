using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using DAL.Services;
using Domain;
using HtmlAgilityPack;

namespace DAL
{
    public class DataContext
    {
        private readonly ArticleService _articleFactory;
        public List<Article> Articles { get; set; }

        public DataContext()
        {
            _articleFactory = new ArticleService();
            Articles = new List<Article>();
            GetArticlesFromFeed();
        }

        public void GetArticlesFromFeed()
        {
            const string feedUri = "https://flipboard.com/@raimoseero/feed-nii8kd0sz?rss";
            var reader = XmlReader.Create(feedUri);
            var feed = SyndicationFeed.Load(reader);
            foreach (var syndicationItem in feed.Items)
            {
                var articleId = 0;
                if (Articles.Count != 0)
                {
                    articleId = Articles.OrderByDescending(x => x.ArticleId).FirstOrDefault().ArticleId++;
                }
                var article = _articleFactory.CreateArticle(syndicationItem,
                    articleId);
                Articles.Add(article);
            }
        }
    }
}
