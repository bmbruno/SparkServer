using SparkServer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkServer.Infrastructure.Entities
{
    public class BlogArticle : IBlogArticle
    {
        public int ID { get; set; }

        public string Title { get; set; }

        public int Tags { get; set; }

        public string Body { get; set; }

        public DateTime PublishDate { get; set; }

        public string UniqueURL { get; set; }
    }
}
