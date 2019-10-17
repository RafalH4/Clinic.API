using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public class Root : User
    {
        public Root(Guid id, string email, string password, 
            string role, DateTime createdAt, string firstName, 
            string secondName, string pesel, string phoneNumber, 
            string postCode, string city, string street, string houseNumber) 
            : base(id, email, password, role, createdAt, 
                  firstName, secondName, pesel, phoneNumber, 
                  postCode, city, street, houseNumber)
        {
        }
    }
}
