using System.Text;

namespace Mineware.Systems.MinewasteGlobal
{
	public static partial class Extensions
	{
		public static readonly StringBuilder Sb = new StringBuilder();

		public static string ToDelimitedString(this int[] x, string delimiter, string enclose = "")
		{
			Sb.Clear();
			var first = true;
			foreach (var i in x)
			{
				if (!first)
				{
					Sb.Append(delimiter);
				}
				else
				{
					first = false;
				}
				if (!string.IsNullOrEmpty(enclose))
				{
					Sb.Append(enclose);
				}
				Sb.Append(i);
				if (!string.IsNullOrEmpty(enclose))
				{
					Sb.Append(enclose);
				}
			}

			return Sb.ToString();
		}

		public static int ToZeroInt32(this string value)
		{
			int result;
			if (!int.TryParse(value, out result))
			{
				result = 0;
			}

			return result;
		}
	}
}
