using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VegFoods.Api.DTO;
using VegFoods.Core.Models;

namespace VegFoods.Api.Mapping
{
    public class MapProfile : Profile 
    {
        public MapProfile()
        {
            CreateMap<Category, CategoryDTO>().ReverseMap();
            CreateMap<Category, CategoryWithRecipesDTO>().ReverseMap();


            CreateMap<Recipe, RecipeDTO>().ReverseMap();
            CreateMap<Recipe, RecipeWithCategoryDTO>().ReverseMap();
          //  CreateMap<Recipe, RecipeWithIngredientsDTO>().ReverseMap();


            CreateMap<Ingredient, IngredientDTO>().ReverseMap();

            CreateMap<UserAddDTO, User>();
            CreateMap<User, UserAddDTO>();

           CreateMap<Recipe, RecipeWithIngredientsDTO>()
     .ForMember(dto => dto.Ingredients, opt => opt.MapFrom(x => x.RecipeIngredients.Select(y => y.Ingredient).ToList()));
        }

    }
}
