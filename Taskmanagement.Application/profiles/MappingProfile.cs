using AutoMapper;
using Taskmanagement.Application.Features.Checklist.DTOs;
using Taskmanagement.Application.Features.Task.DTOs;
using Taskmanagement.Application.Features.User.DTOs;

using Taskmanagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Taskmanagement.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
             #region task Mappings
            CreateMap<Task, TaskDto>().ReverseMap();
            CreateMap<Task, CreateTaskDto>().ReverseMap();
            CreateMap<TaskDetailsDto, Task>().ReverseMap();
            CreateMap<UpdateTaskDto, Task>().ReverseMap();
            CreateMap<TaskListDto, Task>().ReverseMap();

             #endregion task
            
         
           
           
            

            #region checklist Mapping
            CreateMap<Checklist, ChecklistDto>().ReverseMap();
            CreateMap<Checklist, CreateChecklistDto>().ReverseMap();
            CreateMap<Checklist, IChecklistDto>().ReverseMap();
            CreateMap<Checklist, UpdateChecklistDto>().ReverseMap();
            #endregion


            CreateMap<User, _UserDto>().ReverseMap();
            CreateMap<User, Create_UserDto>().ReverseMap();
            CreateMap<User, Update_UserDto>().ReverseMap();
            CreateMap<RegisterDto, Create_UserDto>().ReverseMap();
            CreateMap<RegisterDto, RegistrationModel>().ReverseMap();
        }
    }
}