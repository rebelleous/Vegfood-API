using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VegFoods.Core.Models;

namespace VegFoods.Data.Config
{
    class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public RecipeConfiguration()
        {

        }

        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder
                .HasKey(a => a.Id);

            builder
                .Property(a => a.Id)
                .UseIdentityColumn();

            builder
                .Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .ToTable("Recipes");
        }
    }
}
