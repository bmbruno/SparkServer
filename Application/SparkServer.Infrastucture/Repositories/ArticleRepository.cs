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
            Article item;

            using (var db = new SparkServerEntities())
            {
                item = db.Article.FirstOrDefault(u => u.ID == ID);


            }

            return item;
        }

        public IEnumerable<Article> Get(Func<Article, bool> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            List<Article> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Article.Where(whereClause).ToList();
            }

            return results;
        }

        public IEnumerable<Article> GetAll()
        {
            List<Article> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Article.ToList();
            }

            return results;
        }

        public int Create(Article newItem)
        {
            using (var db = new SparkServerEntities())
            {
                db.Article.Add(newItem);
                db.SaveChanges();
            }

            return newItem.ID;
        }

        public void Update(Article updateItem)
        {
            using (var db = new SparkServerEntities())
            {
                Article toUpdate = db.Article.FirstOrDefault(u => u.ID == updateItem.ID);

                if (toUpdate == null)
                    throw new Exception($"Could not find Article with ID of {updateItem.ID}");

                toUpdate = updateItem;
                db.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var db = new SparkServerEntities())
            {
                Article toDelete = db.Article.FirstOrDefault(u => u.ID == ID);

                if (toDelete == null)
                    throw new Exception($"Could not find Article with ID of {ID}");

                toDelete.Active = false;

                db.SaveChanges();
            }
        }

        public Article Get(string uniqueURL)
        {
            Article item = null;

            using (var db = new SparkServerEntities())
            {
                item = db.Article.FirstOrDefault(u => u.UniqueURL == uniqueURL);

                db.Entry(item).Reference(la => la.Author).Load();
                db.Entry(item).Reference(la => la.SitecoreVersion).Load();
                db.Entry(item).Reference(la => la.Category).Load();
            }

            return item;
        }
    }
}
