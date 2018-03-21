using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.Models
{
    public class Paging
    {
        public int? PageCount { get; set; }

        public int? CurrentPage { get; set; }
    }
}