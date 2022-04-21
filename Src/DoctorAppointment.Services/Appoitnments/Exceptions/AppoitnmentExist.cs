using System;
using System.Runtime.Serialization;

namespace DoctorAppointment.Services.Appoitnments
{
    [Serializable]
    internal class AppoitnmentExist : Exception
    {
        public AppoitnmentExist()
        {
        }

        public AppoitnmentExist(string message) : base(message)
        {
        }

        public AppoitnmentExist(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AppoitnmentExist(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}