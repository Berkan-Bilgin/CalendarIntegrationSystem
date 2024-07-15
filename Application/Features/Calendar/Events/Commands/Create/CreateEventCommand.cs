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

namespace Application.Features.Calendar.Events.Commands.Create
{
    public class CreateEventCommand : IRequest<CreateEventCommandResponse>
    {
        public string Title { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, CreateEventCommandResponse>
    {

        private readonly IMapper _mapper;
        private readonly IEventRepository _eventRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateEventCommandHandler(IMapper mapper, IEventRepository eventRepository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _eventRepository = eventRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CreateEventCommandResponse> Handle(CreateEventCommand request, CancellationToken cancellationToken)
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
            Event newEvent = _mapper.Map<Event>(request);

            newEvent.UserId = userId;
            // Veritabanına ekleme işlemi
            await _eventRepository.AddAsync(newEvent);

            // Event nesnesinden CreateEventCommandResponse nesnesine dönüşüm
            CreateEventCommandResponse response = _mapper.Map<CreateEventCommandResponse>(newEvent);
            return response;
        }




    }
}
