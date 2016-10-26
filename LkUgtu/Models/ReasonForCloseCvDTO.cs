using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LkUgtu.orm;

namespace LkUgtu.Models
{
    public class ReasonForCloseDTO
    {
        public int id { get; set; }
        public string name { get; set; }
    }
    
    public class ReasonsForCloseDTOList
    {
        public List<ReasonForCloseDTO> reasonsforclose { get; private set; }
        public readonly int idParam = 3; // reason close cv
        public ReasonsForCloseDTOList()
        {
            using (var db = new UGTUEntities())
            {
                reasonsforclose = new List<ReasonForCloseDTO>();
                reasonsforclose = db.ZnachParam.Where(s => s.idParam == idParam).ToList().Select(s => DTOClassConstructor.ReasonForCloseDTO(s)).ToList();
            }
        }
    }
}