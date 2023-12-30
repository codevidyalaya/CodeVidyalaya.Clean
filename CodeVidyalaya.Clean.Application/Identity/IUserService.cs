using CodeVidyalaya.Clean.Application.Models.Identity;

namespace CodeVidyalaya.Clean.Application.Identity
{
    public interface IUserService
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployee(string userId);
    }
}
