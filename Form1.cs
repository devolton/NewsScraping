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
            //var temp = new Temp();
            //temp.WriteDictionary();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newsScraper = new NewsScraper("https://pressgazette.co.uk/");

            newsScraper.PrintTop10Words();
        }
    }
}
