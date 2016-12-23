using SparkServer.Data;
using SparkServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository<Article>
    {
        public Article Get(int ID)
        {
            return new Article();
        }

        public IQueryable<Article> Get(Func<Article, bool> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            throw new NotImplementedException();
        }

        public IEnumerable<Article> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create()
        {
            return 0;
        }

        public int Create(Article newArticle)
        {
            throw new NotImplementedException();
        }

        public void Update(Article updateArticle)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {

        }
    }
}
