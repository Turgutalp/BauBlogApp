using System;
using BauBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BauBlogApp.Data.Concrete.EntityFramework.Mappings
{
    public class CategoryMap : IEntityTypeConfiguration<Category>

    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            //Id alani primeryKey yapildi
            builder.HasKey(c => c.Id);
            //idendity-yan 1-1 artmasini istiyoruz
            builder.Property(c => c.Id).ValueGeneratedOnAdd();
            builder.Property(c => c.Name).IsRequired();
            builder.Property(c => c.Name).HasMaxLength(70);
            builder.Property(c => c.Description).HasMaxLength(500);
            builder.Property(a => a.CreatedByName).IsRequired(true);

            builder.Property(c => c.CreatedByName).HasMaxLength(50);
            
            builder.Property(c => c.ModifiedByName).IsRequired(true);

            builder.Property(c => c.ModifiedByName).HasMaxLength(50);
            
            builder.Property(c => c.ModifiedDate).IsRequired(true);

            builder.Property(c => c.CreatedDate).IsRequired(true);
            
            builder.Property(c => c.IsActive).IsRequired(true);

            builder.Property(c => c.IsDeleted).IsRequired(true);

            builder.Property(c => c.Note).HasMaxLength(500);
            
            //tabloya isim verdik
            builder.ToTable("Categories");

            builder.HasData(
                new Category
            {
                Id =1,
                Name = "C#",
                Description = "C# Programlama Dili ile ilgili en guncel bilgiler",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Note = "C# Blog Kategorisi"
            },
                new Category
                {
                    Id =2,
                    Name = "C++",
                    Description = "C++ Programlama Dili ile ilgili en guncel bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "C++ Blog Kategorisi"
                },
                
                new Category
                {
                    Id =3,
                    Name = "Java",
                    Description = "Java Programlama Dili ile ilgili en guncel bilgiler",
                    IsActive = true,
                    IsDeleted = false,
                    CreatedByName = "InitialCreate",
                    CreatedDate = DateTime.Now,
                    ModifiedByName = "InitialCreate",
                    ModifiedDate = DateTime.Now,
                    Note = "Java Blog Kategorisi"
                }
                
                
                );



        }
    }
}