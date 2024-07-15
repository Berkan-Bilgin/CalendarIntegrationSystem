using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Task : Entity
    {

        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public TaskStatus Status { get; set; }

        public Guid UserId { get; set; }
        public User User { get; set; }
    }


    public enum TaskStatus
    {
        Pending,
        Ongoing,
        Completed,
        Cancelled
    }
}
