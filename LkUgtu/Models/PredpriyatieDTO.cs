using System.Collections.Generic;
using LkUgtu.orm;
using System.Linq;

namespace LkUgtu.Models
{
    public class PredpriyatieDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public List<PredpriyatieDTO> getall()
        {
            using (var db = new UGTUEntities())
            {
                var p = db.Predpriyatie.ToList();
                return p.Select(m=>DTOClassConstructor.PredpriyatieDTO(m)).ToList();
            }
        }
    }
}