using AutoMapper;
using ToDo.Mapper.Mappers;

namespace ToDo.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile ()
        {
            TaskMapper.Map(this);
        }
    }
}