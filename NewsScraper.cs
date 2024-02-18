using OpenQA.Selenium;
using System.Security.Cryptography;
namespace NewsScraping
{
    public class NewsScraper
    {
        public OpenQA.Selenium.Chrome.ChromeDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
        public string allHeaderText = "";
        public NewsScraper(string url)
        {
            driver.Url = url;
        }


        //It's function created what would get head text each element on news site

        //public void GetHeadText()
        //{
        //    IWebElement cokiesButton = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        //    cokiesButton.Click();



        //    IWebElement[] header = driver.FindElements(By.ClassName("c-story__header__headline")).ToArray();

        //    foreach (var headerElement in header)
        //    {
        //        MessageBox.Show(headerElement.Text);
        //    }


        //}

        public void PrintTop10Words()
        {
            
            IReadOnlyCollection<IWebElement> headerElements = driver.FindElements(By.ClassName("c-story__header__headline"));

           
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            
            string[] commonWords = { "how","after","top","in", "at", "and", "a", "the", "on", "of", "to", "for", "is", "with", "it", "that", "as", "from", "by", "this", "are", "be", "or", "an", "have", "has", "was", "were", "but", "not" };

            
            foreach (IWebElement element in headerElements)
            {
                
                string[] words = element.Text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

               
                foreach (string word in words)
                {
                    if (!commonWords.Contains(word))
                    {
                        if (wordCounts.ContainsKey(word))
                            wordCounts[word]++;
                        else
                            wordCounts[word] = 1;
                    }
                }
            }

            
            var sortedWordCounts = wordCounts.OrderByDescending(pair => pair.Value);

           
            int rank = 1;

            
            foreach (var pair in sortedWordCounts.Take(10))
            {
                //it's line testing function
                MessageBox.Show($"{rank}. {pair.Key}: {pair.Value}");
                rank++;
            }
        }

        public void SkipCookies()
        {
            IWebElement cokiesButton = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            cokiesButton.Click();
        }
    }
}

