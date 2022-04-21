using DoctorAppointment.Entities;
using DoctorAppointment.Services.Patients.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Patients
{
    public class EFPateintRepository : AppointmentsRepository
    {
        private readonly DbSet<Patient> _Patients;

        public EFPateintRepository(ApplicationDbContext dbcontext)
        {
            _Patients = dbcontext.Set<Patient>();
        }

        public void Add(Patient patient)
        {
            _Patients.Add(patient);
        }


        public Patient GetPatientById(string nationalId) {
            return _Patients.FirstOrDefault(_ => _.NationalCode == nationalId);
        }

        public void Delete(Patient patient)
        {
            _Patients.Remove(patient);
        }

        public List<GetPatientDto> GetAll()
        {
            return _Patients.Select(x => new GetPatientDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                NationalCode = x.NationalCode,
            }).ToList();
        }

        public bool IsExistNationalCode(string nationalCode)
        {
            return _Patients.Any(_ => _.NationalCode == nationalCode);
        }
    }
}
