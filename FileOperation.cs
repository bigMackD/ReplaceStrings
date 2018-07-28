using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonConverter
{
   // [STAThread]
    class FileOperation
    {
        public static string GetFileContent()
        {
            string content = "";
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            { 
                var path = ofd.FileName;
                Console.WriteLine(path);
                content = File.ReadAllText(path);
                return content;
            }
            else return "No file selected!";
        }

        public static JObject convertJson(string fileContent) 
        {
           JObject json = JObject.Parse(fileContent);
            return json;
        }

        public static string replaceStrings(string config, JObject json)
        {
            foreach (var JToken in json){
                config = config.Replace($"{{" + JToken.Key + "}}", JToken.Value.ToString());
            }
            return config;
        }

        public static void saveToFile(string newConfig)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.FileName = "MyNewFile.txt";
            save.Filter = "Text File | .txt";
            if(save.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(save.FileName, newConfig);
            }
        }
    }
}
