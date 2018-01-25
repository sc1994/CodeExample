using System;
using log4net;

namespace Utilities
{
    public static class LogHelper
    {
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
    }
}