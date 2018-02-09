using SparkServer.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.ViewModels
{
    public class RelatedLinkItemViewModel : BaseViewModel
    {
        private int? _SortOrder;

        public int ID { get; set; }

        public string Title { get; set; }

        public string HREF { get; set; }

        public int? SortOrder
        {
            get { if (this._SortOrder.HasValue) { return this._SortOrder; } else { return 0; } }
            set { this._SortOrder = value; }
        }

        public bool Deleted { get; set; }
    }
}