namespace Executor.Exceptions
{
    using System;

    public class InvalidFileNameException : Exception
    {
        public const string ForbiddenSymbolsContainedInName = "The given name contains symbols that are not allowed to be used in names of files or folders.";

        public InvalidFileNameException() : base(ForbiddenSymbolsContainedInName)
        {
        }

        public InvalidFileNameException(string message) : base(message)
        {
        }
    }
}
