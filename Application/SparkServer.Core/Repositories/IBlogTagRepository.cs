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

        /// <summary>
        /// SHould clear and set all blog tags for a given blog ID.
        /// </summary>
        /// <param name="blogID">ID of the blog to update related tags.</param>
        /// <param name="newTagIDList">List of actively-selected blog tag IDs.</param>
        void UpdateTagsForBlog(int blogID, IEnumerable<int> newTagIDList);
    }
}
