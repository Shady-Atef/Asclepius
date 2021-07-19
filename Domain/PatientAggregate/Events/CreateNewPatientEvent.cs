using MediatR;
using System;

namespace Domain.PatientAggregate.Events
{
    public class CreateNewPatientEvent : EventArgs, INotification
    {
        public Patient NewPatient { get; set; }
    }
}