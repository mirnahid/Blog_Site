namespace Blog
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int CommentId { get; set; }

        [Column("Comment")]
        [Required]
        [StringLength(1500)]
        public string Comment1 { get; set; }

        public int ArticleID { get; set; }

        public DateTime UploadDate { get; set; }

        [StringLength(50)]
        public string NameSurname { get; set; }

        public int? Like { get; set; }

        public virtual Article Article { get; set; }
    }
}
