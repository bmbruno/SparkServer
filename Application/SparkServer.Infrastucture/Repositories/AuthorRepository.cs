using SparkServer.Data;
using SparkServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository<Author>
    {
        public Author Get(int ID)
        {
            Author item;

            using (var db = new SparkServerEntities())
            {
                item = db.Author.FirstOrDefault(u => u.ID == ID);
            }

            return item;
        }

        public IQueryable<Author> Get(Func<Author, bool> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            IQueryable<Author> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Author.Where(whereClause).AsQueryable();
            }

            return results;
        }

        public IEnumerable<Author> GetAll()
        {
            IEnumerable<Author> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Author;
            }

            return results;
        }

        public int Create(Author newItem)
        {
            using (var db = new SparkServerEntities())
            {
                db.Author.Add(newItem);
                db.SaveChanges();
            }

            return newItem.ID;
        }

        public void Update(Author updateItem)
        {
            using (var db = new SparkServerEntities())
            {
                Author toUpdate = db.Author.FirstOrDefault(u => u.ID == updateItem.ID);

                if (toUpdate == null)
                    throw new Exception($"Could not find Author with ID of {updateItem.ID}");

                toUpdate = updateItem;
                db.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var db = new SparkServerEntities())
            {
                Author toDelete = db.Author.FirstOrDefault(u => u.ID == ID);

                if (toDelete == null)
                    throw new Exception($"Could not find Author with ID of {ID}");

                toDelete.Active = false;

                db.SaveChanges();
            }
        }
    }
}
