using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static LkUgtu.oAuthLkUgtuProvider;

namespace LkUgtu.Controllers
{
    public class BaseController : Controller
    {
        // public oAuthLkUgtuProvider oAuthUgtu = new oAuthLkUgtuProvider();
        public AllInfo userInfo = null;
    }
}