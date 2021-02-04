using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PieceofCode
{
    class SearchProduct
    {
        // Declare Webdriver
        public static IWebDriver driver;

        public static string currentDir = Environment.CurrentDirectory;
        public static string[] Solutionpath = currentDir.Split("bin");
        static void Main(string[] args)
        {
            // Initialize Chrombrowser
            //driver = new ChromeDriver(@"E:\AutomationCode\PieceofCode\Drivers\");
            driver = new ChromeDriver(Solutionpath[0] + @"Drivers\");

            // Launch URL in browser
            driver.Url = "https://www.amazon.com/";
            // Maximize the window

            driver.Manage().Window.Maximize();
            // Apply Impicit Wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);

            // Eneter text in search box
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("Laptop");

            // Click on Search button
            driver.FindElement(By.XPath("//input[@id='nav-search-submit-button']")).Click();

            // Click on First product of the list
            IList<IWebElement> productList = driver.FindElements(By.XPath("//span[contains(@class,'a-size-medium a-color-base a-text-normal')]"));
            Console.WriteLine("First product is " + productList.ElementAt(0).Text);
            productList.ElementAt(0).Click();



            // Get product price
            string productValue = driver.FindElement(By.Id("price_inside_buybox")).Text;

            // Trim $ sign from the price
            char[] charsToTrim = { '$' };
            string price = productValue.Trim(charsToTrim);

            decimal FinalPrice = Convert.ToDecimal(price);

            // Assert laptop price is more than 100$
            Assert.Greater(FinalPrice, 100);

            // Close the driver
            driver.Quit();

            Console.WriteLine("Test Exexcution is completed");
        }
    }
}
