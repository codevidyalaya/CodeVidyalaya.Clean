namespace CodeVidyalaya.Clean.Application.Features.SubCategory.Queries.GetSubCategoryDetails
{
    public class SubCategoryDetailsDto
    {
        public int Id { get; set; }
        public string SubCategoryName { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public Domain.Category? Category { get; set; }
        public DateTime CeratedDate { get; set; }
    }
}
