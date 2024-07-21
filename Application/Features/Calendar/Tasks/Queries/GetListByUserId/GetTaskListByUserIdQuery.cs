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

namespace Application.Features.Calendar.Tasks.Queries.GetListByUserId
{
    public class GetTaskListByUserIdQuery : IRequest<List<GetTaskListByUserIdQueryResponse>>
    {

        public class GetTaskListByUserIdQueryHandler : IRequestHandler<GetTaskListByUserIdQuery, List<GetTaskListByUserIdQueryResponse>>
        {
            private readonly ITaskRepository _taskRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;

            public GetTaskListByUserIdQueryHandler(ITaskRepository taskRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor)
            {
                _taskRepository = taskRepository;
                _mapper = mapper;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<List<GetTaskListByUserIdQueryResponse>> Handle(GetTaskListByUserIdQuery request, CancellationToken cancellationToken)
            {
                // Kullanıcı kimliğini al
                var userIdString = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

                if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
                {
                    throw new Exception("User ID not found or invalid in the HTTP context.");
                }

                // Veritabanından kullanıcıya ait etkinlikleri çek
                var tasks = await _taskRepository.GetListAsync(e => e.UserId == userId);

                // Etkinlikleri response modeline dönüştür
                var response = _mapper.Map<List<GetTaskListByUserIdQueryResponse>>(tasks);

                return response;
            }
        }
    }
}
