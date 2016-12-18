using SparkServer.Application.Enum;
using SparkServer.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class AddEditViewModel
    {
        public EditMode Mode { get; set; }

        public Article Article { get; set; }
    }
}