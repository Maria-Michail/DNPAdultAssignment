using Models;
using System.Threading.Tasks;

namespace Assignment.Data {
public interface IUserService {
    Task<User> ValidateUser(string username, string password);
}
}