using ErrorDetailsExample.Domain.Users.Enums;

namespace ErrorDetailsExample.Domain.Users;

public record User
{
    public long Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
    public SubscriptionType SubscriptionType { get; set; } = SubscriptionType.Basic;
}