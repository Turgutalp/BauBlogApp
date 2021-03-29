using System.Reflection.Metadata.Ecma335;
using BauBlogApp.Data.Concrete.EntityFramework.Mappings;
using BauBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace BauBlogApp.Data.Concrete.EntityFramework.Contexts
{
    public class BauBlogAppContext : DbContext
    {
        public DbSet<Article> Articles { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: "Server=192.168.8.101,1433; Database=BauBlogAppDatabase; User=sa; Password= Turgutalp77; Trusted_Connection=False;Connect Timeout=30;MultipleActiveResultSets=True;");
            
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ArticleMap());
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new CommentMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            
        }
    }
}