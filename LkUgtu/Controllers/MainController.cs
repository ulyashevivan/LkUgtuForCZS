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

        public ActionResult GetModalViewVakansList()
        {
            return PartialView("ModalViewVakansList");
        }
        public ActionResult GetModalViewTrudoustrList()
        {
            return PartialView("ModalViewTrudoustrList");
        }
        public ActionResult GetModalViewTrudoustrEdit()
        {
            return PartialView("ModalViewTrudoustrEdit");
        }
        public JsonResult GetAllVakans(string search)
        {
            return Json((search==null)?new VakansListDTO().vakans:new VakansListDTO().vakans.Where(p=>p.post.ToLower().Contains(search)), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllTrudoustr(int idStud)
        { 
            return Json(new TrudoustrListDTO(idStud).trudoustrs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTrudoustr(int idTrud)
        {
            var idStud = 24611;
            return Json(new TrudoustrListDTO(idStud).trudoustrs.Where(t=>t.idTrud == idTrud), JsonRequestBehavior.AllowGet);
        }
        //public ActionResult GetVakansModalViewVakansList()
        //{
        //    var model = new VakansListDTO().vakans;
        //    return PartialView("ModalViewVakansList", model);
        //}

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