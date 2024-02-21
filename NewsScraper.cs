using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NewsScraping;

public class NewsScraper
{
    private static NewsScraper _instance;
    private OpenQA.Selenium.Chrome.ChromeDriver _driver = new OpenQA.Selenium.Chrome.ChromeDriver();
    private string[] _commonWords;
    private Dictionary<string, int> _wordCounts;
    private const int _MORE_NEWS_BUTTON_CLICK_COUNT= 25;
    private NewsScraper()
    {
        _driver.Manage().Window.Maximize();
        _driver.Url = "https://pressgazette.co.uk/";
        _wordCounts = new Dictionary<string, int>();
        _commonWords =new[] { "how", "after", "top", "in", "at", "and", "a", "the", "on", "of", "to", "for", "is", "with", "it",
            "that", "as", "from", "by", "this", "are", "be", "or", "an", "have", "has", "was", "were", "but", "not", "will", "be", "why", "a", "-","2024" };
    }
    public static NewsScraper Instance() => _instance ??= new NewsScraper();
    
    public Dictionary<string, int> GetWordsDictionary()
    {
        var megaMenu = _driver.FindElement(By.CssSelector("#mega-menu-button"));
        megaMenu.Click();
        var categories = _driver.FindElement(By.CssSelector("#menu-explore-press-gazette"));
        var liCollection = categories.FindElements(By.CssSelector("li"));
        var refElement = liCollection[1].FindElement(By.CssSelector("a"));
        NewsReferenceClick(refElement);
        var newNewsButton = _driver.FindElement(By.CssSelector("#load-more-archives"));
        MoreNewsButtonClick(newNewsButton);
        var newsBlock = _driver.FindElement(By.ClassName("l-segment__item--centered"));
        Wait(10);
        var headerElements = newsBlock.FindElements(By.CssSelector("h3"));
        FillingWordsDictionary(headerElements);
        _driver.Close();
        return _wordCounts;

    }

    public void SkipCookies()
    {
        IWebElement cokiesButton = _driver.FindElement(By.Id("onetrust-accept-btn-handler"));
        Wait(5);
        cokiesButton.Click();
    }
    private void Wait(int secondsCount)
    {
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secondsCount);
    }
    private void FillingWordsDictionary(ReadOnlyCollection<IWebElement>? webElements)
    {
        foreach (IWebElement element in webElements)
        {

            string[] words = element.Text.ToLower().Split(new char[] { ' ', ',', '.', ';', ':', '-', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);


            foreach (string word in words)
            {
                if (!_commonWords.Contains(word))
                {
                    if (_wordCounts.ContainsKey(word))
                        _wordCounts[word]++;
                    else
                        _wordCounts[word] = 1;
                }
            }
        }

    }
    private void NewsReferenceClick(IWebElement element)
    {
        while (true)//костыль, но без него не хочет обрабатывать событие клик (срабатывает только если перед ним использовать MessageBox.Show());
        {
            try
            {
                element.Click();
                return;
            }
            catch
            {
                continue;
            }
        }
    }
    private void MoreNewsButtonClick(IWebElement element)
    {
        int counter = 0;
        while (counter <= _MORE_NEWS_BUTTON_CLICK_COUNT)
        {
            try
            {
                element.Click();
                counter++;
            }
            catch
            {
                continue;
            }
        }
    }
    
}

