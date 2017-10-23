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
    public class VideoEditViewModel : BaseViewModel
    {
        public EditMode Mode { get; set; }

        public int ID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Subtitle")]
        public string Subtitle { get; set; }

        [Required]
        [Display(Name = "Video URL")]
        public string VideoURL { get; set; }

        [Required]
        [Display(Name = "Publish Date")]
        public DateTime? PublishDate { get; set; }

        [Required]
        [Display(Name = "Author")]
        public int AuthorID { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [Display(Name = "Image Thumbnail Path")]
        public string ImageThumbnailPath { get; set; }

        public List<SelectListItem> AuthorSource { get; set; }

        public VideoEditViewModel()
        {
            AuthorSource = new List<SelectListItem>();
        }
    }
}