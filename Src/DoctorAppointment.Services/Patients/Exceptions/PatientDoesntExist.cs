using System;
using System.Runtime.Serialization;

namespace DoctorAppointment.Services.Patients
{
    [Serializable]
    internal class PatientDoesntExist : Exception
    {
        public PatientDoesntExist()
        {
        }

      
    }
}