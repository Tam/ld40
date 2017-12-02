namespace UI
{
	public class UIStat
	{

		public string name;

		public string value;

		private UIStat()
		{
			// Private constructor, use UIStat.Create
		}

		public static UIStat Create<T>(string name, T value)
		{
			return new UIStat
			{
				name = name,
				value = value.ToString()
			};
		}

	}
}
