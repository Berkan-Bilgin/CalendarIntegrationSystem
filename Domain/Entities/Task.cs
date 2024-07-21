using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Task : CalendarItem
    {

        public TaskStatus Status { get; set; }
    }


    public enum TaskStatus
    {
        Pending,
        Ongoing,
        Completed,
        Cancelled
    }
}
