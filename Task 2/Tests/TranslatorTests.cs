using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslationOfNumberSystems;
using System;

namespace TranslatorTests
{
    [TestClass]
    public class TranslatorTests : Translator
    {

        [TestMethod]
        [DataRow(8, 2, "1000")]
        [DataRow(19, 20, "J")]
        [DataRow(115, 10, "115")]
        [DataRow(4, 3, "11")]
        [DataRow(0, 5, "0")]
        public void PositiveTranslatorTest(int number, int baseOfTheNumberSystem, string result)
        {
            Assert.AreEqual(result, TranslateToSystem(number, baseOfTheNumberSystem));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow(1, 0)]
        [DataRow(1, 1)]
        [DataRow(1, 21)]
        [DataRow(0, 0)]
        public void NegativeTranslatorTest(int number, int baseOfTheNumberSystem)
        {
            string result = TranslateToSystem(number, baseOfTheNumberSystem);
        }

    }
}
