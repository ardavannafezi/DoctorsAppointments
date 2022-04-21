using System.Collections.Generic;


namespace DoctorAppointment.Services.Appoitnments.Contracts
{
    public interface AppointmenmtService
    {
        void Add(AddAppointmentDto dto);
        List<GetAppointmentsDto> GetAll();
        void Delete(int Id);
        void Update(int Id, UpdateAppointment dto);
    }
}
