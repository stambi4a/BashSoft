namespace Executor.Exceptions
{
    using System;

    public class InvalidCommandException : Exception
    {
        public const string InvalidCommandMessage = "The commandName '{0}' is invalid";

        public InvalidCommandException(string input) : base(string.Format(InvalidCommandMessage, input))
        {
        }
    }
}
