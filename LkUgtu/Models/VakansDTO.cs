using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LkUgtu.orm;

namespace LkUgtu.Models
{
    public class VakansDTO
    {
        public int idVakans { get; set; }
        public string post { get; set; }
        public string company { get; set; }
        public string salary { get; set; }
        public string employment { get; set; }
        public string schedule { get; set; }
        public string otherInfo { get; set; }
    }

    public class VakansListDTO
    {
        private readonly int stVakansOpen = 1;// open vakans
        public List<VakansDTO> vakans { get; private set; }
        public VakansListDTO()
        {
            using (var db = new UGTUEntities())
            {
                this.vakans = new List<VakansDTO>();
                var v = db.Vakans.Where(s=>s.idStatus == stVakansOpen).OrderByDescending(o=>o.DataPostVakans).ToList();
                this.vakans = v.Select(s => DTOClassConstructor.VakansDTO(s)).ToList();
            }
        }
     

      
    }
}