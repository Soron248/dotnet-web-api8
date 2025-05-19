using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using testapiproject.Models;

namespace testapiproject.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoryController : ControllerBase
    {
        private static List<Category> categories = new List<Category>();


        [HttpGet]
        public IActionResult GetCategories(string searchvalue = "")
        {
            if (searchvalue != null)
            {
                var foundValue = categories.Where(c => c.Name.Contains(searchvalue, StringComparison.OrdinalIgnoreCase));
                if (foundValue != null)
                {
                    return Ok(ApiResponse<List<Category>>.SuccessResponse(foundValue.ToList(), 200, "Categories return successfull"));

                }
                else
                {
                    return NotFound("Searched value not found");

                }
            }
            return Ok(ApiResponse<List<Category>>.SuccessResponse(categories, 200, "Categories return successfull"));

        }

        [HttpPost]
        public IActionResult CreateCategories(Category categoryData)
        {
            if (string.IsNullOrEmpty(categoryData.Name))
            {
                return BadRequest("Name is required & mendatory");
            }

            var NewCategory1 = new Category
            {
                CateId = Guid.NewGuid(),
                Name = categoryData.Name,
                Description = categoryData.Description,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
            categories.Add(NewCategory1);
            //return Created($"/api/categories/{NewCategory1.CateId}", NewCategory1);
            return Created($"/api/categories/{NewCategory1.CateId}", ApiResponse<Category>.SuccessResponse(NewCategory1, 201, "Categories Post successfull"));
        }

        [HttpPut("{categoryID:guid}")]
        public IActionResult UpdateCategories(Guid categoryID, Category categoryData)
        {
            var findCategory = categories.FirstOrDefault(c => c.CateId == categoryID);
            if (findCategory == null)
            {
                return NotFound("Category id not matched");
            }
            findCategory.Name = categoryData.Name ?? findCategory.Name;
            findCategory.Description = categoryData.Description ?? findCategory.Description;
            findCategory.UpdatedAt = DateTime.UtcNow;
            return Ok(ApiResponse<object>.SuccessResponse(null, 204, "Categories Update successfull"));
        }

        [HttpDelete("{categoryId:guid}")]
        public IActionResult DeleteCategory(Guid categoryId)
        {
            var findCategory = categories.FirstOrDefault(c => c.CateId == categoryId);
            if (findCategory == null)
            {
                return NotFound("Category id not matched");
            }
            categories.Remove(findCategory);
            return Ok(ApiResponse<object>.SuccessResponse(null, 204, "Categories Deleted successfull"));
        }
    }
}
