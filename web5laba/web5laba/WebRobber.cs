using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace web5laba
{
    public static class WebRobber
    {
        public static void GetCsvFile(string v, List<string> words)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", System.IO.Directory.GetCurrentDirectory());
            chromeOptions.AddUserProfilePreference("intl.accept_languages", "nl");
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddArgument("headless");
            IWebDriver driver = new ChromeDriver(chromeOptions);

            foreach (var i in words)
            {            
                driver.Navigate().GoToUrl(v);
                driver.FindElement(By.CssSelector("#SearchFormIndexQ")).SendKeys(i);
                driver.FindElement(By.CssSelector("#search_form_index > div.search-form-submit-index > input[type=submit]")).Click();
                driver.FindElement(By.CssSelector("body > div.content-wrapper > div.download-block > a")).Click();
                
            }
            Thread.Sleep(1000);
            driver.Quit();
        }
    }
}
