using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event : Entity
    {
        public string Title { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EventStatus Status { get; set; }

        public Guid UserId { get; set; }
        virtual public User User { get; set; }
    }



    public enum EventStatus
    {
        Pending,
        Ongoing,
        Completed,
        Cancelled
    }

}

