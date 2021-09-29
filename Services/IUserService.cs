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
        Task<string> Add(User user);
        Task<int> Register(RegisterModel register);
    }
}
