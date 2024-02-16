using OpenQA.Selenium;
using System.Security.Cryptography;
namespace NewsScraping
{
    public class NewsScraper
    {
        private OpenQA.Selenium.Chrome.ChromeDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        
        public NewsScraper(string url)
        {
            driver.Url = url;
        }

        //bool ElementExists(IWebDriver driver, By by)
        //{
        //    try
        //    {
        //        driver.FindElement(by);
        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}
        public void Click()
        {
            IWebElement cokiesButton = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            cokiesButton.Click();

            ////IWebElement bannerButton = driver.FindElement(By.Id("ranson-NoButtonElement--eVVZJF98jnguyTLl2tsf"));
            ////driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            ////bannerButton.Click();

            //IWebElement nextButton = driver.FindElement(By.Id("load-more-archives"));
            //while (ElementExists(driver, By.Id("load-more-archives")))
            //{
            //    nextButton.Click();
            //}

            IWebElement[] header = driver.FindElements(By.ClassName("c-story__header__headline")).ToArray();

            foreach (var headerElement in header)
            {
                MessageBox.Show(headerElement.Text);
            }


        }
   
        
    }
}

