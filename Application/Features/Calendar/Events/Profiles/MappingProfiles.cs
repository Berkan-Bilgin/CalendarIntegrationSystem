using Application.Features.Calendar.Events.Commands.Create;
using Application.Features.Calendar.Events.Commands.Update;
using Application.Features.Calendar.Events.Queries.GetListByUserId;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Calendar.Events.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, CreateEventCommand>().ReverseMap();
            CreateMap<Event, CreateEventCommandResponse>().ReverseMap();

            CreateMap<Event, UpdateEventCommand>().ReverseMap();
            CreateMap<Event, UpdateEventCommandResponse>().ReverseMap();

            CreateMap<Event, GetEventListByUserIdQueryResponse>().ReverseMap();






        }
    }
}
