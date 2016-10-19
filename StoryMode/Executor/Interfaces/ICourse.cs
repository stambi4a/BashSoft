namespace Executor.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Executor.Models;

    public interface ICourse : IComparable<ICourse>
    {
        string Name { get; }

        IReadOnlyDictionary<string, IStudent> StudentsByName { get; }

        void EnrollStudent(IStudent student);
    }
}
