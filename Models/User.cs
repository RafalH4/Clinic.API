using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Models
{
    public abstract class User
    {
        protected User(Guid id, string email, string password, 
            string role, DateTime createdAt, string firstName, 
            string secondName, string pesel, string phoneNumber, 
            string postCode, string city, string street, 
            string houseNumber)
        {
            Id = id;
            Email = email;
            Role = role;
            CreatedAt = createdAt;
            FirstName = firstName;
            SecondName = secondName;
            Pesel = pesel;
            PhoneNumber = phoneNumber;
            PostCode = postCode;
            City = city;
            Street = street;
            HouseNumber = houseNumber;
        }

        public Guid Id { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Role { get; set; }
        public DateTime CreatedAt { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Pesel { get; set; }
        public string PhoneNumber { get; set; }
        public string PostCode { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string HouseNumber { get; set; }

    }
}
