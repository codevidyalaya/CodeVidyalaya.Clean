using CodeVidyalaya.Clean.Domain.Common;

namespace CodeVidyalaya.Clean.Domain;

public class Category : BaseEntity
{
    
    public string CategoryName { get; set; } = string.Empty;

    // Navigation property
    public List<SubCategory>? Subcategories { get; set; }
}