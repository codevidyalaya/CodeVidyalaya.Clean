using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<int>
    {
        public string CategoryName { get; set; } 
    }
}
