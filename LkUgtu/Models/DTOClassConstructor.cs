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

        public static TrudoustrDTO TrudoustrDTO(Trudoustr t)
        {
            return new TrudoustrDTO()
            {
                idTrud = t.IDTrudoustr,
                idStud = t.IDStudent,
                company = t.Predpriyatie.Name,
                post = t.Dolznost.NameDolznost,
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