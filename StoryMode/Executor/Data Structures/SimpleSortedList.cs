namespace Executor.Data_Structures
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Executor.Interfaces;
    public class SimpleSortedList<T> : ISimpleOrderedBag<T> where T: IComparable<T>
    {
        private const int DefaultSize = 16;
        private T[] innerCollection;
        private int size;
        private IComparer<T> comparer;

        public SimpleSortedList(IComparer<T> comparer, int capacity)
        {
            this.comparer = comparer;
            this.InitializeInnerCollection(capacity);
        }

        public SimpleSortedList(int capacity)
            : this(Comparer<T>.Create((x, y) => x.CompareTo(y)), capacity)
        {            
        }

        public SimpleSortedList(IComparer<T> comparer)
            : this(comparer, DefaultSize)
        {
        }

        public SimpleSortedList()
           : this(Comparer<T>.Create((x, y)=>x.CompareTo(y)), DefaultSize)
        {
        }

        public int Capacity => this.innerCollection.Length;

        public int Size => this.size;

        public void Add(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }
            if (this.Size >= this.innerCollection.Length - 1)
            {
                this.MultiResize(new List<T> {element});
            }

            this.innerCollection[this.size] = element;
            this.size++;
            Array.Sort(this.innerCollection, 0, this.size, this.comparer);
        }

        public void AddAll(IEnumerable<T> elements)
        {
            if (elements == null)
            {
                throw new ArgumentNullException();
            }

            if (this.Size + elements.Count() >= this.innerCollection.Length)
            {
                this.MultiResize(elements);
            }

            foreach (var element in elements)
            {
                if (element == null)
                {
                    throw new ArgumentNullException();
                }
                this.innerCollection[this.Size] = element;
                this.size++;
            }

            Array.Sort(this.innerCollection, 0, this.Size, this.comparer);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Size; i++)
            {
                yield return this.innerCollection[i];
            }
        }

        public string JoinWith(string joiner)
        {
            if (joiner == null)
            {
                throw new ArgumentNullException();
            }
            var builder = new StringBuilder();
            foreach (var element in this)
            {
                builder.Append(element);
                builder.Append(joiner);
            }

            builder.Remove(builder.Length - joiner.Length, joiner.Length);

            return builder.ToString();
        }
        public bool Remove(T element)
        {
            if (element == null)
            {
                throw new ArgumentNullException();
            }

            bool hasBeenRemoved = false;
            int indexOfRemovedElement = 0;
            for (var i = 0; i < this.Size; i++)
            {
                if (this.innerCollection[i].Equals(element))
                {
                    indexOfRemovedElement = i;
                    this.innerCollection[i] = default(T);
                    hasBeenRemoved = true;
                    break;
                } 
            }

            if (hasBeenRemoved)
            {
                for (var i = indexOfRemovedElement; i < this.Size - 1; i++)
                {
                    this.innerCollection[i] = this.innerCollection[i + 1];
                }

                this.innerCollection[this.Size - 1] = default(T);
            }

            this.size--;
            return hasBeenRemoved;
        }


        private void InitializeInnerCollection(int capacity)
        {
            if (capacity < 0)
            {
                throw new ArgumentException("Capacity cannot be negative!");
            }

            this.innerCollection = new T[capacity];
        }

        private void MultiResize(IEnumerable<T> elements)
        {
            int newSize = this.innerCollection.Length * 2;
            while (this.Size + elements.Count() >= newSize)
            {
                newSize *= 2;
            }

            var newCollection = new T[newSize];
            Array.Copy(this.innerCollection, newCollection, this.Size);
            this.innerCollection = newCollection;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
