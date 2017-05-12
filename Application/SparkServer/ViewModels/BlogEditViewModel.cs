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
    public class BlogEditViewModel : BaseViewModel
    {
        public EditMode Mode { get; set; }

        public int ID { get; set; }

        [Required]
        [Display(Name = "Title")]
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public string Body { get; set; }

        public DateTime? PublishDate { get; set; }

        public int AuthorID { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }

        public string UniqueURL { get; set; }

        public string ImagePath { get; set; }

        public string ImageThumbnailPath { get; set; }

        public List<SelectListItem> AuthorList { get; set; }
    }
}