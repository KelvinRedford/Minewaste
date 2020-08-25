using System.Data;

namespace Mineware.Systems.MinewasteGlobal
{
	public static partial class Extensions
	{
		public static int GetInt(this DataRow row, string column)
		{
			int result;
			var value = row[column].ToString();
			if (string.IsNullOrWhiteSpace(value))
			{
				result = 0;
			}
			else
			{
				if (!int.TryParse(value, out result))
				{
					result = 0;
				}
			}
			return result;
		}

		public static double GetDouble(this DataRow row, string column)
		{
			double result;
			var value = row[column].ToString();
			if (string.IsNullOrWhiteSpace(value))
			{
				result = 0;
			}
			else
			{
				if (!double.TryParse(value, out result))
				{
					result = 0;
				}
			}
			return result;
		}
	}
}