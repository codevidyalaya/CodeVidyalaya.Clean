using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.UpdateSubCategory
{
    public class UpdateSubCategoryCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
