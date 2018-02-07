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

        /// <summary>
        /// Should perform a soft delete of a related link object.
        /// </summary>
        /// <param name="relatedLinkID">ID of the related link object.</param>
        void DeleteRelatedLink(int relatedLinkID);

        /// <summary>
        /// Should update the fields on a related link object based on the ID.
        /// </summary>
        /// <param name="relatedLinkID">ID of the related link object.</param>
        /// <param name="title">Title of the link.</param>
        /// <param name="HREF">Href of the link.</param>
        /// <param name="sortOrder">Sort order of the link.</param>
        void UpdateRelatedLink(int relatedLinkID, string title, string HREF, int sortOrder);

        /// <summary>
        /// Should save a new related links object in the database.
        /// </summary>
        /// <param name="title">Title of the link.</param>
        /// <param name="HREF">Href of the link.</param>
        /// <param name="sortOrder">Sort order of the link.</param>
        void AddRelatedLink(int articleID, string title, string HREF, int sortOrder);

        // TODO: marked for removal
        ///// <summary>
        ///// Should return an enumerable of related article objects from the database.
        ///// </summary>
        ///// <param name="articleID">ID of article.</param>
        ///// <returns>Enumerable of related article objects.</returns>
        //IEnumerable<A> GetRelatedArticles(int articleID);

        ///// <summary>
        ///// Should return an enumerable of related article link objects from the database.
        ///// </summary>
        ///// <param name="articleID">ID of article.</param>
        ///// <returns>Enumerable of related article link objects.</returns>
        //IEnumerable<L> GetRelatedLinks(int articleID);
    }
}
