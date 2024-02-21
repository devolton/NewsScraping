using OpenQA.Selenium;

namespace NewsScraping;

public class NewsScraper
{
    private OpenQA.Selenium.Chrome.ChromeDriver driver = new OpenQA.Selenium.Chrome.ChromeDriver();
    private string allHeaderText = "";
    public NewsScraper(string url)
    {
        driver.Manage().Window.Maximize();
        driver.Url = url;

    }


    public Dictionary<string, int> GetWordsDictionary()
    {
        var megaMenu = driver.FindElement(By.CssSelector("#mega-menu-button"));
        megaMenu.Click();
        var categories = driver.FindElement(By.CssSelector("#menu-explore-press-gazette"));
        var liCollection = categories.FindElements(By.CssSelector("li"));
        var refElement = liCollection[1].FindElement(By.CssSelector("a"));
        while (true)//костыль, но без него не хочет обрабатывать событие клик, только если перед ним использовать MessageBox.Show();
        {
            try
            {
                refElement.Click();
                break;
            }
            catch
            {
                continue;
            }
        }
        var newNewsButton = driver.FindElement(By.CssSelector("#load-more-archives"));

        int counter = 0;
        while (counter <= 20)
        {
            try
            {
                newNewsButton.Click();
               
                counter++;
            }
            catch
            {
                continue;
            }
        }
       
        var newsBlock = driver.FindElement(By.ClassName("l-segment__item--centered"));
        Wait(10);
        var headerElements = newsBlock.FindElements(By.CssSelector("h3"));

        Dictionary<string, int> wordCounts = new Dictionary<string, int>();


        string[] commonWords = { "how", "after", "top", "in", "at", "and", "a", "the", "on", "of", "to", "for", "is", "with", "it", "that", "as", "from", "by", "this", "are", "be", "or", "an", "have", "has", "was", "were", "but", "not", "will", "be","why","a","-" };


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
    

        driver.Close();
        return wordCounts;


    }

    public void SkipCookies()
    {
        IWebElement cokiesButton = driver.FindElement(By.Id("onetrust-accept-btn-handler"));
        Wait(5);
        cokiesButton.Click();
    }
    private void Wait(int secondsCount)
    {
        driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsCount);
    }
}

