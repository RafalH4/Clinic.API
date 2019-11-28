using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IMedOfficeService
    {
        Task<IEnumerable<MedOffice>> GetAll();
        Task<MedOffice> GetById();
        Task AddMedOffice();
        Task UpdateMedArea();
        Task DeleteMedArea();
    }
}
