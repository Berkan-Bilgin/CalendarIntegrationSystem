using Application.Features.Calendar.Events.Commands.Create;
using Application.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendar.Tasks.Commands.Create
{
    public class CreateTaskCommand : IRequest<CreateTaskCommandResponse>
    {
        public string Title { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, CreateTaskCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateTaskCommandHandler(IMapper mapper, ITaskRepository taskRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateTaskCommandResponse> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {

            //var userId = _httpContextAccessor.HttpContext.User?.FindFirst("sub")?.Value;
            //var userId = int.Parse(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            var userIdString = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;


            // ISecuredRequest bu kontrolü yapıcak muhtemelen
            if (string.IsNullOrEmpty(userIdString))
            {
                throw new Exception("User ID not found in the HTTP context.");
            }

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                throw new Exception("Invalid User ID format.");
            }


            // Request nesnesinden Event nesnesine dönüşüm
            Domain.Entities.Task newTask = _mapper.Map<Domain.Entities.Task>(request);

            newTask.UserId = userId;
            // Veritabanına ekleme işlemi
            await _taskRepository.AddAsync(newTask);

            // Event nesnesinden CreateEventCommandResponse nesnesine dönüşüm
            CreateTaskCommandResponse response = _mapper.Map<CreateTaskCommandResponse>(newTask);
            return response;
        }

    }
}
