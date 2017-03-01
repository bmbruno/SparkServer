using SparkServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Core.Repositories
{
    public interface IBlogTagRepository<T> : IRepositoryBase<T>
    {
        /// <summary>
        /// Should return a list of object of type T based on the input list of integers (ID values).
        /// </summary>
        /// <param name="list">List of ID values.</param>
        /// <returns>IEnumerable of type T.</returns>
        IEnumerable<T> GetFromList(IEnumerable<int> list);
    }
}
