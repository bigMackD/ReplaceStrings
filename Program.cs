using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace JsonConverter
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.WriteLine("Select path to config file:");
            var ConfigContent = FileOperation.GetFileContent();

            Console.WriteLine("Select path to json file:");
            var JsonContent = FileOperation.GetFileContent();

            var ContentAsJson = FileOperation.convertJson(JsonContent);
           
            var newContent = FileOperation.replaceStrings(ConfigContent, ContentAsJson);

            Console.WriteLine("Select save location:");
            FileOperation.saveToFile(newContent);
           
        }
    }
}
