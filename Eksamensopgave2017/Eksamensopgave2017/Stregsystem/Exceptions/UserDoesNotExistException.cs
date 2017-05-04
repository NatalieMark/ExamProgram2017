using System;
namespace Stregsystem
{
    public class UserDoesNotExistException : Exception
    {
        public UserDoesNotExistException() { }

        public UserDoesNotExistException(string message) : base(message) { }

        public UserDoesNotExistException(string message, Exception inner) : base(message, inner) { }
    }
}
