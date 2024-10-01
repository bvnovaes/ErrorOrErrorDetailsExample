using ErrorDetailsExample.Domain.Users;
using ErrorDetailsExample.Domain.Users.Services;
using ErrorDetailsExample.Infrastructure.Repositories;
using ErrorOr;

namespace ErrorDetailsExample.Application.Users.Services;

public class DeleteUserService(IUserRepository userRepository) : IDeleteUserService
{
    public ErrorOr<User> DeleteUser(long id)
    {
        return userRepository.DeleteUser(id);
    }
}