namespace CodeVidyalaya.Clean.Application.Contracts.Persistence
{
    public interface IUnitOfWork :IDisposable
    {
        ICategoryRepository Category { get; }
        ISubCategoryRepository SubCategory { get; }

        Task Save();
    }
}
