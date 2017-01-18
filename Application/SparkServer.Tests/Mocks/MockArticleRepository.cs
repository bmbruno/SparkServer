using SparkServer.Data;
using SparkServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace SparkServer.Infrastructure.Repositories
{
    public class MockArticleRepository : IArticleRepository<Article>
    {
        public Article Get (string uniqueURL)
        {
            return Get(2);
        }

        public Article Get(int ID)
        {
            Article item;

            item = new Article();
            item.ID = ID;
            item.PublishDate = new DateTime(year: 2016, month: 1, day: 6);
            item.Title = "Test Article Title";
            item.Body = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>";
            item.AuthorID = 1;

            item.Active = true;
            item.CreateDate = new DateTime(year: 2016, month: 1, day: 5);

            return item;
        }

        public IEnumerable<Article> Get(Expression<Func<Article, bool>> whereClause)
        {
            List<Article> testList = new List<Article>();

            testList.Add(new Article());
            testList.Add(new Article());
            testList.Add(new Article());

            return testList.AsEnumerable<Article>();
        }

        public IEnumerable<Article> GetAll()
        {
            List<Article> testList = new List<Article>();

            testList.Add(new Article());
            testList.Add(new Article());
            testList.Add(new Article());

            return testList.AsEnumerable<Article>();
        }

        public int Create(Article newBlog)
        {
            return 1;
        }

        public void Update(Article updateItem)
        {
            return;
        }

        public void Delete(int ID)
        {
            return;
        }
    }
}
