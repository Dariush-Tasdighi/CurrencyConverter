using System.Linq;

namespace Application
{
	public static class Algorithms
	{
		static Algorithms()
		{
		}

		public static System.Collections.Generic
			.HashSet<string> Dfs(Graph graph, string startVertex, string endVertex)
		{
			var visited =
				new System.Collections.Generic.HashSet<string>();

			if (string.IsNullOrWhiteSpace(value: endVertex) ||
				string.IsNullOrWhiteSpace(value: startVertex))

			{
				return visited;
			}

			endVertex =
				endVertex.ToUpper();

			startVertex =
				startVertex.ToUpper();

			if (graph.AdjacencyList.ContainsKey(key: startVertex) == false)
			{
				return visited;
			}

			var stack =
				new System.Collections.Generic.Stack<string>();

			stack.Push(item: startVertex);

			while (stack.Count != 0)
			{
				var currentVertex = stack.Pop();

				if (visited.Contains(item: currentVertex))
				{
					continue;
				}

				visited.Add(item: currentVertex);

				var neighbours =
					graph.AdjacencyList[key: currentVertex];

				foreach (var neighborVertex in neighbours)
				{
					if (visited.Contains(item: neighborVertex))
					{
						continue;
					}

					if (neighborVertex == endVertex)
					{
						visited.Add(item: neighborVertex);

						return visited;
					}
				}

				bool isPushed = false;

				foreach (var neighborVertex in neighbours.Reverse())
				{
					if (neighborVertex.Equals(value: endVertex) ||
						visited.Contains(item: neighborVertex) ||
						stack.Contains(item: neighborVertex))
					{
						continue;
					}

					isPushed = true;
					stack.Push(item: neighborVertex);
				}

				if (isPushed == false)
				{
					var lastVisitedItem =
						visited.LastOrDefault();

					if (lastVisitedItem != null)
					{
						visited.Remove(item: lastVisitedItem);
					}
				}
			}

			// If endVertex did not found!
			visited.Clear();

			return visited;
		}
	}
}
