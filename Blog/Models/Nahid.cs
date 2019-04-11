namespace Blog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nahid")]
    public partial class Nahid
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Nahid()
        {
            Articles = new HashSet<Article>();
            UserRoles = new HashSet<UserRole>();
        }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
        [StringLength(200)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(50)]
        public string MailAdress { get; set; }

        public bool? Gender { get; set; }

        public int? ImageID { get; set; }

        public bool? Author { get; set; }

        public bool? Online { get; set; }

        public bool? Approved { get; set; }

        [StringLength(500)]
        public string Descriptions { get; set; }

        [Key]
        public int UserId { get; set; }

        public DateTime? RegistrationDate { get; set; }

        public DateTime? DateofBrith { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Article> Articles { get; set; }

        public virtual Imagee Imagee { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
