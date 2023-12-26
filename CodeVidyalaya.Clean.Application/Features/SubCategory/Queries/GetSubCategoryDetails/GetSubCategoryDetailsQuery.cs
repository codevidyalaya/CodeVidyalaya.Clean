using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetSubCategoryDetails
{
    public class GetSubCategoryDetailsQuery:IRequest<SubCategoryDetailsDto>
    {
        public int Id { get; set; }
    }
}
