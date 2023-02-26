using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogodynka
{
    internal class FileWritter
    {
        private string forecastText;
        private string path;
        private string fileName;

        public FileWritter(string path, string forecastText, string fileName)
        {
            this.forecastText = forecastText;
            this.path = path;
            this.fileName = fileName;
        }
        public void saveForeCast()
        {
            try
            {
                Console.WriteLine("zapisywanie do pliku...");
                File.WriteAllText(path + fileName + ".csv", forecastText,Encoding.UTF32);
            }catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

   
