using System;
using System.Text;
using BauBlogApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BauBlogApp.Data.Concrete.EntityFramework.Mappings
{
    public class UserMap: IEntityTypeConfiguration<User>

    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property((u => u.Id)).ValueGeneratedOnAdd();
            builder.Property(u => u.Email).IsRequired();
            builder.Property(u => u.Email).HasMaxLength(50);
            //uniq index  isunig default true email uniq belirlendi yani 1 email ile 1 kez kayit olur
            builder.HasIndex(u => u.Email).IsUnique();
            builder.Property(u => u.UserName).IsRequired();
            builder.Property(u => u.UserName).HasMaxLength(20);
            builder.HasIndex(u => u.UserName).IsUnique();
            builder.Property(u => u.PasswordHash).IsRequired();
            builder.Property(u => u.PasswordHash).HasColumnType("VARBINARY(500)");
            builder.Property(u => u.Description).HasMaxLength(500);
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.FirstName).HasMaxLength(30);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.LastName).HasMaxLength(30);
            builder.Property(u => u.Picture).IsRequired();
            builder.Property(u => u.Picture).HasMaxLength(250);
            builder.HasOne<Role>(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId);
            
            builder.Property(u => u.CreatedByName).IsRequired(true);

            builder.Property(u => u.CreatedByName).HasMaxLength(50);
            
            builder.Property(u => u.ModifiedByName).IsRequired(true);

            builder.Property(u => u.ModifiedByName).HasMaxLength(50);
            
            builder.Property(u => u.ModifiedDate).IsRequired(true);

            builder.Property(u => u.CreatedDate).IsRequired(true);
            
            builder.Property(u => u.IsActive).IsRequired(true);

            builder.Property(u => u.IsDeleted).IsRequired(true);

            builder.Property(u => u.Note).HasMaxLength(500);


            builder.ToTable("Users");

            builder.HasData(new User
            {
                Id = 1,
                RoleId = 1,
                FirstName = "Turgutalp",
                LastName = "Tug",
                UserName = "turguttug",
                Email = "turgut@gmail.com",
                Picture = "https://encrypted-tbn0.gstatic.com/images?q=tbn%3AANd9GcSX4wVGjMQ37PaO4PdUVEAliSLi8-c2gJ1zvQ&usqp=CAU",
                IsActive = true,
                IsDeleted = false,
                CreatedByName = "InitialCreate",
                CreatedDate = DateTime.Now,
                ModifiedByName = "InitialCreate",
                ModifiedDate = DateTime.Now,
                Description = "Ilk Admin Kullanici",
                Note = "Admin Kullanicisi",
                PasswordHash = Encoding.ASCII.GetBytes("0192023a7bbd73250516f069df18b500"),
                

            });

        }
    }
}