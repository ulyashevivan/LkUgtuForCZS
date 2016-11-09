using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LkUgtu.orm;

namespace LkUgtu.Models
{
    public static class CRUDController
    {
         public static void SaveTrud(int idStud
                                  , int? idTrud
                                  , string inputPredpr
                                  , string inputPost
                                  , string inputDepartment
                                  , int? inputSalary
                                  , string inputDateStart
                                  , string inputDateStop
                                  , string inputOtherInfo
                                  , string checkIsSpeciality
                                  , string checkWithSpravka
                                  //, HttpPostedFileBase spravkaFile
                                  , string checkIsPraktik
                                  , string inputDateAdd)
        {
            try
            {
                if (idTrud == null)
                {
                    SaveNewTrud(idStud
                        , inputPredpr
                        , inputPost
                        , inputDepartment
                        , inputSalary
                        , inputDateStart
                        , inputDateStop
                        , inputDateAdd
                        , inputOtherInfo
                        , checkIsSpeciality
                        , checkIsPraktik
                        , checkWithSpravka);
                }
                else
                {
                    SaveOldTrud((int)idTrud
                        , inputPredpr
                        , inputPost
                        , inputDepartment
                        , inputSalary
                        , inputDateStart
                        , inputDateStop
                        , inputDateAdd
                        , inputOtherInfo
                        , checkIsSpeciality
                        , checkIsPraktik
                        , checkWithSpravka);
                }
            }
            catch (Exception ex)
            {

            }
        }

        private static void SaveOldTrud(int id
                                  , string Predpr
                                  , string Post
                                  , string Department
                                  , int? Salary
                                  , string DateStart
                                  , string DateStop
                                  , string DateAdd
                                  , string OtherInfo
                                  , string IsSpeciality
                                  , string IsPraktik
                                  , string WithSpravka
                                  )
        {
            using (var db = new UGTUEntities())
            {
                Trudoustr tr = db.Trudoustr.Where(t => t.IDTrudoustr == id).FirstOrDefault();
                tr.IDPredpriyatie = GetIdPredprByName(Predpr, db);
                tr.IDDolznost = GetIdPostByName(Post, db);
                tr.Otdel = Department;
                tr.ZarPlata = Salary;
                tr.DopInfo = OtherInfo;
                tr.DataBegin = DateTime.Parse(DateStart);
                tr.DataEnd = DateTime.Parse(DateStop);
                tr.DataObzvon = DateTime.Parse(DateAdd);
                tr.RabotaPoSpec = GetBoolByString(IsSpeciality);
                tr.Spravka = GetBoolByString(WithSpravka);
                tr.IDVidPraktiki = GetIdPractikByString(IsPraktik);
                db.SaveChanges();
            }
        }

        private static int? GetIdPractikByString(string praktik)
        {
            return (praktik == null) ? (int?)null : 1;
        }
        private static bool GetBoolByString(string speciality)
        {
            return (speciality == "true"|| speciality == "on") ? true : false;
        }

        private static int? GetIdPostByName(string post, UGTUEntities db)
        {
            var result = db.Dolznost.Where(d => d.NameDolznost == post).SingleOrDefault();
            if (result == null)
            {
                return AddNewPost(post);
            }
            else
            {
                return result.IDDolznost;
            }
        }

        private static int AddNewPost(string post)
        {
            using (var d = new UGTUEntities())
            {
                Dolznost dol = new Dolznost()
                {
                    NameDolznost = post
                };
                d.Dolznost.Add(dol);
                d.SaveChanges();
                return dol.IDDolznost;
            }
        }

        private static int GetIdPredprByName(string predpr, UGTUEntities db)
        {
            var result = db.Predpriyatie.Where(p => p.Name == predpr).SingleOrDefault();
            if (result == null)
            {
                return AddNewPredpr(predpr);
            } else {
                return result.IDPredpriyatie;
            }
        }

        public static void SaveRegistration(int? idRes, int inputEmployment, string inputOtherInfo, string inputDateAdd)
        {
            try
            {
                if (idRes == null)
                {

                }
                else {
                    SaveOldRegistration((int)idRes, inputEmployment, inputOtherInfo, inputDateAdd);
                }
            } catch(Exception e)
            {
                
            }
        }

        private static void SaveOldRegistration(int idRes, int inputEmployment, string inputOtherInfo, string inputDateAdd)
        {
            using (var db = new UGTUEntities())
            {
                var registration = db.Resume.Where(w => w.idResume == idRes).SingleOrDefault();
                registration.DopInfo = inputOtherInfo;
                registration.DataPrinytiya = DateTime.Parse(inputDateAdd);
                registration.Param_Resume.Where(w => w.idParam == czsCONSTs.idParamEmployment).SingleOrDefault().idResumeZnachParam = inputEmployment;
                db.SaveChanges();
            }
        }

        private static int AddNewPredpr(string predpr)
        {
            throw new Exception();
        }

        private static void SaveNewTrud(int idStud
                                  , string Predpr
                                  , string Post
                                  , string Department
                                  , int? Salary
                                  , string DateStart
                                  , string DateStop
                                  , string DateAdd
                                  , string OtherInfo
                                  , string IsSpeciality
                                  , string IsPraktik
                                  , string WithSpravka)
        {
            using (var db = new UGTUEntities())
            {
                Trudoustr tr = new Trudoustr()
                {
                    IDStudent = idStud,
                    IDPredpriyatie = GetIdPredprByName(Predpr, db),
                    IDDolznost = GetIdPostByName(Post, db),
                    Otdel = Department,
                    ZarPlata = Salary,
                    DataBegin = DateTime.Parse(DateStart),
                    DataEnd = DateTime.Parse(DateStop),
                    DataObzvon = DateTime.Parse(DateAdd),
                    DopInfo = OtherInfo,
                    RabotaPoSpec = GetBoolByString(IsSpeciality),
                    Spravka = GetBoolByString(WithSpravka),
                    IDVidPraktiki = GetIdPractikByString(IsPraktik)
                };
                db.Trudoustr.Add(tr);
                db.SaveChanges();
            }
        }
    }
}