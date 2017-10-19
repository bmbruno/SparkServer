using SparkServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class HomeVideoViewModel : BaseViewModel
    {
        public List<VideoViewModel> VideoList { get; set; }

        public HomeVideoViewModel()
        {
            VideoList = new List<VideoViewModel>();
        }
    }
}