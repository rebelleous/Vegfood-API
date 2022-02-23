using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using VegFoods.Core.Models;

namespace VegFoods.Data.Config
{
    class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
    {
        public IngredientConfiguration()
        {

        }
        public void Configure(EntityTypeBuilder<Ingredient> builder)
        {
            builder
                .HasKey(m => m.Id);

            builder
                .Property(m => m.Id)
                .UseIdentityColumn();

            builder
                .Property(m => m.Name)
                .IsRequired()
                .HasMaxLength(50);

            

            builder
                .ToTable("Ingredients");

        }
    }
}
