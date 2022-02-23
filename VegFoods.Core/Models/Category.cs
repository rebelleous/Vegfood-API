using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace VegFoods.Core.Models
{
    
   public class Category
    {
        public Category()
        {
            Recipes = new Collection<Recipe>();
        }
       
        public int Id { get; set;}
        public string Name { get; set;}
        public IEnumerable<Recipe> Recipes { get; set;}
    }
}
