using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class VideoEditListViewModel : BaseViewModel
    {
        public List<VideoListItemViewModel> VideoList { get; set; }

        public VideoEditListViewModel()
        {
            VideoList = new List<VideoListItemViewModel>();
        }
    }
}