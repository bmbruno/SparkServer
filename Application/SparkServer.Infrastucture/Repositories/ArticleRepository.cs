using SparkServer.Data;
using SparkServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;
using System.Data.Entity;

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

        public IEnumerable<Article> Get(Expression<Func<Article, bool>> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            List<Article> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Article.Include(u => u.Category).Include(u => u.SitecoreVersion).Include(u => u.Author).Where(whereClause).ToList();
            }

            return results;
        }

        public IEnumerable<Article> GetAll()
        {
            List<Article> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Article.Include(u => u.Category).Include(u => u.SitecoreVersion).Include(u => u.Author).ToList();
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
                db.Article.Attach(updateItem);

                var entry = db.Entry(updateItem);
                entry.Property(e => e.Title).IsModified = true;
                entry.Property(e => e.Subtitle).IsModified = true;
                entry.Property(e => e.CategoryID).IsModified = true;
                entry.Property(e => e.Body).IsModified = true;
                entry.Property(e => e.SitecoreVersionID).IsModified = true;
                entry.Property(e => e.PublishDate).IsModified = true;
                entry.Property(e => e.AuthorID).IsModified = true;
                entry.Property(e => e.UniqueURL).IsModified = true;
                entry.Property(e => e.SortOrder).IsModified = true;

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

                if (item == null)
                    throw new Exception($"No article found for UniqueURL: {uniqueURL}");

                db.Entry(item).Reference(la => la.Author).Load();
                db.Entry(item).Reference(la => la.SitecoreVersion).Load();
                db.Entry(item).Reference(la => la.Category).Load();
            }

            return item;
        }

        public IEnumerable<Article> GetRecent(int numberToLoad)
        {
            List<Article> blogList = new List<Article>();

            using (var db = new SparkServerEntities())
            {
                blogList = db.Article.Where(u => u.Active)
                                     .Include(a => a.Author)
                                     .Include(b => b.SitecoreVersion)
                                     .Include(c => c.Category)
                                     .OrderByDescending(u => u.PublishDate)
                                     .Take(numberToLoad).ToList();
            }

            return blogList;
        }
    }
}
