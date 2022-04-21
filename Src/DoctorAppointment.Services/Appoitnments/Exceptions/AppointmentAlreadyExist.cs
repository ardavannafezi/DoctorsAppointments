using System;
using System.Runtime.Serialization;

namespace DoctorAppointment.Services.Appoitnments
{
    [Serializable]
    internal class AppointmentAlreadyExist : Exception
    {
        public AppointmentAlreadyExist()
        {
        }

        public AppointmentAlreadyExist(string message) : base(message)
        {
        }

        public AppointmentAlreadyExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AppointmentAlreadyExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}