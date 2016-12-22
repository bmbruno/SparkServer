using SparkServer.Data;
using SparkServer.Core.Repositories;
using SparkServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository<Blog>
    {
        public Blog Get(int ID)
        {
            Blog blogArticle;

            using (var db = new SparkServerEntities())
            {
                blogArticle = db.Blog.FirstOrDefault(u => u.ID == ID);
            }

            return blogArticle;
        }

        public IQueryable<Blog> Get(Func<Blog, bool> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            IQueryable<Blog> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Blog.Where(whereClause).AsQueryable();
            }

            return results;
        }

        public IEnumerable<Blog> GetAll()
        {
            IEnumerable<Blog> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Blog;
            }

            return results;
        }

        public int Create(Blog newBlog)
        {
            using (var db = new SparkServerEntities())
            {
                db.Blog.Add(newBlog);
                db.SaveChanges();
            }

            return newBlog.ID;
        }

        public void Update(Blog updateBlog)
        {
            using (var db = new SparkServerEntities())
            {
                Blog toUpdate = db.Blog.FirstOrDefault(u => u.ID == updateBlog.ID);

                if (toUpdate == null)
                    throw new Exception($"Could not find Blog with ID of {updateBlog.ID}");

                toUpdate = updateBlog;
                db.Entry(updateBlog).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var db = new SparkServerEntities())
            {
                Blog toDelete = db.Blog.FirstOrDefault(u => u.ID == ID);

                toDelete.Active = false;

                db.SaveChanges();
            }
        }
    }
}
