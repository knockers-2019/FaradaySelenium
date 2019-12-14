using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FaradaySelenium
{
    [TestClass]
    public class UnitTest1
    {
        private void setup() 
        { 
        }

        [TestMethod]
        public void HomeButtonCheck()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44305/");
            Thread.Sleep(200);
            driver.FindElement(By.Id("Home")).Click();
            Thread.Sleep(200);

            var welcomeText = driver.FindElement(By.ClassName("display-4")).Text;

            Assert.AreEqual("Welcome", welcomeText);  
        }

        [TestMethod]
        public void FaradayLogoCheck()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44305/");
            Thread.Sleep(200);
            driver.FindElement(By.Id("FaradayLogo")).Click();
            Thread.Sleep(200);

            var welcomeText = driver.FindElement(By.ClassName("display-4")).Text;

            Assert.AreEqual("Welcome", welcomeText);
        }

        [TestMethod]
        public void ContactButtonCheck()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44305/");
            Thread.Sleep(200);
            driver.FindElement(By.Id("Contact")).Click();
            Thread.Sleep(200);

            var textM = driver.FindElement(By.Id("ContactMikkel")).Text;
            var textJ = driver.FindElement(By.Id("ContactJonas")).Text;

            Assert.AreEqual("Name: Mikkel Wexøe Ertbjerg", textM);
            Assert.AreEqual("Name: Jonas Manley Pedersen", textJ);
        }


        ///                 Above is okay - has been checked                       ///

         
        [TestMethod]
        public void CreatePageCreate()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:44305/");
            Thread.Sleep(200);
            driver.FindElement(By.Id("Contact")).Click();
            Thread.Sleep(200);

            var textM = driver.FindElement(By.Id("ContactMikkel")).Text;
            var textJ = driver.FindElement(By.Id("ContactJonas")).Text;

            Assert.AreEqual("Name: Mikkel Wexøe Ertbjerg", textM);
            Assert.AreEqual("Name: Jonas Manley Pedersen", textJ);
        }
    }
}
