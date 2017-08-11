using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HIMS.Utilities
{
    public class Logger
    {
        public Logger()
        {

        }

        private static log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public static void LogInfo(string infoMessage)
        {
            Log.Info(infoMessage);
        }

        public static void LogWarning(string warningMessage)
        {
            Log.Warn(warningMessage);
        }

        public static void LogError(string errorMessage, Exception ex)
        {
            Log.Error(errorMessage, ex);
        }

        public static void LogError(string errorMessage)
        {
            Log.Error(errorMessage);
        }

        public static void LogLatency(string section, TimeSpan time)
        {
            Logger.LogInfo(string.Format("Section '{0}' took {1} minute(s) and {2} seconds to execute.", section, time.Minutes, time.Seconds));
        }
    }
}
