using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AssistanceOnlineWeb.Controllers
{
    public class UsersController : Controller
    {
       
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

      
    }
}
