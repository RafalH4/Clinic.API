using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class MedArea
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Contract> Contracts { get; set; }
    }
}
