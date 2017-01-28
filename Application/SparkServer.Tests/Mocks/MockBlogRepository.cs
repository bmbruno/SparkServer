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
    public class MockBlogRepository : IBlogRepository<Blog>
    {
        public Blog Get(int ID)
        {
            Blog item;

            item = new Blog();
            item.ID = 1;
            item.PublishDate = new DateTime(year: 2017, month: 1, day: 5);
            item.Title = "Test Blog Title";
            item.Subtitle = "Test Subtitle";
            item.Body = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>";
            item.AuthorID = 1;

            item.Active = true;
            item.CreateDate = new DateTime(year: 2017, month: 1, day: 2);

            return item;
        }

        public IEnumerable<Blog> Get(Expression<Func<Blog, bool>> whereClause)
        {
            List<Blog> testList = new List<Blog>();

            testList.Add(new Blog());
            testList.Add(new Blog());
            testList.Add(new Blog());

            return testList.AsEnumerable<Blog>();
        }

        public IEnumerable<Blog> GetAll()
        {
            List<Blog> testList = new List<Blog>();

            testList.Add(new Blog());
            testList.Add(new Blog());
            testList.Add(new Blog());

            return testList.AsEnumerable<Blog>();
        }

        public int Create(Blog newBlog)
        {
            return 1;
        }

        public void Update(Blog updateItem)
        {
            return;
        }

        public void Delete(int ID)
        {
            return;
        }

        public Blog Get(int year, int month, string uniqueURL)
        {
            Blog item;

            item = new Blog();
            item.ID = 1;
            item.PublishDate = new DateTime(year: 2017, month: 2, day: 2);
            item.Title = "Test Blog Title";
            item.Subtitle = "Test Subtitle";
            item.Body = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>";
            item.AuthorID = 1;

            item.Active = true;
            item.CreateDate = new DateTime(year: 2017, month: 2, day: 1);

            return item;
        }

        public IEnumerable<Blog> GetByDate(int year, int? month)
        {
            return this.GetAll();
        }

        public IEnumerable<Blog> GetRecent(int numberToLoad)
        {
            return new List<Blog>();
        }

        public IEnumerable<Blog> GetByTagID(int tagID)
        {
            return new List<Blog>();
        }
    }
}
