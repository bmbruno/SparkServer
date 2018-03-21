using SparkServer.Application.Enum;
using SparkServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class BaseViewModel
    {
        public MainMenu MenuSelection { get; set; }

        public Paging Paging { get; set; }

        public BaseViewModel()
        {
            Paging = new Paging();
        }
    }
}