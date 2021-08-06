using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace Task8
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            IWebDriver browser;
            browser = new OpenQA.Selenium.Chrome.ChromeDriver();
            browser.Manage().Window.Maximize();

            browser.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            browser.Navigate().GoToUrl("https://www.bbc.com/sport");

            IWebElement Header = browser.FindElement(By.Id("orb-header"));
            IWebElement SearchLine = browser.FindElement(By.Name("suggid"));
            IWebElement Page = browser.FindElement(By.TagName("body"));
            IWebElement Home = browser.FindElement(By.LinkText("Home"));
            IWebElement OlGames = browser.FindElement(By.PartialLinkText("Games"));
            IWebElement Tennis = browser.FindElement(By.XPath("/html/body/div[8]/div[1]/div/nav/div[1]/div/ul/li[6]"));
            IWebElement SearchForm = browser.FindElement(By.ClassName("b-f"));
            IWebElement Article = browser.FindElement(By.CssSelector("li.sp-c-sport-navigation__item "));

            Console.WriteLine("FINISH");
            Console.ReadKey();
        }
    }
}
