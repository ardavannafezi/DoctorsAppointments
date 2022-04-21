using DoctorAppointment.Services.Patients;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/Patients")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly PatientsService _service;

        public PatientsController(PatientsService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddPatient(AddPatientDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetPatientDto> GetPatient()
        {
            return _service.GetAll();
        }

        [HttpDelete("{nationalId}")]
        public void DeletePatient(string nationalId)
        {
            _service.Delete(nationalId);
        }
        

        [HttpPut]
        public void UpdatePatient(string nationalCode, UpdatePatientsDto dto)
        {
            _service.Update(nationalCode, dto);
        }
        
    }   
}
