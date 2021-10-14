using BMSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSWebAPI.Services
{
    public interface IUserAccountDetailService
    {
        UserAccountDetailModel Get(int userId);
        UserAccountDetailModel Upsert(UserAccountDetailModel userAccountDetailModel);
    }
}
