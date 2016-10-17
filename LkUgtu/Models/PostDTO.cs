using LkUgtu.Models;
using LkUgtu.orm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LkUgtu.Models
{
    public class PostDTO
    { 
        public int id { get; set; }
        public string name { get; set; }
        internal List<PostDTO> getall()
        {
            using (var db = new UGTUEntities())
            {
                var d = db.Dolznost.ToList();
                return d.Select(m => DTOClassConstructor.PostDTO(m)).ToList();
            }
        }
    }
}