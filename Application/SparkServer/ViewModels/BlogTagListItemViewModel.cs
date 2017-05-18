using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class BlogTagListItemViewModel : BaseViewModel
    { 
        public int ID { get; set; }

        public string Name { get; set; }
    }
}