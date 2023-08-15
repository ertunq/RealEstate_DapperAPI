using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using RealEstate_DapperAPI.Models.Dtos.CategoryDtos;
using RealEstate_DapperAPI.Repositories.CategoryRepository;
using System.Net;

namespace RealEstate_DapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryRepository _CategoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _CategoryRepository = categoryRepository;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            var categories = await _CategoryRepository.GetAllCategoryAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            _CategoryRepository.CreateCategory(createCategoryDto);
            return Ok("Category Added");
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            _CategoryRepository.DeleteCategory(id);
            return Ok("Category Deleted");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            _CategoryRepository.UpdateCategory(updateCategoryDto);
            return Ok("Category Updated");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _CategoryRepository.GetCategory(id);
            return Ok(category);
        }
    }
    }
