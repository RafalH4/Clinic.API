using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IAuthService
    {
        Task Register(string email, string password, string firstName, string secondName,
            string pesel, string phoneNumber, string postCode, string city,
            string street, string houseNumber);
        Task Login(string userName, string password);

    }
}
