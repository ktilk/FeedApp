using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Domain;

namespace DAL
{
    public class DataContext
    {
        public List<Article> Articles { get; set; }

        public DataContext()
        {
            Articles = new List<Article>();
            GetArticlesFromFeed();
        }


        //TODO see meetod eraldi serviceisse tõsta
        public void GetArticlesFromFeed()
        {
            const string feedUri = "https://flipboard.com/@raimoseero/feed-nii8kd0sz?rss";
            var reader = XmlReader.Create(feedUri);
            //var reader = new XmlTextReader(feedUri);
            var feed = SyndicationFeed.Load(reader);
            foreach (var syndicationItem in feed.Items)
            {
                var article = new Article();
                var author = syndicationItem.Authors.FirstOrDefault();
                if (author != null)
                    article.Author = author.Email;
                var category = syndicationItem.Categories.FirstOrDefault();
                if (category != null)
                    article.Category = category.Name;
                article.Description = syndicationItem.Summary.Text;
                var link = syndicationItem.Links.FirstOrDefault();
                if (link != null)
                    article.Link = link.Uri.AbsoluteUri;
                article.PublishDate = syndicationItem.PublishDate.DateTime;
                article.Title = syndicationItem.Title.Text;
                article.ArticleId = Articles.Count == 0
                    ? 0
                    : Articles.OrderByDescending(x => x.ArticleId).FirstOrDefault().ArticleId++;
                Articles.Add(article);
            }
        }
    }
}
