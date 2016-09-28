using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LkUgtu.Controllers
{
    public class AccountController : BaseController
    {
        
        // GET: Account
        public void Login()
        {
            //oAuthUgtu.init("d3d5994a1485f599e05cc04d4ea8d2 ", "270cafee3c7183b8cf8cf98dc79bbe", "http://localhost:6358/Account/GetCode");
            oAuthLkUgtuProvider.SendUserToURI();
        }


        public ActionResult GetCode(string code)
        {
            if (oAuthLkUgtuProvider.GetToken(code))
            {
                return RedirectToAction("Index", "Main");
            } else
            {
                return View("Error");
            }
        }
    }
}