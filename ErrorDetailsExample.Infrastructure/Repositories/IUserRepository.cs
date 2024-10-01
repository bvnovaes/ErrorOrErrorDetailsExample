using ErrorDetailsExample.Domain.Users;
using ErrorOr;

namespace ErrorDetailsExample.Infrastructure.Repositories;

public interface IUserRepository
{
    ErrorOr<User> GetUserById(long id);
    ErrorOr<List<User>> GetAllUsers();
    ErrorOr<User> AddUser(User user);
    ErrorOr<User> UpdateUser(User user);
    ErrorOr<User> DeleteUser(long id);
}