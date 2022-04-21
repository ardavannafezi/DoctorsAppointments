using DoctorAppointment.Services.Appoitnments;
using DoctorAppointment.Services.Appoitnments.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DoctorAppointment.RestAPI.Controllers
{
    [Route("api/appointment")]
    [ApiController]
    public class AppointmentController : ControllerBase
    {
        private readonly AppointmenmtService _service;

        public AppointmentController(AppointmenmtService service)
        {
            _service = service;
        }

        [HttpPost]
        public void AddAppointment(AddAppointmentDto dto)
        {
            _service.Add(dto);
        }

        [HttpGet]
        public List<GetAppointmentsDto> GetAppoitnment()
        {
            return _service.GetAll();
        }

        [HttpDelete("{id}")]
        public void DeleteAppointment(int Id)
        {
            _service.Delete(Id);
        }
        

        [HttpPut]
        public void UpdateApppointment(int Id, UpdateAppointment dto)
        {
            _service.Update(Id, dto);
        }
        
    }   
}
