using System;

namespace DoctorAppointment.Services.Appoitnments.Contracts
{
    public class GetAppointmentsDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }

    }
}