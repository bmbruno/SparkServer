using SparkServer.Application.Enum;
using SparkServer.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SparkServer.ViewModels
{
    public class MediaEditViewModel : BaseViewModel
    {
        public EditMode Mode { get; set; }
        
        public HttpPostedFileBase NewFile { get; set; }

        public MediaEditViewModel() { }
    }
}