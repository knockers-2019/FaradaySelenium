using System;
using System.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FaradaySelenium
{
    [TestClass]
    public class FaradaySelenium
    {
        private string url = "https://localhost:44305/";

        [TestMethod]
        public void HomeButtonCheck()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
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
            driver.Navigate().GoToUrl(url);
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
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(200);
            driver.FindElement(By.Id("Contact")).Click();
            Thread.Sleep(200);

            var textM = driver.FindElement(By.Id("ContactMikkelName")).Text;
            var textJ = driver.FindElement(By.Id("ContactJonasName")).Text;
            var emailM = driver.FindElement(By.Id("ContactMikkelEmail")).Text;
            var emailJ = driver.FindElement(By.Id("ContactJonasEmail")).Text;

            Assert.AreEqual("Name: Mikkel Wexøe Ertbjerg", textM);
            Assert.AreEqual("Name: Jonas Manley Pedersen", textJ);
            Assert.AreEqual("Email: Cph-me209@cphbusiness.dk", emailM);
            Assert.AreEqual("Email: Jonasmanley@hotmail.com", emailJ);
        }


        [TestMethod]
        public void CreatePageCreate()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(200);
            driver.FindElement(By.Id("CreateBooking")).Click();
            Thread.Sleep(200);

            driver.FindElement(By.Id("selectedDate")).SendKeys("22/12/2019");
            driver.FindElement(By.Id("inputName")).SendKeys("Jonas");
            driver.FindElement(By.Id("inputLastname")).SendKeys("Pedersem");
            driver.FindElement(By.Id("inputDriverlicens")).SendKeys("647283741");
            Thread.Sleep(500);
            driver.FindElement(By.Id("submitButton")).Click();
            var alertText = driver.SwitchTo().Alert().Text;

            Assert.AreEqual("Succefully created a new book", alertText);
        }

        ///                 Above is okay - has been checked                       ///

        [TestMethod]
        public void CancelBooking()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);
            Thread.Sleep(200);
            driver.FindElement(By.Id("Bookings")).Click();
            Thread.Sleep(200);
            var startElement = driver.FindElement(By.Id("selectedCancel")).Text;
            driver.FindElement(By.Id("submitButton")).Click();

            var newElement = driver.FindElement(By.Id("selectedCancel")).Text;

            Assert.AreNotEqual(startElement, newElement);
        }
    }
}
