using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SparkServer.Application.Enum
{
    public enum ViewMode
    {
        /// <summary>
        /// Used for full-view, dashboad-style, or multi-view data display.
        /// </summary>
        Overview = 0,

        /// <summary>
        /// Used for list-only data display.
        /// </summary>
        List = 1,

        /// <summary>
        /// Used for small or subset data display.
        /// </summary>
        Compact = 2
    }
}