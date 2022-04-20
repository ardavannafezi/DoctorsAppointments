using System;
using System.Runtime.Serialization;

namespace DoctorAppointment.Services.Patients
{
    [Serializable]
    internal class PatientAlreadyExistException : Exception
    {
        public PatientAlreadyExistException()
        {
        }

    }
}