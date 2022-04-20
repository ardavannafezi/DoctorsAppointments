using DoctorAppointment.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorRepository
    {
        void Add(Doctor doctor);
        bool IsExistNationalCode(string nationalCode);
        List<GetDoctorDto> GetAll();
        void Delete(Doctor doctor);
        public Doctor GetDoctorById(string nationalId);
    }
}