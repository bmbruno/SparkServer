﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }
    }
}