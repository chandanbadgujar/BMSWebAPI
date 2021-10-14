using BMSWebAPI.Entities;
using BMSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSWebAPI.Services
{
    public interface IUserService
    {
        string Add(User user);
        int Register(RegisterModel register);
        User GetByUsername(string username);
    }
}
