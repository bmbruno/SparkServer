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
    
    public partial class Article
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Article()
        {
            this.Article1 = new HashSet<Article>();
            this.RelatedArticle = new HashSet<RelatedArticle>();
            this.RelatedArticle1 = new HashSet<RelatedArticle>();
        }
    
        public int ID { get; set; }
        public string Title { get; set; }
        public int CategoryID { get; set; }
        public string Body { get; set; }
        public int SitecoreVersionID { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public string UniqueURL { get; set; }
        public int AuthorID { get; set; }
        public bool Active { get; set; }
        public System.DateTime CreateDate { get; set; }
    
        public virtual Author Author { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Article1 { get; set; }
        public virtual Article Article2 { get; set; }
        public virtual SitecoreVersion SitecoreVersion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelatedArticle> RelatedArticle { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RelatedArticle> RelatedArticle1 { get; set; }
    }
}
