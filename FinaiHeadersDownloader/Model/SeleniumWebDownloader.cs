using FinaiHeadersDownloader.Model.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;


namespace FinaiHeadersDownloader.Model
{
    public class SeleniumWebDownloader : IWebDownloader
    {
        public List<string> Headers { get; set; }

        public List<string> DownloadHeaders(string path)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            Headers = new List<string>();

            using (IWebDriver driver = new ChromeDriver(chromeOptions))
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Navigate().GoToUrl(path);
                int pageNumber = 1;
                while (Headers.Count < 20 || pageNumber>10)
                {
                    var items = driver.FindElements(By.ClassName("post-entry"));
                    if (items.Count > 0)
                    {
                        foreach (var item in items)
                        {
                            if (Headers.Count < 20)
                                Headers.Add(item.Text);
                        }
                    }
                    if (OpenNextPage(driver, ++pageNumber) == false)
                        return Headers;
                }
                return Headers;
            }
        }

        private bool OpenNextPage(IWebDriver driver, int pageNumber)
        {
            if (GoToFooter(driver) == false)
                return false;
            var nextPageButton = driver.FindElement(By.LinkText(pageNumber.ToString()));
            if (nextPageButton != null)
            {
                nextPageButton.Click();
            }
            System.Threading.Thread.Sleep(5000);
            return true;
        }

        private bool GoToFooter(IWebDriver driver)
        {
            var footer = driver.FindElement(By.CssSelector("#footer > div"));
            if (footer != null)
            {
                Actions actions = new Actions(driver);
                actions.MoveToElement(footer).Perform();
                return true;
            }
            return false;
        }
    }
    
}
