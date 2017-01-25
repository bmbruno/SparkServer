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
    public class BlogTagRepository : IBlogTagRepository<BlogTag>
    {
        public BlogTag Get(int ID)
        {
            BlogTag item;

            using (var db = new SparkServerEntities())
            {
                item = db.BlogTag.FirstOrDefault(u => u.ID == ID);
            }

            return item;
        }

        public IEnumerable<BlogTag> Get(Expression<Func<BlogTag, bool>> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            List<BlogTag> results;

            using (var db = new SparkServerEntities())
            {
                results = db.BlogTag.Where(whereClause).ToList();
            }

            return results;
        }

        public IEnumerable<BlogTag> GetAll()
        {
            List<BlogTag> results;

            using (var db = new SparkServerEntities())
            {
                results = db.BlogTag.Where(u => u.Active).ToList();
            }

            return results;
        }
        
        public int Create(BlogTag newItem)
        {
            using (var db = new SparkServerEntities())
            {
                db.BlogTag.Add(newItem);
                db.SaveChanges();
            }

            return newItem.ID;
        }

        public void Update(BlogTag updateItem)
        {
            using (var db = new SparkServerEntities())
            {
                BlogTag toUpdate = db.BlogTag.FirstOrDefault(u => u.ID == updateItem.ID);

                if (toUpdate == null)
                    throw new Exception($"Could not find BlogTag with ID of {updateItem.ID}");

                toUpdate = updateItem;
                db.Entry(toUpdate).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var db = new SparkServerEntities())
            {
                BlogTag toDelete = db.BlogTag.FirstOrDefault(u => u.ID == ID);

                if (toDelete == null)
                    throw new Exception($"Could not find BlogTag with ID of {ID}");

                toDelete.Active = false;

                db.SaveChanges();
            }
        }
    }
}
