using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendar.Events.Queries.GetListByUserId
{
    public class GetEventListByUserIdQuery : IRequest<List<GetEventListByUserIdQueryResponse>>
    {

        public class GetEventListByUserIdQueryHandler : IRequestHandler<GetEventListByUserIdQuery, List<GetEventListByUserIdQueryResponse>>
        {
            private readonly IEventRepository _eventRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetEventListByUserIdQueryHandler(IEventRepository eventRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _eventRepository = eventRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<List<GetEventListByUserIdQueryResponse>> Handle(GetEventListByUserIdQuery request, CancellationToken cancellationToken)
            {
                // Kullanıcı kimliğini al
                var userIdString = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
                {
                    throw new Exception("User ID not found or invalid in the HTTP context.");
                }

                // Veritabanından kullanıcıya ait etkinlikleri çek
                var events = await _eventRepository.GetListAsync(e => e.UserId == userId);

                // Etkinlikleri response modeline dönüştür
                var response = _mapper.Map<List<GetEventListByUserIdQueryResponse>>(events);

                return response;
            }
        }
    }
}
