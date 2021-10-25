using BMSWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSWebAPI.Services
{
    public interface IAuthService
    {
        User GetUser(string jwt);
    }
}
