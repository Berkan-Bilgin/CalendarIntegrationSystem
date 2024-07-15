using Application.Repositories;
using Core.DataAccess;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UserRepository : EfRepositoryBase<User, CalendarIntegrationSystemDbContext>, IUserRepository
    {
        public UserRepository(CalendarIntegrationSystemDbContext context) : base(context)
        {
        }
    }
}
