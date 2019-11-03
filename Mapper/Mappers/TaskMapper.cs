using AutoMapper;
using ToDo.Entities;
using ToDo.Models;

namespace ToDo.Mapper.Mappers
{
    public static class TaskMapper
    {
        public static void Map(Profile profile)
        {
            profile.CreateMap<Task, TaskViewModel>();
            profile.CreateMap<TaskDTO, Task>();
        }
    }
}