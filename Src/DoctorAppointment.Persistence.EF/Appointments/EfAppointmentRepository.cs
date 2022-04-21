using DoctorAppointment.Entities;
using DoctorAppointment.Services.Appoitnments.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DoctorAppointment.Persistence.EF.Appointments
{
    public class EFAppointmentRepository : AppointmentRepository
    {
        private readonly DbSet<Appointment> _Appointments;

        public EFAppointmentRepository(ApplicationDbContext dbcontext)
        {
            _Appointments = dbcontext.Set<Appointment>();
        }

        public void Add(Appointment appointment)
        {
            _Appointments.Add(appointment);
        }


        public Appointment GetAppointmentById(int Id) {
            return _Appointments.FirstOrDefault(_ => _.Id == Id);
        }

        public void Delete(Appointment appointment)
        {
            _Appointments.Remove(appointment);
        }

        public List<GetAppointmentsDto> GetAll()
        {
            return _Appointments.Select(x => new GetAppointmentsDto
            {
                Id = x.Id,
                DoctorId = x.DoctorId,
                PatientId = x.PatientId,
                Date = x.Date,
            }).ToList();
        }

        public bool IsExist(int doctorId, int patientId, DateTime date)
        {
            return _Appointments.Any(_ => _.DoctorId == doctorId
            && _.PatientId == patientId && _.Date == date.Date);
        }

        public bool IsExistById(int id)
        {
            return _Appointments.Any(_ => _.Id == id);
        }

        public int CountDoctorAppointment(int DoctorId, DateTime Date)
        {
                var doctorsappointments = _Appointments
                  .Where(_ => _.DoctorId == DoctorId && _.Date == Date.Date)
                  .Select(_ => new Appointment
                  {
                      DoctorId = _.Doctor.Id,
                  });

                return doctorsappointments.Count();
            
        }
    }
}
