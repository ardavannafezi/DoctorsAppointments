using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAppointment.Services.Doctors.Contracts
{
    public interface DoctorService
    {
        void Add(AddDoctorDto dto);
        List<GetDoctorDto> GetAll();
        void Delete(string nationalId);
        void Update(string nationalCode, UpdatedocterDto dto);
    }
}
