//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SparkServer.Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class BlogsTags
    {
        public int ID { get; set; }
        public int BlogID { get; set; }
        public int TagID { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual Blog Blog { get; set; }
        public virtual BlogTag BlogTag { get; set; }
    }
}
