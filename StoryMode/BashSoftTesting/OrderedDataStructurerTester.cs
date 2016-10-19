using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BashSoftTesting
{
    using System.Collections.Generic;
    using System.Linq;

    using Executor.Data_Structures;
    using Executor.Interfaces;

    
    [TestClass]
    public class OrderedDataStructurerTester
    {
        private ISimpleOrderedBag<string> names;

        [TestInitialize]
        public void SetUp()
        {
            this.names = new SimpleSortedList<string>();
        }

        [TestMethod]
        public void TestEmptyCtor()
        {
            this.names = new SimpleSortedList<string>();
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialCapacity()
        {
            this.names = new SimpleSortedList<string>(20);
            Assert.AreEqual(this.names.Capacity, 20);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithAllParams()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase, 30);
            Assert.AreEqual(this.names.Capacity, 30);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestCtorWithInitialComparer()
        {
            this.names = new SimpleSortedList<string>(StringComparer.OrdinalIgnoreCase);
            Assert.AreEqual(this.names.Capacity, 16);
            Assert.AreEqual(this.names.Size, 0);
        }

        [TestMethod]
        public void TestAddIncreasesSize()
        {
            this.names.Add("Nasko");
            Assert.AreEqual(1, this.names.Size);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestAddNullThrowsException()
        {
            this.names.Add(null);
        }

        [TestMethod]
        public void TestAllUnsortedDataIsHeldSorted()
        {
            this.names.Add("Rosen");
            this.names.Add("Balkan");
            this.names.Add("Georgi");
            Assert.AreEqual("Balkan", this.names.First(), "First name should be Balkan!");
            Assert.AreEqual("Georgi", this.names.Skip(1).First(), "Second name should be Georgi!");
            Assert.AreEqual("Rosen", this.names.Skip(2).First(), "Third name should be Rosen!");
        }

        [TestMethod]
        public void TestAddinElementsMoreThanInitialCapacity()
        {
            for (var i = 0; i < 17; i++)
            {
                this.names.Add("Stani" + i);
            }

            Assert.AreEqual(17, this.names.Size, "Size should be 17!");
            Assert.AreEqual(32, this.names.Capacity, "Capacity should be 32!");

        }

        [TestMethod]
        public void TestAddingAllFRomCollectionIncreasesSize()
        {
            var list = new List<string> { "Iwan", "John" };
            this.names.AddAll(list);
            Assert.AreEqual(2, this.names.Size, "Size should be 2!");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestAddingAllFromNullThrowsException()
        {
            var list = new List<string> { null, null };
            this.names.AddAll(list);
        }

        [TestMethod]
        public void TestAddAllKeepsCollectionSorted()
        {
            var list = new List<string> { "Iwan", "John", "Kamen", "Fred" };
            this.names.AddAll(list);
            Assert.AreEqual("Fred", this.names.First(), "First name should be Fred!");
            Assert.AreEqual("Iwan", this.names.Skip(1).First(), "Second name should be Iwan!");
            Assert.AreEqual("John", this.names.Skip(2).First(), "Third name should be John!");
            Assert.AreEqual("Kamen", this.names.Skip(3).First(), "Last name should be Kamen!");
        }

        [TestMethod]
        public void TestRemoveValidElementDecreasesSize()
        {
            var list = new List<string> { "Iwan", "John", "Kamen", "Fred" };
            this.names.AddAll(list);
            this.names.Remove("John");
            Assert.AreEqual(3, this.names.Size, "Size of list should be 3!");
        }

        [TestMethod]
        public void TestRemoveValidElementRemovesSelectedOne()
        {
            var list = new List<string> { "Iwan", "John", "Kamen", "Fred" };
            this.names.AddAll(list);
            this.names.Remove("John");
            bool containsRemoved = this.names.Contains("John");
            Assert.IsFalse(containsRemoved, "colelction should not cotain removed element!");
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestRemovingNullThrowsException()
        {
            var list = new List<string> { "Iwan", "John", "Kamen", "Fred" };
            this.names.AddAll(list);
            this.names.Remove(null);
        }

        [ExpectedException(typeof(ArgumentNullException))]
        [TestMethod]
        public void TestJoinWithNullthrowsException()
        {
            var list = new List<string> { "Iwan", "John", "Kamen", "Fred" };
            this.names.AddAll(list);
            this.names.JoinWith(null);
        }

        [TestMethod]
        public void TestJoinWorksAsExpected()
        {
            var list = new List<string> { "Iwan", "John", "Kamen", "Fred" };
            this.names.AddAll(list);
            var result = this.names.JoinWith(", ");
            Assert.AreEqual("Fred, Iwan, John, Kamen", result, "Result should return elements joined with \',\'");
        }
    }
}
