﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Core.Repositories
{
    public interface IBlogRepository<T> : IRepositoryBase<T>
    {
        /// <summary>
        /// Should retrieve a blog-type object from a datastore using the unique URL scheme.
        /// </summary>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <param name="uniqueURL">UniqueURL.</param>
        /// <returns>Object of type T.</returns>
        T Get(int year, int month, string uniqueURL);

        /// <summary>
        /// Should retrieve blog-type objects from a datastore for any combination of year + month. Year is a minimum requirement.
        /// </summary>
        /// <param name="year">Year.</param>
        /// <param name="month">Month.</param>
        /// <returns>Object of type T.</returns>
        IEnumerable<T> GetByDate(int year, int? month);
    }
}
