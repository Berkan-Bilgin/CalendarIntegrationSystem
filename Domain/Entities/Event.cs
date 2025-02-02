﻿using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Event : CalendarItem
    {
        public EventStatus Status { get; set; }
        public string Location { get; set; }
    }



    public enum EventStatus
    {
        Pending,
        Ongoing,
        Completed,
        Cancelled
    }

}

