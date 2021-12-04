using System;

namespace NLPI.Services.Exceptions
{
    public sealed class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException() : base("Invalid username or password.") { }
    }
}
