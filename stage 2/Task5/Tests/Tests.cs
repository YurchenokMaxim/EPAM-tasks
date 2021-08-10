using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using OpenQA.Selenium;
using System.Threading;

namespace Task9
{
    [TestClass]
    public class Tests : EntryPoint
    {
        [TestMethod]
        [DataRow("experimentalaccount1@mail.ru", "Y)ppiiklPB13")]
        [DataRow("experimentalaccount2@mail.ru", "tPTTRkpyt42#")]
        public void PositiveTestOfComeInToEmail(string login, string password)
        {
            IWebDriver browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ComeInToEmail(browser, login, password);
            MainPageOfEmail mainPage = new MainPageOfEmail(browser);
            string result = browser.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;

            Assert.AreEqual(result, login);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        [DataRow("", "tPTTRkpyt42")]
        [DataRow("experimentalaccount2@mail.ru", "")]
        public void NegativeTestOfComeInToEmail(string login, string password)
        {
            IWebDriver browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            browser.Manage().Window.Maximize();
            ComeInToEmail(browser, login, password);
            MainPageOfEmail mainPage = new MainPageOfEmail(browser);
            string result = browser.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;

            Assert.AreEqual(result, login);
        }

        [TestMethod]
        [ExpectedException(typeof(ElementNotInteractableException))]
        [DataRow("experimentalaccount", "Y)ppiiklPB13")]
        public void NegativeTestOfComeInToEmailNoSuchElementException(string login, string password)
        {
            IWebDriver browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            browser.Manage().Window.Maximize();
            ComeInToEmail(browser, login, password);
            MainPageOfEmail mainPage = new MainPageOfEmail(browser);
            string result = browser.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;

            Assert.AreEqual(result, login);
        }

        [TestMethod]
        [ExpectedException(typeof(NoSuchElementException))]
        [DataRow("experimentalaccount2@mail.ru", "tPTTRkpyt42")]
        public void NegativeTestOfComeInToEmailNotInteractableException(string login, string password)
        {
            IWebDriver browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            browser.Manage().Window.Maximize();
            ComeInToEmail(browser, login, password);
            MainPageOfEmail mainPage = new MainPageOfEmail(browser);
            string result = browser.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;

            Assert.AreEqual(result, login);
        }

        [TestMethod]
        public void PositiveTestOdSendLetter()
        {
            IWebDriver browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            browser.Manage().Window.Maximize();
            string name1 = "experimentalaccount1@mail.ru";
            string password1 = "Y)ppiiklPB13";
            string name2 = "experimentalaccount2@mail.ru";
            string password2 = "tPTTRkpyt42#";

            ComeInToEmail(browser, name1, password1);
            MainPageOfEmail mainPage = new MainPageOfEmail(browser);
            SendMessage(browser, name2, "Something");
            Thread.Sleep(2000);
            ExitFromEmail(mainPage);
            ComeInToEmail(browser, name2, password2);
            string result = GetMessageOfLetter(browser, "Максим Юрченок");

            Assert.AreEqual("Something", result);
        }

        [TestMethod]
        public void PositiveTestOfChangeNickname()
        {
            IWebDriver browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();
            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            string name1 = "experimentalaccount1@mail.ru";
            string password1 = "Y)ppiiklPB13";
            string name2 = "experimentalaccount2@mail.ru";
            string password2 = "tPTTRkpyt42#";

            ComeInToEmail(browser, name1, password1);
            MainPageOfEmail mainPage = new MainPageOfEmail(browser);
            SendMessage(browser, name2, "Something");
            Thread.Sleep(2000);
            ExitFromEmail(mainPage);
            ComeInToEmail(browser, name2, password2);
            AnswerMessage(browser, "Maxim Yurchenok");
            Thread.Sleep(2000);
            ExitFromEmail(mainPage);
            ComeInToEmail(browser, name1, password1);
            string result = GetMessageOfLetter(browser, "Максим Юрченок");
            ChangeNickname(browser, result);
            result = (browser.FindElement(By.Id("nickname"))).Text;
            Assert.AreEqual("Maxim Yurchenok", result);
        }
    }
}