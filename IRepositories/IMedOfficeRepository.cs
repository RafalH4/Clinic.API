using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IMedOfficeRepository
    {
        Task<IEnumerable<MedOffice>> Get();
        Task<IEnumerable<MedOffice>> GetByDepartment(Department department);
        Task<MedOffice> GetById(Guid id);
        Task AddMedOffice(MedOffice medOffice);
        Task UpdateMedOffice(MedOffice medOffice);
        Task DeleteMedOffice(MedOffice medOffice);
    }
}
