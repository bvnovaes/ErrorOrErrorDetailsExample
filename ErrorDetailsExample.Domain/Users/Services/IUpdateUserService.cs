using ErrorOr;

namespace ErrorDetailsExample.Domain.Users.Services;

public interface IUpdateUserService
{
    ErrorOr<User> UpdateUser(User user);
}