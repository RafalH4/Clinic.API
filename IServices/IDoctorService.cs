using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDetailDto>> GetAll();
        Task<DoctorDetailDto> GetById(Guid id);
        Task<DoctorDetailDto> GetByPesel(string pesel);
        Task<DoctorDetailDto> GetByEmail(string email);
        Task AddDoctor(string email, string password, 
            string pesel, string firstName, string secondName,
            string phoneNumber, string postCode, string city, 
            string street, string houseNumber);
        Task DeleteDoctor(Guid id);
        Task UpdateDoctor(Guid id, string street, string postCode, string phoneNumber, string city);

    }
}
