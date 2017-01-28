﻿using SparkServer.Data;
using SparkServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Linq.Expressions;

namespace SparkServer.Infrastructure.Repositories
{
    public class BlogRepository : IBlogRepository<Blog>
    {
        public Blog Get(int ID)
        {
            Blog item;

            using (var db = new SparkServerEntities())
            {
                item = db.Blog.FirstOrDefault(u => u.ID == ID);
            }

            return item;
        }

        public IEnumerable<Blog> Get(Expression<Func<Blog, bool>> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            List<Blog> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Blog.Where(whereClause).Include(u => u.Author).ToList();
            }

            return results;
        }

        public IEnumerable<Blog> GetAll()
        {
            List<Blog> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Blog.Where(u => u.Active).ToList();
            }

            return results;
        }
        
        public int Create(Blog newItem)
        {
            using (var db = new SparkServerEntities())
            {
                db.Blog.Add(newItem);
                db.SaveChanges();
            }

            return newItem.ID;
        }

        public void Update(Blog updateItem)
        {
            using (var db = new SparkServerEntities())
            {
                Blog toUpdate = db.Blog.FirstOrDefault(u => u.ID == updateItem.ID);

                if (toUpdate == null)
                    throw new Exception($"Could not find Blog with ID of {updateItem.ID}");

                toUpdate = updateItem;
                db.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var db = new SparkServerEntities())
            {
                Blog toDelete = db.Blog.FirstOrDefault(u => u.ID == ID);

                if (toDelete == null)
                    throw new Exception($"Could not find Blog with ID of {ID}");

                toDelete.Active = false;

                db.SaveChanges();
            }
        }

        public Blog Get(int year, int month, string uniqueURL)
        {
            Blog item = null;

            using (var db = new SparkServerEntities())
            {
                item = db.Blog.FirstOrDefault(u => u.UniqueURL == uniqueURL);

                db.Entry(item).Reference(la => la.Author).Load();
                db.Entry(item).Collection(la => la.BlogsTags).Load();
            }

            return item;
        }

        public IEnumerable<Blog> GetByDate(int year, int? month)
        {
            List<Blog> blogList = new List<Blog>();

            using (var db = new SparkServerEntities())
            {
                if (month.HasValue)
                {
                    blogList = db.Blog.Where(
                        u => u.Active &&
                        u.PublishDate.Value.Year == year &&
                        u.PublishDate.Value.Month == month).Include(u => u.Author).ToList();
                }
                else
                {
                    blogList = db.Blog.Where(
                        u => u.Active && u.PublishDate.Value.Year == year).Include(u => u.Author).ToList();
                }
            }

            return blogList;
        }

        public IEnumerable<Blog> GetRecent(int numberToLoad)
        {
            List<Blog> blogList = new List<Blog>();

            using (var db = new SparkServerEntities())
            {
                blogList = db.Blog.Where(u => u.Active)
                                  .Include(a => a.Author)
                                  .OrderByDescending(u => u.PublishDate)
                                  .Take(numberToLoad)
                                  .ToList();
            }

            return blogList;
        }

        public IEnumerable<Blog> GetByTagID(int tagID)
        {
            List<Blog> blogList = new List<Blog>();

            using (var db = new SparkServerEntities())
            {
                blogList = db.BlogsTags.Where(u => u.TagID == tagID).Select(p => p.Blog).Include(a => a.Author).ToList();
            }

            return blogList;
        }
    }
}
