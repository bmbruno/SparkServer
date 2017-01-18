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
    public class MockAuthorRepository : IAuthorRepository<Author>
    {
        public Author Get(int ID)
        {
            Author item;

            item = new Author();
            item.ID = 1;
            item.FirstName = "FirstName";
            item.LastName = "LastName";

            item.Active = true;
            item.CreateDate = new DateTime(year: 2016, month: 1, day: 5);

            return item;
        }

        public IEnumerable<Author> Get(Expression<Func<Author, bool>> whereClause)
        {
            List<Author> testList = new List<Author>();

            testList.Add(new Author());
            testList.Add(new Author());
            testList.Add(new Author());

            return testList.AsEnumerable<Author>();
        }

        public IEnumerable<Author> GetAll()
        {
            List<Author> testList = new List<Author>();

            testList.Add(new Author());
            testList.Add(new Author());
            testList.Add(new Author());

            return testList.AsEnumerable<Author>();
        }

        public int Create(Author newBlog)
        {
            return 1;
        }

        public void Update(Author updateItem)
        {
            return;
        }

        public void Delete(int ID)
        {
            return;
        }
    }
}
