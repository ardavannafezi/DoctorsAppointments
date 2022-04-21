using System;
using System.Runtime.Serialization;

namespace DoctorAppointment.Services.Appoitnments
{
    [Serializable]
    internal class DayIsFull : Exception
    {
        public DayIsFull()
        {
        }

        public DayIsFull(string message) : base(message)
        {
        }

        public DayIsFull(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected DayIsFull(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}