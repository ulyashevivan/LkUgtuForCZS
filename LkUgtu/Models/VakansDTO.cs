using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LkUgtu.orm;

namespace LkUgtu.Models
{
    public class VakansDTO
    {
        public string post { get; set; }
        public string company { get; set; }
        public string salary { get; set; }
        public string employment { get; set; }
        public string schedule { get; set; }
        public string otherInfo { get; set; }
    }

    public class VakansListDTO
    {
        public List<VakansDTO> vakans { get; private set; }
        public VakansListDTO()
        {
            using (var db = new UGTUEntities())
            {
                this.vakans = new List<VakansDTO>();
                var v = db.Vakans.ToList();
                this.vakans = v.Select(s => DTOClassConstructor.VakansDTO(s)).ToList();
            }
        }
     

      
    }
}