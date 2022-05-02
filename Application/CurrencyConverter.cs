using System.Linq;

namespace Application
{
	public class CurrencyConverter : object, ICurrencyConverter
	{
		static CurrencyConverter()
		{
			// Note: It is Thread Safe!
			Instance = new CurrencyConverter();
		}

		public static CurrencyConverter Instance;

		protected static object MyLocker = new();

		private CurrencyConverter() : base()
		{
			Graph = new Graph();

			Items =
				new System.Collections.Generic.List<CurrencyConverterItem>();
		}

		public Graph Graph { get; }

		public System.Collections.Generic.IList<CurrencyConverterItem> Items { get; }

		public void ClearConfiguration()
		{
			lock (MyLocker)
			{
				Graph.Clear();
				Items.Clear();
			}
		}

		public void UpdateConfiguration
			(System.Collections.Generic.IEnumerable
			<System.Tuple<string, string, double>> conversionRates)
		{
			foreach (var item in conversionRates)
			{
				AddItem(fromCurrency: item.Item1, toCurrency: item.Item2, rate: item.Item3);
			}
		}

		protected void
			AddItem(string fromCurrency, string toCurrency, double rate)
		{
			if (string.IsNullOrWhiteSpace(value: toCurrency) ||
				string.IsNullOrWhiteSpace(value: fromCurrency))
			{
				return;
			}

			toCurrency =
				toCurrency.ToUpper();

			fromCurrency =
				fromCurrency.ToUpper();

			lock (MyLocker)
			{
				// **************************************************
				Graph.AddVertex(vertex: toCurrency);
				Graph.AddVertex(vertex: fromCurrency);
				Graph.AddEdge(firstVertex: fromCurrency, secondVertex: toCurrency);
				// **************************************************

				// **************************************************
				var foundedItem =
					Items
					.Where(current => current.ToCurrency.ToLower() == toCurrency.ToLower())
					.Where(current => current.FromCurrency.ToLower() == fromCurrency.ToLower())
					.FirstOrDefault();

				if (foundedItem != null)
				{
					foundedItem.Rate = rate;
				}
				else
				{
					var newItem =
						new CurrencyConverterItem
						(fromCurrency: fromCurrency, toCurrency: toCurrency, rate: rate);

					Items.Add(item: newItem);
				}
				// **************************************************
			}
		}

		public double Convert
			(string fromCurrency, string toCurrency, double amount)
		{
			var visited =
				Algorithms.Dfs
				(graph: Graph, startVertex: fromCurrency, endVertex: toCurrency);

			if (visited == null || visited.Count < 2)
			{
				return 0;
			}

			var visitedList =
				visited.ToList();

			double totalRate = 1;

			for (int index = 0; index <= visitedList.Count - 2; index++)
			{
				var currentItem = visitedList[index];
				var nextItem = visitedList[index + 1];

				double rate =
					GetRate(fromCurrency: currentItem, toCurrency: nextItem);

				totalRate *= rate;
			}

			double result =
				amount * totalRate;

			return result;
		}

		protected double
			GetRate(string fromCurrency, string toCurrency)
		{
			var foundedItem =
				Items
				.Where(current => current.ToCurrency.ToLower() == toCurrency.ToLower())
				.Where(current => current.FromCurrency.ToLower() == fromCurrency.ToLower())
				.FirstOrDefault();

			if (foundedItem != null)
			{
				return foundedItem.Rate;
			}
			else
			{
				foundedItem =
					Items
					.Where(current => current.ToCurrency.ToLower() == fromCurrency.ToLower())
					.Where(current => current.FromCurrency.ToLower() == toCurrency.ToLower())
					.FirstOrDefault();

				if (foundedItem != null)
				{
					return foundedItem.ReverseRate;
				}
				else
				{
					return 0;
				}
			}
		}
	}
}
