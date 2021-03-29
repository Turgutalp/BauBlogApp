using System;
using BauBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BauBlogApp.Data.Concrete.EntityFramework.Mappings
{
    public class CommentMap: IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
           //primeryKey
           builder.HasKey(c => c.Id);
           builder.Property(c => c.Id).ValueGeneratedOnAdd();
           builder.Property(c => c.Text).IsRequired();
           builder.Property(c => c.Text).HasMaxLength(1000);
           
           builder.HasOne<Article>(c => c.Article)
               .WithMany(a => a.Comments)
               .HasForeignKey(c => c.ArticleId);
           
           builder.Property(a => a.CreatedByName).IsRequired(true);

           builder.Property(c => c.CreatedByName).HasMaxLength(50);
            
           builder.Property(c => c.ModifiedByName).IsRequired(true);

           builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            
           builder.Property(c => c.ModifiedDate).IsRequired(true);

           builder.Property(c => c.CreatedDate).IsRequired(true);
            
           builder.Property(c => c.IsActive).IsRequired(true);

           builder.Property(c => c.IsDeleted).IsRequired(true);

           builder.Property(c => c.Note).HasMaxLength(500);

           builder.ToTable("Comments");

           builder.HasData(
               new Comment
           {
               Id =1,
               ArticleId = 1,
               Text = "Yorummm Yorum yorum",
               IsActive = true,
               IsDeleted = false,
               CreatedByName = "InitialCreate",
               CreatedDate = DateTime.Now,
               ModifiedByName = "InitialCreate",
               ModifiedDate = DateTime.Now,
               Note = "C# Makale Yorumu",
               
               

           },
               new Comment
               {
                   Id =2,
                   ArticleId = 2,
                   Text = "Yorummm Yorum yorum",
                   IsActive = true,
                   IsDeleted = false,
                   CreatedByName = "InitialCreate",
                   CreatedDate = DateTime.Now,
                   ModifiedByName = "InitialCreate",
                   ModifiedDate = DateTime.Now,
                   Note = "C++ Makale Yorumu",
               
               

               },
               
               new Comment
               {
                   Id =3,
                   ArticleId = 3,
                   Text = "Yorummm Yorum yorum",
                   IsActive = true,
                   IsDeleted = false,
                   CreatedByName = "InitialCreate",
                   CreatedDate = DateTime.Now,
                   ModifiedByName = "InitialCreate",
                   ModifiedDate = DateTime.Now,
                   Note = "Java Makale Yorumu",
               
               

               }
               );


        }
    }
}