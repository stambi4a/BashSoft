namespace Executor.Exceptions
{
    using System;

    public class KeyNotFoundException : Exception
    {
        public const string NotEnrolledInCourse = "Student must be enrolled in a course before you set his mark.";

        public KeyNotFoundException() : base(NotEnrolledInCourse)
        {
        }

        public KeyNotFoundException(string message) : base(message)
        {
        }
    }
}
