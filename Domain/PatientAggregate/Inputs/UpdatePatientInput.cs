using System;

namespace Domain.PatientAggregate.Inputs
{
    public class UpdatePatientInput
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public DateTime DOB { get; set; }
        public string NationaID { get; set; }
        public string Address { get; set; }
        public long UpdatedBy { get; set; }
    }
}