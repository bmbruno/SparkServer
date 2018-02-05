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
    public class ArticleEditViewModel : BaseViewModel
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
        [Display(Name = "Category")]
        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Sitecore Version")]
        public int SitecoreVersionID { get; set; }

        [Required]
        [Display(Name = "Body")]
        public string Body { get; set; }

        [Required]
        [Display(Name = "Publish Date")]
        public DateTime? PublishDate { get; set; }

        [Required]
        [Display(Name = "Author")]
        public int AuthorID { get; set; }

        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [Display(Name = "Unique URL")]
        public string UniqueURL { get; set; }

        // TODO: marked for removal
        // public List<int> RelatedArticles { get; set; }

        public List<RelatedLinkItemViewModel> RelatedLinks { get; set; }

        public List<SelectListItem> AuthorSource { get; set; }

        public List<SelectListItem> CategorySource { get; set; }

        public List<SelectListItem> SitecoreVersionSource { get; set; }

        // TODO: marked for removal
        // public List<SelectListItem> RelatedArticlesSource { get; set; }

        [Display(Name = "Sort Order")]
        public int? SortOrder { get; set; }

        public ArticleEditViewModel()
        {
            RelatedLinks = new List<RelatedLinkItemViewModel>();
            AuthorSource = new List<SelectListItem>();
            CategorySource = new List<SelectListItem>();
            SitecoreVersionSource = new List<SelectListItem>();
        }
    }
}