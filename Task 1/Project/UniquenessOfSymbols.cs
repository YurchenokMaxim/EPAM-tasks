using System;

namespace Uniqueness
{
    public class UniquenessOfSymbols
    {
        /// <summary>
        /// Method of assigning the largest value of two.
        /// </summary>
        /// <param  first value = "value1"></param>
        /// <param  second value = "value2"></param>
        protected static int GetMaximumOfNumbers(int value1, int value2)
        {
            if (value1 > value2)
            {
                return value1;
            }
            return value2;
        }

        /// <summary>
        /// Method for determining the uniqueness of a symbol and return bool variable uniqueness.
        /// </summary>
        /// <param massiv of saved symbols = "symbols"></param>
        /// <param  Symbol that will research = "symbol"></param>
        /// <param counter = "sum"></param>
        /// <param uniqueness of symbol in this lyne = "uniqueness"></param>
        protected static bool GetUniquenessOfSymbol(char[] symbols, char symbol, bool uniqueness)
        {
            for (int index = 0; index < symbols.Length; index++)
            {
                if (symbol == symbols[index])
                {
                    uniqueness = false;
                    break;
                }
                else
                {
                    uniqueness = true;
                }
            }
            return uniqueness;
        }

        /// <summary>
        /// This method find the largest sequence of non repeat symbols and return length of this.
        /// </summary>
        /// <param Line with different symbols="entry"></param>
        /// <returns>Return a length of the largest line that this method find.</returns>
        public static int GetNumberOfNoRepeatSymbols(string entry)
        {

            if (String.IsNullOrEmpty(entry))
            {
                throw new Exception("The input data has zero length or equals null");
            }

            char[] line = entry.ToCharArray();
            int result = 1;
            int sum = 1;
            for (int index = 1; index < entry.Length; index++)
            {
                if (line[index] != line[index - 1])
                {
                    sum++;
                }
                else
                {
                    if (sum > result)
                    {
                        result = sum;
                        sum = 1;
                    }
                }
            };
            result = GetMaximumOfNumbers(sum, result);
            return result;
        }

        /// <summary>
        /// This method find the largest absolute uniqueness sequence of symbols in line and return length of this.
        /// </summary>
        /// <param Line with different symbols ="entry"></param>
        /// <returns>Return a length of the largest absolute uniqueness line that this method find.</returns>
        public static int GetLengthOfAbsoluteUniquenessLine(string entry)
        {
            if (String.IsNullOrEmpty(entry))
            {
                throw new Exception("The input data has zero length or equals null");
            }

            int sum = 0;
            int result = 1;
            bool uniqueness = true;
            int counter = 0;
            char[] symbols = new char[entry.Length + 1];
            char[] line = entry.ToCharArray();

            for (int index = 0; index < line.Length; index++)
            {
                uniqueness = GetUniquenessOfSymbol(symbols, line[index], uniqueness);
                if (!uniqueness)
                {
                    sum = 0;
                }
                else
                if (uniqueness)
                {
                    symbols[counter] = line[index];
                    counter++;
                    sum++;
                }

                result = GetMaximumOfNumbers(sum, result);
                uniqueness = true;
            }

            result = GetMaximumOfNumbers(sum, result);
            return result;
        }

        static void Main(string[] args)
        {
            try
            {
                string entry = args[0];

                //The first block of code that is responsible for the absence of duplicate characters
                int result = GetNumberOfNoRepeatSymbols(entry);
                Console.WriteLine($"The answer in the first block of code  {result}");

                //The second block of code, which is responsible for the complete uniqueness of the row
                result = GetLengthOfAbsoluteUniquenessLine(entry);
                Console.WriteLine($"The answer in the second block of code  {result}");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}