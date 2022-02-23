using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegFoods.Api.DTO
{
    public class RecipeDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public virtual List<RecipeIngredientDTO> recipeIngredient {get;set;}
    }
}
