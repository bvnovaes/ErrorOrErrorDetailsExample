using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using ErrorDetailsExample.Infrastructure.Repositories;
using ErrorOr;

namespace ErrorDetailsExample.Application.Users.Services;

public class UpdateUserService(IUserRepository userRepository) : IUpdateUserService
{
    public ErrorOr<User> UpdateUser(User user)
    {
        return userRepository.UpdateUser(user);
    }
}