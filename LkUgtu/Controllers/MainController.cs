﻿using LkUgtu.Models;
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
        /// <summary>
        /// Получение модального окна для списка вакансий
        /// </summary>
        /// <returns></returns>
        public ActionResult GetModalViewVakansList()
        {
            return PartialView("ModalViewVakansList");
        }
        /// <summary>
        /// Получение модального окна для списка трудоустройств
        /// </summary>
        /// <returns></returns>
        public ActionResult GetModalViewTrudoustrList()
        {
            return PartialView("ModalViewTrudoustrList");
        }
        /// <summary>
        /// Получение модального окна для редктирования трудоустройства
        /// </summary>
        /// <returns></returns>
        public ActionResult GetModalViewTrudoustrEdit()
        {
            ViewBag.action = "Правка";
            return PartialView("ModalViewTrudoustrEdit");
        }

        /// <summary>
        /// Получение модального окна  для добавления трудоустройства
        /// </summary>
        /// <returns></returns>
        public ActionResult GetModalAddTrudoustr()
        {
            ViewBag.action = "Добавление";
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
            var idStud = 29124;
            return Json(new TrudoustrListDTO(idStud).trudoustrs.Where(t=>t.idTrud == idTrud), JsonRequestBehavior.AllowGet);
        }
        public JsonResult SendTrud()
        {
            var r = Request;
            var c = Response;
            return Json(r, JsonRequestBehavior.AllowGet);
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