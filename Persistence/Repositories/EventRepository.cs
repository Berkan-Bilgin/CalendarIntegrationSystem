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
    public class EventRepository : EfRepositoryBase<Event, CalendarIntegrationSystemDbContext>, IEventRepository
    {
        public EventRepository(CalendarIntegrationSystemDbContext context) : base(context)
        {
        }
    }
}
