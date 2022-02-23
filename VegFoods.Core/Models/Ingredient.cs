using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace VegFoods.Core.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<RecipeIngredient> RecipeIngredients{ get; set; }
    }
}
