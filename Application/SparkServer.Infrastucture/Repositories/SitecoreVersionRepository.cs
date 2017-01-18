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
    public class SitecoreVersionRepository : ISitecoreVersionRepository<SitecoreVersion>
    {
        public SitecoreVersion Get(int ID)
        {
            SitecoreVersion item;

            using (var db = new SparkServerEntities())
            {
                item = db.SitecoreVersion.FirstOrDefault(u => u.ID == ID);
            }

            return item;
        }

        public IEnumerable<SitecoreVersion> Get(Expression<Func<SitecoreVersion, bool>> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            List<SitecoreVersion> results;

            using (var db = new SparkServerEntities())
            {
                results = db.SitecoreVersion.Where(whereClause).ToList();
            }

            return results;
        }

        public IEnumerable<SitecoreVersion> GetAll()
        {
            List<SitecoreVersion> results;

            using (var db = new SparkServerEntities())
            {
                results = db.SitecoreVersion.ToList();
            }

            return results;
        }

        public int Create(SitecoreVersion newItem)
        {
            using (var db = new SparkServerEntities())
            {
                db.SitecoreVersion.Add(newItem);
                db.SaveChanges();
            }

            return newItem.ID;
        }

        public void Update(SitecoreVersion updateItem)
        {
            using (var db = new SparkServerEntities())
            {
                SitecoreVersion toUpdate = db.SitecoreVersion.FirstOrDefault(u => u.ID == updateItem.ID);

                if (toUpdate == null)
                    throw new Exception($"Could not find SitecoreVersion with ID of {updateItem.ID}");

                toUpdate = updateItem;
                db.Entry(toUpdate).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var db = new SparkServerEntities())
            {
                SitecoreVersion toDelete = db.SitecoreVersion.FirstOrDefault(u => u.ID == ID);

                if (toDelete == null)
                    throw new Exception($"Could not find SitecoreVersion with ID of {ID}");

                toDelete.Active = false;

                db.SaveChanges();
            }
        }
    }
}
