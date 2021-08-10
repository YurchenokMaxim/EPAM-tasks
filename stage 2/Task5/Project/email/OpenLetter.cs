using OpenQA.Selenium;
using System;

namespace Task9
{
    public class OpenLetter
    {
        private IWebDriver browser;

        private IWebDriver Browser
        {
            get
            {
                return browser;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("Web driver does not exist");
                }
                else
                {
                    browser = value;
                }
            }
        }

        private static readonly string nameOfAuthorXPath = "/html/body/div[5]/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div/div/div[2]/div[1]/div[1]/div/div[2]/div[1]/span";

        private static readonly string textOfLetterXPath = "/html/body/div[5]/div/div[1]/div[1]/div/div[2]/span/div[2]/div/div/div/div/div/div/div[2]/div[1]/div[3]/div[2]/div[1]/div/div/div/div/div/div/div/div/div/div[1]";

        public OpenLetter(IWebDriver browser)
        {
            this.Browser = browser;
        }

        /// <summary>
        /// Return text of letter.
        /// </summary>
        /// <param name of author="nameOfAuthor"></param>
        /// <returns>text of letter</returns>
        public string GetTextOfLetter(string nameOfAuthor)
        {
            if (nameOfAuthor == string.Empty)
            {
                throw new Exception("Name of author does not exist");
            }
            string result = "";
            if (browser.FindElement(By.XPath(nameOfAuthorXPath)).Text == nameOfAuthor)
            {
                result = Browser.FindElement(By.XPath(textOfLetterXPath)).Text;
            }
            return result;
        }
    }
}
