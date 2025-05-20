using AutoMapper;
using testapiproject.Controllers;
using testapiproject.DTOs;
using testapiproject.Interfaces;
using testapiproject.Models;

namespace testapiproject.Services
{
    public class CategoryService : IntCateServices
    {
        private static readonly List<Category> _categories = new List<Category>();

        public readonly IMapper _mapper;
        public CategoryService(IMapper mapper)
        {
            _mapper = mapper;
        }


        public List<CategoryReadDto> GetAllCategory()
        {
            return _mapper.Map<List<CategoryReadDto>>(_categories);
        }

        public CategoryReadDto? GetCategoryById(Guid categoryID)
        {
            var foundCategory = _categories.FirstOrDefault(c => c.CateId == categoryID);
            return foundCategory == null ? null : _mapper.Map<CategoryReadDto>(foundCategory);
        }

        public CategoryReadDto CreateCategory(CategoryCreateDto categoryCreate)
        {
            var NewCategory1 = _mapper.Map<Category>(categoryCreate);
            NewCategory1.CateId = Guid.NewGuid();
            NewCategory1.CreatedAt = DateTime.UtcNow;
            NewCategory1.UpdatedAt = DateTime.UtcNow;

            _categories.Add(NewCategory1);

            return _mapper.Map<CategoryReadDto>(NewCategory1);
        }

        public CategoryReadDto UpdateCategory(Guid categoryID, CategoryUpdateDto categoryData)
        {
            var findCategory = _categories.FirstOrDefault(c => c.CateId == categoryID);
            if (findCategory == null)
            {
                return null;
            }

            _mapper.Map(categoryData ,findCategory);
            return _mapper.Map<CategoryReadDto>(findCategory);
        }
        public bool DeleteCategoryById(Guid categoryID)
        {
            var findCategory = _categories.FirstOrDefault(c => c.CateId == categoryID);
            if (findCategory == null)
            {
                return false;
            }
            _categories.Remove(findCategory);
            return true;
        }

    }
}
