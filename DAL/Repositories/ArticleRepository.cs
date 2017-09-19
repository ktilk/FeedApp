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
        private readonly DataContext _dc = new DataContext();

        public List<Article> All => _dc.Articles;

        public Article GetById(int id)
        {
            return _dc.Articles.Find(x => x.ArticleId == id);
        }
    }
}
