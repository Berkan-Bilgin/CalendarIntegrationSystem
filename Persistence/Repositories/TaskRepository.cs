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
    public class TaskRepository : EfRepositoryBase<Domain.Entities.Task, CalendarIntegrationSystemDbContext>, ITaskRepository
    {
        public TaskRepository(CalendarIntegrationSystemDbContext context) : base(context)
        {
        }
    }
}
