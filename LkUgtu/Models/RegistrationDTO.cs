using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LkUgtu.Models
{
    public class RegistrationDTO
    {
        public int id { get; private set; }
        public ReasonForCloseDTO reasonClose { get; private set; }
        public DateTime dateRegistration { get; private set; }
        public stateRegistrarionDTO stateReg { get; private set; }
        public string marks { get; private set; }
        public string otherInfo { get; private set; }
    }

    public class stateRegistrarionDTO
    {
        public int id { get; private set; }
        public string name { get; private set; }

        public readonly int typeId = 0;
    }

    public class RegistrationDTOList
    {
        public List<RegistrationDTO> registrations { get; private set; }
    }
}