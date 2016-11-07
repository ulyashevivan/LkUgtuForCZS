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
        public readonly int idParam = 3; // reason close cv
        public ReasonForCloseDTO()
        {
        }
        public ReasonForCloseDTO(ICollection<Param_Resume> paramRes)
        {
            using(var db = new UGTUEntities())
            {
                var reason = paramRes.Where(p => p.idParam == idParam).SingleOrDefault();
                if (reason != null)
                {
                    id = (int)reason?.idResumeZnachParam;
                    name = db.ZnachParam.SingleOrDefault(d => d.idZnachParam == id)?.ZnachParamName;
                }
            }
        }
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