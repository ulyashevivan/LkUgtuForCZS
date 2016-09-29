using LkUgtu.orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LkUgtu.Models
{
    public class IndexDTO
    {
        public string email { get; set; }
        public string group_name { get; set; }
        public int idStud { get; set; }
        public string fullName { get; set; }
        public IndexVakansDTO vakansInIndex {get; set;}
        public IndexRegisrationDTO regisrationInIndex { get; set; }
        public IndexTrudousrDTO trudoustrInIndex { get; set; }
        public IndexDTO(string mail, string group, int ugtu_id)
        {
            this.email = mail;
            this.group_name = group;
            this.idStud = ugtu_id;
            this.fullName = this.getFullName();
            this.vakansInIndex = new IndexVakansDTO(this.idStud);
            this.regisrationInIndex = new IndexRegisrationDTO(this.idStud);
            this.trudoustrInIndex = new IndexTrudousrDTO(this.idStud);
        }
        private string getFullName()
        {
            using (UGTUEntities db = new UGTUEntities()) {
                return db.Person.Where(m => m.nCode == this.idStud).Select(m => m.PersonFullName).FirstOrDefault();
            }
        }

    }

    public class IndexVakansDTO
    {
        public int countVakans { get; set; }
        public int countPredpr { get; set; }

        public IndexVakansDTO(int idStud)
        {
            using (var db = new UGTUEntities())
            {
                this.countPredpr = db.Predpriyatie.Count();
                this.countVakans = db.Vakans.Count();
            }
        }
    }

    public class IndexRegisrationDTO
    {
        public bool state { get; set; }
        public int countReg { get; set; }

        public IndexRegisrationDTO (int idStud)
        {
            using (var db = new UGTUEntities())
            {
                var resumes = db.Resume.Where(m => m.idStud == idStud).ToArray();
                this.countReg = resumes.Count();
                this.state = (resumes.Where(m => m.idStatus == czsCONSTs.statusResumeOpen).Count() > 0) ? true : false;
            }
        }
    }
    public class IndexTrudousrDTO
    {
        public int countTridoustr { get; set; }
        public int countPraktik { get; set; }

        public IndexTrudousrDTO(int idStud)
        {
            using (var db = new UGTUEntities()) {
                var trudoustrs = db.Trudoustr.Where(m => m.IDStudent == idStud).ToArray();
                this.countTridoustr = trudoustrs.Where(m => m.IDVidPraktiki == null).Count();
                this.countPraktik = trudoustrs.Where(m => m.IDVidPraktiki != null).Count();
            }
        }
    }
}