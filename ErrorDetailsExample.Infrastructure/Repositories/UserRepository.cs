using ErrorDetailsExample.Domain.Users;
using ErrorOr;

namespace ErrorDetailsExample.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private static List<User> _users = [];

    public ErrorOr<User> GetUserById(long id)
    {
        var user = _users.FirstOrDefault(x => x.Id == id);

        return user is not null
            ? user
            : Error.NotFound(description: "Usuário não encontrado");
    }

    public ErrorOr<List<User>> GetAllUsers()
    {
        return _users;
    }

    public ErrorOr<User> AddUser(User user)
    {
        if (_users.Any(x => x.Id == user.Id))
        {
            return Error.Conflict(description: "Usuário já existe");
        }

        _users.Add(user);
        return user;
    }

    public ErrorOr<User> UpdateUser(User user)
    {
        User? existingUser = _users.FirstOrDefault(u => u.Id == user.Id);

        if (existingUser is null)
        {
            return Error.NotFound(description: "Usuário não encontrado");
        }

        existingUser.FirstName = user.FirstName;
        existingUser.LastName = user.LastName;
        existingUser.Email = user.Email;
        existingUser.Password = user.Password;
        existingUser.SubscriptionType = user.SubscriptionType;

        return existingUser;
    }

    public ErrorOr<User> DeleteUser(long id)
    {
        User? existingUser = _users.FirstOrDefault(u => u.Id == id);
        if (existingUser is null)
        {
            return Error.NotFound(description: "Usuário não encontrado");
        }

        _users.Remove(existingUser);
        return existingUser;
    }
}