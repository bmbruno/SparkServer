﻿using SparkServer.Data;
using SparkServer.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository<Category>
    {
        public Category Get(int ID)
        {
            Category item;

            using (var db = new SparkServerEntities())
            {
                item = db.Category.FirstOrDefault(u => u.ID == ID);
            }

            return item;
        }

        public IQueryable<Category> Get(Func<Category, bool> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            IQueryable<Category> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Category.Where(whereClause).AsQueryable();
            }

            return results;
        }

        public IEnumerable<Category> GetAll()
        {
            IEnumerable<Category> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Category;
            }

            return results;
        }

        public int Create(Category newItem)
        {
            using (var db = new SparkServerEntities())
            {
                db.Category.Add(newItem);
                db.SaveChanges();
            }

            return newItem.ID;
        }

        public void Update(Category updateItem)
        {
            using (var db = new SparkServerEntities())
            {
                Category toUpdate = db.Category.FirstOrDefault(u => u.ID == updateItem.ID);

                if (toUpdate == null)
                    throw new Exception($"Could not find Category with ID of {updateItem.ID}");

                toUpdate = updateItem;
                db.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var db = new SparkServerEntities())
            {
                Category toDelete = db.Category.FirstOrDefault(u => u.ID == ID);

                if (toDelete == null)
                    throw new Exception($"Could not find Category with ID of {ID}");

                toDelete.Active = false;

                db.SaveChanges();
            }
        }
    }
}
