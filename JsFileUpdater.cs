using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace NewsScraping;
public class JsFileUpdater
{

    private Dictionary<string, int> _collection;
    private readonly string _filePath;
    private readonly int _wordsCount;

    public JsFileUpdater(Dictionary<string, int> collection)
    {
        _collection = collection;
        _filePath = "../../../Frontend/script/wordsData.js";
        _wordsCount = 20;
    }
    private void SortAndTrimDictionary() => _collection = _collection.OrderByDescending(pair => pair.Value).Take(_wordsCount).Reverse().ToDictionary(pair => pair.Key, pair => pair.Value);
    private string ReadJsFile()
    {
        using var sr = new StreamReader(_filePath);
        return sr.ReadToEnd();
    }
  
    private string UpdateFile(string oldContent)
    {
        SortAndTrimDictionary();
    
        var jsonCollectoin = JsonSerializer.Serialize<Dictionary<string, int>>(_collection);
        var sb = new StringBuilder(oldContent);
        if (oldContent.Contains('%'))
        {
            return sb.Replace("'%'", jsonCollectoin).ToString();
        }
        var startIndex = oldContent.IndexOf('{');
        var endIndex = oldContent.IndexOf('}');
        var strForRemove = oldContent.Substring(startIndex, endIndex - startIndex + 1);
        return sb.Replace(strForRemove, jsonCollectoin).ToString();

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
        MessageBox.Show("Update js file!");
    }

}


