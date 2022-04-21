using DoctorAppointment.Entities;
using DoctorAppointment.Infrastructure.Application;
using DoctorAppointment.Services.Appoitnments.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Appoitnments

{
    public class AppointmentAppService : AppointmenmtService
    {
        private readonly AppointmentRepository _repository;
        private readonly UnitOfWork _unitOfWork;

        public AppointmentAppService(
            AppointmentRepository repository,
            UnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public void Add(AddAppointmentDto dto)
        {
            var appointment = new Appointment
            {
                PatientId = dto.PatientId,
                DoctorId = dto.DoctorId,
                Date = dto.Date.Date,

            };

            int AppointmentsInDay = _repository
                .CountDoctorAppointment(dto.DoctorId, dto.Date);

            if (AppointmentsInDay >= 6)
            {
                throw new DayIsFull();
            }

            var isAppointmentExist = _repository
                .IsExist(appointment.DoctorId, appointment.PatientId, dto.Date.Date);

            if(isAppointmentExist)
            {
                throw new AppointmentAlreadyExist();
            }

            _repository.Add(appointment);
            _unitOfWork.Commit();
        }

        public List<GetAppointmentsDto> GetAll()
        {
            return _repository.GetAll();
        }

        public void Delete(int id)
        {
            var isAppointmentExist = _repository
                .IsExistById(id);

            if (isAppointmentExist == false)
            {
                throw new AppoitnmentExist();
            }
            
            _repository.Delete(_repository
                .GetAppointmentById(id));
            _unitOfWork.Commit();
        }

        public void Update(int id , UpdateAppointment dto)
        {
            var isAppointmentExist = _repository
                .IsExist(dto.DoctorId, dto.PatientId, dto.Date);

            if (isAppointmentExist == false)
            {
                throw new AppointmentDoesntExist();
            }

            var appointment =  _repository.GetAppointmentById(id);

            appointment.DoctorId = dto.DoctorId;
            appointment.PatientId = dto.PatientId;
            appointment.Date = dto.Date.Date;
            _unitOfWork.Commit();

        }

    }
}
