using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VegFoods.Core.Models;

namespace VegFoods.Data.Config
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public CategoryConfiguration()
        {

        }
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(a => a.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
               .Property(m => m.Name)
               .IsRequired()
               .HasMaxLength(50);

            builder
                .ToTable("Categories");
        }
    }
}
