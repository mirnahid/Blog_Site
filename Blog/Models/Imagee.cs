namespace Blog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Imagee")]
    public partial class Imagee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Imagee()
        {
            Articles = new HashSet<Article>();
            Nahids = new HashSet<Nahid>();
        }

        [Key]
        public int ImageId { get; set; }

        [StringLength(250)]
        public string Small { get; set; }

        [StringLength(250)]
        public string Middle { get; set; }

        [StringLength(250)]
        public string Big { get; set; }

        [StringLength(250)]
        public string Video { get; set; }

        public int? ArticleID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }

        public virtual Article Article { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Nahid> Nahids { get; set; }
    }
}
