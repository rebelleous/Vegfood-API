using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace VegFoods.Core.Models
{
    public class Recipe
    {
      
        public int Id { get; set; }
        public string Name { get; set;}
        public int? CategoryId { get; set; } = null; 
        public string Description { get; set; }
        public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; }
        public Category? Category { get; set;}

        public User User { get; set; }
        
    }
}
