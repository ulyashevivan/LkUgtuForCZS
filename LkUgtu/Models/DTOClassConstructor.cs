using LkUgtu.orm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LkUgtu.Models
{
    public static class DTOClassConstructor
    {
        public static VakansDTO VakansDTO(Vakans v)
        {
            return new VakansDTO()
            {
                idVakans = v.idVakans,
                company = v.Predpriyatie.Name,
                otherInfo = v.DopInfo,
                salary = v.ZarPlata,
                schedule = v.InfoGrafikRab,
                employment = "",
                post = v.Dolznost.NameDolznost
            };
        }
        public static PostDTO PostDTO(Dolznost p)
        {
            return new PostDTO()
            {
                id = p.IDDolznost,
                name = p.NameDolznost
            };
        }

        public static ReasonForCloseDTO ReasonForCloseDTO(ZnachParam s)
        {
            return new ReasonForCloseDTO()
            {
                id = s.idZnachParam,
                name = s.ZnachParamName
            };
        }

        public static EmploymentDTO EmploymentDTO(ZnachParam s)
        {
            return new EmploymentDTO()
            {
                id = s.idZnachParam,
                name = s.ZnachParamName
            };
        }

        public static PredpriyatieDTO PredpriyatieDTO(Predpriyatie p)
        {
            return new PredpriyatieDTO()
            {
                    id = p.IDPredpriyatie,
                    name = p.Name
            };
        }
        public static DepartmentDTO DepartmentDTO (Trudoustr tr)
        {
            return new DepartmentDTO()
            {
                id = 0,
                name = tr.Otdel
            };
        }
        public static TrudoustrDTO TrudoustrDTO(Trudoustr t)
        {
            return new TrudoustrDTO()
            {
                idTrud = t.IDTrudoustr,
                idStud = t.IDStudent,
                company = new PredpriyatieDTO() {id=t.Predpriyatie.IDPredpriyatie, name=t.Predpriyatie.Name },
                post = new DolznostDTO() { id = t.Dolznost.IDDolznost, name = t.Dolznost.NameDolznost },
                salary = t.ZarPlata,
                department = t.Otdel,
                otherInfo = t.DopInfo,
                withSpravka = t.Spravka,
                isWorkSpecialty = t.RabotaPoSpec,
                dateStart = t.DataBegin,
                dateStop = t.DataEnd,
                dateCall = t.DataObzvon,
                isPractik = (t.IDVidPraktiki!=null)?true:false,
            };
        }
    }
}