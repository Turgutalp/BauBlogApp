using System;
using BauBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BauBlogApp.Data.Concrete.EntityFramework.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            //primeryKey var mi ?
            //Id alani primeryKey oldu
            builder.HasKey(a => a.Id);
            //Identity alanimiz, Id alanimizi bir bir arttirir.
            builder.Property(a => a.Id).ValueGeneratedOnAdd();

            builder.Property(a => a.Title).HasMaxLength(100);

            //isrequired=> zorunlu miu ?
            builder.Property(a => a.Title).IsRequired(true);

            builder.Property(a => a.Content).IsRequired(true);

            builder.Property(a => a.Content).HasColumnType("NVARCHAR(MAX)");
            
            builder.Property(a => a.Date).IsRequired(true);
            
            builder.Property(a => a.SeoAuthor).IsRequired(true);
            
            builder.Property(a => a.SeoAuthor).HasMaxLength(50);
            
            builder.Property(a => a.SeoDescription).HasMaxLength(150);
            
            builder.Property(a => a.SeoDescription).IsRequired(true);

            builder.Property(a => a.SeoTags).HasMaxLength(70);

            builder.Property(a => a.SeoTags).IsRequired(true);

            builder.Property(a => a.ViewsCount).IsRequired(true);

            builder.Property(a => a.CommentCount).IsRequired(true);

            builder.Property(a => a.Thumbnail).IsRequired(true);
            
            builder.Property(a => a.Thumbnail).HasMaxLength(250);
            

            builder.Property(a => a.CreatedByName).IsRequired(true);

            builder.Property(a => a.CreatedByName).HasMaxLength(50);
            
            builder.Property(a => a.ModifiedByName).IsRequired(true);

            builder.Property(a => a.ModifiedByName).HasMaxLength(50);
            
            builder.Property(a => a.ModifiedDate).IsRequired(true);

            builder.Property(a => a.CreatedDate).IsRequired(true);
            
            builder.Property(a => a.IsActive).IsRequired(true);

            builder.Property(a => a.IsDeleted).IsRequired(true);

            builder.Property(a => a.Note).HasMaxLength(500);
            
            //1-n iliskisi

            builder.HasOne<Category>(a => a.Category)
                .WithMany(c => c.Articles)
                .HasForeignKey(a => a.CategoryId);

            builder.HasOne<User>(a => a.User)
                .WithMany(u => u.Articles)
                .HasForeignKey(a => a.UserId);
            
            //tablo ismi ne olmali
            builder.ToTable("Articles");

            builder.HasData(
                new Article
            {
                Id = 1,
                CategoryId = 1,
                Title = "C# 9.0 ve .Net 5",
                Content = "c# .net backend ",
                Thumbnail = "Default.jpg",
                SeoDescription = "C# 9.0 , .Net",
                SeoTags = "C#,C#9,.Net",
                SeoAuthor = "Turgutalp",
                Date = DateTime.Now,
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# 9.0 ve .net5 Yenilikler",
                UserId = 1,
                ViewsCount = 235,
                CommentCount = 1

            },
                new Article
                {
                    Id = 2,
                    CategoryId = 2,
                    Title = "C++ 11.0 ve 19",
                    Content = "C++ Embedded ",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "C++ Embedded",
                    SeoTags = "C++",
                    SeoAuthor = "Turgutalp",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ ve Embedded Sistemler",
                    UserId = 1,
                    ViewsCount = 100,
                    CommentCount = 1
                  

                },
                
                new Article
                {
                    Id = 3,
                    CategoryId = 3,
                    Title = "Java 12.0 ve 14",
                    Content = "Java EE, Spring, Hibernate .......",
                    Thumbnail = "Default.jpg",
                    SeoDescription = "Java EE Bize Neler Sunuyor",
                    SeoTags = "Java,Spring",
                    SeoAuthor = "Turgutalp",
                    Date = DateTime.Now,
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Java diliyle Spring,Hibernate,EE islemleri",
                    UserId = 1,
                    ViewsCount = 295,
                    CommentCount = 1

                }
                
                );


        }
    }
}