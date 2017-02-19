namespace BarCodeReader
{
	public class CurrentUser
	{
		public static void Clear()
		{
			Name = null;
			ShopName = null;
			Ranking = null;
		}

		public static void Init(string name, string shopName, int? ranking)
		{
			Name = name;
			ShopName = shopName;
			Ranking = ranking;
		}

		public static string Name
		{
			get;
			private set;
		}

		public static string ShopName
		{
			get;
			private set;
		}

		public static int? Ranking
		{
			get;
			private set;
		}
	}
}