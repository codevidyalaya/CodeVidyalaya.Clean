using AutoMapper;
using CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.CreateSubCategory;
using CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.UpdateSubCategory;
using CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetAllSubCategory;
using CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetSubCategoryDetails;
using CodeVidyalaya.Clean.Domain;

namespace CodeVidyalaya.Clean.Application.MappingProfiles
{
    public class SubCategoryProfile : Profile
    {
        public SubCategoryProfile()
        {
            CreateMap<SubCategoryDto, SubCategory>().ReverseMap();
            CreateMap<SubCategory, SubCategoryDetailsDto>().ReverseMap();
            CreateMap<CreateSubCategoryCommand, SubCategory>().ReverseMap();
            CreateMap<UpdateSubCategoryCommand, SubCategory>().ReverseMap();
        }
    }
}
