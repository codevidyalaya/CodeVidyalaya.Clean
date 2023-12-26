using CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetAllSubCategory;
using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Queries.GetAllSubCategory
{
    public class GetSubCategoryQuery : IRequest<List<SubCategoryDto>>
    {
    }
}
