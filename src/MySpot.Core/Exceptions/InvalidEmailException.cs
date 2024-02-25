using MySpot.Core.Exceptions;

namespace MySpot.Infrastructure.Exceptions;

public sealed class InvalidEmailException : CustomException
{
    public string Email { get; set; }

    public InvalidEmailException(string email) : base($"Email: '{email}' is invalid")
    {
        Email = email;
    }
}