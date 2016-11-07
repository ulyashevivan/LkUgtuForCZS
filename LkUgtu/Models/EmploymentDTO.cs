using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LkUgtu.orm;

namespace LkUgtu.Models
{
    public class EmploymentDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public readonly int idParam = 2; // employment
        public EmploymentDTO(){}
        public EmploymentDTO(ICollection<Param_Resume> paramRes)
        {
            using (var db = new UGTUEntities())
            {
                var empl = paramRes.Where(p => p.idParam == idParam).SingleOrDefault();
                if (empl != null)
                {
                    id = (int)empl?.idResumeZnachParam;
                    name = db.ZnachParam.SingleOrDefault(d => d.idZnachParam == id)?.ZnachParamName;
                }
            }
        }
    }
    public class EmploymentDTOList
    {
        public List<EmploymentDTO> employments { get; private set; }
        public readonly int idParam = 2; // employment
        public EmploymentDTOList()
        {
            using (var db = new UGTUEntities())
            {
                employments = new List<EmploymentDTO>();
                employments = db.ZnachParam.Where(s => s.idParam == idParam).ToList().Select(s => DTOClassConstructor.EmploymentDTO(s)).ToList();
            }
        }
    }
}