using System;
using System.Runtime.Serialization;

namespace DoctorAppointment.Services.Doctors
{
    [Serializable]
    internal class DoctorDontExist : Exception
    {
        public DoctorDontExist()
        {
        }

        public DoctorDontExist(string message) : base(message)
        {
        }

        public DoctorDontExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DoctorDontExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}