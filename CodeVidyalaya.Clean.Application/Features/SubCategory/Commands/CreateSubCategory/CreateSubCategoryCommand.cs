using MediatR;

namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Commands.CreateSubCategory
{
    public class CreateSubCategoryCommand :IRequest<Unit>
    {
        public int CategoryId { get; set; }
        public string SubCategoryName { get; set; } = string.Empty;
    }
}
