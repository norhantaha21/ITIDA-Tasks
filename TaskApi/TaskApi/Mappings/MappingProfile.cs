using AutoMapper;
using TaskApi.Dtos;
using TaskApi.Models;

namespace TaskApi.Mappings
{
    public class MappingProfile:Profile
    {
        public MappingProfile() {
            CreateMap<Tasks, TaskDto>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.Name));

            CreateMap<CreateTaskRequestDto, TaskDto>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<UpdateTaskRequestDto, TaskDto>();
        }
    }
}
