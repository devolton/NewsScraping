using OpenQA.Selenium;

namespace NewsScraping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {



        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newsScraper = new NewsScraper("https://pressgazette.co.uk/");
            newsScraper.SkipCookies();
            var wordsCollection = newsScraper.GetWordsDictionary();
            new JsFileUpdater(wordsCollection).WriteDictionary();
            Close();

        }
    }
}
