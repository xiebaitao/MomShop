using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Mom.Web
{
    public class BaseController:Controller
    {
        /// <summary>
        /// 页码
        /// </summary>
        protected int PageIndex
        {
            get
            {
                return int.Parse(Request["PageIndex"] ?? "1");
            }
        }

        /// <summary>
        /// 显示的条数
        /// </summary>
        protected int PageSize
        {
            get
            {
                return int.Parse(Request["PageSize"] ?? "15");
            }
        }

        /// <summary>
        /// 是否验证登录 默认不登录false
        /// </summary>
        protected virtual bool IsLogin
        {
            get
            {
                return false;
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //检查登录
            if (IsLogin && SessionAccess.UserID <= 0)
            {
                filterContext.HttpContext.Response.Redirect("/Login/Index");
            }

            base.OnActionExecuting(filterContext);
        }

        //重写json
        protected override JsonResult Json(object data, string contentType, Encoding contentEncoding, JsonRequestBehavior behavior)
        {
            return new CustomsJsonResult { Data = data, ContentType = contentType, ContentEncoding = contentEncoding, JsonRequestBehavior = behavior };
        }
    }
}