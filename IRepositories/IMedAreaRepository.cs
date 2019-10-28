using Clinic.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IRepositories
{
    public interface IMedAreaRepository
    {
        Task<IEnumerable<MedArea>> Get();
        Task AddMedArea(MedArea medArea);
        Task DeleteArea(MedArea medArea);
        Task UpdateArea(MedArea medArea);
    }
}
