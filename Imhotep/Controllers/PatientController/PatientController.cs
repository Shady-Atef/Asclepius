using Imhotep.Controllers.PatientController.Request;
using Domain.PatientAggregate;
using Domain.PatientAggregate.Inputs;
using Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Imhotep.Controllers.PatientController
{
    [ApiController]
    [Route("api/Patient")]
    public class PatientController : Controller
    {
        public ImhotepUOW UOW { get; }
        public IMediator Mediator { get; }

        public PatientController(ImhotepUOW _uow, IMediator _mediatR)
        {
            this.UOW = _uow;
            this.Mediator = _mediatR;
        }

        [HttpPost]
        [Route("CreatePatient")]
        public IActionResult Create(CreatePatientRequest request)
        {
            Patient Patient = new Patient();
            var user = User.Identity.Name;
            var input = new CreatePatientInput
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Address = request.Address,
                DOB = request.DOB,
                MiddleName = request.MiddleName,
                NationaID = request.NationaID,
                PatientID = UOW.PatientRepo.GetNextRoaderKey()
            };
            Patient.Create(input);
            Patient.OnEvent += OnAggregateEvent;
            UOW.PatientRepo.Add(Patient);
            UOW.SaveChanges();
            return Ok();
        }

        private void OnAggregateEvent(object sender, EventArgs e)
        {
            Mediator.Publish(e);
        }
    }
}