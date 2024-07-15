﻿using Core.DataAccess;
using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Repositories
{
    public interface IUserOperationClaimRepository : IRepository<Domain.Entities.UserOperationClaim>, IAsyncRepository<Domain.Entities.UserOperationClaim>
    {
    }
}
