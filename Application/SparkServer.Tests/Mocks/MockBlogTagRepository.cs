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
    public class MockBlogTagRepository : IBlogTagRepository<BlogTag>
    {
        public BlogTag Get(int ID)
        {
            BlogTag item;

            item = new BlogTag();
            item.ID = 1;
            item.Name = "Test Tag A";

            item.Active = true;
            item.CreateDate = new DateTime(year: 2017, month: 1, day: 2);

            return item;
        }

        public IEnumerable<BlogTag> Get(Expression<Func<BlogTag, bool>> whereClause)
        {
            List<BlogTag> testList = new List<BlogTag>();

            testList.Add(new BlogTag());
            testList.Add(new BlogTag());
            testList.Add(new BlogTag());

            return testList.AsEnumerable<BlogTag>();
        }

        public IEnumerable<BlogTag> GetAll()
        {
            List<BlogTag> testList = new List<BlogTag>();

            testList.Add(new BlogTag());
            testList.Add(new BlogTag());
            testList.Add(new BlogTag());

            return testList.AsEnumerable<BlogTag>();
        }

        public int Create(BlogTag newBlog)
        {
            return 1;
        }

        public void Update(BlogTag updateItem)
        {
            return;
        }

        public void Delete(int ID)
        {
            return;
        }

        public IEnumerable<BlogTag> GetFromList(IEnumerable<int> list)
        {
            return new List<BlogTag>();
        }

        public void UpdateTagsForBlog(int blogID, IEnumerable<int> updatedList)
        {
            return;
        }
    }
}
