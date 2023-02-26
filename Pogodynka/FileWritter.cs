using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogodynka
{
    internal class FileWritter
    {
        private string forecastText { get; init; }
        private string path { get; init; }
        private string fileName { get; init; }

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
                
                File.WriteAllText(path + fileName + ".csv", forecastText,Encoding.UTF32);
                Console.WriteLine("\nPlik " + fileName +".csv został zapisany!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

   
