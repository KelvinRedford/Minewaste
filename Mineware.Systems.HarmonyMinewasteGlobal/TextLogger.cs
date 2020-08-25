using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Mineware.Systems.MinewasteGlobal
{
	/// <summary>
	/// TextEventLog : Simplified text logger.
	/// Start by ClearLog, then write the events, and end by FinaliseLog()
	/// </summary>
	public static class TextEventLog
	{
		private static string _logFilePath = string.Empty;
		private const string Path = @"C:\Logs";
		private static bool _enabled;
		private static readonly StringBuilder Queued = new StringBuilder(); 

		public static bool Enabled { get { return _enabled; } set { _enabled = value; } }

		public static bool DoEventLogging
		{
			get { return File.Exists(Path + @"\doLogging.txt"); }
		}

		private static readonly Stopwatch Lapser = new Stopwatch();
		private static string _lapserMsg;

		public static void ClearLog()
		{
			Queued.Clear();
			// Make sure we have a working log file
			if (_logFilePath == string.Empty)
			{
				_logFilePath = Path + @"\Log-" + DateTime.Today.ToString("MM-dd-yyyy") + "." + "txt";
			}
			if (!Directory.Exists(Path))
			{
				Directory.CreateDirectory(Path);
			}
			if (!File.Exists(_logFilePath))
			{
				File.Create(_logFilePath);
			}
		}

		public static void WriteLog(string strLog)
		{
			// Only record when active
			if (_enabled)
			{
				Queued.Append(string.Format("{0:dd-MM-yyyy hh:mm:ss.fff tt} -> {1}{2}",
					DateTime.Now,
					strLog,
					Environment.NewLine));
			}
		}

		public static void FinaliseLog()
		{
			if (Queued.Length > 0)
			{
				File.AppendAllText(_logFilePath, Queued.ToString());
			}
		}

		public static void StartTimerEvent(string msg)
		{
			_lapserMsg = msg;
			Lapser.Restart();
		}

		public static void WriteTimedEvent()
		{
			Lapser.Stop();
			WriteLog(_lapserMsg + " : " + Lapser.Elapsed);
		}

		public static void SaveData(DataTable data, string prefix = "")
		{
			if (!_enabled)
			{
				return;
			}
			var file = Path + @"\" + prefix + data.TableName + ".xml";
			if (File.Exists(file))
			{
				File.Delete(file);
			}
			data.WriteXml(file);
		}
	}
}

