using System.Text.Json.Serialization;
using ErrorDetailsExample.Domain.Users.Enums;

namespace ErrorDetailsExample.Contracts.Responses;

public record UserResponse(
    long Id,
    string FirstName,
    string LastName,
    string Email,
    [property: JsonConverter(typeof(JsonStringEnumConverter))]
    SubscriptionType SubscriptionType);