using OpenQA.Selenium;
using System;
using System.Threading;

namespace Task9
{
    public class AnswerForLetterPage
    {
        private readonly static string answerMessageLineXPath = "/html/body/div[15]/div[2]/div/div[1]/div[2]/div[3]/div[5]/div/div/div[2]/div[1]/div[1]";

        private readonly static string sendButtonXPath = "/html/body/div[15]/div[2]/div/div[2]/div[1]/span[1]/span";

        private IWebElement answerMessageLine;

        private IWebElement sendButton;

        public AnswerForLetterPage(IWebDriver browser)
        {
            if (browser == null)
            {
                throw new Exception("Web driver does not exist");
            }
            answerMessageLine = browser.FindElement(By.XPath(answerMessageLineXPath));
            sendButton = browser.FindElement(By.XPath(sendButtonXPath));
        }

        /// <summary>
        /// This method send answer of message.
        /// </summary>
        /// <param answer="answer"></param>
        /// <returns>message about success</returns>
        public string AnswerToMessage(string answer)
        {
            if(answer == string.Empty)
            {
                throw new Exception("Answer message does not exist");
            }
            answerMessageLine.SendKeys(answer);
            sendButton.Click();
            Thread.Sleep(2000);
            return "Successful answer";
        }
    }
}
