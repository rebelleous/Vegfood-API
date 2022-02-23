using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VegFoods.Api.DTO
{
    public class RecipeWithCategoryDTO : RecipeDTO
    {
        public CategoryDTO Category { get; set; }

    }
}
