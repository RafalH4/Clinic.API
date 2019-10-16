using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IDoctorRepository
    {
        Task<Doctor> Get(Guid id);
    }
}
