using System;
using System.Collections.Generic;

namespace TranslationOfNumberSystems
{
    public class Translator
    {
        static private Dictionary<int, string> Symbols = new Dictionary<int, string>
        {
            {0, "0" }, {1, "1" }, {2, "2" }, {3, "3" }, {4, "4" }, {5, "5" }, {6, "6" }, {7, "7" }, {8, "8" }, {9, "9" },
            {10, "A" }, {11, "B" }, {12, "C" }, {13, "D" }, {14, "E" },  {15, "F" }, {16, "G" }, {17, "H" }, {18, "I" }, {19, "J" }
        };

        /// <summary>
        /// This method converts numbers from decimal system to specified
        /// </summary>
        /// <param This number will translate="number"></param>
        /// <param The base of the number system="baseOfTheNumberSystem"></param>
        /// <returns>Return number in new number system.</returns>
        public static string TranslateToSystem(int number, int baseOfTheNumberSystem)
        {

            if (baseOfTheNumberSystem <= 1 || baseOfTheNumberSystem > 20)
            {
                throw new Exception("The Base Of Number System can't be less than one and more than 20");
            }

            if (number < 0)
            {
                throw new Exception("The Number can't be negative");
            }

            string result = string.Empty;

            if (number == 0)
            {
                result = "0";
            }
            else
            {
                while (number != 0)
                {
                    result = result.Insert(0, Symbols[number % baseOfTheNumberSystem].ToString());
                    number = number / baseOfTheNumberSystem;
                }
            }
            return result;
        }

        static void Main(string[] args)
        {
        }
    }
}
