using DoctorAppointment.Entities;
using DoctorAppointment.Services.Doctors.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Persistence.EF.Doctors
{
    public class EFDoctoRepository : DoctorRepository
    {
        private readonly DbSet<Doctor> _doctors;

        public EFDoctoRepository(ApplicationDbContext dbcontext)
        {
            _doctors = dbcontext.Set<Doctor>();
        }

        public void Add(Doctor doctor)
        {
           _doctors.Add(doctor);
        }


        public Doctor GetDoctorById(string nationalId) {
            return _doctors.FirstOrDefault(_ => _.NationalCode == nationalId);
        }

        public void Delete(Doctor doctor)
        {  
            _doctors.Remove(doctor);
        }

        public List<GetDoctorDto> GetAll()
        {
            return _doctors.Select(x => new GetDoctorDto
            {
                FirstName = x.FirstName,
                LastName = x.LastName,
                Field = x.Field,
                NationalCode = x.NationalCode,
            }).ToList();
        }

        public bool IsExistNationalCode(string nationalCode)
        {
            return _doctors.Any(_ => _.NationalCode == nationalCode);
        }
    }
}
