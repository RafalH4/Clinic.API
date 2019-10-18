using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class Doctor : User
    {
        public Doctor(Guid id, string email, string password, 
            string role, DateTime createdAt, string firstName, 
            string secondName, string pesel, string phoneNumber, 
            string postCode, string city, string street, string houseNumber) 
            : base(id, email, password, role, createdAt, 
                  firstName, secondName, pesel, phoneNumber, 
                  postCode, city, street, houseNumber) { }


        public List<Contract> Contracts { get; set; }
        public List<Appointment> Appointments { get; set; }
    }
}
