namespace Application
{
	internal class Program
	{
		private static void Main()
		{
			#region Test Graph and DFS Algorithm
			//var graph = new Graph();

			//graph.AddVertex("A");
			//graph.AddVertex("B");
			//graph.AddVertex("C");
			//graph.AddVertex("D");
			//graph.AddVertex("E");
			//graph.AddVertex("F");
			//graph.AddVertex("G");
			//graph.AddVertex("H");

			//// مقادیر تکراری مشکلی به وجود نمی‌آورد
			//graph.AddVertex("H");

			//graph.AddEdge(firstVertex: "A", secondVertex: "B");

			//// مقادیر تکراری مشکلی به وجود نمی‌آورد
			//graph.AddEdge(firstVertex: "A", secondVertex: "B");

			//graph.AddEdge(firstVertex: "B", secondVertex: "C");
			//graph.AddEdge(firstVertex: "B", secondVertex: "D");
			//graph.AddEdge(firstVertex: "C", secondVertex: "E");

			//graph.AddEdge(firstVertex: "F", secondVertex: "G");
			//graph.AddEdge(firstVertex: "G", secondVertex: "H");

			//graph.Display();

			//// **************************************************
			//var visited = Algorithms.Dfs
			//	(graph: graph, startVertex: "A", endVertex: "B");

			//foreach (var vertex in visited)
			//{
			//	System.Console.Write(vertex);
			//}

			//System.Console.WriteLine();
			//// **************************************************

			//// **************************************************
			//visited = Algorithms.Dfs
			//	(graph: graph, startVertex: "A", endVertex: "C");

			//foreach (var vertex in visited)
			//{
			//	System.Console.Write(vertex);
			//}

			//System.Console.WriteLine();
			//// **************************************************

			//// **************************************************
			//visited = Algorithms.Dfs
			//	(graph: graph, startVertex: "A", endVertex: "E");

			//foreach (var vertex in visited)
			//{
			//	System.Console.Write(vertex);
			//}

			//System.Console.WriteLine();
			//// **************************************************

			//// **************************************************
			//visited = Algorithms.Dfs
			//	(graph: graph, startVertex: "D", endVertex: "E");

			//foreach (var vertex in visited)
			//{
			//	System.Console.Write(vertex);
			//}

			//System.Console.WriteLine();
			//// **************************************************

			//// **************************************************
			//visited = Algorithms.Dfs
			//	(graph: graph, startVertex: "H", endVertex: "F");

			//foreach (var vertex in visited)
			//{
			//	System.Console.Write(vertex);
			//}

			//System.Console.WriteLine();
			//// **************************************************

			//// **************************************************
			//visited = Algorithms.Dfs
			//	(graph: graph, startVertex: "B", endVertex: "TEMP");

			//foreach (var vertex in visited)
			//{
			//	System.Console.Write(vertex);
			//}

			//System.Console.WriteLine();
			//// **************************************************

			//// **************************************************
			//visited = Algorithms.Dfs
			//	(graph: graph, startVertex: "B", endVertex: "G");

			//foreach (var vertex in visited)
			//{
			//	System.Console.Write(vertex);
			//}

			//System.Console.WriteLine();
			//// **************************************************

			//// **************************************************
			//visited = Algorithms.Dfs
			//	(graph: graph, startVertex: "e", endVertex: "d");

			//foreach (var vertex in visited)
			//{
			//	System.Console.Write(vertex);
			//}

			//System.Console.WriteLine();
			//// **************************************************
			#endregion Test Graph and DFS Algorithm

			var currencyConverter =
				CurrencyConverter.Instance;

			var conversionRates =
				new System.Collections.Generic.List<System.Tuple<string, string, double>>();

			conversionRates.Add
				(new System.Tuple<string, string, double>(item1: "Dollar", item2: "Toman", item3: 27000));

			conversionRates.Add
				(new System.Tuple<string, string, double>(item1: "Euro", item2: "Dollar", item3: 1.5));

			conversionRates.Add
				(new System.Tuple<string, string, double>(item1: "Pound", item2: "Euro", item3: 2));

			currencyConverter.UpdateConfiguration(conversionRates: conversionRates);

			currencyConverter.Graph.Display();

			// **************************************************
			var visited = Algorithms.Dfs
				(graph: currencyConverter.Graph, startVertex: "Pound", endVertex: "Toman");

			var index = -1;

			foreach (var vertex in visited)
			{
				index++;

				if (index != 0)
				{
					System.Console.Write(" | ");
				}

				System.Console.Write(vertex);
			}

			System.Console.WriteLine();
			// **************************************************

			double result;

			// **************************************************
			result =
				currencyConverter.Convert
				(fromCurrency: "Pound", toCurrency: "Euro", amount: 1000);

			System.Console.WriteLine(value: result);
			// **************************************************

			// **************************************************
			result =
				currencyConverter.Convert
				(fromCurrency: "Pound", toCurrency: "Dollar", amount: 1000);

			System.Console.WriteLine(value: result);
			// **************************************************

			// **************************************************
			result =
				currencyConverter.Convert
				(fromCurrency: "Pound", toCurrency: "Toman", amount: 1000);

			System.Console.WriteLine(value: result);
			// **************************************************
		}
	}
}
