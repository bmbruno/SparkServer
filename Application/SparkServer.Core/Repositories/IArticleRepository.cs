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
        /// Should return an Article object based on the uniqueURL key value.
        /// </summary>
        /// <param name="uniqueURL"></param>
        /// <returns></returns>
        T Get(string uniqueURL);
    }
}
