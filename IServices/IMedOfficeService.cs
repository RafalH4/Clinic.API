using Clinic.API.DTOs;
using Clinic.API.DTOs.Get;
using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IMedOfficeService
    {
        Task<IEnumerable<MedOfficeDto>> GetAll();
        Task<MedOffice> GetById(Guid id);
        Task<IEnumerable<MedOffice>> GetByDepartment(Guid departmentId);
        Task AddMedOffice(AddMedOfficeDto medOffice);
        Task UpdateMedOffice(MedOfficeDetailDto medOffice);
        Task DeleteMedOffice(Guid id);
    }
}
