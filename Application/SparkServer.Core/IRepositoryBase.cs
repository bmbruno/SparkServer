using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Core
{
    public interface IRepositoryBase<T>
    {
        /// <summary>
        /// Should implement a database retrieval.
        /// </summary>
        /// <param name="ID">ID of the object to get from the database.</param>
        /// <returns>Object of type T.</returns>
        T Get(int ID);

        /// <summary>
        /// Get items of T type from the database with a Where clause predicate.
        /// </summary>
        /// <param name="whereClause">LINQ Where clause predicate.</param>
        /// <returns>IQueryable of type T.</returns>
        IEnumerable<T> Get(Func<T, bool> whereClause);

        /// <summary>
        /// Returns all items from database.
        /// </summary>
        /// <returns>IQueryable of type T.</returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Should implement a database save of the given item.
        /// </summary>
        /// <param name="newItem">Item to save to database.</param>
        /// <returns>Primary Key ID of the new item.</returns>
        int Create(T newItem);

        /// <summary>
        /// Should implement an update at the field level of an item in the database based on the given item.
        /// </summary>
        /// <param name="updateItem">Item with updated fields.</param>
        void Update(T updateItem);

        /// <summary>
        /// Should implement a soft database delete (when possible). A 'soft delete' refers to deactivating a row rather than a true deletion.
        /// </summary>
        /// <param name="ID">Primary Key ID of the item to delete.</param>
        void Delete(int ID);
    }
}
