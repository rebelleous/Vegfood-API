using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegFoods.Api.DTO
{
    public class CategoryWithRecipesDTO : CategoryDTO
    {
        public ICollection<RecipeDTO> Recipes { get; set; }

    }
}
