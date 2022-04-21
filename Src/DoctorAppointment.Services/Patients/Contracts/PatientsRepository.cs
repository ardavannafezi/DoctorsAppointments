using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientsRepository
    {
        void Add(Patient patient);
        bool IsExistNationalCode(string nationalCode);
        List<GetPatientDto> GetAll();
        void Delete(Patient patient);
        public Patient GetPatientById(string nationalId);
    }
}