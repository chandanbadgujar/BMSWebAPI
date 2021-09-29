﻿using BMSWebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BMSWebAPI.Services
{
    public interface ILoanService
    {
        LoanModel Get(int userId);
        LoanModel Upsert(LoanModel loanModel);
    }
}
