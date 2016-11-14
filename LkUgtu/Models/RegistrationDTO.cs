using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LkUgtu.orm;

namespace LkUgtu.Models
{
    public class RegistrationDTO
    {
        public int id { get; private set; }
        public ReasonForCloseDTO reasonClose { get; private set; }
        public DateTime dateRegistration { get; private set; }
        public DateTime? dateUnRegistration { get; private set; }
        public stateRegistrarionDTO stateReg { get; private set; }
        public EmploymentDTO employment { get; private set; }
        public string marks { get; private set; }
        public string otherInfo { get; private set; }

        public RegistrationDTO(Resume res)
        {
            id = res.idResume;
            marks = res.Otmetki;
            otherInfo = res.DopInfo;
            reasonClose = new ReasonForCloseDTO(res.Param_Resume);
            dateRegistration = res.DataPrinytiya;
            dateUnRegistration = res.DataZakritiya;
            employment = new EmploymentDTO(res.Param_Resume);
            stateReg = DTOClassConstructor.stateRegistrarionDTO(res.Status);

        }
        public RegistrationDTO()
        {
            id = 0;
            marks = null;
            otherInfo = null;
            reasonClose = null;
            dateRegistration = DateTime.Now;
            dateUnRegistration = null;
            employment = null;
            stateReg = null;

        }
    }

    public class stateRegistrarionDTO
    {
        public int id { get; set; }
        public string name { get; set; }

        public readonly int typeId = 0;
    }

    public class RegistrationDTOList
    {
        public int idStud { get; private set; }
        public List<RegistrationDTO> registrations { get; private set; }
        public RegistrationDTOList(int id)
        {
            idStud = id;
            registrations = new List<RegistrationDTO>();
            using (var db = new UGTUEntities())
            {
                var regs = db.Resume.Where(r => r.idStud == id).ToArray();
                foreach(var reg in regs)
                {
                    registrations.Add(new RegistrationDTO(reg));
                }
            }
        }
    }
}