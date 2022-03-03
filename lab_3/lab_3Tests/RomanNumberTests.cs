using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass()]
    public class RomanNumberTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            string expected = "IV";
            RomanNumber real = new RomanNumber(4);

            Assert.AreEqual(expected, real.ToString());
        }

        [TestMethod()]
        public void ToStringTest1()
        {
            string expected = "CIX";
            RomanNumber real = new RomanNumber(109);

            Assert.AreEqual(expected, real.ToString());
        }

        [TestMethod()]
        public void CloneTest()
        {
            RomanNumber number_1 = new RomanNumber(10);
            RomanNumber number_2 = (RomanNumber)number_1.Clone();

            Assert.IsTrue(number_1.CompareTo(number_2) == 0);
        }

        [TestMethod()]
        public void CompareToTest()
        {
            int expected = 0;
            RomanNumber number_1 = new RomanNumber(1);
            RomanNumber number_2 = new RomanNumber(1);

            int real = number_1.CompareTo(number_2);

            Assert.AreEqual(expected, real);
        }

        [TestMethod()]
        public void CompareToTest1()
        {
            int expected = 1;
            RomanNumber number_1 = new RomanNumber(2);
            RomanNumber number_2 = new RomanNumber(1);

            int real = number_1.CompareTo(number_2);

            Assert.AreEqual(expected, real);
        }

        [TestMethod()]
        public void CompareToTest2()
        {
            int expected = -1;
            RomanNumber number_1 = new RomanNumber(1);
            RomanNumber number_2 = new RomanNumber(2);

            int real = number_1.CompareTo(number_2);

            Assert.AreEqual(expected, real);
        }

        [TestMethod()]
        public void AddTest()
        {
            RomanNumber number_1 = new RomanNumber(1);
            RomanNumber number_2 = new RomanNumber(2);
            RomanNumber expected = new RomanNumber(3);

            int real = (number_1 + number_2).CompareTo(expected);

            Assert.AreEqual(0, real);
        }

        [TestMethod()]
        public void AddTest1()
        {
            RomanNumber number_1 = new RomanNumber(1);
            RomanNumber number_2 = null;

            Assert.ThrowsException<ArgumentNullException>(() => number_1 + number_2);
        }

        [TestMethod()]
        public void SubTest()
        {
            RomanNumber number_1 = new RomanNumber(3);
            RomanNumber number_2 = new RomanNumber(1);
            RomanNumber expected = new RomanNumber(2);

            int real = (number_1 - number_2).CompareTo(expected);

            Assert.AreEqual(0, real);
        }

        [TestMethod()]
        public void SubTest1()
        {
            RomanNumber number_1 = new RomanNumber(3);
            RomanNumber number_2 = null;

            Assert.ThrowsException<ArgumentNullException>(() => number_1 - number_2);
        }

        [TestMethod()]
        public void SubTest2()
        {
            RomanNumber number_1 = new RomanNumber(3);
            RomanNumber number_2 = new RomanNumber(5);

            Assert.ThrowsException<RomanNumberException>(() => number_1 - number_2);
        }

        [TestMethod()]
        public void MulTest()
        {
            RomanNumber number_1 = new RomanNumber(3);
            RomanNumber number_2 = new RomanNumber(5);
            RomanNumber expected = new RomanNumber(15);

            int real = (number_1 * number_2).CompareTo(expected);

            Assert.AreEqual(0, real);
        }

        [TestMethod()]
        public void MulTest1()
        {
            RomanNumber number_1 = new RomanNumber(3);
            RomanNumber number_2 = null;

            Assert.ThrowsException<ArgumentNullException>(() => number_1 * number_2);
        }

        [TestMethod()]
        public void DivTest()
        {
            RomanNumber number_1 = new RomanNumber(15);
            RomanNumber number_2 = new RomanNumber(5);
            RomanNumber expected = new RomanNumber(3);

            int real = (number_1 / number_2).CompareTo(expected);

            Assert.AreEqual(0, real);
        }

        [TestMethod()]
        public void DivTest1()
        {
            RomanNumber number_1 = new RomanNumber(3);
            RomanNumber number_2 = null;

            Assert.ThrowsException<ArgumentNullException>(() => number_1 / number_2);
        }

        [TestMethod()]
        public void DivTest2()
        {
            RomanNumber number_1 = new RomanNumber(15);
            RomanNumber number_2 = new RomanNumber(16);

            Assert.ThrowsException<RomanNumberException>(() => number_1 / number_2);
        }

        [TestMethod()]
        public void RomanNumberTest()
        {
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumber(0));
        }

        [TestMethod()]
        public void RomanNumberTest1()
        {
            Assert.IsNotNull(new RomanNumber(1));
        }

        [TestMethod()]
        public void RomanNumberTest2()
        {
            Assert.ThrowsException<RomanNumberException>(() => new RomanNumber(5013));
        }
    }
}