using testapiproject.DTOs;

namespace testapiproject.Interfaces
{
    public interface IntCateServices
    {
        Task<List<CategoryReadDto>> GetAllCategory();
        Task<CategoryReadDto?> GetCategoryById(Guid categoryID);
        Task<CategoryReadDto> CreateCategory(CategoryCreateDto categoryCreate);
        Task<CategoryReadDto> UpdateCategory(Guid categoryID, CategoryUpdateDto categoryData);
        Task<bool> DeleteCategoryById(Guid categoryID);


    }
}
