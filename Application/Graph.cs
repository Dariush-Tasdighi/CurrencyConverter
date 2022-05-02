namespace Application
{
	public class Graph : object
	{
		public Graph() : base()
		{
			AdjacencyList =
				new System.Collections.Generic.Dictionary
				<string, System.Collections.Generic.HashSet<string>>();
		}

		public System.Collections.Generic
			.Dictionary<string, System.Collections.Generic.HashSet<string>> AdjacencyList
		{ get; }

		public void Clear()
		{
			AdjacencyList.Clear();
		}

		public void AddVertex(string vertex)
		{
			if (string.IsNullOrWhiteSpace(value: vertex))
			{
				return;
			}

			vertex =
				vertex.ToUpper();

			if(AdjacencyList.ContainsKey(key: vertex) == false)
			{
				AdjacencyList[key: vertex] =
					new System.Collections.Generic.HashSet<string>();
			}
		}

		public void AddEdge(string firstVertex, string secondVertex)
		{
			if (string.IsNullOrWhiteSpace(value: firstVertex) ||
				string.IsNullOrWhiteSpace(value: secondVertex))
			{
				return;
			}

			firstVertex =
				firstVertex.ToUpper();

			secondVertex =
				secondVertex.ToUpper();

			if (AdjacencyList.ContainsKey(key: firstVertex) &&
				AdjacencyList.ContainsKey(key: secondVertex))
			{
				AdjacencyList[key: firstVertex].Add(item: secondVertex);
				AdjacencyList[key: secondVertex].Add(item: firstVertex);
			}
		}

		public void Display()
		{
			System.Console.WriteLine("----------");
			System.Console.WriteLine("--- Graph ");
			System.Console.WriteLine("----------");

			foreach (var item in AdjacencyList)
			{
				System.Console.WriteLine(value: item.Key);

				System.Console.Write(" > ");

				var index = -1;

				foreach (var adjacency in item.Value)
				{
					index++;

					if (index != 0)
					{
						System.Console.Write(" | ");
					}

					System.Console.Write(value: adjacency);
				}

				System.Console.WriteLine();
			}
		}
	}
}
