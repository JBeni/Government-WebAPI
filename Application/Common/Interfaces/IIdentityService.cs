using GovernmentSystem.Application.Common.Models;
using System.Threading.Tasks;

namespace GovernmentSystem.Application.Common.Interfaces
{
    public interface IIdentityService
    {
        Task<string> GetUserNameAsync(string userId);
        Task<bool> IsInRoleAsync(string userId, string role);
        Task<bool> AuthorizeAsync(string userId, string policyName);
        Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password);
        Task<Result> DeleteUserAsync(string userId);
        //Task<Result> DeleteUserAsync(ApplicationUser user);
    }
}
