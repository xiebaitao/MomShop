using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mom.Web.Areas.Users.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Users/Login
        public ActionResult Index()
        {
            return View();
        }
    }
}