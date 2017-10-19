using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class VideoViewModel : BaseViewModel
    {
        public int VideoID { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string VideoURL { get; set; }

        public string ThumbnailURL { get; set; }

        public string PublishDateLong { get; set; }

        public string URL
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        
        public VideoViewModel()
        {
            MenuSelection = Application.Enum.MainMenu.Videos;
        }
    }
}