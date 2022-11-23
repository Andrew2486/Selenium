using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.Generic;
using System.Threading;

namespace Selenium_13384951
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            IWebDriver driver = new ChromeDriver();//Creates instance of chrome
            driver.Navigate().GoToUrl("http://www.google.com");// Goes to url
            driver.FindElement(By.Name("q")).SendKeys("Taupo weather");//inputs text
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);//enter key
        }
        [TestMethod]
        public void TestMethod2()
        {
            IWebDriver driver = new ChromeDriver();//Creates instance of chrome
            driver.Navigate().GoToUrl("http://www.trademe.co.nz/a/");// Goes to URL
            driver.FindElement(By.Id("search")).SendKeys("IT Jobs");//Inputs text in search bar
            driver.FindElement(By.Id("search")).SendKeys(Keys.Enter);//Presses enter
        }
        [TestMethod]
        public void TestMethod3()
        {
            List<string> ele = new List<string>();//List to store links
            IWebDriver driver = new ChromeDriver();//Opens up new instance of chrome
            driver.Navigate().GoToUrl("http://automationpractice.com");
            foreach (var item in driver.FindElements(By.TagName("a")))
            {
                string temp = "automationpractice";// keyword to check against
                if (item.GetAttribute("href").Contains(temp))// checks against keyword
                {
                    ele.Add(item.GetAttribute("href"));// Adds link to list
                }
            }
            foreach (var item in ele)
            {
                driver.Navigate().GoToUrl(item); //Cycles though each link in the list
            }
        }
        [TestMethod]
        public void TestMethod4()
        {
            IWebDriver driver = new ChromeDriver();// Creates instance of chrome
            driver.Navigate().GoToUrl("http://automationpractice.com");// Navigates to URL
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[2]/div/div[2]")).Click(); // Clicks add to cart on item
            Thread.Sleep(5000); //Will not work if I do not delay gives it time to load correctly
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")).Click(); //Clicks continue shopping button
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[3]/div/div[2]")).Click();// Clicks add to cart on item
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")).Click();//Clicks continue shopping button
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[6]/div/div[2]")).Click();// Clicks add to cart on item
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a/span")).Click();//Clicks go to cart button
            driver.FindElement(By.XPath("//*[@id='2_7_0_0']/i")).Click(); //Removes one item from cart
            Thread.Sleep(10000); //Slows the test down as website loads too slow or skips shipping cost
            Assert.AreEqual("$58.50", driver.FindElement(By.XPath("//*[@id='total_price']")).Text);// Checks total against Expected
        }
        [TestMethod]
        public void TestMethod5()// Expected total = 69.51 + $2 for shipping
        {
            IWebDriver driver = new ChromeDriver();// Opens a new instance of google chrome
            driver.Navigate().GoToUrl("http://automationpractice.com");// Goes to URL 
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[1]/div/div[2]")).Click(); //Adds to cart
            Thread.Sleep(5000); // Gives website time to load
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")).Click();//Clicks continue shopping button
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[2]/div/div[2]")).Click();//Adds to cart
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")).Click();//Clicks continue shopping button
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[3]/div/div[2]")).Click();//Adds to cart
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")).Click();//Clicks continue shopping button
            driver.FindElement(By.XPath("//*[@id='homefeatured']/li[4]/div/div[2]")).Click();//Adds to cart
            Thread.Sleep(10000);// Lets website update by delaying the next step
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/span")).Click();//Clicks continue shopping button
            driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a/span")).Click();//Clicks the go to cart button
            driver.FindElement(By.XPath("//*[@id='4_16_0_0']/i")).Click();// Removes the most expensive dress
            Thread.Sleep(15000);// Gives website time to adjust the price with shipping
            Assert.AreEqual("$71.51", driver.FindElement(By.XPath("//*[@id='total_price']")).Text); // Compares the expected price against the accual after shipping
        }
        [TestMethod]
        public void TestMethod6()
        {
            List<string> ele = new List<string>(); // Creates a list to store links
            IWebDriver driver = new ChromeDriver(); // Creates a instance of chrome
            driver.Navigate().GoToUrl("https://www.trademe.co.nz/a/"); // Goes to trademe website
            foreach (var item in driver.FindElements(By.TagName("a")))
            {
                string Maintemp = "trademe";
                string ptemp = "property";
                string stemp = "services";
                if (item.GetAttribute("href").Contains(Maintemp))//Keeps ruturning null
                //if (item.GetAttribute("href").Contains(Maintemp))
                {
                    if (item.GetAttribute("href").Contains(ptemp) || (item.GetAttribute("href").Contains(stemp)))
                    {
                        ele.Add(item.GetAttribute("href"));
                    }
                }              
            }
            foreach (var item in ele)
            {
                driver.Navigate().GoToUrl(item);
            }
        }
    }
}