using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsScraping
{
    public class Temp
    {

        private SortedDictionary<string, int> _collection;
        private readonly string _filePath;

        public Temp()
        {
            _collection = new SortedDictionary<string, int>
            {
                { "Hello", 10 },
                { "World", 2 },
                { "Name", 4 },
                {"Beta",12 },
                {"Hololo",23 },
                {"Heiis",67 },
                {"OpenGamer",54 }
            };
            _filePath = "../../../Frontend/script/wordsData.js";
        }
        private string ReadJsFile()
        {
            using var sr = new StreamReader(_filePath);
            return sr.ReadToEnd();
        }
        private string UpdateFile(string oldContent)
        {
            var jsonCollectoin = JsonSerializer.Serialize<SortedDictionary<string, int>>(_collection);
            MessageBox.Show(jsonCollectoin);
            var sb = new StringBuilder(oldContent);

            if (oldContent.Contains('%'))
            {
                return sb.Replace("'%'", jsonCollectoin).ToString();
            }
            else
            {
                var startIndex = oldContent.IndexOf('{');      
                var endIndex = oldContent.IndexOf('}');          
                var strForRemove = oldContent.Substring(startIndex, endIndex-startIndex+1);
                MessageBox.Show(strForRemove);
                return sb.Replace(strForRemove, jsonCollectoin).ToString();
            }



        }
        private void WriteJsFile(string newContent)
        {
            using var sw = new StreamWriter(_filePath);
            sw.Write(newContent);


        }
        public void WriteDictionary()
        {
            var oldFileContent = ReadJsFile();
            var updateFileContent = UpdateFile(oldFileContent);
            WriteJsFile(updateFileContent);
        }

    }
}
