using Microsoft.VisualStudio.TestTools.UnitTesting;
using Uniqueness;
using System;

namespace UniquenessTests
{
    [TestClass]
    public class UniquenessOfSymbolsTests : UniquenessOfSymbols
    {
        [TestMethod]
        [DataRow(-1, 0)]
        [DataRow(0, 0)]
        [DataRow(0, -1)]
        public void CompareResultAndMax_TestMethod(int value1, int value2)
        {
            int result;
            if (value1 >= value2)
            {
                result = value1;
            }
            else
            {
                result = value2;
            }
            value2 = GetMaximumOfNumbers(value1, value2);
            Assert.AreEqual(result, value2);
        }

        [TestMethod]
        [DataRow("sdab", 'a', 5, false, false)]
        [DataRow("sdb", 'a', 5, false, true)]
        [DataRow("sdab", 'a', 5, true, false)]
        [DataRow("sdb", 'a', 5, true, true)]
        [DataRow("Asdb", 'a', 5, true, true)]
        [DataRow("sdb", 'a', 5, true, true)]
        public void PositiveTestMethodOfUniqueness(string str, char mass, int sum, bool uniqueness, bool TrueUniqueness)
        {
            char[] symbols = str.ToCharArray();
            uniqueness = GetUniquenessOfSymbol(symbols, mass, uniqueness);
            Assert.AreEqual(TrueUniqueness, uniqueness);
        }

        [TestMethod]
        [DataRow("abcdAAkl", 5)]
        [DataRow(" ", 1)]
        [DataRow("abccdfgh", 5)]
        public void TestOfNonRepeatUniquness(string entry, int result)
        {
            Assert.AreEqual(GetNumberOfNoRepeatSymbols(entry), result);
        }


        [TestMethod]
        [DataRow("abcdAAkl", 5)]
        [DataRow(" ", 1)]
        [DataRow("abcdabcdefg", 4)]
        [DataRow("abcadefg", 4)]
        public void PositiveTestOfAbsoluteUniqueness(string entry, int result)
        {
            Assert.AreEqual(GetLengthOfAbsoluteUniquenessLine(entry), result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow("")]
        public void NegativeTestOfAbsoluteUniqueness(string entry)
        {
            int result = GetLengthOfAbsoluteUniquenessLine(entry);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow("")]
        public void NegativeTestOfNonRepeatUniquness(string entry)
        {
            int result = GetNumberOfNoRepeatSymbols(entry);
        }
    }
}
