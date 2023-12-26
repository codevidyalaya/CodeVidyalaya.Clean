using AutoMapper;
using CodeVidyalaya.Clean.Application.Features.Category.Commands.CreateCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Commands.UpdateCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Queries.GetAllCategory;
using CodeVidyalaya.Clean.Application.Features.Category.Queries.GetCategoryDetails;
using CodeVidyalaya.Clean.Domain;

namespace CodeVidyalaya.Clean.Application.MappingProfiles
{
    public class CategoryProfile :Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>().ReverseMap();
            CreateMap<Category, CategoryDetailsDto>().ReverseMap();
            CreateMap<CreateCategoryCommand,Category>().ReverseMap();
            CreateMap<UpdateCategoryCommand,Category>().ReverseMap();
        }
    }
}
