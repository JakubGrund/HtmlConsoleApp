using System;
using System.Xml.Linq;

namespace HtmlConsoleApp
{
    class Program
    {
        static void Main()
        {
            XDocument inputDocument = XDocument.Load(@"C:\Users\Jakub\Desktop\HtmlConsoleApp\HtmlConsoleApp\data\HTMLEditor_data_IN.html");
            string outputDocument = (@"C:\Users\Jakub\Desktop\HtmlConsoleApp\HtmlConsoleApp\data\HTMLEditor_data_OUT.html");


        }
    }
}
