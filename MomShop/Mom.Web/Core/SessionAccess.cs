using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace Mom.Web
{
    public class SessionAccess:HttpBase
    {
        public static int UserID
        {
            get
            {
                return Convert.ToInt32(Session["UserID"]);
            }
            set
            {
                Session["UserID"] = value;
            }
        }

        public static string Name
        {
            get
            {
                return Session["Name"].ToString();
            }
            set
            {
                Session["Name"] = value;
            }
        }
    }
}