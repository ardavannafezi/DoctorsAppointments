using DoctorAppointment.Services.Doctors;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorsController : ControllerBase
    {
        private readonly DoctorService _service;

        public DoctorsController(DoctorService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddDoctor(AddDoctorDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetDoctorDto> GetDoctors()
        {
            return _service.GetAll();
        }

        [HttpDelete("{nationalId}")]
        public void DeleteDoctor(string nationalId)
        {
            _service.Delete(nationalId);
        }
        

        [HttpPut]
        public void Update(string nationalCode, UpdatedocterDto dto)
        {
            _service.Update(nationalCode, dto);
        }
        
    }   
}
