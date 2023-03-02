using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pogodynka
{
    public class FileWritter
    {
        private string forecastText { get; init; }
        Menu menu;
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
                menu = new Menu();
                menu.backToMenu();
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}

   
