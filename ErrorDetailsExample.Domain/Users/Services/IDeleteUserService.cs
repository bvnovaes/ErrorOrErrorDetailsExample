using ErrorOr;

namespace ErrorDetailsExample.Domain.Users.Services;

public interface IDeleteUserService
{
    ErrorOr<User> DeleteUser(long id);
}