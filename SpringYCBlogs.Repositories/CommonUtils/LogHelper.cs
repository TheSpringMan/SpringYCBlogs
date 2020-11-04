using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace SpringYCBlogs.Infrastructure.CommonUtils
{
    public class LogHelper
    {
        private static ILog _log = LogManager.GetLogger("SpringYCBlogsLog");
        public static void Info(string message)
        {
            _log.Info(message);
        }

        public static void Info(string message, Exception ex)
        {
            _log.Info(message, ex);
        }

        public static void Error(string message)
        {
            _log.Error(message);
        }

        public static void Error(string message, Exception ex)
        {
            _log.Error(message, ex);
        }
    }
}
