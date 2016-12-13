using SparkServer.Core.Repositories;
using SparkServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SparkServer.Infrastructure.Entities;

namespace SparkServer.Infrastructure.Repositories
{
    public class ArticleRepository : IArticleRepository<Article>
    {
        public Article Get()
        {
            return new Article();
        }

        public int Create()
        {
            return 0;
        }
    }
}
