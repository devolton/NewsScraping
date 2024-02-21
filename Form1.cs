using OpenQA.Selenium;

namespace NewsScraping
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
       
        }



        private void runButton_Click(object sender, EventArgs e)
        {
            var newsScraper = NewsScraper.Instance();
            newsScraper.SkipCookies();
            var wordsCollection = newsScraper.GetWordsDictionary();
            JsFileUpdater.Instance(wordsCollection).WriteDictionary();
            Close();

        }
    }
}
