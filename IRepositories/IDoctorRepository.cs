using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> GetById(Guid id);
        Task<Doctor> GetByEmail(string email);
        Task<Doctor> GetByPesel(string pesel);
        Task AddDoctor(Doctor doctor);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(Doctor doctor);
    }
}
