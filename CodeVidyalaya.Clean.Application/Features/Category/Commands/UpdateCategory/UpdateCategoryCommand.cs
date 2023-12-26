using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand :IRequest<int>
    {
        public int Id { get; set; }
    }
}
