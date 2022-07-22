using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Models
{
    public class BlogContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }

        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuthorMTMPost>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.AuthorMTMPosts)
                .HasForeignKey(b1 => b1.AuthorId);

            modelBuilder.Entity<AuthorMTMPost>()
                .HasOne(b => b.Post)
                .WithMany(ba => ba.AuthorMTMPosts)
                .HasForeignKey(b1 => b1.PostId);
        }
    }
}
