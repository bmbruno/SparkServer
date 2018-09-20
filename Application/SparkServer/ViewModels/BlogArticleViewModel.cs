using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class BlogArticleViewModel : BaseViewModel
    {
        public int BlogID { get; set; }

        public string UniqueURL { get; set; }

        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Body { get; set; }

        public string ImagePath { get; set; }

        public string ImageThumbnailPath { get; set; }

        public string AuthorFullName { get; set; }

        public DateTime PublishDate { get; set; }

        public List<BlogTagViewModel> BlogTags { get; set; }

        public string URL
        {
            get
            {
                return $"/blog/{this.PublishDate.Year}/{this.PublishDate.Month}/{this.UniqueURL}";
            }
        }

        public string ImageURL
        {
            get
            {
                if (!String.IsNullOrEmpty(this.ImagePath))
                    return this.ImagePath;
                else
                    return "/Content/Images/default_blog_bg.jpg";
            }
        }
        
        public BlogArticleViewModel()
        {
            BlogTags = new List<BlogTagViewModel>();
            MenuSelection = Application.Enum.MainMenu.Blog;
        }
        
    }
}