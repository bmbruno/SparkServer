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
    
    public partial class SitecoreVersion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SitecoreVersion()
        {
            this.Article = new HashSet<Article>();
        }
    
        public int ID { get; set; }
        public string Version { get; set; }
        public string Revision { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Article { get; set; }
    }
}
