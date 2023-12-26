namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetAllSubCategory
{
    public class SubCategoryDto
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Domain.Category? Category { get; set; }
    }
}
