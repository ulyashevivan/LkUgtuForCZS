using LkUgtu.orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LkUgtu.Models
{
    public class TrudoustrDTO
    {
        public int idTrud { get; set; }
        public decimal idStud { get; set; }
        public DolznostDTO post { get; set; }
        public PredpriyatieDTO company { get; set; }
        public string department { get; set; }
        public Nullable<DateTime> dateStart { get; set; }
        public Nullable<DateTime> dateStop { get; set; }
        public int? salary { get; set; }
        public string otherInfo { get; set; }
        public Nullable<DateTime> dateCall { get; set; }
        public bool? isWorkSpecialty { get; set; }
        public bool? withSpravka { get; set; }
        public bool? isPractik { get; set; }
        public List<DepartmentDTO> getalldep()
        {
            using (var db = new UGTUEntities())
            {
                var tr = db.Trudoustr.ToList();
                return tr.Select(d=>DTOClassConstructor.DepartmentDTO(d)).Where(d=>d.name!=null).Distinct().ToList();
            }
        }
    }

    public class TrudoustrListDTO
    {
        public List<TrudoustrDTO> trudoustrs { get; private set; }
        public TrudoustrListDTO(int idStud)
        {
            using (var db = new UGTUEntities())
            {
                this.trudoustrs = new List<TrudoustrDTO>();
                var t = db.Trudoustr.Where(s=>s.IDStudent == idStud).ToList();
                this.trudoustrs = t.Select(s => DTOClassConstructor.TrudoustrDTO(s)).ToList();
            }
        }
    }
    public class DepartmentDTO: IEquatable<DepartmentDTO>
    {
        public int id { get; set; }
        public string name { get; set; }

        public bool Equals(DepartmentDTO other)
        {
            if (this.name == other.name)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override int GetHashCode()
        {
            return this.name.GetHashCode();
        }
    }
}