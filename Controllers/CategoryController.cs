using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapiproject.DTOs;
using testapiproject.Interfaces;
using testapiproject.Models;
using testapiproject.Services;

namespace testapiproject.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private IntCateServices _categoryServices;

        public CategoryController(IntCateServices categoryService)
        {
            _categoryServices = categoryService;
        }

        [HttpGet]
        public IActionResult GetCategories(string searchvalue = "")
        {
            var categoryList = _categoryServices.GetAllCategory();

            return Ok(ApiResponse<List<CategoryReadDto>>.SuccessResponse(categoryList, 200, "Categories return successfull"));
        }

        [HttpGet("{categoryID:guid}")]
        public IActionResult GetCategoryById(Guid categoryID)
        {
            var foundCategory = _categoryServices.GetCategoryById(categoryID);
            if (foundCategory == null)
            {
                return NotFound(ApiResponse<object>.ErrorResponse(new List<string> { "Id not matched" }, 404, "VAlDATION FAILED"));
            }

            return Ok(ApiResponse<CategoryReadDto>.SuccessResponse(foundCategory, 200, "Categories return successfull"));

        }

        [HttpPost]
        public IActionResult CreateCategories(CategoryCreateDto categoryData)
        {
            if (string.IsNullOrEmpty(categoryData.Name))
            {
                return BadRequest("Name is required & mendatory");
            }

            var newCategory = _categoryServices.CreateCategory(categoryData);

            return Created(nameof(GetCategoryById), ApiResponse<CategoryReadDto>.SuccessResponse(newCategory, 201, "Categories Post successfull"));
        }

        [HttpPut("{categoryID:guid}")]
        public IActionResult UpdateCategories(Guid categoryID, CategoryUpdateDto categoryData)
        {
            var findCategory = _categoryServices.UpdateCategory(categoryID,categoryData);
            if (findCategory == null)
            {
                return NotFound("Category id not matched");
            }

            return Ok(ApiResponse<CategoryReadDto>.SuccessResponse(findCategory, 200, "Categories Update successfull"));
        }

        [HttpDelete("{categoryId:guid}")]
        public IActionResult DeleteCategory(Guid categoryId)
        {
            var findCategory = _categoryServices.DeleteCategoryById(categoryId);
            if (!findCategory)
            {
                return NotFound("Category id not matched");
            }

            return Ok(ApiResponse<object>.SuccessResponse(null, 204, "Categories Deleted successfull"));
        }
    }
}
