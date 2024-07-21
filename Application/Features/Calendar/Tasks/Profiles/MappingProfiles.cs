using Application.Features.Calendar.Events.Commands.Create;
using Application.Features.Calendar.Events.Commands.Update;
using Application.Features.Calendar.Events.Queries.GetListByUserId;
using Application.Features.Calendar.Tasks.Commands.Create;
using Application.Features.Calendar.Tasks.Commands.Update;
using Application.Features.Calendar.Tasks.Queries.GetListByUserId;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskEntity = Domain.Entities.Task;


namespace Application.Features.Calendar.Tasks.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<TaskEntity, CreateTaskCommand>().ReverseMap();
            CreateMap<TaskEntity, CreateTaskCommandResponse>().ReverseMap();

            CreateMap<TaskEntity, UpdateTaskCommand>().ReverseMap();
            CreateMap<TaskEntity, UpdateTaskCommandResponse>().ReverseMap();

            CreateMap<TaskEntity, GetTaskListByUserIdQueryResponse>().ReverseMap();






        }
    }
}
