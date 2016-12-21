using SparkServer.Core.Repositories;
using SparkServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparkServer.Infrastructure.Entities;

namespace SparkServer.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository<BlogArticle>
    {
        public BlogArticle Get(int ID)
        {
            return new BlogArticle();
        }

        public IQueryable<BlogArticle> Get(Func<BlogArticle, bool> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            throw new NotImplementedException();
        }

        public IEnumerable<BlogArticle> GetAll()
        {
            throw new NotImplementedException();
        }

        public int Create()
        {
            return 0;
        }

        public int Create(BlogArticle newArticle)
        {
            throw new NotImplementedException();
        }

        public void Delete(int ID)
        {

        }
    }
}
