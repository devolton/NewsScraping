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
            var svs = new NewsScraper("https://pressgazette.co.uk/");

            svs.Click();
        }
    }
}