using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegFoods.Core.Models;

namespace VegFoods.Api.DTO
{
    public class RecipeWithIngredientsDTO : RecipeDTO
    {
        public RecipeWithIngredientsDTO()
        {
           
        }

        public ICollection<IngredientDTO> Ingredients { get; set; }
    }
}
