using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Patients.Contracts
{
    public interface PatientsService
    {
        void Add(AddPatientDto dto);
        List<GetPatientDto> GetAll();
        void Delete(string nationalId);
        void Update(string nationalCode, UpdatePatientsDto dto);
    }
}
