using LkUgtu.Models;
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
        public JsonResult AutocompletePred()
        {
            return Json(new PredpriyatieDTO().getall(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AutocompletePost()
        {
            return Json(new PostDTO().getall(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult AutocompleteDepartment()
        {
            return Json(new TrudoustrDTO().getalldep(), JsonRequestBehavior.AllowGet);
        }
    }
}