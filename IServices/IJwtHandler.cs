using Clinic.API.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.IServices
{
    public interface IJwtHandler
    {
        String CreateToken(User user);
    }
}
