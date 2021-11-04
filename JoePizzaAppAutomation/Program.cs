using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace JoePizzaAppAutomation
{
    class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver(@"C:\Program Files");
            string url = "https://pizzaappshop.azurewebsites.net/";

            driver.Navigate().GoToUrl(url);
            Thread.Sleep(2000);

            IWebElement addToCart = driver.FindElement(By.Id("add-to-cart-1"));
            addToCart.Click();
            Thread.Sleep(2000);

            IWebElement addmore = driver.FindElement(By.Id("add-more"));
            addmore.Click();
            Thread.Sleep(2000);

            IWebElement addToCart2 = driver.FindElement(By.Id("add-to-cart-2"));
            addToCart2.Click();
            Thread.Sleep(2000);

            IWebElement Checkout = driver.FindElement(By.Id("checkout-now"));
            Checkout.Click();
            Thread.Sleep(2000);

            IWebElement FirstName = driver.FindElement(By.Id("first-name"));
            FirstName.SendKeys("Pranav" + Keys.Tab);
            Thread.Sleep(2000);

            IWebElement LastName = driver.FindElement(By.Id("last-name"));
            LastName.SendKeys("Vatsa" + Keys.Tab);
            Thread.Sleep(2000);

            IWebElement Address1 = driver.FindElement(By.Id("address-line1"));
            Address1.SendKeys("No.454, 8th Main" + Keys.Tab);
            Thread.Sleep(2000);

            IWebElement Address2 = driver.FindElement(By.Id("address-line-2"));
            Address2.SendKeys("Near JSSATE, RR Nagar" + Keys.Tab);
            Thread.Sleep(2000);

            IWebElement Pincode = driver.FindElement(By.Id("pincode"));
            Pincode.SendKeys("560098" + Keys.Tab);
            Thread.Sleep(2000);

            IWebElement City = driver.FindElement(By.Id("city"));
            City.SendKeys("Bengaluru" + Keys.Tab);
            Thread.Sleep(2000);

            IWebElement State = driver.FindElement(By.Id("state"));
            State.SendKeys("Karnataka" + Keys.Tab);
            Thread.Sleep(2000);

            IWebElement phone = driver.FindElement(By.Id("phone"));
            phone.SendKeys("3333333333" + Keys.Tab);
            Thread.Sleep(2000);

            IWebElement email = driver.FindElement(By.Id("email"));
            email.SendKeys("pranav@mail.com" + Keys.Enter);
            Thread.Sleep(5000);

            IWebElement home = driver.FindElement(By.Id("home"));
            home.Click();
            Thread.Sleep(3000);

            IWebElement trackorder = driver.FindElement(By.Id("track-order"));
            trackorder.Click();
            Thread.Sleep(2000);

            IWebElement phonenum = driver.FindElement(By.Id("phone-num"));
            phonenum.SendKeys("3333333333" + Keys.Enter);
            Thread.Sleep(5000);
            driver.Quit();
        }
    }
}
