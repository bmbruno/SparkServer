using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Core.Repositories
{
    public interface IArticleRepository<T> : IRepositoryBase<T>
    {
        /// <summary>
        /// Should return an article object based on the uniqueURL key value.
        /// </summary>
        /// <param name="uniqueURL">Unique URL of the article to load.</param>
        /// <returns>Article-type object.</returns>
        T Get(string uniqueURL);

        /// <summary>
        /// Should return an enumerable of article objects ordered by publish date descending, limited by the numberToLoad.
        /// </summary>
        /// <param name="numberToLoad">Number of article objects to load.</param>
        /// <returns>Enumerable of article-type objects.</returns>
        IEnumerable<T> GetRecent(int numberToLoad);
    }
}
