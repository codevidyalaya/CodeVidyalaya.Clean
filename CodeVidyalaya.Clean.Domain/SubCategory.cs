using CodeVidyalaya.Clean.Domain.Common;

namespace CodeVidyalaya.Clean.Domain;

public class SubCategory : BaseEntity
{
    public string SubCategoryName { get; set; } = string.Empty;

    //Foreign
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
