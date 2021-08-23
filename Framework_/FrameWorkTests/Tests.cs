using System;
using OpenQA.Selenium;
using NUnit.Framework;
using CategoryAttribute = NUnit.Framework.CategoryAttribute;
using Assert = NUnit.Framework.Assert;
using TestContext = NUnit.Framework.TestContext;
using NUnit.Framework.Interfaces;
using System.Threading;

namespace Framework_
{
    [TestFixture]
    public class Tests : Steps
    {
        private IWebDriver driver;

        private User user1;

        private User user2;

        [SetUp]
        public void Setup()
        {
            driver = new OpenQA.Selenium.Chrome.ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Manage().Window.Maximize();
            user1 = UserCreator.GetFirstUser();
            user2 = UserCreator.GetSecondUser();
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == ResultState.Failure.Status)
            {
                ScreenshotMaker.MakeScreenshot(driver);
            }
            driver.Quit();
        }

        [Category("All")]
        [Category("Smoke")]
        [TestCase("experimentalaccount1@mail.ru", "Y)ppiiklPB13")]
        [TestCase("experimentalaccount2@mail.ru", "tPTTRkpyt42#")]
        public void PositiveTestOfComeInToEmail(string login, string password)
        {
            User user = new User(login, password);
            ComeInToEmail(driver, user.username, user.password);
            MainPageOfEmail mainPage = new MainPageOfEmail(driver);
            string result = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;
            Assert.AreEqual(result, user.username);
        }

        [Test]
        [Category("All")]
        public void PositiveTestOfSendLetter()
        {
            string name1 = "experimentalaccount1@mail.ru";
            string password1 = "Y)ppiiklPB13";
            string name2 = "experimentalaccount2@mail.ru";
            string password2 = "tPTTRkpyt42#";

            ComeInToEmail(driver, name1, password1);
            MainPageOfEmail mainPage = new MainPageOfEmail(driver);
            SendMessage(driver, name2, "Something");
            Thread.Sleep(2000);
            ExitFromEmail(mainPage);
            ComeInToEmail(driver, name2, password2);
            string result = GetMessageOfLetter(driver, "Максим Юрченок");

            Assert.AreEqual("Something", result);
        }

        [Test]
        [Category("All")]
        public void PositiveTestOfChangeNickname()
        {
            ComeInToEmail(driver, user1.username, user1.password);
            MainPageOfEmail mainPage = new MainPageOfEmail(driver);
            SendMessage(driver, user2.username, "Something");
            Thread.Sleep(2000);
            ExitFromEmail(mainPage);
            ComeInToEmail(driver, user2.username, user2.password);
            AnswerMessage(driver, "Maxim Yurchenok");
            Thread.Sleep(2000);
            ExitFromEmail(mainPage);
            ComeInToEmail(driver, user1.username, user1.password);
            string result = GetMessageOfLetter(driver, "Максим Юрченок");
            ChangeNickname(driver, result);
            result = (driver.FindElement(By.XPath("//*[@id='nickname']"))).GetAttribute("Value");
            Assert.AreEqual("Maxim Yurchenok", result);
        }

        [Category("All")]
        [Category("Smoke")]
        [TestCase("", "tPTTRkpyt42")]
        [TestCase("experimentalaccount2@mail.ru", "")]
        public void NegativeTestOfComeInToEmail(string login, string password)
        {
            try
            {
                ComeInToEmail(driver, login, password);
                MainPageOfEmail mainPage = new MainPageOfEmail(driver);
                string result = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;

            }
            catch (Exception ex)
            {
                Assert.AreEqual(ex.Message, "Login or password does not exist");
            }
        }

        [Category("All")]
        [Category("Smoke")]
        [TestCase("experimentalaccount", "Y)ppiiklPB13")]
        public void NegativeTestOfComeInToEmailNoSuchElementException(string login, string password)
        {
            try
            {
                ComeInToEmail(driver, login, password);
                MainPageOfEmail mainPage = new MainPageOfEmail(driver);
                string result = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("element not interactable\n"));
            }
        }

        [Category("All")]
        [Category("Smoke")]
        [TestCase("experimentalaccount2@mail.ru", "tPTTRkpyt42")]
        public void NegativeTestOfComeInToEmailNotInteractableException(string login, string password)
        {
            try
            {
                ComeInToEmail(driver, login, password);
                MainPageOfEmail mainPage = new MainPageOfEmail(driver);
                string result = driver.FindElement(By.XPath("/html/body/div[3]/div[1]/div/div[2]/div[2]/span[2]")).Text;
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.Message.Contains("no such element"));
            }
        }
    }
}