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
            XDocument inputDocument = XDocument.Load(@"C:\Users\Jakub\Desktop\HtmlConsoleApp\HtmlConsoleApp\data\HTMLEditor_data_IN.html");
            string outputDocument = (@"C:\Users\Jakub\Desktop\HtmlConsoleApp\HtmlConsoleApp\data\HTMLEditor_data_OUT.html");

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
				Main();
			}

			selectedIndex = int.Parse(Console.ReadKey().KeyChar.ToString());

			if (selectedOption == "delete")
			{
				selectedIndex++;

				XElement element =
					inputDocument.Descendants().
					SingleOrDefault(e => ((string)e.Attribute("id")) == selectedIndex.ToString());

				if (element != null)
				{
					/*Odebrani posledniho znaku*/
					//element.Value = element.Value.Remove(element.Value.Length - 1);

					/*Odebrani prvniho znaku*/

					element.Value = element.Value.Remove(0, 1);

					using (StreamWriter sw = File.CreateText(outputDocument))
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
					SingleOrDefault(e => ((string)e.Attribute("id")) == selectedIndex.ToString());

				selectedIndex++;

				XElement secondElement =
					inputDocument.Descendants().
					SingleOrDefault(e => ((string)e.Attribute("id")) == selectedIndex.ToString());


				if (firstElement != null && secondElement != null)
				{

					firstElement.Value = firstElement.Value + secondElement.Value;

					using (StreamWriter sw = File.CreateText(outputDocument))
					{
						sw.Write(inputDocument);
					}

					//Console.Write(secondElement.Parent.Name);

					Console.Write("\n\n HOTOVO! :) \n\n\n");
				}
				else
				{
					Console.Clear();
					Console.Write("Byl zadán neplatný index! \n\n");
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
			Console.Write("Zadejte index textu pro operaci (1-7): \n\n");
			Console.Write("Vámi vybraná možnost: ");
		}

	}

		
}

