using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Core.Repositories
{
    public interface IBlogRepository<T> : IRepositoryBase<T>
    {
        /// <summary>
        /// Should retrieve a blog-type object from a datastore using a combination of the date and unique URL scheme.
        /// </summary>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="day">Day.</param>
        /// <param name="uniqueURL">UniqueURL.</param>
        /// <returns>Object of type T.</returns>
        T Get(int year, int month, int day, string uniqueURL);
    }
}
