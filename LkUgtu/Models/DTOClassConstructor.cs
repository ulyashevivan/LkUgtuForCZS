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
                company = v.Predpriyatie.Name,
                otherInfo = v.DopInfo,
                salary = v.ZarPlata,
                schedule = v.InfoGrafikRab,
                employment = "",
                post = v.Dolznost.NameDolznost
            };
        }
    }
}