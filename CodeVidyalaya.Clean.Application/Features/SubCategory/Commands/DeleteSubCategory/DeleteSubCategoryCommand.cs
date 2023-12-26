using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.DeleteSubCategory
{
    public class DeleteSubCategoryCommand :IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
