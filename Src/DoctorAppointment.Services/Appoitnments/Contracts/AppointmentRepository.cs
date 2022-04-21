using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appoitnments.Contracts
{
    public interface AppointmentRepository
    {
        void Add(Appointment appointment);
        bool IsExist(int doctorId, int patientId, DateTime date );
        bool IsExistById(int id);
        List<GetAppointmentsDto> GetAll();
        void Delete(Appointment appointment);
        public Appointment GetAppointmentById(int Id);
    }
}