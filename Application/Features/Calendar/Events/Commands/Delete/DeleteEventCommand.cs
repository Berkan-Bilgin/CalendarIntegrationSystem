using Application.Repositories;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;

namespace Application.Features.Calendar.Events.Commands.Delete
{
    public class DeleteEventCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

    public class DeleteEventCommandHandler : IRequestHandler<DeleteEventCommand, Unit>
    {
        private readonly IEventRepository _eventRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public DeleteEventCommandHandler(IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor)
        {
            _eventRepository = eventRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Unit> Handle(DeleteEventCommand request, CancellationToken cancellationToken)
        {
            // Kullanıcı kimliğini al
            var userIdString = _httpContextAccessor.HttpContext.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userIdString) || !Guid.TryParse(userIdString, out Guid userId))
            {
                throw new Exception("User ID not found or invalid in the HTTP context.");
            }

            // Silinecek etkinliği al
            Event eventToDelete = await _eventRepository.GetAsync(e => e.Id == request.Id);

            if (eventToDelete == null)
            {
                throw new Exception("Event not found.");
            }

            // Kullanıcının etkinliği silme yetkisi olup olmadığını kontrol et
            if (eventToDelete.UserId != userId)
            {
                throw new UnauthorizedAccessException("You are not authorized to delete this event.");
            }

            // Etkinliği sil
            await _eventRepository.DeleteAsync(eventToDelete);

            // Başarılı işlemde Unit.Value döneriz
            return Unit.Value;
        }
    }
}
