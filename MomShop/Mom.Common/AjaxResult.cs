using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mom.Common
{
    /// <summary>
    /// ajax统一返回数据格式
    /// </summary>
    public class AjaxResult
    {
        /// <summary>
        /// 0失败  1成功
        /// </summary>
        public int code { get; set; }

        /// <summary>
        /// 提示信息
        /// </summary>
        public string msg { get; set; }

        /// <summary>
        /// 返回数据
        /// </summary>
        public object data { get; set; }
      
    }
}
