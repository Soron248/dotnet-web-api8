using AutoMapper;
using Microsoft.EntityFrameworkCore;
using testapiproject.Controllers;
using testapiproject.Data;
using testapiproject.DTOs;
using testapiproject.Interfaces;
using testapiproject.Models;

namespace testapiproject.Services
{
    public class CategoryService : IntCateServices
    {
        //private static readonly List<Category> _categories = new List<Category>();
        private readonly AppDbContext _appDbContext;
        //mapper added
        public readonly IMapper _mapper;
        public CategoryService(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }


        public async Task<List<CategoryReadDto>> GetAllCategory()
        {
            var categories = await _appDbContext.Categories.ToListAsync();

            return _mapper.Map<List<CategoryReadDto>>(categories);
        }

        public async Task<CategoryReadDto?> GetCategoryById(Guid categoryID)
        {
            var foundCategory = await _appDbContext.Categories.FindAsync(categoryID);
            return foundCategory == null ? null : _mapper.Map<CategoryReadDto>(foundCategory);
        }

        public async Task<CategoryReadDto> CreateCategory(CategoryCreateDto categoryCreate)
        {
            var NewCategory1 = _mapper.Map<Category>(categoryCreate);
            NewCategory1.CateId = Guid.NewGuid();
            NewCategory1.CreatedAt = DateTime.UtcNow;
            NewCategory1.UpdatedAt = DateTime.UtcNow;

            await _appDbContext.Categories.AddAsync(NewCategory1);

            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<CategoryReadDto>(NewCategory1);
        }

        public async Task<CategoryReadDto> UpdateCategory(Guid categoryID, CategoryUpdateDto categoryData)
        {
            var findCategory = await _appDbContext.Categories.FindAsync(categoryID);
            if (findCategory == null)
            {
                return null;
            }

            _mapper.Map(categoryData ,findCategory);

            _appDbContext.Categories.Update(findCategory);
            await _appDbContext.SaveChangesAsync();

            return _mapper.Map<CategoryReadDto>(findCategory);
        }
        public async Task<bool> DeleteCategoryById(Guid categoryID)
        {
            var findCategory = await _appDbContext.Categories.FindAsync(categoryID);
            if (findCategory == null)
            {
                return false;
            }
            _appDbContext.Categories.Remove(findCategory);
            await _appDbContext.SaveChangesAsync();
            return true;
        }

    }
}
