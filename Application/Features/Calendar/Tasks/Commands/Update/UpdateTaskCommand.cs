using Application.Features.Calendar.Tasks.Commands.Update;
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

namespace Application.Features.Calendar.Events.Commands.Update
{
    public class UpdateTaskCommand : IRequest<UpdateTaskCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class UpdateTaskCommandHandler : IRequestHandler<UpdateTaskCommand, UpdateTaskCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITaskRepository _taskRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateTaskCommandHandler(IMapper mapper, ITaskRepository taskRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _taskRepository = taskRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UpdateTaskCommandResponse> Handle(UpdateTaskCommand request, CancellationToken cancellationToken)
        {
            var userIdString = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdString))
            {
                throw new Exception("User ID not found in the HTTP context.");
            }

            if (!Guid.TryParse(userIdString, out Guid userId))
            {
                throw new Exception("Invalid User ID format.");
            }

            // Mevcut etkinliği al
            Domain.Entities.Task existingTask = await _taskRepository.GetAsync(e => e.Id == request.Id);

            if (existingTask == null)
            {
                throw new Exception("Task not found.");
            }

            // Güncelleme işlemi için gerekli kontroller
            if (existingTask.UserId != userId)
            {
                throw new Exception("Unauthorized to update this task.");
            }

            // Mevcut etkinliği güncelle
            UpdateTaskProperties(existingTask, request);

            // Veritabanında güncelleme işlemi
            await _taskRepository.UpdateAsync(existingTask);

            // Etkinlik nesnesinden UpdateTaskCommandResponse nesnesine dönüşüm
            UpdateTaskCommandResponse response = _mapper.Map<UpdateTaskCommandResponse>(existingTask);
            return response;
        }

        private void UpdateTaskProperties(Domain.Entities.Task existingTask, UpdateTaskCommand request)
        {
            if (!string.IsNullOrEmpty(request.Title))
            {
                existingTask.Title = request.Title;
            }

            if (request.StartDate.HasValue)
            {
                existingTask.StartDate = request.StartDate.Value;
            }

            if (request.EndDate.HasValue)
            {
                existingTask.EndDate = request.EndDate.Value;
            }
        }
    }
}




