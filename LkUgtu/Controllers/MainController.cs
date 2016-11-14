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
                HttpContext.Session["idStud"] = dto.idStud;
                //HttpContext.Session["emailStud"] = dto.email;
                //HttpContext.Session["FIOStud"] = dto.fullName;
                //HttpContext.Session["groupStud"] = dto.group_name;
                //HttpContext.Response.Cookies["idStud"].Value = dto.idStud.ToString();
                //HttpContext.Response.Cookies["emailStud"].Value = dto.email;
                //HttpContext.Response.Cookies["FIOStud"].Value = dto.fullName;
                //HttpContext.Response.Cookies["groupStud"].Value = dto.group_name;
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
            return Json((search==null)?new VakansListDTO().vakans.ToList():new VakansListDTO().vakans.Where(p=>p.post.ToLower().Contains(search)).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllTrudoustr()
        {
            int idStud = (int)HttpContext.Session["idStud"];
            return Json(new TrudoustrListDTO(idStud).trudoustrs, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTrudoustr(int idTrud)
        {
            int idStud = (int)HttpContext.Session["idStud"];
            return Json(new TrudoustrListDTO(idStud).trudoustrs.Where(t=>t.idTrud == idTrud).ToList(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllRegs()
        {
            //string stud = HttpContext.Request.Cookies["idStud"].Value;
            //string email = HttpContext.Request.Cookies["emailStud"].Value;
            //string fio = HttpContext.Request.Cookies["FIOStud"].Value;
            //string group = HttpContext.Request.Cookies["groupStud"].Value;
            int idStud = (int)HttpContext.Session["idStud"];
            //int idStud = int.Parse(HttpContext.Request.Cookies["idStud"].Value);
            return Json(new RegistrationDTOList(idStud).registrations.OrderByDescending(o=>o.dateRegistration), JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetModalAddRegistration()
        {
            int idStud = (int)HttpContext.Session["idStud"];
            ViewBag.action = "Добавление";
            RegistrationDTO model = new RegistrationDTO();
            var employments = new EmploymentDTOList().employments;
            ViewBag.employments = new SelectList(employments, typeof(EmploymentDTO).GetProperties()[0].Name, typeof(EmploymentDTO).GetProperties()[1].Name).ToList();
            return PartialView("ModalViewRegistrationEdit", model);
        }
        public ActionResult GetModalEditRegistration()
        {
            int idStud = (int)HttpContext.Session["idStud"];
            ViewBag.action = "Редактирование";
            var model = new RegistrationDTOList(idStud).registrations.Where(w => w.dateUnRegistration == null && w.stateReg.id == czsCONSTs.statusResumeOpen).SingleOrDefault();
            var employments = new EmploymentDTOList().employments;
            ViewBag.employments = new SelectList(employments
                , typeof(EmploymentDTO).GetProperties()[0].Name
                , typeof(EmploymentDTO).GetProperties()[1].Name
                , model.employment.id).ToList();
            return PartialView("ModalViewRegistrationEdit",model);
        }
        public ActionResult GetModalHistoryRegistration()
        {
            return PartialView("ModalViewRegistrationHistory");
        }
        public ActionResult GetModalCloseRegistration()
        {
            int idStud = (int)HttpContext.Session["idStud"];
            var reasonsforclose = new ReasonsForCloseDTOList().reasonsforclose;
            ViewBag.idStud = idStud;
            ViewBag.reasonsforclose = new SelectList(reasonsforclose, typeof(ReasonForCloseDTO).GetProperties()[0].Name, typeof(ReasonForCloseDTO).GetProperties()[1].Name).ToList();
            return PartialView("ModalViewRegistrationClose");
        }
        public JsonResult EditRegistrationSave(
             int? idRes
            ,int inputEmployment
            ,string inputOtherInfo
            ,string inputDateAdd)
        {
            int idStud = (int)HttpContext.Session["idStud"];
            CRUDController.SaveRegistration(idStud, idRes, inputEmployment, inputOtherInfo, inputDateAdd);
            return Json("OK",JsonRequestBehavior.AllowGet);
        }
        public JsonResult CloseRegistrationSave(
            int idStud
            ,int inputReasonClose
            ,string inputDateClose)
        {
            CRUDController.CloseRegistration(idStud, inputReasonClose, inputDateClose);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }
        public JsonResult SendTrud(int? idTrud
                                  , string inputPredpr
                                  , string inputPost
                                  , string inputDepartment
                                  , int? inputSalary
                                  , string inputDateStart
                                  , string inputDateStop
                                  , string inputOtherInfo
                                  , string checkIsSpeciality
                                  , string checkWithSpravka
                                  , string checkIsPraktik
                                  , string inputDateAdd)
        {
            var r = Request.Params["inputPredpr"];
            var file = Request.Files["spravkaFile"];
            int idStud = (int)HttpContext.Session["idStud"];
            CRUDController.SaveTrud(idStud
                                  , idTrud
                                  , inputPredpr
                                  , inputPost
                                  , inputDepartment
                                  , inputSalary
                                  , inputDateStart
                                  , inputDateStop
                                  , inputOtherInfo
                                  , checkIsSpeciality
                                  , checkWithSpravka
                                  , checkIsPraktik
                                  , inputDateAdd);
            return Json("OK", JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetAllRegistrations(int idStud)
        //{

        //    return Json(null, JsonRequestBehavior.AllowGet);
        //}
    }
}