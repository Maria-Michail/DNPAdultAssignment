using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Models;

namespace WebApi.Data
{
    public interface IUserService
    {
        Task<IList<User>> allUsersAsync();
        Task<User> ValidateUser(string userName, string passWord);
    }
}