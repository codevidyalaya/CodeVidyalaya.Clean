using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Queries.GetAllCategory
{
    public class GetCategoryQuery :IRequest<List<CategoryDto>>
    {
    }
}
