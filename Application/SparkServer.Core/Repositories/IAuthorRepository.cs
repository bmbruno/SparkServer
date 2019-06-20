using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Core.Repositories
{
    public interface IAuthorRepository<T> : IRepositoryBase<T>
    {
        /// <summary>
        /// Should implement a database retrieval for an author by SSOID.
        /// </summary>
        /// <param name="ID">SSOID of the object to get from the database.</param>
        /// <returns>Object of type T.</returns>
        T Get(Guid ssoID);
    }
}
