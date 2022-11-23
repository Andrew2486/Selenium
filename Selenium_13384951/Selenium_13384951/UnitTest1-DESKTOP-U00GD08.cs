using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_13384951
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.google.com");
            driver.FindElement(By.Name("q")).SendKeys("Taupo weather");
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
        }

        [TestMethod]
        public void TestMethod2()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://www.trademe.co.nz/a/");
            driver.FindElement(By.Name("")).SendKeys("Taupo weather");
           // driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
        }
    }
}
