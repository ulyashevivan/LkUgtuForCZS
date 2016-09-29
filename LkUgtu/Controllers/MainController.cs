using LkUgtu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static LkUgtu.oAuthLkUgtuProvider;

namespace LkUgtu.Controllers
{
    public class MainController : BaseController
    {
        // GET: Main
        public ActionResult Index()
        {
            //if (userInfo==null) {return RedirectToAction("Login", "Account"); }
            var res = oAuthLkUgtuProvider.GetAllInfo();
            IndexDTO dto;
            if (res.type == "Error") {
                return View("Error", "Получены некоректные данные");
            }
            if ((bool)res.is_student || (bool)res.is_worker)
            {

                userInfo = res;
                dto = new IndexDTO(
                    userInfo.student_info.accs.FirstOrDefault().email, 
                    userInfo.student_info.accs.FirstOrDefault().group_name, 
                    userInfo.student_info.accs.FirstOrDefault().ugtu_id
                    );
                return View(dto);
            } else
            {
                return View("Error", "Вы не являетесь студентом или сотрудником УГТУ");
            }
        }


        //public ActionResult VakansPanel(AllInfo info)
        //{
        //    return PartialView();
        //}
        //public ActionResult RegistrationPanel(AllInfo info)
        //{
        //    return PartialView();
        //}
        //public ActionResult TrudoustrPanel(AllInfo info)
        //{
        //    return PartialView();
        //}


    }
}