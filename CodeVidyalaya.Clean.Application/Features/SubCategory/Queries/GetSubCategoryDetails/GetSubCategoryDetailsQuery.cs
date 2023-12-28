using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetSubCategoryDetails
{
    public record GetSubCategoryDetailsQuery(int Id) :IRequest<SubCategoryDetailsDto>;
    
}
