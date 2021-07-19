using Domain.PatientAggregate.Events;
using Domain.PatientAggregate.Inputs;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.PatientAggregate
{
    [Table("Patient")]
    public class Patient : ParentEntity
    {
        #region props

        [Key]
        public long PatientID { get; private set; }

        [ConcurrencyCheck]
        public int Version { get; set; }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        public DateTime DOB { get; private set; }
        public string NationaID { get; private set; }
        public string Address { get; private set; }

        #endregion props

        #region Event

        public event EventHandler OnEvent;

        #endregion Event

        public void Create(CreatePatientInput input)
        {
            this.PatientID = input.PatientID;
            this.FirstName = input.FirstName;
            this.MiddleName = input.MiddleName;
            this.LastName = input.LastName;
            this.NationaID = input.NationaID;
            this.Address = input.Address;
            this.CreatedBy = input.CreatedBy;
            this.CreationTime = DateTime.Now;
            this.Version++;

            OnEvent?.Invoke(this, new CreateNewPatientEvent
            {
                NewPatient = this
            });
        }

        public void Update(UpdatePatientInput input)
        {
            this.FirstName = input.FirstName;
            this.MiddleName = input.MiddleName;
            this.LastName = input.LastName;
            this.NationaID = input.NationaID;
            this.Address = input.Address;
            this.UpdatedBy = input.UpdatedBy;
            this.Version++;

            OnEvent?.Invoke(this, new UpdatePatientEvent
            {
                NewPatient = this
            });
        }
    }
}