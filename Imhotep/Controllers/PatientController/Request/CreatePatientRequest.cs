using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Imhotep.Controllers.PatientController.Request
{
    public class CreatePatientRequest
    {
        public string FirstName { get;  set; }
        public string LastName { get;  set; }
        public string MiddleName { get;  set; }
        public DateTime DOB { get;  set; }
        public string NationaID { get;  set; }
        public string Address { get;  set; }
    }
}
