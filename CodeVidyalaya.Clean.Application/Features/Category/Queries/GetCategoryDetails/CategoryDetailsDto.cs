using System.ComponentModel.DataAnnotations.Schema;

namespace CodeVidyalaya.Clean.Application.Features.Category.Queries.GetCategoryDetails
{
    public class CategoryDetailsDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public List<Domain.SubCategory>? SubCategories { get; set; }
    }
}
