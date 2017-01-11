using SparkServer.Data;
using SparkServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Infrastructure.Repositories
{
    public class MockBlogRepository : IBlogRepository<Blog>
    {
        public Blog Get(int ID)
        {
            Blog item;

            item = new Blog();
            item.ID = 1;
            item.PublishDate = new DateTime(year: 2016, month: 12, day: 31);
            item.Title = "Test Blog Title";
            item.Subtitle = "Test Subtitle";
            item.Body = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>";
            item.AuthorID = 1;

            item.Active = true;
            item.CreateDate = new DateTime(year: 2016, month: 12, day: 30);

            return item;
        }

        public IEnumerable<Blog> Get(Func<Blog, bool> whereClause)
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

        public Blog Get(int year, int month, int day, string uniqueURL)
        {
            Blog item;

            item = new Blog();
            item.ID = 1;
            item.PublishDate = new DateTime(year: year, month: month, day: day);
            item.Title = "Test Blog Title";
            item.Subtitle = "Test Subtitle";
            item.Body = "<p>Lorem ipsum dolor sit amet, consectetur adipiscing elit.</p>";
            item.AuthorID = 1;

            item.Active = true;
            item.CreateDate = new DateTime(year: year, month: month, day: day);

            return item;
        }
    }
}
