using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Commands.UpdateCategory
{
    public class UpdateCategoryCommand :IRequest<Unit>
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
