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
    public class UpdateEventCommand : IRequest<UpdateEventCommandResponse>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    public class UpdateEventCommandHandler : IRequestHandler<UpdateEventCommand, UpdateEventCommandResponse>
    {
        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<UpdateEventCommandResponse> Handle(UpdateEventCommand request, CancellationToken cancellationToken)
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
            Event existingEvent = await _eventRepository.GetAsync(e => e.Id == request.Id);

            if (existingEvent == null)
            {
                throw new Exception("Event not found.");
            }

            // Güncelleme işlemi için gerekli kontroller
            if (existingEvent.UserId != userId)
            {
                throw new Exception("Unauthorized to update this event.");
            }

            // Mevcut etkinliği güncelle
            UpdateEventProperties(existingEvent, request);

            // Veritabanında güncelleme işlemi
            await _eventRepository.UpdateAsync(existingEvent);

            // Etkinlik nesnesinden UpdateEventCommandResponse nesnesine dönüşüm
            UpdateEventCommandResponse response = _mapper.Map<UpdateEventCommandResponse>(existingEvent);
            return response;
        }

        private void UpdateEventProperties(Event existingEvent, UpdateEventCommand request)
        {
            if (!string.IsNullOrEmpty(request.Title))
            {
                existingEvent.Title = request.Title;
            }

            if (request.StartDate.HasValue)
            {
                existingEvent.StartDate = request.StartDate.Value;
            }

            if (request.EndDate.HasValue)
            {
                existingEvent.EndDate = request.EndDate.Value;
            }
        }
    }
}




