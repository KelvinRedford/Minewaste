using System.Data;
using System.IO;

namespace Mineware.Systems.MinewasteGlobal
{
	public static class DataTableHelper
	{
		private static DataSet _xmlSaver = new DataSet();

		public static void ClearSaveToXmlTables()
		{
			_xmlSaver = new DataSet();
		}

		public static void SaveToXml(DataTable data, string filename = "", bool clearTablesAfterSave = true)
		{
			_xmlSaver.Tables.Add(data);
			if (!string.IsNullOrEmpty(filename))
			{
				if (SaveToXml(_xmlSaver, filename))
				{
					if (clearTablesAfterSave)
					{
						ClearSaveToXmlTables();
					}
				}
			}
		}

		public static bool SaveToXml(DataSet data, string filename)
		{
			var done = true;
			try
			{
				using (var fs = new StreamWriter(filename))
				{
					_xmlSaver.WriteXml(fs);
				}
			}
			catch
			{
				done = false;
			}
			return done;
		}
	}
}
