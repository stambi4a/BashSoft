namespace Executor.Exceptions
{
    using System;

    class DuplicateEntryInStructureException : Exception
    {
        public const string DuplicateEntry = "The {0} already exists in {1}.";

        public DuplicateEntryInStructureException(string entry, string structure) : base(string.Format(DuplicateEntry, entry, structure))
        {
        }

        public DuplicateEntryInStructureException(string message) : base(message)
        {
        }
    }
}
