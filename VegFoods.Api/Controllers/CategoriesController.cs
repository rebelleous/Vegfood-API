using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VegFoods.Api.DTO;
using VegFoods.Core.Models;
using VegFoods.Core.Services;
using VegFoods.Core.StringInfos;

namespace VegFoods.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
       //[Authorize(Roles = RoleInfo.Admin)]
        public async Task<IActionResult> GetAll()
        {
            
            var categories = await _categoryService.GetAllAsync();
           
            return Ok(_mapper.Map<IEnumerable<CategoryDTO>>(categories));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
           
            CategoryDTO categoryDTO;
            var category = await _categoryService.GetByIdAsync(id);
            return Ok(_mapper.Map<CategoryWithRecipesDTO>(category));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDTO categoryDTO)
        {
            var newcategory = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDTO));

            return Created(string.Empty, _mapper.Map<CategoryDTO>(newcategory));
        }

           [HttpDelete("{id}")]
            public IActionResult Remove(int id)
            {
                var category = _categoryService.GetByIdAsync(id).Result;
                _categoryService.Remove(category);
                return Ok("Kategori Başarıyla Silindi");

            }
        

        [HttpPut]
        public IActionResult Update(CategoryDTO categoryDTO)

        {
            var category = _categoryService.Update(_mapper.Map<Category>(categoryDTO));

            return NoContent();
        }

        [HttpGet("{id}/recipes")]
        public async Task<IActionResult> GetAllWithRecipesAsync(int id)
        {
            var category = await _categoryService.GetAllWithRecipesAsync(id);
            return Ok(_mapper.Map<CategoryWithRecipesDTO>(category));
        }

  
    }
}
