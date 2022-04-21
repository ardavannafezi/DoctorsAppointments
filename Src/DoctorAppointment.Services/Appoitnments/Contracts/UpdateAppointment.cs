using System;

namespace DoctorAppointment.Services.Appoitnments
{
    public class UpdateAppointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

    }
}