using SparkServer.Application.Enum;
using SparkServer.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class ArticleAddEditViewModel
    {
        public EditMode Mode { get; set; }

        // TODO: use ArticleViewModel for this?
        //public Article Article { get; set; }
    }
}