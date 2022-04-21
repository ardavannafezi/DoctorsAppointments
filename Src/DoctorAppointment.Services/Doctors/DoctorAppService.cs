using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Doctors.Contracts;
using DoctorAppointment.Services.Doctors.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors
{
    public class DoctorAppService : DoctorService
    {
        private readonly DoctorRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public DoctorAppService(
            DoctorRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddDoctorDto dto)
        {
            var doctor = new Doctor
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                Field = dto.Field,
                NationalCode = dto.NationalCode,
            };

            var isDoctorExist = _repository
                .IsExistNationalCode(doctor.NationalCode);

            if(isDoctorExist)
            {
                throw new DoctorAlreadyExistException();
            }

            _repository.Add(doctor);
            _unitOfWork.Commit();
        }

        public List<GetDoctorDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(string nationalCode)
        {
            var isDoctorExist = _repository
                .IsExistNationalCode(nationalCode);

            if (isDoctorExist == false)
            {
                throw new DoctorDontExist();
            }
            
            _repository.Delete(_repository
                .GetDoctorById(nationalCode));
            _unitOfWork.Commit();
        }

        public void Update(string nationalCode , UpdateDoctorsDto dto)
        {
            var isDoctorExist = _repository
                .IsExistNationalCode(nationalCode);

            if (isDoctorExist == false)
            {
                throw new DoctorDontExist();
            }

            var doctor =  _repository.GetDoctorById(nationalCode);

            doctor.FirstName = dto.FirstName;
            doctor.LastName = dto.LastName;
            doctor.Field = dto.Field;
            doctor.NationalCode = dto.NationalCode;
            _unitOfWork.Commit();

        }

    }
}
