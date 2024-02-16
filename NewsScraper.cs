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

        public void GetHeadText()
        {
            IWebElement cokiesButton = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            cokiesButton.Click();

            

            IWebElement[] header = driver.FindElements(By.ClassName("c-story__header__headline")).ToArray();

            foreach (var headerElement in header)
            {
                MessageBox.Show(headerElement.Text);
            }


        }
   
        
    }
}

