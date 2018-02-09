using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class RelatedLinkItemViewModel : BaseViewModel
    { 
        public int ID { get; set; }

        public string Title { get; set; }

        public string HREF { get; set; }

        public int? SortOrder
        {
            get { if (this.SortOrder.HasValue) { return this.SortOrder; } else { return 0; } }

            set { this.SortOrder = value; }
        }

        public bool Deleted { get; set; }
    }
}