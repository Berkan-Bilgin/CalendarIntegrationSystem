using Application.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Application.Features.Calendar.Tasks.Commands.Delete
{
    public class DeleteTaskCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

    public class DeleteTaskCommandHandler : IRequestHandler<DeleteTaskCommand, Unit>
    {
        private readonly ITaskRepository _taskRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteTaskCommandHandler(ITaskRepository taskRepository, IHttpContextAccessor httpContextAccessor)
        {
            _taskRepository = taskRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(DeleteTaskCommand request, CancellationToken cancellationToken)
        {
            // Kullanıcı kimliğini al
            var userIdString = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                throw new Exception("User ID not found or invalid in the HTTP context.");
            }

            // Silinecek etkinliği al
            Domain.Entities.Task taskToDelete = await _taskRepository.GetAsync(e => e.Id == request.Id);

            if (taskToDelete == null)
            {
                throw new Exception("Task not found.");
            }

            // Kullanıcının etkinliği silme yetkisi olup olmadığını kontrol et
            if (taskToDelete.UserId != userId)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this task.");
            }

            // Etkinliği sil
            await _taskRepository.DeleteAsync(taskToDelete);

            // Başarılı işlemde Unit.Value döneriz
            return Unit.Value;
        }
    }
}
