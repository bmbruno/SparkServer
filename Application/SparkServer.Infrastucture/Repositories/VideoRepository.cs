using SparkServer.Data;
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
    public class VideoRepository : IVideoRepository<Video>
    {
        public Video Get(int ID)
        {
            Video item;

            using (var db = new SparkServerEntities())
            {
                item = db.Video.Include(u => u.Author).FirstOrDefault(u => u.ID == ID);
            }

            return item;
        }

        public IEnumerable<Video> Get(Expression<Func<Video, bool>> whereClause)
        {
            // CALLING: ArticleRepo.Get(x => x.Title == "abcdef");
            // USING: db.Articles.Where(whereClause);

            List<Video> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Video.Where(whereClause).Include(u => u.Author).ToList();
            }

            return results;
        }

        public IEnumerable<Video> GetAll()
        {
            List<Video> results;

            using (var db = new SparkServerEntities())
            {
                results = db.Video.Where(u => u.Active).Include(u => u.Author).ToList();
            }

            return results;
        }
        
        public int Create(Video newItem)
        {
            using (var db = new SparkServerEntities())
            {
                db.Video.Add(newItem);
                db.SaveChanges();
            }

            return newItem.ID;
        }

        public void Update(Video updateItem)
        {
            using (var db = new SparkServerEntities())
            {
                db.Video.Attach(updateItem);

                var entry = db.Entry(updateItem);
                entry.Property(e => e.Title).IsModified = true; 
                entry.Property(e => e.Subtitle).IsModified = true;
                entry.Property(e => e.VideoURL).IsModified = true;
                entry.Property(e => e.PublishDate).IsModified = true;
                entry.Property(e => e.AuthorID).IsModified = true;
                entry.Property(e => e.ImageThumbnailPath).IsModified = true;

                db.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var db = new SparkServerEntities())
            {
                Video toDelete = db.Video.FirstOrDefault(u => u.ID == ID);

                if (toDelete == null)
                    throw new Exception($"Could not find Video with ID of {ID}");

                toDelete.Active = false;

                db.SaveChanges();
            }
        }

        public Video Get(int year, int month, string uniqueURL)
        {
            throw new NotImplementedException();

            //Video item = null;

            //using (var db = new SparkServerEntities())
            //{
            //    item = db.Video.FirstOrDefault(u => u.UniqueURL == uniqueURL);

            //    db.Entry(item).Reference(la => la.Author).Load();
            //    db.Entry(item).Collection(la => la.VideosTags).Load();
            //}

            //return item;
        }

        public IEnumerable<Video> GetByDate(int year, int? month)
        {
            throw new NotImplementedException();

            //List<Video> VideoList = new List<Video>();

            //using (var db = new SparkServerEntities())
            //{
            //    if (month.HasValue)
            //    {
            //        VideoList = db.Video.Where(
            //            u => u.Active &&
            //            u.PublishDate.Value.Year == year &&
            //            u.PublishDate.Value.Month == month).Include(u => u.Author).Include(u => u.VideosTags).ToList();
            //    }
            //    else
            //    {
            //        VideoList = db.Video.Where(
            //            u => u.Active && u.PublishDate.Value.Year == year).Include(u => u.Author).Include(u => u.VideosTags).ToList();
            //    }
            //}

            //return VideoList;
        }

        public IEnumerable<Video> GetRecent(int numberToLoad)
        {
            throw new NotImplementedException();
            
            //List<Video> VideoList = new List<Video>();

            //using (var db = new SparkServerEntities())
            //{
            //    VideoList = db.Video.Where(u => u.Active)
            //                      .Include(a => a.Author)
            //                      .Include(a => a.VideosTags)
            //                      .OrderByDescending(u => u.PublishDate)
            //                      .Take(numberToLoad)
            //                      .ToList();
            //}

            //return VideoList;
        }

        public IEnumerable<Video> GetByTagID(int tagID)
        {
            throw new NotImplementedException();

            //List<Video> VideoList = new List<Video>();

            //using (var db = new SparkServerEntities())
            //{
            //    VideoList = db.VideosTags.Where(u => u.TagID == tagID)
            //                           .Select(p => p.Video)
            //                           .Include(a => a.Author)
            //                           .Include(a => a.VideosTags)
            //                           .ToList();
            //}

            //return VideoList;
        }
    }
}
