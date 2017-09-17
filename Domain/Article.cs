using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Article
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public DateTime PublishDate { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
    }
}
