namespace Blog
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BlogContext : DbContext
    {
        public BlogContext()
            : base("name=BlogContext")
        {
        }

        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<AuthorFollow> AuthorFollows { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<Imagee> Imagees { get; set; }
        public virtual DbSet<Nahid> Nahids { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>()
                .Property(e => e.Title)
                .IsFixedLength();

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Comments)
                .WithRequired(e => e.Article)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Imagees)
                .WithOptional(e => e.Article)
                .HasForeignKey(e => e.ArticleID);

            modelBuilder.Entity<Article>()
                .HasMany(e => e.Tags)
                .WithMany(e => e.Articles)
                .Map(m => m.ToTable("ArticleTag").MapLeftKey("ArticleID").MapRightKey("TagID"));

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Imagee>()
                .HasMany(e => e.Articles)
                .WithOptional(e => e.Imagee)
                .HasForeignKey(e => e.ImageID);

            modelBuilder.Entity<Nahid>()
                .HasMany(e => e.Articles)
                .WithRequired(e => e.Nahid)
                .HasForeignKey(e => e.AuthorID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Nahid>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Nahid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.UserRoles)
                .WithRequired(e => e.Role)
                .WillCascadeOnDelete(false);
        }
    }
}
