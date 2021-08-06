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
        public void PositiveCompareResultAndMax(int value1, int value2)
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
        public void PositiveTestOfNonRepeatUniquness(string entry, int result)
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

        [TestMethod]
        [DataRow("A", 1)]
        [DataRow("Z", 1)]
        [DataRow("a", 1)]
        [DataRow("Z", 1)]
        [DataRow("AAADDDD", 4)]
        [DataRow("AA111FFF", 3)]
        public void PositiveTestOfGetLengthOfLineOfIdenticalLatinLetters(string entry, int result)
        {
            Assert.AreEqual(GetLengthOfLineOfIdenticalLatinLetters(entry), result);
        }

        [TestMethod]
        [DataRow("0", 1)]
        [DataRow("9", 1)]
        [DataRow("2224444", 4)]
        [DataRow("33gg777", 3)]
        public void PositiveTestOfGetLengthOfLineOfIdenticalNumbers(string entry, int result)
        {
            Assert.AreEqual(GetLengthOfLineOfIdenticalNumbers(entry), result);
        }
    }
}
