using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Patients.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients
{
    public class PatientAppService : PatientsService
    {
        private readonly PatientsRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public PatientAppService(
            PatientsRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddPatientDto dto)
        {
            var patient = new Patient
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                NationalCode = dto.NationalCode,
            };

            var isPatientExist = _repository
                .IsExistNationalCode(patient.NationalCode);

            if(isPatientExist)
            {
                throw new PatientAlreadyExistException();
            }

            _repository.Add(patient);
            _unitOfWork.Commit();
        }

        public List<GetPatientDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(string nationalCode)
        {
            var isPatientExist = _repository
                .IsExistNationalCode(nationalCode);

            if (isPatientExist == false)
            {
                throw new PatientDoesntExist();
            }
            
            _repository.Delete(_repository
                .GetPatientById(nationalCode));
            _unitOfWork.Commit();
        }

        public void Update(string nationalCode , UpdatePatientsDto dto)
        {
            var isPatientExist = _repository
                .IsExistNationalCode(nationalCode);

            if (isPatientExist == false)
            {
                throw new PatientDoesntExist();
            }

            var patient =  _repository.GetPatientById(nationalCode);

            patient.FirstName = dto.FirstName;
            patient.LastName = dto.LastName;
            patient.NationalCode = dto.NationalCode;
            _unitOfWork.Commit();

        }

    }
}
