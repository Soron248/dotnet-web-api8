using AutoMapper;
using testapiproject.DTOs;
using testapiproject.Models;

namespace testapiproject.Profiles
{
    public class CategoryProfile: Profile
    {
        public CategoryProfile() 
        {
            CreateMap<Category, CategoryReadDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdateDto, Category>();
        }
    }
}
