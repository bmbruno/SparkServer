using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Core.Repositories
{
    public interface IVideoRepository<T> : IRepositoryBase<T>
    {
        /// <summary>
        /// Should retrieve a video-type object from a datastore using the unique URL scheme.
        /// </summary>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="uniqueURL">UniqueURL.</param>
        /// <returns>Object of type T.</returns>
        T Get(int year, int month, string uniqueURL);

        /// <summary>
        /// Should retrieve video-type objects from a datastore for any combination of year + month. Year is a minimum requirement.
        /// </summary>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <returns>Object of type T.</returns>
        IEnumerable<T> GetByDate(int year, int? month);

        /// <summary>
        /// Should return an enumerable of video objects ordered by publish date descending, limited by the numberToLoad.
        /// </summary>
        /// <param name="numberToLoad">Number of video objects to load.</param>
        /// <returns>Enumerable of video-type objects.</returns>
        IEnumerable<T> GetRecent(int numberToLoad);

        /// <summary>
        /// Should retrieve video-type objects from a datastore based on tag ID.
        /// </summary>
        /// <param name="tagID">ID of tag object.</param>
        /// <returns>IEnumerable of video-type objecs.</returns>
        IEnumerable<T> GetByTagID(int tagID);
    }
}
