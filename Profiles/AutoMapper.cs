using AutoMapper;

namespace TodoServices.Profiles
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<User, Login>();
            CreateMap<UserSecretsConfigurationExtensions,>
        }
    }
}
