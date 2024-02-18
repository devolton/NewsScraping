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
            new JsFileUpdater(new Dictionary<string, int>
            {
                {"Hello",2 },
                {"World",3 },
                {"Dictionary",1 },
                {"Salo",12 },
                {"Mortal",9 },
                {"Hololo",65 },
                {"Gogog",10 },
                {"Upopo",77},
                {"Tako",99 },
                {"Guuu",4 },
                {"Hell",21 },
                {"Worl",31 },
                {"Dictionay",111 },
                {"Sal",85 },
                {"Morta",12 },
                {"Holoo",22 },
                {"Gogg",45 },
                {"Uppo",67},
                {"Tao",33 },
                {"Guu",54 },
                {"yyyy",19 }

            }).WriteDictionary();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newsScraper = new NewsScraper("https://pressgazette.co.uk/");

            newsScraper.GetHeadText();
        }
    }
}