using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;

namespace HtmlConsoleApp
{
    class Program
    {
		public static string selectedOption { get; private set; }

		public static int selectedIndex { get; private set; }

		static void Main()
        {
			/* Nacteni dat IN and OUT HTML Souboru */

            XDocument inputDocument = XDocument.Load(@"C:\Users\Jakub\Desktop\HtmlConsoleApp\HtmlConsoleApp\data\HTMLEditor_data_IN.html");
            string outputDocument = (@"C:\Users\Jakub\Desktop\HtmlConsoleApp\HtmlConsoleApp\data\HTMLEditor_data_OUT.html");

			// Hlavni nabidka dvou metod 

			showMainMenu();
			var option = Console.ReadKey().Key;

			if (option == ConsoleKey.A)
			{
				selectedOption = "delete";
				showIndexMenu();
			}
			else if (option == ConsoleKey.B)
			{
				selectedOption = "merge";
				showIndexMenu();
			}
			else
			{
				Main(); // V pripade ze se zmackne spatna hodnota 
			}

			selectedIndex = int.Parse(Console.ReadKey().KeyChar.ToString()); // Prevedeni na cislo

			if (selectedOption == "delete")
			{
				selectedIndex++; //zvyseni indexu id 

				XElement element = 
					inputDocument.Descendants().
					SingleOrDefault(e => ((string)e.Attribute("id")) == selectedIndex.ToString());

				if (element != null) // kdybzch menil 7
				{
					/*Odebrani posledniho znaku*/
					//element.Value = element.Value.Remove(element.Value.Length - 1);

					/*Odebrani prvniho znaku*/

					element.Value = element.Value.Remove(0, 1); 

					using (StreamWriter sw = File.CreateText(outputDocument)) // jak vytvorit vystupni soubor 
					{
						sw.Write(inputDocument);
					}

					Console.Write("\n\n HOTOVO! :) \n\n\n");
				}
				else
				{
					Console.Clear();
					Console.Write("Byl zadán neplatný index! \n\n");
				}

			}
			else
			{

				XElement firstElement =
					inputDocument.Descendants().
					SingleOrDefault(e => ((string)e.Attribute("id")) == selectedIndex.ToString()); // prvni zadanej element

				selectedIndex++;

				XElement secondElement =
					inputDocument.Descendants().
					SingleOrDefault(e => ((string)e.Attribute("id")) == selectedIndex.ToString());


				if (firstElement != null && secondElement != null) // overeni jestli je nasel 
				{

					firstElement.Value = firstElement.Value + secondElement.Value;
					secondElement.Value = "";

					using (StreamWriter sw = File.CreateText(outputDocument))
					{
						sw.Write(inputDocument);
					}

					Console.Write("\n\n HOTOVO! :) \n\n\n");
				}
				else
				{
					Console.Clear();
					Console.Write("Byl zadán neplatný index!\n\n");
				}
			}
		}
		static void showMainMenu()
		{
			Console.Clear();
			Console.Write("Vyberte požadavanou operaci: \n\n");
			Console.Write("A) Smazání prvního znaku \n");
			Console.Write("B) Sloučení nasledujiciho textu s vybranym textem \n\n");
			Console.Write("Vámi vybraná možnost (A or B): ");
		}

		static void showIndexMenu()
		{
			Console.Clear();
			Console.Write("Zadejte index textu pro operaci (v tomto případě 1-6): \n\n");
			Console.Write("Vámi vybraná možnost: ");
		}

	}

		
}

