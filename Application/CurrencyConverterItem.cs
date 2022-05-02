namespace Application
{
	public class CurrencyConverterItem : object
	{
		public CurrencyConverterItem
			(string fromCurrency, string toCurrency, double rate) : base()
		{
			Rate = rate;
			ToCurrency = toCurrency;
			FromCurrency = fromCurrency;
		}

		public double Rate { get; set; }

		public double ReverseRate
		{
			get
			{
				double result =
					(double)1 / (double)Rate;

				return result;
			}
		}

		public string ToCurrency { get; set; }

		public string FromCurrency { get; set; }
	}
}
