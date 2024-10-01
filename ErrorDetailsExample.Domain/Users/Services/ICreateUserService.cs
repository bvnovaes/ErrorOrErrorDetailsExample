using ErrorOr;

namespace ErrorDetailsExample.Domain.Users.Services;

public interface ICreateUserService
{
    ErrorOr<User> CreateUser(User user);
}