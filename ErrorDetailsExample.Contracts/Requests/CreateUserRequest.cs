using System.Text.Json.Serialization;
using ErrorDetailsExample.Domain.Users.Enums;

namespace ErrorDetailsExample.Contracts.Requests;

public record CreateUserRequest(
    long Id,
    string FirstName,
    string LastName,
    string Email,
    string Password,
    [property: JsonConverter(typeof(JsonStringEnumConverter))]
    SubscriptionType SubscriptionType);