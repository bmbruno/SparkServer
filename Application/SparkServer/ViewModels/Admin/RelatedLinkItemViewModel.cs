using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class RelatedLinkItemViewModel : BaseViewModel
    {        
        public int ID { get; set; }

        [Display(Name = "Title")]
        public string Title { get; set; }

        [Display(Name = "Link HREF")]
        public string HREF { get; set; }
        
        private int? _SortOrder;

        [Display(Name = "Sort Order")]
        public int? SortOrder
        {
            get { if (this._SortOrder.HasValue) { return this._SortOrder; } else { return 0; } }
            set { this._SortOrder = value; }
        }

        public bool Deleted { get; set; }
    }
}