using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace DAL.Repositories
{
    public class ArticleRepository
    {
        private DataContext dc = new DataContext();

        public List<Article> All => dc.Articles;

        public Article GetById(int id)
        {
            return dc.Articles.Find(x => x.ArticleId == id);
        }
    }
}
