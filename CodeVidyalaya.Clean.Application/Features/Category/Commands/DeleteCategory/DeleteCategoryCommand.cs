using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand :IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
