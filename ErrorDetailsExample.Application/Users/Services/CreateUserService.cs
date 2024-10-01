using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using ErrorDetailsExample.Infrastructure.Repositories;
using ErrorOr;

namespace ErrorDetailsExample.Application.Users.Services;

public class CreateUserService(IUserRepository userRepository) : ICreateUserService
{
    public ErrorOr<User> CreateUser(User user)
    {
        return userRepository.AddUser(user);
    }
}
