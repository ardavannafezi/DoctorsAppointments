using System;
using System.Runtime.Serialization;

namespace DoctorAppointment.Services.Appoitnments
{
    [Serializable]
    internal class AppointmentDoesntExist : Exception
    {
        public AppointmentDoesntExist()
        {
        }

        public AppointmentDoesntExist(string message) : base(message)
        {
        }

        public AppointmentDoesntExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AppointmentDoesntExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}