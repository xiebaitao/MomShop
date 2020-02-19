using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace Mom.Web
{
    public class HttpBase
    {
        public static HttpRequest Request
        {
            get
            {
                return HttpContext.Current.Request;
            }
        }

        public static HttpResponse Response
        {
            get
            {
                return HttpContext.Current.Response;
            }
        }
        public static HttpSessionState Session
        {
            get
            {
                return HttpContext.Current.Session;
            }
        }
    }
}