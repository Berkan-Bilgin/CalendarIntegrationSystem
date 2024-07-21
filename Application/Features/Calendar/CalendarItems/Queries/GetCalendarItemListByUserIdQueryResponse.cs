using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendar.CalendarItems.Queries
{
    public class GetCalendarItemListByUserIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string ItemType { get; set; }

        public string? Location { get; set; }


    }

    public class GetTaskUserIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Domain.Entities.TaskStatus Status { get; set; }

        public string ItemType { get; set; }


    }

    public class GetEventByUserIdQueryResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EventStatus Status { get; set; }

        public string ItemType { get; set; }

        public string? Location { get; set; }
    }

    public class CombinedResponse
    {
        public List<GetEventByUserIdQueryResponse> Events { get; set; }
        public List<GetTaskUserIdQueryResponse> Tasks { get; set; }
    }
}
