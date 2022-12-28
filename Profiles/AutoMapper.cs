using AutoMapper;
using TodoServices.DTO;
using TodoServices.Model;

namespace TodoServices.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, Login>().ReverseMap();
            CreateMap<User, Register>().ReverseMap();
            CreateMap<Tasks,CreateTasks>().ReverseMap();
        }
    }
}
