using System;
using System.Collections.Generic;
using System.Text;

namespace VegFoods.Core.Models
{
   public class RecipeIngredient
    {
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }

        public virtual Recipe Recipe { get; set; }
        public virtual Ingredient Ingredient { get; set; }
    }
}
