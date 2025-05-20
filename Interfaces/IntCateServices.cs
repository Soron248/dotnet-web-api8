using testapiproject.DTOs;

namespace testapiproject.Interfaces
{
    public interface IntCateServices
    {
        List<CategoryReadDto> GetAllCategory();
        CategoryReadDto? GetCategoryById(Guid categoryID);
        CategoryReadDto CreateCategory(CategoryCreateDto categoryCreate);
        CategoryReadDto UpdateCategory(Guid categoryID, CategoryUpdateDto categoryData);
        bool DeleteCategoryById(Guid categoryID);


    }
}
