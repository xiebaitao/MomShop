using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
namespace Mom.Common
{
    public static class LogHelper
    {
        /// <summary>
        /// 不用理
        /// </summary>
        public static string Name { get; set; } = "logger";

        public readonly static ILog log = LogManager.GetLogger(Name);

        /// <summary>
        /// 打印错误日志
        /// </summary>
        /// <param name="content"></param>
        public static void Write(object content)
        {
            log.Error(content);
        }
    }
}
