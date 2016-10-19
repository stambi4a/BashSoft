namespace Executor.Interfaces
{
    using System;
    using System.Collections.Generic;

    public interface ISimpleOrderedBag<T> : IEnumerable<T> where T : IComparable<T>
    {
        bool Remove(T element);

        int Capacity { get; }

        int Size { get; }

        void Add(T element);

        void AddAll(IEnumerable<T> elements);

        string JoinWith(string joiner);
    }
}
