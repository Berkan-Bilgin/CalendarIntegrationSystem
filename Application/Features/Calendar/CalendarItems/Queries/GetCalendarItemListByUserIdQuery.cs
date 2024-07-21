using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Application.Features.Calendar.CalendarItems.Queries.GetListByUserId
{
    public class GetCalendarItemListByUserIdQuery : IRequest<CombinedResponse>
    {
        public class GetCalendarItemListByUserIdQueryHandler : IRequestHandler<GetCalendarItemListByUserIdQuery, CombinedResponse>
        {
            private readonly ICalendarItemRepository _calendarItemRepository;
            private readonly IEventRepository _eventRepository;
            private readonly ITaskRepository _taskRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetCalendarItemListByUserIdQueryHandler(ICalendarItemRepository calendarItemRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, ITaskRepository taskRepository, IEventRepository eventRepository)
            {
                _calendarItemRepository = calendarItemRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
                _taskRepository = taskRepository;
                _eventRepository = eventRepository;
            }

            public async Task<CombinedResponse> Handle(GetCalendarItemListByUserIdQuery request, CancellationToken cancellationToken)
            {
                // Kullanıcı kimliğini al
                var userIdString = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
                {
                    throw new Exception("User ID not found or invalid in the HTTP context.");
                }

                // Veritabanından kullanıcıya ait etkinlikleri çek
                var events = await _eventRepository.GetListAsync(e => e.UserId == userId);
                var tasks = await _taskRepository.GetListAsync(e => e.UserId == userId);

                Console.WriteLine($"events Items nedir: {JsonSerializer.Serialize(events, new JsonSerializerOptions { WriteIndented = true })}");
                Console.WriteLine($"tasks Items nedir: {JsonSerializer.Serialize(tasks, new JsonSerializerOptions { WriteIndented = true })}");

                // Event ve Task öğelerini response modeline dönüştür
                var eventResponse = _mapper.Map<List<GetEventByUserIdQueryResponse>>(events);
                var taskResponse = _mapper.Map<List<GetTaskUserIdQueryResponse>>(tasks);

                // Event ve Task listelerini birleştir
                var combinedResponse = new CombinedResponse
                {
                    Events = eventResponse,
                    Tasks = taskResponse
                };

                return combinedResponse;
            }
        }
    }
}
