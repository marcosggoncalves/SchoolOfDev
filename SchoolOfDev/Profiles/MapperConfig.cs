using AutoMapper;

namespace SchoolOfDev.Profiles
{
    public static class MapperConfig
    {
        public static MapperConfiguration GetMapperConfig()
        {
            return new MapperConfiguration(config =>
            {
                config.AddProfile(new UserProfile());
            });
        }
    }
}
