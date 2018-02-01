using System;
using log4net;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Utilities
{
	public static class LogHelper
	{
		private static readonly string DefaultFilePath = AppDomain.CurrentDomain.BaseDirectory + "/UserLog/";
		private static readonly Dictionary<string, string> HashFiles = new Dictionary<string, string>();

		public static void LogError<T>(this T that, Exception ex, string message = null)
		{
			var log = LogManager.GetLogger(typeof(T));
			log.Error(message, ex);
		}

		public static void LogInfo<T>(this T that, string message, Exception ex = null)
		{
			var log = LogManager.GetLogger(typeof(T));
			log.Info(message, ex);
		}

		public static void LogError(this Type that, Exception ex, string message = null)
		{
			var log = LogManager.GetLogger(that);
			log.Error(message, ex);
		}

		public static void LogInfo(this Type that, string message, Exception ex = null)
		{
			var log = LogManager.GetLogger(that);
			log.Info(message, ex);
		}

		public static bool UserLog(string content, string title = null, string fileName = null, string filePath = null)
		{
			var defaultFfileName = DateTime.Today.ToString("yyyyMMdd") + ".txt";
			var name = fileName ?? defaultFfileName;
			if (!HashFiles.ContainsKey(name))
				HashFiles.Add(name, name.ToMd5());

			var str = new StringBuilder();
			str.AppendLine("-----------------------------------------------------------------------");
			str.AppendLine("时间:" + DateTime.Now.ToString("O"));
			if (!title.IsNullOrEmpty())
			{
				str.AppendLine("标题:" + title);
			}
			str.AppendLine("内容:" + content);
			str.AppendLine("-----------------------------------------------------------------------\r\n\r\n");

			try
			{
				lock (HashFiles[name])
				{
					var path = (filePath ?? DefaultFilePath) + name;
					var directoryName = new FileInfo(path).DirectoryName;
					if (directoryName != null && !Directory.Exists(directoryName))
					{
						Directory.CreateDirectory(directoryName);
					}
					File.AppendAllText(path, str.ToString(), Encoding.UTF8);
					return true;
				}
			}
			catch
			{
				return false;
			}
		}
	}
}