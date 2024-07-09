using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Config
{
    public class ProductConfiguration : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.Property(p => p.Id).IsRequired();
            builder.Property(p=> p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Description).IsRequired();
            builder.Property(p => p.Price).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Discount).HasColumnType("decimal(18,2)");
            builder.ToTable(tb => tb.HasCheckConstraint("CK_Product_Discount", "[Discount] >= 0 AND [Discount] <= 1"));
            // Se puede leer como un producto tiene una categoria y una categoria tiene muchos productos   
            // Se puede leer como un producto tiene una marca y una marca tiene muchos productos     
            // Se puede leer como un producto tiene muchas fotos y una foto pertenece a un producto                                                    
            builder.HasOne(p => p.Category).WithMany().HasForeignKey(p => p.ProductCategoryId);
            builder.HasOne(p => p.Brand).WithMany().HasForeignKey(p => p.ProductBrandId);
            builder.HasMany(p => p.Photos).WithOne().HasForeignKey(p => p.ProductId);
            

        }
    }
}