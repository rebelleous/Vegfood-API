using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VegFoods.Api.DTO;
using VegFoods.Core.Models;
using VegFoods.Core.Services;
using VegFoods.Core.StringInfos;

namespace VegFoods.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IingredientService _ingredientService;
        private readonly IMapper _mapper;

        public IngredientsController(IingredientService ingredientService, IMapper mapper)
        {
            _mapper = mapper;
            _ingredientService = ingredientService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            var ingredients = await _ingredientService.GetAllAsync();

            return Ok(_mapper.Map<IEnumerable<IngredientDTO>>(ingredients));
        }

        [HttpGet("{id}")]
        
        public async Task<IActionResult> GetById(int id)
        {
            
                var ingredient = await _ingredientService.GetByIdAsync(id);

                return Ok(_mapper.Map<IngredientDTO>(ingredient));

        }

        [HttpPut]
        public IActionResult Update(IngredientDTO ingredientDTO)

        {
            var ıngredient = _ingredientService.Update(_mapper.Map<Ingredient>(ingredientDTO));

            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Save(IngredientDTO ıngredientDTO)
        {
            var newIngredient = await _ingredientService.AddAsync(_mapper.Map<Ingredient>(ıngredientDTO));

            return Created(string.Empty, _mapper.Map<IngredientDTO>(newIngredient));
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var ingredient = _ingredientService.GetByIdAsync(id).Result;
            _ingredientService.Remove(ingredient);
            return Ok("Kategori Başarıyla Silindi");

        }

     


    }
}
