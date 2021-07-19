using MediatR;
using System;

namespace Domain.PatientAggregate.Events
{
    public class UpdatePatientEvent : EventArgs, INotification
    {
        public Patient NewPatient { get; set; }
    }
}